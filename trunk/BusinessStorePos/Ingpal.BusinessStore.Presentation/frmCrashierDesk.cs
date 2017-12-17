using Com.Alipay;
using Com.Alipay.Business;
using Com.Alipay.Domain;
using Com.Alipay.Model;
using DevExpress.XtraEditors;
using Ingpal.BusinessStore.Business;
using Ingpal.BusinessStore.Infrastructure;
using Ingpal.BusinessStore.Infrastructure.Win32;
using Ingpal.BusinessStore.Model;
using Ingpal.BusinessStore.Model.Entity;
using Ingpal.BusinessStore.Model.Interface;
using Ingpal.BusinessStore.Model.Print;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using WxPayAPI;
using System.Threading.Tasks;
namespace Ingpal.BusinessStore.Presentation
{
    public partial class frmCrashierDesk : BaseForm
    {

        private bool isValid = false;
        private PayMentType paymentType = PayMentType.None;
        private static IAlipayTradeService serviceClient = null;
        private System.Data.DataSet posResultSet = new System.Data.DataSet();
        private static List<MDMTypeSubEntity> MDMSubList = MdmBLL.Instance.MDMSubList;
        private List<KeyValueModel> listPosInfo = new List<KeyValueModel>();
        private DiscountResult discountResult = new DiscountResult();

        public delegate void ClearPosHander();
        public event ClearPosHander ClearPostEvent;

        /// <summary>
        /// 门店满减规则
        /// </summary>
        public List<StoreEventMoneyOffRule> StoreEventMoneyOffRules { get; private set; }
        /// <summary>
        /// 整单折扣规则
        /// </summary>
        public StoreEventMoneyOffRule StoreEventMoneyOffRule { get; set; }
        private List<PosExt> PosGoodsList { get; set; }

        private CouponcsResult CouponcsResult { get; set; }

        /// <summary>
        /// 选择的优惠券
        /// </summary>
        private Couponcs SelectedCouponcs { get; set; }

        private CrashierParams CrashierParams { get; set; }

        public frmCrashierDesk()
        {
            InitializeComponent();
            base.BaseInit();
            this.printDocument1.QueryPageSettings += PrintDocument1_QueryPageSettings;
            PrintSetting();
        }

        private void PrintDocument1_QueryPageSettings(object sender, QueryPageSettingsEventArgs e)
        {
            var g = this.CreateGraphics();
            var page_height = PrintTicket(g);
            g.Dispose();
            e.PageSettings.PaperSize = new PaperSize("auto pager", printDocument1.DefaultPageSettings.PaperSize.Width, page_height + 20);
        }
        public frmCrashierDesk(List<PosExt> posGoodsList, CrashierParams crashierParams) : this()
        {
            CrashierParams = crashierParams;
            this.PosGoodsList = posGoodsList;
            Load += FrmCrashierDesk_Load;
            Load += SetPosDetail;
            var isMember = !string.IsNullOrEmpty(crashierParams.member_name);
            lblMember.Visible = isMember;
            lblMember.Text = isMember ? $"会  员：{crashierParams.member_name}" : "";
            lblGuiderName.Text = $"导  购：{crashierParams.Guider.GuderName}";
        }
        /// <summary>
        /// 应用优惠策略
        /// </summary>
        /// <param name="applyCoupon">是否应该用优惠券</param>
        /// <returns></returns>
        private DiscountResult LoadSetDiscountResult()
        {
            var retailGoodsAmount = PosGoodsList.Sum(item => item.PosSalesCount * item.RetailPrice);
            var discountGoodsAmount = PosGoodsList.Sum(item => item.PosDiscountPrice * item.PosSalesCount);

            var goodsCount = PosGoodsList.Sum(item => item.PosSalesCount);
            listPosInfo.Add(new KeyValueModel { Key = $"应收金额(折扣优惠前)", Value = $"{retailGoodsAmount}" });
            listPosInfo.Add(new KeyValueModel { Key = $"商品数量", Value = $"{goodsCount}" });
            var filterDiscountGoods = PosGoodsList.Where(item => item.PosDiscountPrice > 0);
            if (filterDiscountGoods.Count() > 0)
            {
                var discount = filterDiscountGoods.Sum(item => (item.RetailPrice - item.PosDiscountPrice) * item.PosSalesCount);
                discountResult.SubtractAmount += discount;
                listPosInfo.Add(new KeyValueModel { Key = $"单品折扣总金额", Value = $"-{ discount }" });
            }

            //整单折扣
            StoreEventMoneyOffRule = Marketing.GetWholeDiscountFreeGoodsEventRules();
            if (StoreEventMoneyOffRule != null && !string.IsNullOrEmpty(StoreEventMoneyOffRule.ConditionValue))
            {
                discountResult.WholeDiscountResult = StoreEventMoneyOffRule;
                var res = (discountResult.WholeDiscountResult.ConditionValue).ToDecimal() / 10;
                //折扣之后打折
                var discountReatailAmount = (retailGoodsAmount - discountResult.SubtractAmount);
                var wholeDiscountAmount = discountReatailAmount - decimal.Ceiling(discountReatailAmount * (res / 10));
                listPosInfo.Add(new KeyValueModel { Key = $"整单{res}折金额", Value = $"-{wholeDiscountAmount}" });
                discountResult.SubtractAmount += wholeDiscountAmount;
            }

            //买赠
            var freeGoodsItem = PosGoodsList.Where(item => item.PosDiscountPrice == 0 && item.RetailPrice == 0);
            if (freeGoodsItem.Count() > 0)
            {
                var freeGoodsDetail = string.Join(",", freeGoodsItem.Select(item => item.Name));
                listPosInfo.Add(new KeyValueModel { Key = $"免费赠品{freeGoodsItem.Count()}件", Value = $"{freeGoodsDetail}" });
            }
            SummerItems.TotalAmount = retailGoodsAmount - discountResult.SubtractAmount;

            //满减金额降序排列，所有折扣之后
            StoreEventMoneyOffRules = Marketing.GetStoreEventMoneyOffRules();
            if (null != StoreEventMoneyOffRules)
            {
                var filterRules = StoreEventMoneyOffRules.Where(item => SummerItems.TotalAmount >= decimal.Parse(item.ConditionName))
                                                         .OrderByDescending(item => decimal.Parse(item.ConditionName)).ToList();
                if (filterRules.Count() > 0)
                {
                    discountResult.MoneyOfResult = filterRules.FirstOrDefault();
                    var res = discountResult.MoneyOfResult;
                    listPosInfo.Add(new KeyValueModel { Key = $"满{res.ConditionName}减{res.ConditionValue}", Value = $"-{res.ConditionValue}" });
                    discountResult.SubtractAmount += res.ConditionValue.ToDecimal();
                }
            }
            var product_fee = retailGoodsAmount - discountResult.SubtractAmount;
            product_fee = decimal.Ceiling(product_fee);

            listPosInfo.Add(new KeyValueModel { Key = $"应收金额(折扣优惠后)", Value = $"{product_fee}" });
            grdPosSummary.DataSource = listPosInfo;
            SummerItems.TotalAmount = product_fee;
            SummerItems.DiscountAmount = discountResult.SubtractAmount;
            SummerItems.NoDiscountAmount = retailGoodsAmount;

            //会员优惠券
            if (!string.IsNullOrEmpty(CrashierParams.member_id))
            {
                MemberCoupon(product_fee);
            }

            return discountResult;
        }




        /// <summary>
        /// 会员优惠券
        /// </summary>
        /// <param name="product_fee"></param>
        private void MemberCoupon(decimal product_fee)
        {

            if (!string.IsNullOrEmpty(CrashierParams.member_id))
            {
                ConfirmMemberOrder confirmMemberOrder = new ConfirmMemberOrder();
                confirmMemberOrder.product_fee = (SummerItems.NoDiscountAmount * 100).ToString();
                confirmMemberOrder.shop_name = UserInfo.Instance.StoreName.ToString();
                confirmMemberOrder.uid = CrashierParams.member_id.ToInt32();
                confirmMemberOrder.shop_sn = UserInfo.Instance.StoreID.ToString();
                confirmMemberOrder.products = PosGoodsList.Select(item =>
                {
                    products p = new products();
                    var baseGoodsInfo = SysBLL.Instance.GetALL<GoodsBaseEntity>(where: $"BarId='{item.BarID}'");
                    if (baseGoodsInfo.Count > 0 && null != baseGoodsInfo)
                    {
                        var goodsBase = baseGoodsInfo.FirstOrDefault();
                        int price = (int)goodsBase.RetailPrice * 100;
                        p.price = price;
                        p.quantity = item.PosSalesCount;
                        p.product_number = goodsBase.OuterBarID;

                    }
                    return p;
                }
                ).ToList();

                //获取会员优惠券
                try
                {
                    string couponcsResultString = ExternalAPI.ConfirmMemberOrder(confirmMemberOrder);
                    if (null != couponcsResultString)
                    {
                        CouponcsResult = Newtonsoft.Json.JsonConvert.DeserializeObject<CouponcsResult>(couponcsResultString);
                    }
                }
                catch (Exception ee)
                {


                }
            }
        }


        /// <summary>
        /// 提交订单
        /// </summary>
        /// <param name="ticketCode"></param>
        private OrderPostResult PostOrderInfo(string ticketCode, string coupon_id)
        {
            OrderPostResult orderPostResult = null;
            if (!string.IsNullOrEmpty(CrashierParams.member_id))
            {
                ConfirmMemberOrder confirmMemberOrder = new ConfirmMemberOrder();
                confirmMemberOrder.product_fee = (SummerItems.NoDiscountAmount * 100).ToString();
                confirmMemberOrder.discount_fee = (SummerItems.NoCouponcsDiscountAmount * 100).ToString();
                confirmMemberOrder.payment_fee = (SummerItems.TotalAmount * 100).ToString();
                confirmMemberOrder.shop_name = UserInfo.Instance.StoreName.ToString();
                confirmMemberOrder.uid = CrashierParams.member_id.ToInt32();
                confirmMemberOrder.shop_sn = UserInfo.Instance.StoreID.ToString();
                confirmMemberOrder.products = PosGoodsList.Select(item =>
                {
                    products p = new products();
                    var baseGoodsInfo = SysBLL.Instance.GetALL<GoodsBaseEntity>(where: $"BarId='{item.BarID}'");
                    if (baseGoodsInfo.Count > 0 && null != baseGoodsInfo)
                    {
                        var goodsBase = baseGoodsInfo.FirstOrDefault();

                        int price = (int)item.RetailPrice * 100;
                        p.price = price;
                        p.quantity = item.PosSalesCount;
                        p.product_number = goodsBase.OuterBarID;

                    }
                    return p;
                }
                ).ToList();
                try
                {
                    string orderPostResultMsg = ExternalAPI.PostOrderInfo(confirmMemberOrder, ticketCode, coupon_id);
                    if (!string.IsNullOrEmpty(orderPostResultMsg))
                    {
                        orderPostResult = Newtonsoft.Json.JsonConvert.DeserializeObject<OrderPostResult>(orderPostResultMsg);
                    }
                }
                catch
                {
                    return null;
                }
            }
            return orderPostResult;
        }
        private void InitEvent()
        {
            serviceClient = AlipayServices.CreateServiceClient();
            tabNetPay.Hide();
            tabPayInfo.SelectedTabPageIndex = 0;
            tabPayInfo.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
            LoadSetDiscountResult();
        }

        private void FrmCrashierDesk_Load(object sender, EventArgs e)
        {
            txtActualAmount.Focus();
        }

        private void SetPosDetail(object sender, EventArgs e)
        {
            gridCrasher.DataSource = PosGoodsList;
            InitEvent();
            SummerItems.TotalCount = (int)gvCrasher.Columns["PosSalesCount"].SummaryItem.SummaryValue;
            //实收金额
            SummerItems.ActualAmount = 0.00m;
            //应收金额
            txtTotalAmount.Text = SummerItems.TotalAmount.ToString();
            txtActualAmount.Focus();
        }

        /// <summary>
        /// 验证实收
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtActualAmount_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtActualAmount.Text))
            {
                txtChange.Text = string.Empty;
                isValid = false;
            }

            string temp = @"^(?!0(\.0+)?$)([1-9][0-9]*|0)(\.[0-9]+)?$";
            Regex rex = new Regex(temp);
            if (!rex.IsMatch(txtActualAmount.Text))
            {
                isValid = false;
                txtActualAmount.ForeColor = Color.Red;
                btnPayment.Enabled = isValid;
                return;
            }
            txtActualAmount.ForeColor = Color.Black;
            SummerItems.ActualAmount = txtActualAmount.Text.ToDecimal();
            txtChange.Text = (SummerItems.ActualAmount - SummerItems.TotalAmount).ToString();

            if (SummerItems.ActualAmount < SummerItems.TotalAmount)
            {
                isValid = false;
            }
            else
            {
                isValid = true;
            }
            if (paymentType == PayMentType.None)
            {
                paymentType = PayMentType.Crash;
                tileCrash.Checked = true;

            }
            btnPayment.Enabled = isValid;
            txtActualAmount.Focus();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int height = this.PrintTicket(e.Graphics);
        }

        #region 小票相关

        /// <summary>
        /// 绘制打印文档
        /// </summary>
        /// <param name="g">绘图</param>
        /// <returns></returns>
        private int PrintTicket(Graphics g)
        {
            var height = 80;
            try
            {
                var posEntity = ConvertHelper.ConvertDataTable<PosEntity>(posResultSet.Tables[0]).FirstOrDefault();
                var posDetailEntity = ConvertHelper.ConvertDataTable<PosDetailEntity>(posResultSet.Tables[1]);
                //var ticketProperties = MdmBLL.Instance.GetMDMByNameOrCode(new MDMEntity() { MDMName = "TiketProperties" });
                var ticketProperties = MDMSubList.Where(item => item.MDMTypeName == "小票属性");


                if (ticketProperties != null && ticketProperties.Count() >= 5)
                {
                    height = this.DrawTicketTitle(ticketProperties.SingleOrDefault(q => q.SubName == "标题").SubValue, g); //绘制标题

                    Image barImgSource = BarCode.CreatePictureBarCode(360, 60, posEntity.TicketCode);
                    //var barImg = barImgSource.GetThumbnailImage(288, 50, null, IntPtr.Zero);
                    var barImg = barImgSource.GetThumbnailImage(320, 60, null, IntPtr.Zero);

                    height += 30;
                    g.DrawImage(barImg, 0, height, barImg.Width, barImg.Height);
                    height += (barImg.Height + 25);
                    height = this.DrawTicketItem(height + 7, g, $"收 银 员：{posEntity.Cashier}", StringAlignment.Near);
                    height = this.DrawTicketItem(height + 7, g, $"销售时间：{posEntity.SaleDate.ToString("yyyy/MM/dd HH:mm")}", StringAlignment.Near);
                    height = this.DrawTicketItem(height + 7, g, $"销售单号：{posEntity.TicketCode}", StringAlignment.Near);
                    height = this.DrawTicketLine(height + 10, g, true);  //绘制虚线
                    height = this.DrawTiketTableRow(height, g, new PrintRow()
                    {
                        Cells = new List<PrintCell> {
                    new PrintCell() { Index=0, Percent=57, Text="品名"  },
                    //new PrintCell() { Index=0, Percent=19, Text="数量"  },
                    new PrintCell() { Index=0, Percent=19, Text="单价"  },
                    new PrintCell() { Index=0, Percent=22, Text="小计"  },
                }
                    });
                    foreach (var item in posDetailEntity)
                    {
                        var discountPrice = item.RetailPrice - item.DiscountPrice;
                        var retailPrice = item.RetailPrice;
                        string priceText = string.Empty;
                        if (item.RetailPrice > 0 && item.DiscountPrice == 0)
                        {
                            priceText = $"{retailPrice.ToString("0.00")}";
                        }
                        else if (item.RetailPrice == 0 && item.DiscountPrice == 0)
                        {

                        }
                        else if (item.RetailPrice > 0 && item.DiscountPrice > 0)
                        {
                            priceText = discountPrice > 0 ? $"{retailPrice.ToString("0.00")}\r\n({-discountPrice})" : $"{retailPrice.ToString("0.00")}";
                        }

                        height = this.DrawTiketTableRow(height + 15, g, new PrintRow()
                        {
                            Cells = new List<PrintCell>
                        {
                            new PrintCell() { Index=0, Percent=57, Text=$"{item.GoodsName}\r\n  X {int.Parse(item.GoodsCount.ToString()).ToString()}"  },
                            //new PrintCell() { Index=0, Percent=19, Text= int.Parse(item.GoodsCount.ToString()).ToString() },
                            new PrintCell() { Index=0, Percent=19, Text=priceText  },
                            new PrintCell() { Index=0, Percent=22, Text=item.GoodsAmount.ToString("0.00")  },
                        }
                        });
                    }
                    int totalCount = posEntity.TotalCount;
                    decimal totalAmount = posEntity.TotalAmount;
                    //height = this.DrawTicketLine(height, g, true);  //绘制虚线
                    height = this.DrawTicketItem(height + 7, g, $"数量:{posEntity.TotalCount}", StringAlignment.Far, null, 283 + (posEntity.TotalCount.ToString().Length));

                    height = this.DrawTicketItem(height + 7, g, string.Format("总计:{0:0.00}", SummerItems.NoDiscountAmount), StringAlignment.Far, null, 275 + SummerItems.NoDiscountAmount.ToString("{0:0.00}").Length);

                    height = this.DrawTicketItem(height + 7, g, string.Format("优惠:{0:0.00}", $"-{discountResult.SubtractAmount}"), StringAlignment.Far, null, 277 + discountResult.SubtractAmount.ToString("{0:0.00}").Length);

                    height = this.DrawTicketItem(height + 7, g, string.Format("实收:{0:0.00}",
    SummerItems.NoDiscountAmount - discountResult.SubtractAmount), StringAlignment.Far, null, 275 + (SummerItems.NoDiscountAmount - discountResult.SubtractAmount).ToString("{0:0.00}").Length);

                    var payTypeName = RefelectDescrbtion.GetEnumDesc(typeof(PayMentType), posEntity.PayType);
                    height = this.DrawTicketItem(height + 10, g, string.Format("支付方式:{0}", payTypeName), StringAlignment.Far, null, 281 + payTypeName.Length);
                    //height = this.DrawTicketLine(height, g, true);  //绘制虚线
                    Func<string, string> GetValue = (code) =>
                    {
                        return ticketProperties.SingleOrDefault(q => q.SubName == code).SubValue;
                    };
                    height = this.DrawTicketImage(height + 35, g, GetValue("二维码"));//画图片

                    height = this.DrawTicketItem(height + 7, g, UserInfo.Instance.StoreName);
                    height += 8;
                    height = this.DrawTicketItem(height + 7, g, $"门店地址:{UserInfo.Instance.Address}");
                    height += 8;
                    height = this.DrawTicketItem(height + 7, g, $"{GetValue("联系方式")}", font: new Font("宋体", 16, FontStyle.Bold));
                    height = this.DrawTicketItem(height + 7, g, $"{GetValue("脚注")}");
                }

            }
            catch
            {
                ShowMessage("打印小票出错!");
            }
            return height;
        }

        /// <summary>
        /// 绘制小票图片
        /// </summary>
        /// <param name="pixY"></param>
        /// <param name="g"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private int DrawTicketImage(int pixY, Graphics g, string url = "")
        {
            if (!string.IsNullOrEmpty(url))
            {
                if (this.HttpDownload(url, "\\Images\\QRCode.png"))
                {
                    var image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "\\Images\\QRCode.png");
                    Bitmap bitmap = new Bitmap(image, 240, 240);

                    var paperSize = printDocument1.DefaultPageSettings.PaperSize;
                    int paperWidth = paperSize.Width;
                    var width = bitmap.Width;
                    var height = bitmap.Height;
                    var pixX = bitmap.Width;
                    g.DrawImage(bitmap, new PointF(15, pixY));

                    //g.DrawImage(bitmap, new PointF(paperWidth - (width + 15), pixY));

                    return pixY + height + 20;
                }
                else
                {
                    return pixY;
                }
            }
            else
            {
                return pixY;
            }


        }

        /// <summary>
        /// 绘制小票标题
        /// </summary>
        /// <param name="title">标题内容</param>
        /// <param name="g">画板</param>
        private int DrawTicketTitle(string title, Graphics g, StringAlignment align = StringAlignment.Center, Font font = null)
        {
            Font fontTitle = new Font("微软雅黑", 16, FontStyle.Bold);
            if (null != font)
            {
                fontTitle = font;
            }
            //定义文字的对齐方式
            StringFormat sf = new StringFormat();
            sf.Alignment = align;
            sf.LineAlignment = StringAlignment.Center;


            g.DrawString(title + "\r\n", fontTitle, new SolidBrush(Color.Black), new Rectangle(0, 40, printDocument1.DefaultPageSettings.PaperSize.Width, 30), sf);

            var size = GetFontSize(title, fontTitle.Size, FontStyle.Regular);
            return Convert.ToInt32(Math.Ceiling(size.Height)) + 25;
        }

        /// <summary>
        /// 绘制线段
        /// </summary>
        /// <param name="pixY">位置</param>
        /// <param name="g">画板</param>
        /// <param name="drawdash">是否画虚线</param>
        private int DrawTicketLine(int pixY, Graphics g, bool drawdash)
        {
            if (drawdash)
            {
                Pen pen = new Pen(Color.Black, 1);
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
                pen.DashPattern = new float[] { 5, 5 };
                g.DrawLine(pen, 0, pixY, printDocument1.DefaultPageSettings.PaperSize.Width, pixY);
            }
            else
            {
                g.DrawLine(Pens.Black, 0, pixY, printDocument1.DefaultPageSettings.PaperSize.Width, pixY);
            }

            return pixY + 2;
        }

        /// <summary>
        /// 绘制小票的普通文字
        /// </summary>
        /// <param name="pixY">高度</param>
        /// <param name="g">画板</param>
        /// <returns></returns>
        private int DrawTicketItem(int pixY, Graphics g, string itemString, StringAlignment align = StringAlignment.Center, Font font = null, int width = 290)
        {
            Font fontTitle = new Font("宋体", 9f, FontStyle.Regular);
            if (null != font)
            {
                fontTitle = font;
            }
            StringFormat sf = new StringFormat();
            sf.Alignment = align;
            sf.LineAlignment = align;
            g.DrawString(itemString, fontTitle, new SolidBrush(Color.Black), new Rectangle(1, pixY, width, 30), sf);
            var size = GetFontSize(itemString, fontTitle.Size, FontStyle.Regular);
            return pixY + Convert.ToInt32(Math.Ceiling(fontTitle.GetHeight()));
        }

        /// <summary>
        /// 绘制一行表格
        /// </summary>
        /// <param name="pixel_Y">起始高度</param>
        /// <param name="g">画板</param>
        /// <param name="row">表格数据</param>
        /// <returns></returns>
        private int DrawTiketTableRow(int pixel_Y, Graphics g, PrintRow row)
        {
            if (null != row)
            {
                //定义字体大小
                float fontSize = 9F;
                //定义文字的对齐方式
                StringFormat sf = new StringFormat();
                if (row.TextAlign == 1)
                {
                    sf.Alignment = StringAlignment.Center;
                }
                else if (row.TextAlign == 0)
                {
                    sf.Alignment = StringAlignment.Near;
                }
                else
                {
                    sf.Alignment = StringAlignment.Far;
                }
                sf.LineAlignment = StringAlignment.Center;


                var cells = row.Cells.OrderBy(q => q.Index);
                var page_width = printDocument1.DefaultPageSettings.PaperSize.Width;
                var rect_x = 1;

                foreach (var item in cells)
                {
                    var rectWidth = Convert.ToInt32(Math.Ceiling(page_width * (item.Percent / 100.0)));
                    g.DrawString(item.Text, row.RowFont, new SolidBrush(Color.Black), new Rectangle(rect_x, pixel_Y, rectWidth, 30), sf);
                    rect_x += rectWidth;
                }

                pixel_Y += Convert.ToInt32(Math.Ceiling(GetFontSize(cells.First().Text, fontSize, FontStyle.Regular).Height));

            }
            return pixel_Y;
        }

        /// <summary>
        /// 获取文字所占的大小
        /// </summary>
        /// <param name="text"></param>
        /// <param name="fontSize"></param>
        /// <param name="style"></param>
        /// <returns></returns>
        private SizeF GetFontSize(string text, float fontSize, FontStyle style)
        {
            Graphics vGraphics = this.CreateGraphics();
            SizeF vSizeF = vGraphics.MeasureString(text, new Font("宋体", fontSize, style));
            int dStrLength = Convert.ToInt32(Math.Ceiling(vSizeF.Width)) + 2;
            return vSizeF;
        }

        private int getYc(double cm)
        {
            return (int)(cm / 25.4) * 100;
        }

        /// <summary>
        /// POS打印
        /// </summary>
        public void PrintSetting()
        {
            //打印控制器设置
            //this.printDocument1.PrintController = new System.Drawing.Printing.StandardPrintController();
            printDocument1.DefaultPageSettings.Margins = new Margins(5, 5, 5, 5);
            printDocument1.DefaultPageSettings.PaperSize = new PaperSize("First custom size", getYc(88), 600);
            //this.printDocument1.PrinterSettings.PrinterName = "";
            //Margins margins = new Margins(
            //this.printv_pos.Document = this.printd_pos;
            //printv_pos.PrintPreviewControl.AutoZoom = false;
            //printv_pos.PrintPreviewControl.Zoom = 1;
            // this.printv_pos.ShowDialog(win);
        }
        #endregion


        /// <summary>
        /// 按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Click(object sender, EventArgs e)
        {
            Control btn = sender as SimpleButton;
            if (btn == null) { btn = sender as Label; }
            var isDisabled = paymentType == PayMentType.Crash || paymentType == PayMentType.None;
            switch (btn.Name)
            {
                case "btnClose":
                    Close();
                    break;
                case "btnPayment":
                    ((frmPos)this.Owner).Clear();

                    //验证回传会员订单通过后才允许收银
                    PosEntity postEntity = GetPostEntity();
                    if (CrashierParams.member_id != null)
                    {
                        string couponcs_id = SelectedCouponcs == null ? "" : SelectedCouponcs.id.ToString();
                        //提交订单
                        OrderPostResult orderPostResult = PostOrderInfo(postEntity.TicketCode, couponcs_id);
                        if (orderPostResult == null)
                        {
                            ShowMessage("系统收银失败！回传会员订单信息时接口初始化失败！");
                            return;
                        }
                        else
                        {
                            //回传成功
                            if (orderPostResult.http_code == 200)
                            {
                                try
                                {
                                    WriteLog(new PartialLog
                                    {
                                        Description = $"订单回传成功，小票号{postEntity.TicketCode}，接口订单号{orderPostResult.data.order_sn}",
                                        ModuleName = "订单回传",
                                        StoreID = UserInfo.Instance.StoreID.ToString(),
                                        Type = LogType.CS.ToString(),
                                        Result = ResultType.error.ToString()
                                    });
                                }
                                catch { }
                            }
                            else
                            {
                                try
                                {
                                    ShowMessage($"系统收银失败！回传会员订单时接口数据验证失败.错误码：{orderPostResult.http_code}");
                                    WriteLog(new PartialLog
                                    {
                                        Description = $"订单回传失败，小票号{postEntity.TicketCode}。接口返回:{orderPostResult.data.ToString()}",
                                        ModuleName = "订单回传",
                                        StoreID = UserInfo.Instance.StoreID.ToString(),
                                        Type = LogType.CS.ToString(),
                                        Result = ResultType.error.ToString()
                                    });
                                }
                                catch { }
                                return;
                            }
                        }
                    }

                    Payment(postEntity, (PosEntity entity) =>
                    {
                        paymentType = PayMentType.None;
                        ClearData();
                        printDocument1.Print();
                        tableLayoutPanel1.Enabled = false;
                        SelectedCouponcs = null;
                        return true;
                    });
                    Close();
                    break;
                case "btnDelete":
                    if (isDisabled)
                    {
                        txtActualAmount.Focus();
                        WinAPI.keybd_event(Keys.Back, 0, 0, 0);
                    }
                    break;
                case "btnRemove":
                    if (isDisabled)
                    {
                        txtActualAmount.Focus();
                        txtActualAmount.Text = null;
                        //  WinAPI.keybd_event(Keys.Delete, 0, 0, 0);
                    }
                    break;
                default:
                    if (isDisabled)
                    {
                        txtActualAmount.Focus();
                        txtActualAmount.Text += btn.Text;
                        txtActualAmount.SelectionStart = txtActualAmount.Text.Length;
                    }
                    break;
            }
        }

        /// <summary>
        /// pos主表
        /// </summary>
        /// <returns></returns>
        private PosEntity GetPostEntity()
        {
            PosEntity entity = new PosEntity();
            entity.RecordStatus = RecordType.Normal;
            entity.Id = Guid.NewGuid();
            entity.Cashier = UserInfo.Instance.UserCode;
            entity.CashierID = UserInfo.Instance.ID;
            entity.RecordSerial = CrashierParams.recode_serial ?? PosBLL.instance.GetBatchNumber("LS");
            entity.TicketCode = CrashierParams.ticket_code ?? PosBLL.instance.GetBatchNumber("TK");
            //折扣前总金额
            entity.TotalAmount = SummerItems.NoDiscountAmount;
            entity.ActualAmount = txtActualAmount.Text.ToDecimal();
            entity.TotalCount = SummerItems.TotalCount;
            entity.PayType = (int)paymentType;
            entity.StoreID = UserInfo.Instance.StoreID;
            entity.SaleDate = DateTime.Now;
            entity.DiscountAmount = SummerItems.DiscountAmount;
            bool isNetPay = paymentType == PayMentType.Alipay || paymentType == PayMentType.WeChat;
            //找零：实收-应收
            entity.ChangeAmount = isNetPay ? 0.00m : entity.ActualAmount - SummerItems.TotalAmount;
            //商品额度 折扣后总金额
            entity.GoodsAmount = SummerItems.TotalAmount;
            entity.GuiderID = CrashierParams.Guider.GuiderID;
            entity.Guider = CrashierParams.Guider.GuderName;
            //entity.MemberGuid = CrashierParams.member_id;
            return entity;
        }

        /// <summary>
        /// pos明细
        /// </summary>
        /// <param name="posEntity"></param>
        /// <returns></returns>
        private List<PosDetailEntity> GetPosDetail(PosEntity posEntity)
        {
            List<PosDetailEntity> listPosDetail = new List<PosDetailEntity>();
            PosGoodsList.ForEach(item =>
            {
                var posDetail = new PosDetailEntity()
                {
                    RetailPrice = item.RetailPrice,
                    PosID = posEntity.Id,
                    ID = Guid.NewGuid(),
                    GoodsID = item.ID,
                    GoodsCategory = item.Category,
                    SaleDate = DateTime.Now,
                    StoreID = (int)posEntity.StoreID,
                    BarID = item.BarID,
                    CashierID = posEntity.CashierID,
                    GoodsCount = item.PosSalesCount,
                    GoodsName = item.Name,
                    GoodsAmount = item.PosSalesCount * (item.PosDiscountPrice > 0 ? item.PosDiscountPrice : item.RetailPrice),
                    DiscountPrice = item.PosDiscountPrice,
                    DiscountAmount = item.PosSalesCount * (item.RetailPrice - item.PosDiscountPrice),
                    BuyingPrice = item.BuyingPrice
                };
                listPosDetail.Add(posDetail);
            });
            return listPosDetail;
        }


        /// <summary>
        /// 付款
        /// </summary>
        private void Payment(PosEntity posEntity = null, Func<PosEntity, bool> fun = null)
        {
            if (paymentType == PayMentType.None)
            {
                XtraMessageBox.Show("请选择付款方式！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                PosEntity entity;
                if (null == posEntity)
                {
                    entity = GetPostEntity();
                }
                else
                {
                    entity = posEntity;
                }
                if (XtraMessageBox.Show("请确认收款信息是否无误？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    int rs = PosBLL.instance.InsertPos(entity);
                    if (rs > 0)
                    {
                        List<PosDetailEntity> listPosDetail = GetPosDetail(entity);
                        listPosDetail.ForEach(item =>
                        {
                            var selectedGoods = PosGoodsList.Where(goods => goods.BarID == item.BarID && goods.StoreID == entity.StoreID).FirstOrDefault();
                            PosBLL.instance.InsertPosDetail(item);
                            GoodsBLL.instance.UpdateGoodsStock(new GoodsEntity
                            {
                                StoreID = (int)entity.StoreID,
                                SaleQuantity = item.GoodsCount,
                                SaleAmount = selectedGoods.SaleAmount + (selectedGoods.SaleQuantity * item.RetailPrice),
                                BarID = item.BarID
                            });
                        });
                        posResultSet = PosBLL.instance.GetPosResultByPosID(entity.Id);
                    }
                    fun?.Invoke(entity);
                }
            }
            catch (Exception ee)
            {
                posResultSet = null;
                XtraMessageBox.Show($"收费结账出现异常。\r\n原因：{ee.Message}", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        /// <summary>
        /// http下载文件
        /// </summary>
        /// <param name="url">下载文件地址</param>
        /// <param name="path">文件存放地址，包含文件名</param>
        /// <returns></returns>
        public bool HttpDownload(string url, string path)
        {

            string tempFile = AppDomain.CurrentDomain.BaseDirectory + path; //临时文件

            if (System.IO.File.Exists(tempFile))
            {
                return true;
            }
            try
            {
                FileStream fs = new FileStream(tempFile, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                // 设置参数
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                //发送请求并获取相应回应数据
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                //直到request.GetResponse()程序才开始向目标网页发送Post请求
                Stream responseStream = response.GetResponseStream();
                //创建本地文件写入流
                //Stream stream = new FileStream(tempFile, FileMode.Create);
                byte[] bArr = new byte[1024];
                int size = responseStream.Read(bArr, 0, (int)bArr.Length);
                while (size > 0)
                {
                    //stream.Write(bArr, 0, size);
                    fs.Write(bArr, 0, size);
                    size = responseStream.Read(bArr, 0, (int)bArr.Length);
                }
                //stream.Close();
                fs.Close();
                responseStream.Close();
                // System.IO.File.Move(tempFile, path);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private void ClearData()
        {
            gridCrasher.DataSource = null;
            txtActualAmount.Text = "";
            txtTotalAmount.Text = "";
            txtChange.Text = "";
            txtBarCode.Text = "";
            Common.Messager<PosCustom>.SendNotifyToSubscriber(null, "cash_clear");
        }

        private void frmCrashierDesk_FormClosed(object sender, FormClosedEventArgs e)
        {
            ClearPostEvent();
        }

        /// <summary>
        /// 付款方式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tilePaymentType_ItemClick(object sender, TileItemEventArgs e)
        {
            TileItem tileItem = sender as TileItem;
            //小键盘、扫码区域可见性控制
            bool IsNetPay = (tileItem.Name == "tileAlipay" || tileItem.Name == "tileWechart");
            //txtActualAmount.ReadOnly = IsNetPay;
            e.Item.Checked = true;
            if (IsNetPay)
            {
                //临时根据业务需求取消支付宝微信支付
                //tabPayInfo.SelectedTabPageIndex = 1;
                //tabKeyPad.Hide();
            }
            else
            {
                tabPayInfo.SelectedTabPageIndex = 0;
                tabNetPay.Hide();
            }
            switch (tileItem.Name)
            {
                case "tileAlipay":
                    paymentType = PayMentType.Alipay;
                    txtActualAmount.Text = "";
                    lblPayMsg.Text = string.Empty;
                    txtBarCode.Focus();
                    txtActualAmount.Text = SummerItems.TotalAmount.ToString();
                    break;
                case "tileWechart":
                    paymentType = PayMentType.WeChat;
                    txtActualAmount.Text = "";
                    lblPayMsg.Text = string.Empty;
                    txtActualAmount.Text = SummerItems.TotalAmount.ToString();
                    break;
                case "tileCrash":
                    paymentType = PayMentType.Crash;
                    txtActualAmount.Text = "";

                    break;
                case "tileBankCard":
                    paymentType = PayMentType.Card;
                    txtActualAmount.Text = SummerItems.TotalAmount.ToString();
                    break;
                case "tileGoodsCenter":
                    paymentType = PayMentType.Market;
                    txtActualAmount.Text = SummerItems.TotalAmount.ToString();
                    break;
                default:
                    break;
            }
        }

        private void barCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (paymentType == PayMentType.None)
            {
                XtraMessageBox.Show("请选择付款方式！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (e.KeyChar == (char)Keys.Enter)
            {
                try
                {
                    SearchControl edit = sender as SearchControl;
                    string barContent = edit.Text.Trim();
                    bool isNullBarCode = string.IsNullOrEmpty(barContent);
                    var posEntity = GetPostEntity();
                    var poseDetailEntity = GetPosDetail(GetPostEntity());
                    /*
                    if (paymentType == PayMentType.Alipay && !isNullBarCode)
                    {
                        IPayment alipay = new Alipy(posEntity, poseDetailEntity, barContent);

                        alipay.Pay(payResult =>
                        {
                            AlipayF2FPayResult _payResult = payResult as AlipayF2FPayResult;
                            Func<AlipayF2FPayResult, bool> doAction = (result) =>
                             {
                                 bool isNull = (result == null);
                                 txtActualAmount.Text = isNull ? "" : result.response.ReceiptAmount;
                                 lbl_BuyerAccout.Text = isNull ? "" : result.response.BuyerLogonId;
                                 lbl_BuyerPayAmount.Text = isNull ? "" : result.response.BuyerPayAmount ?? result.response.ReceiptAmount;
                                 lbl_GMTPayment.Text = isNull ? "" : result.response.GmtPayment ?? "";
                                 lbl_OutTradeNo.Text = isNull ? "" : result.response.OutTradeNo;
                                 lbl_TradNo.Text = isNull ? "" : result.response.TradeNo;
                                 labelControl9.Text = "平台订单号:";
                                 txtChange.Text = "";
                                 return false;
                             };
                            //Aop.Api.Response.AlipayTradePayResponse response = aliayResponse as Aop.Api.Response.AlipayTradePayResponse;
                            //var tradeRes = Newtonsoft.Json.JsonConvert.DeserializeObject<AlipayTradeResponse>(response.Body);
                            //var isSuccess = tradeRes.alipay_trade_query_response.trade_status.Equals("TRADE_SUCCESS");
                            switch (_payResult.Status)
                            {
                                case ResultEnum.SUCCESS:
                                    doAction(_payResult);
                                    ((frmPos)this.Owner).Clear();
                                    posEntity.ChangeAmount = 0;
                                    Payment(posEntity, (PosEntity entity) =>
                                    {
                                        PosBLL.instance.UpdatePosPayNo(entity.Id.ToString(), _payResult.response.TradeNo);
                                        paymentType = PayMentType.None;
                                        printDocument1.Print();
                                        ClearData();
                                        tableLayoutPanel1.Enabled = false;
                                        lblPayMsg.Text = "支付宝付款成功";
                                        return true;
                                    });
                                    break;
                                case ResultEnum.FAILED:
                                case ResultEnum.UNKNOWN:
                                    lblPayMsg.Text = "支付宝支付款失败";
                                    txtBarCode.Text = string.Empty;
                                    txtBarCode.Focus();
                                    doAction(null);
                                    //result = "网络异常，请检查网络配置后，更换外部订单号重试";
                                    break;
                            }
                            return true;
                        });
                    }
                    if (paymentType == PayMentType.WeChat && !isNullBarCode)
                    {
                        WxPayData result = MicroPay.Run("sdda", (int)SummerItems.TotalAmount * 100, barContent.Trim(), posEntity.TicketCode);

                        if (result.CheckSign() && result.GetValue("return_code").ToString() == "SUCCESS" && result.GetValue("result_code").ToString() == "SUCCESS")
                        {
                            posEntity.ChangeAmount = 0;
                            posEntity.PayOrderNo = result.GetValue("out_trade_no").ToString();
                            Payment(posEntity, (PosEntity entity) =>
                            {
                                //posResultSet = PosBLL.instance.GetPosResultByPosID(posEntity.Id);
                                paymentType = PayMentType.None;
                                lblPayMsg.Text = "微信支付付款成功！";
                                txtActualAmount.Text = (result.GetValue("cash_fee").ToString().ToInt32() / 100.00).ToString();
                                lbl_BuyerAccout.Text = result.GetValue("openid").ToString();
                                lbl_BuyerPayAmount.Text = (result.GetValue("cash_fee").ToString().ToInt32() / 100.00).ToString();
                                lbl_GMTPayment.Text = result.GetValue("time_end").ToString();
                                lbl_OutTradeNo.Text = result.GetValue("out_trade_no").ToString();
                                lbl_TradNo.Text = result.GetValue("transaction_id").ToString();
                                labelControl9.Text = "微信订单号:";
                                txtChange.Text = "";
                                printDocument1.Print();
                                ClearData();
                                tableLayoutPanel1.Enabled = false;
                                return true;
                            });


                            //PosBLL.instance.InsertPos(posEntity);
                            //foreach (var item in poseDetailEntity)
                            //{
                            //    PosBLL.instance.InsertPosDetail(item);
                            //}

                            //PosBLL.instance.UpdatePosPayNo(posEntity.Id.ToString(), result.GetValue("transaction_id").ToString());

                        }
                        else
                        {
                            txtBarCode.Text = string.Empty;
                            txtBarCode.Focus();
                            lblPayMsg.Text = "微信支付付款失败！";
                        }
                    }
                    */
                }
                catch (Exception ee)
                {
                    //XtraMessageBox.Show($"支付出现异常。\r\n异常原因：{ee.Message}", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
        }

        private class SummerItems
        {
            /// <summary>
            /// 折扣后总金额
            /// </summary>
            public static decimal TotalAmount { get; set; }
            /// <summary>
            /// 实收金额
            /// </summary>
            public static decimal ActualAmount { get; set; }
            /// <summary>
            /// 商品数量
            /// </summary>
            public static int TotalCount { get; set; }
            /// <summary>
            /// 折扣金额
            /// </summary>
            public static decimal DiscountAmount { get; set; }
            /// <summary>
            /// 折扣金额(不含优惠券)
            /// </summary>
            public static decimal NoCouponcsDiscountAmount { get; set; }

            /// <summary>
            /// 折扣前总金额
            /// </summary>
            public static decimal NoDiscountAmount { get; set; }

        }

        private class Alipy : Model.Interface.IPayment
        {
            public void Pay() { }
            public PosEntity PosEntity { get; set; }
            public List<PosDetailEntity> PostDetailList { get; set; }
            public string AuthoCode { get; set; }
            public Alipy(PosEntity _posEntity, List<PosDetailEntity> _postDetailList, string _authorCode)
            {
                PosEntity = _posEntity;
                PostDetailList = _postDetailList;
                AuthoCode = _authorCode;
            }
            public object CreatePaymentArgs()
            {
                AlipayTradePayContentBuilder builder = new AlipayTradePayContentBuilder();
                string out_trade_no = "";
                if (String.IsNullOrEmpty(PosEntity.TicketCode.ToString().Trim()))
                {
                    out_trade_no = System.DateTime.Now.ToString("yyyyMMddHHmmss") + "0000" + (new Random()).Next(1, 10000).ToString();
                }
                else
                {
                    out_trade_no = PosEntity.TicketCode.ToString().Trim();
                }
                //PartnerID
                //收款账号
                builder.seller_id = MDMSubList.GetOneName("支付宝接口", "PartnerID");
                //订单编号
                builder.out_trade_no = out_trade_no;
                //支付场景，无需修改
                builder.scene = "bar_code";
                //支付授权码,付款码
                builder.auth_code = AuthoCode.ToString().Trim().Trim();
                //订单总金额
                builder.total_amount = PosEntity.TotalAmount.ToString().Trim();
                //参与优惠计算的金额
                //builder.discountable_amount = "";
                //不参与优惠计算的金额
                //builder.undiscountable_amount = "";
                //订单名称
                builder.subject = $"{UserInfo.Instance.StoreName}-{PosEntity.TicketCode}".Trim();
                //自定义超时时间
                builder.timeout_express = "3m";
                //门店编号，很重要的参数，可以用作之后的营销
                builder.store_id = UserInfo.Instance.StoreID.ToString().Trim();
                //操作员编号，很重要的参数，可以用作之后的营销
                builder.operator_id = UserInfo.Instance.ID.ToString();

                //传入商品信息详情
                List<GoodsInfo> gList = new List<GoodsInfo>();

                PostDetailList.ForEach(item =>
                {
                    gList.Add(new Com.Alipay.Model.GoodsInfo
                    {
                        alipay_goods_id = item.BarID.ToString().Trim(),
                        goods_category = item.GoodsCategory.Trim(),
                        goods_name = item.GoodsName,
                        price = item.RetailPrice.ToString(),
                        quantity = item.GoodsCount.ToString(),
                        goods_id = item.BarID.ToString().Trim(),
                        body = $"DiscountPrice:{item.DiscountPrice},DiscountAmount:{item.DiscountAmount}"
                    });
                    builder.body += $"{item.GoodsName}*{item.GoodsAmount}|";
                }
                );
                builder.goods_detail = gList;
                return builder;
            }

            public void Pay(Func<object, bool> funCallBack)
            {
                AlipayTradePayContentBuilder builder = CreatePaymentArgs() as AlipayTradePayContentBuilder;
                string out_trade_no = builder.out_trade_no;

                AlipayF2FPayResult payResult = serviceClient.tradePay(builder);

                //switch (payResult.Status)
                //{
                //    case ResultEnum.SUCCESS:
                //        break;
                //    case ResultEnum.FAILED:
                //        break;
                //    case ResultEnum.UNKNOWN:
                //        //result = "网络异常，请检查网络配置后，更换外部订单号重试";
                //        break;
                //}
                funCallBack(payResult);
            }
        }


        private void printDocument1_EndPrint(object sender, PrintEventArgs e)
        {
            //Close();
        }

        private void groupControl1_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            Close();
        }

        private void btnCoupon_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmCoupon frm = new Presentation.frmCoupon(CouponcsResult);
            frm.SelectCouponEvent += Frm_SelectCouponEvent;
            frm.ShowDialog(this);

        }
        /// <summary>
        /// 优惠券
        /// </summary>
        /// <param name="couponcs"></param>

        private void Frm_SelectCouponEvent(Couponcs couponcs)
        {
            SelectedCouponcs = couponcs;
            int insertIndex = listPosInfo.FindIndex(item => item.Key == "应收金额(折扣优惠后)");
            listPosInfo.Insert(insertIndex, new KeyValueModel { Key = $"优惠券,满{couponcs.full},减{couponcs.deduct}", Value = couponcs.deduct == 0 ? "0" : $"-{couponcs.deduct}" });
            SummerItems.TotalAmount = SummerItems.TotalAmount - int.Parse(couponcs.deduct.ToString());
            //优惠总金额（不含优惠券）
            SummerItems.NoCouponcsDiscountAmount = discountResult.SubtractAmount;
            //优惠总金额（包含优惠券）
            SummerItems.DiscountAmount = discountResult.SubtractAmount + int.Parse(couponcs.deduct.ToString());
            txtTotalAmount.Text = SummerItems.TotalAmount.ToString();
            listPosInfo.Where(item => item.Key == "应收金额(折扣优惠后)").First().Value = SummerItems.TotalAmount.ToString();

            grdPosSummary.DataSource = listPosInfo;
            grdPosSummary.RefreshDataSource();
            this.btnCoupon.Text = $"{couponcs.title}-满{couponcs.full},减{couponcs.deduct}";
        }

        private void txtActualAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!(Char.IsNumber(e.KeyChar)) && ((int)e.KeyChar != 46 || ((int)e.KeyChar == 46 && txtActualAmount.Text.Length == 0)) && (int)e.KeyChar != 8)
                || !(paymentType == PayMentType.Crash || paymentType == PayMentType.None))
            {
                e.Handled = true;
            }
        }
    }
}