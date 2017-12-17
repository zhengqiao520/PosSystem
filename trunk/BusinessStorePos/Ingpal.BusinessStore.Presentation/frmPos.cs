using AutoMapper;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Tile;
using Ingpal.BusinessStore.Business;
using Ingpal.BusinessStore.Infrastructure;
using Ingpal.BusinessStore.Model;
using Ingpal.BusinessStore.Model.Entity;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Ingpal.BusinessStore.Presentation
{
    public partial class frmPos : BaseForm
    {

        private List<PosExt> PosGoodsList = new List<PosExt>();
        private List<string> BuyGoodsIds { get; set; }
        private List<string> SendGoodsIds { get; set; }
        private CrashierParams crashierParams = new CrashierParams();
        /// <summary>
        /// 小票号
        /// </summary>
        public string TicketCode { get; private set; }

        /// <summary>
        /// 流水号
        /// </summary>
        public string RecordSerial { get; private set; }

        #region win32
        /// <summary>
        /// 注册热键
        　/// </summary>
        /// <param name="hWnd">为窗口句柄</param>
        /// <param name="id">注册的热键识别ID</param>
        /// <param name="control">组合键代码  Alt的值为1，Ctrl的值为2，Shift的值为4，Shift+Alt组合键为5
        ///  Shift+Alt+Ctrl组合键为7，Windows键的值为8
        /// </param>
        /// <param name="vk">按键枚举</param>
        /// <returns></returns>
        [DllImport("user32")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, uint control, Keys vk);

        /// <summary>
        /// 取消注册的热键
        /// </summary>
        /// <param name="hWnd">窗口句柄</param>
        /// <param name="id">注册的热键id</param>
        /// <returns></returns>
        [DllImport("user32")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);
        #endregion


        public frmPos()
        {
            InitializeComponent();
            InitCategories();
            InitEvent();
        }

        /// <summary>
        /// 初始化产品分类
        /// </summary>
        private void InitCategories()
        {
            try
            {
                tileBarGroupNav.Items.Clear();
                var categories = GoodsBLL.instance.GetGoodsCategoryByStoreID(UserInfo.Instance.StoreID.ToString());
                if (categories == null)
                {
                    ShowMessage("没有授权可销售的商品或库存为空，请联系管理员！");
                    return;
                }
                tileBarGroupNav.Items.Add(this.GetTileItem(0, "全部商品"));
                foreach (var item in categories)
                {
                    this.tileBarGroupNav.Items.Add(this.GetTileItem(item.ID, item.Category));
                }
            }
            catch (Exception ee)
            {
                XtraMessageBox.Show($"初始化产品分类异常：{ee.Message}", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// 获取TileItem
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="Text">文本</param>
        /// <returns></returns>
        private TileBarItem GetTileItem(int id, string Text)
        {
            var tileItem = new TileBarItem();
            tileItem.AppearanceItem.Selected.BackColor = Color.FromArgb(255, 128, 128);
            tileItem.AppearanceItem.Selected.Options.UseBackColor = true;
            tileItem.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            tileItem.Id = id;
            tileItem.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Medium;
            tileItem.Name = string.Format("tileItem{0}", id);
            tileItem.AppearanceItem.Normal.BackColor = Color.FromArgb(123, 123, 123);
            TileItemElement tileElement = new TileItemElement();
            tileElement.Text = Text;
            tileElement.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileItem.Elements.Add(tileElement);
            tileItem.ItemClick += tileItem_ItemClick;

            return tileItem;
        }

        /// <summary>
        /// 初始化设定
        /// </summary>ss
        private void InitEvent()
        {
            base.BaseInit();
            Load += FrmPos_Load;
            txtSearchGoods.ButtonClick += TxtSearchGoods_ButtonClick;
            InitData();
            SetupView();
            splitContainerControl2.SplitterPosition = splitContainerControl2.Height;
            tileReturnGoods.Visible = IsShopManager;
            txtSearchGoods.Focus();
            TimeStart();
            lblNetWork.Text = $"网络状态：{(NetUtil.IsConnectInternet() ? "网络已连接" : "网络已断开")}";
            lblStoreName.Text += UserInfo.Instance.StoreName;
            lblCrasher.Text += UserInfo.Instance.RealName;

            cboGuider.Properties.DataSource = StoreBLL.Instance.QueryGuiderInfoListByStoreID(UserInfo.Instance.StoreID);
            cboGuider.Properties.DisplayMember = "GuderName";
            cboGuider.Properties.ValueMember = "GuiderID";
            cboGuider.Properties.NullText = "请选择导购";
            cboGuider.Properties.DropDownItemHeight = 25;
            cboGuider.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("GuderName", "导购"));
            QueryFreeGoods();
        }
        private void TimeStart()
        {
            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Start();
            timer.Tick += (s, e) =>
            {
                var sysTime = SysBLL.Instance.GetSysTime();
                var dt = string.IsNullOrEmpty(sysTime) ? DateTime.Now.ToString() : sysTime;
                lblDateTime.Text = $"操作时间：{ dt}";
            };
        }
        private void QueryFreeGoods()
        {
            try
            {
                //查询买赠
                StoreEventMoneyOffRule storeEventMoneyOffRule = Marketing.GetWholeDiscountFreeGoodsEventRules(DiscountType.FreeGoodsDiscount);
                if (storeEventMoneyOffRule == null)
                {
                    return;
                }
                if (!string.IsNullOrEmpty(storeEventMoneyOffRule.ConditionValue) && !string.IsNullOrEmpty(storeEventMoneyOffRule.ConditionName))
                {
                    BuyGoodsIds = storeEventMoneyOffRule.ConditionName.Trim().Replace("\n", "").Replace("\r", "").Split(new char[] { '|' }).ToList();
                    SendGoodsIds = storeEventMoneyOffRule.ConditionValue.Trim().Replace("\n", "").Replace("\r", "").Split(new char[] { '|' }).ToList();
                }
            }
            catch
            {
            }
        }
        /// <summary>
        /// 搜索栏按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtSearchGoods_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var btn = e.Button;
            switch (btn.Caption)
            {
                case "search":
                    txtSearchGoods_KeyPress(null, new KeyPressEventArgs((char)Keys.Enter));
                    break;
                case "combo":
                    txtSearchGoods.ShowPopup();
                    break;
                case "member":
                    break;
                default:
                    txtSearchGoods.Text = string.Empty;
                    break;
            }
        }

        private void FrmPos_Load(object sender, EventArgs e)
        {
            RegisterHotKeys();
            grdGoods.DataSource = new List<PosExt>();
        }

        #region 系统热键快捷
        /// <summary>
        /// 注册系统热键
        /// </summary>
        private void RegisterHotKeys()
        {
            RegisterHotKey(this.Handle, 20175261, 0, Keys.F1);
            RegisterHotKey(this.Handle, 20175262, 0, Keys.F2);
            RegisterHotKey(this.Handle, 20175263, 0, Keys.F3);
            RegisterHotKey(this.Handle, 20175264, 0, Keys.F4);
            RegisterHotKey(this.Handle, 20175266, 0, Keys.F6);
            RegisterHotKey(this.Handle, 20175269, 0, Keys.F9);
            RegisterHotKey(this.Handle, 201752611, 0, Keys.F11);
        }

        /// <summary>
        /// 取消自定义系统热键
        /// </summary>
        private void UnregisterHotKeys()
        {
            UnregisterHotKey(this.Handle, 20175261);
            UnregisterHotKey(this.Handle, 20175262);
            UnregisterHotKey(this.Handle, 20175263);
            UnregisterHotKey(this.Handle, 20175264);
            UnregisterHotKey(this.Handle, 20175266);
            UnregisterHotKey(this.Handle, 20175269);
            UnregisterHotKey(this.Handle, 201752611);
        }

        // 响应热键
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x0312:                               　　//这个是window消息定义的注册的热键消息
                    switch (m.WParam.ToString())   //如果是注册的那个热键
                    {
                        //F1
                        case "20175261":
                            break;
                        //F2
                        case "20175262":
                            tileSaleList.PerformItemClick();
                            break;
                        //F3
                        case "20175263":
                            btnHandingOrder.PerformClick();
                            break;
                        //F4
                        case "20175264":
                            btnGetHanding.PerformClick();
                            break;
                        //F6
                        case "20175266":
                            tileStockQuery.PerformItemClick();
                            break;
                        //F9
                        case "20175269":
                            tileTransferWork.PerformItemClick();
                            break;
                        //F10
                        case "201752610":
                            //tileReturnGoods.PerformItemClick();
                            break;
                        //F11
                        case "201752611":
                            tileReturnGoods.PerformItemClick();
                            break;

                    }
                    break;
            }

            base.WndProc(ref m);
        }
        #endregion


        private void tileDiscount_ItemClick(object sender, TileItemEventArgs e)
        {
            frmDiscount frm = new Presentation.frmDiscount();
            frm.Show(this);
        }
        private void txtSearchGoods_KeyPress(object sender, KeyPressEventArgs e)
        {
            //回车
            if (e.KeyChar == (char)Keys.Enter)
            {
                BeginAddGoods(txtSearchGoods.Text.Trim());
            }
        }
        /// <summary>
        /// 客显消息通知
        /// </summary>
        /// <param name="goodsCodeOrName"></param>
        private void BeginAddGoods(string goodsCodeOrName = "")
        {
            FindAddGoods(goodsCodeOrName, () =>
            {
                grdGoods.DataSource = PosGoodsList;
                gvGoods.RefreshData();
                txtSearchGoods.ClosePopup();
                txtSearchGoods.Text = "";
            });
            //添加买赠
            var extistBarIds = PosGoodsList.Select(item => item.BarID).ToList();
            if (BuyGoodsIds != null && BuyGoodsIds.Count > 0)
            {
                var res = from p in PosGoodsList where BuyGoodsIds.Any(s => s.Contains(p.BarID.Trim())) select p;
                if (res.Count() == BuyGoodsIds.Count)
                {
                    var tag = '*';
                    var numLimit = BuyGoodsIds.Where(k => k.Contains(tag));
                    var isNumLimit = numLimit.Any();
                    if (isNumLimit)
                    {
                        var qCnt = 0;
                        var goodsLimitNum = 0;
                        foreach (var q in numLimit)
                        {
                            var seq = q.Split(tag);
                            if (seq.Length > 1 && int.TryParse(seq[1].Trim(), out goodsLimitNum))
                            {
                                if (PosGoodsList.Any(p => p.BarID == seq[0].Trim() && p.PosSalesCount >= goodsLimitNum)) { qCnt++; }
                            }
                        }
                        if (qCnt == numLimit.Count())
                        {
                            isNumLimit = false;
                        }
                    }
                    if (!isNumLimit)
                    {
                        ScreenPremium();
                    }
                }
            }
            var pos_entity = this.GetPosCustomEntity();
            Common.Messager<PosCustom>.SendNotifyToSubscriber(pos_entity, "pos");
        }

        /// <summary>
        /// 增加赠品到商品列表
        /// </summary>
        private void ScreenPremium()
        {
            SendGoodsIds.ForEach(item =>
            {
                if (!string.IsNullOrEmpty(item.Trim()))
                {
                    FindAddGoods(item.Trim(), () =>
                    {
                        grdGoods.DataSource = PosGoodsList;
                        gvGoods.RefreshData();
                    }, true);
                }
            });
        }

        /// <summary>
        /// 根据条码或商品名查找并添加合并到商品列表
        /// </summary>
        /// <param name="goodsCodeOrName">条码</param>
        /// <param name="act">会掉函数</param>
        /// <param name="isSendGoods">是否赠品</param>
        /// <param name="exchangeGoods">换购商品信息</param>
        private void FindAddGoods(string goodsCodeOrName = "", Action act = null, bool isSendGoods = false, GoodsGrantExt exchangeGoods = null)
        {
            if (string.IsNullOrEmpty(goodsCodeOrName)) return;
            //库存充足
            var entity = GoodsBLL.instance.GetGoodsListByCodeOrName(goodsCodeOrName, UserInfo.Instance.StoreID.ToString());
            if (entity != null)
            {
                if (entity.Count > 1)
                {
                    txtSearchGoods.Properties.Items.Clear();
                    txtSearchGoods.Properties.Items.AddRange(entity.Select(item => item.Name).ToArray());
                    txtSearchGoods.ShowPopup();
                }
                else
                {
                    if (entity[0].StockQuantity <= 0)
                    {
                        XtraMessageBox.Show("商品库存不足!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    Mapper.Initialize(m => m.CreateMap<GoodsEntity, PosExt>());
                    var mapGoodsExt = Mapper.Map<PosExt>(entity[0]);
                    var realPrice = 0.0m;
                    if (isSendGoods)
                    {
                        realPrice = 0.0m;
                        mapGoodsExt.PosDiscountPrice = 0.00m;
                        mapGoodsExt.RetailPrice = 0.00m;
                    }
                    else if (exchangeGoods != null)
                    {
                        //换购价作为折扣销售价格
                        mapGoodsExt.PosDiscountPrice = exchangeGoods.ExchangePrice;
                        realPrice = mapGoodsExt.PosDiscountPrice;
                    }
                    else
                    {
                        //单品折扣
                        GoodsGrantEntity goodsGrant = Marketing.DiscountGoodsItem(mapGoodsExt);
                        realPrice = goodsGrant == null ? 0 : goodsGrant.DiscountPrice;
                        mapGoodsExt.PosDiscountPrice = realPrice > 0 ? realPrice : mapGoodsExt.PosDiscountPrice;
                    }
                    if (PosGoodsList.Count > 0)
                    {
                        //var fitGoods = PosGoodsList.Find(item => item.BarID == mapGoodsExt.BarID&&item.RetailPrice== mapGoodsExt.RetailPrice);
                        var fitGoods = PosGoodsList.Find(item => item.BarID == mapGoodsExt.BarID && item.RetailPrice == mapGoodsExt.RetailPrice && item.PosDiscountPrice == mapGoodsExt.PosDiscountPrice);
                        if (fitGoods != null)
                        {
                            fitGoods.PosSalesCount += 1;
                            fitGoods.PosSalesAmount = fitGoods.PosSalesCount * (realPrice > 0 ? realPrice : mapGoodsExt.RetailPrice); ;
                        }
                        else
                        {
                            mapGoodsExt.PosSalesCount = 1;
                            mapGoodsExt.PosSalesAmount = mapGoodsExt.PosSalesCount * (realPrice > 0 ? realPrice : mapGoodsExt.RetailPrice);
                            PosGoodsList.Add(mapGoodsExt);
                        }
                    }
                    else
                    {
                        //单品折扣价格生效则按照单品折扣价格计算
                        mapGoodsExt.PosSalesCount = 1;
                        mapGoodsExt.PosSalesAmount = mapGoodsExt.PosSalesCount * (realPrice > 0 ? realPrice : mapGoodsExt.RetailPrice);
                        var existData = grdGoods.DataSource as List<PosExt>;
                        if (existData != null && existData.Any())
                        {
                            PosGoodsList = existData;
                        }
                        PosGoodsList.Add(mapGoodsExt);
                    }
                }
            }
            act?.Invoke();
        }


        /// <summary>
        /// 单元格数值改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvGoods_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            int rowHander = gvGoods.FocusedRowHandle;
            if (rowHander >= 0)
            {
                if (e.Column == gvGoods.Columns["PosSalesCount"])
                {

                    var focusRow = gvGoods.GetRow(rowHander) as PosExt;
                    if (focusRow.PosSalesCount <= focusRow.StockQuantity)
                    {
                        var newSalesAmount = focusRow.PosSalesCount * focusRow.RetailPrice;
                        gvGoods.SetRowCellValue(rowHander, gvGoods.Columns["PosSalesAmount"], newSalesAmount);

                    }
                    else
                    {
                        XtraMessageBox.Show("购买数量超过本店最大库存!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        var newSalesAmount = focusRow.StockQuantity * focusRow.RetailPrice;
                        gvGoods.SetRowCellValue(rowHander, gvGoods.Columns["PosSalesAmount"], newSalesAmount);
                        return;
                    }
                }
            }
        }
        /// <summary>
        /// 键盘事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvGoods_KeyDown(object sender, KeyEventArgs e)
        {
            var focusRow = gvGoods.GetFocusedRow() as PosExt;
            if (focusRow != null)
            {
                //键盘+
                if (e.KeyCode == Keys.Oemplus || e.KeyCode == Keys.Add)
                {
                    focusRow.PosSalesCount++;
                    focusRow.PosSalesAmount = focusRow.PosSalesCount * focusRow.RetailPrice;
                }
                //键盘-
                if (e.KeyCode == Keys.OemMinus || e.KeyCode == Keys.Subtract)
                {
                    if (focusRow.PosSalesCount > 1)
                    {
                        focusRow.PosSalesCount--;
                        focusRow.PosSalesAmount = focusRow.PosSalesCount * focusRow.RetailPrice;
                    }
                    else
                    {
                        XtraMessageBox.Show("商品数量必须大于0!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                gvGoods.UpdateCurrentRow();
            }

        }
        /// <summary>
        /// 单元格编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvGoods_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            int rowHander = gvGoods.FocusedRowHandle;
            var focuseRow = gvGoods.GetFocusedRow() as PosExt;
            if (focuseRow != null)
            {
                if (e.Column == gvGoods.Columns["PosSalesCount"])
                {

                    var goodsPrice = focuseRow.PosDiscountPrice > 0 ? focuseRow.PosDiscountPrice : focuseRow.RetailPrice;
                    if (focuseRow.PosSalesCount <= focuseRow.StockQuantity)
                    {
                        focuseRow.PosSalesAmount = (int)e.CellValue * goodsPrice;
                        gvGoods.SetRowCellValue(rowHander, gvGoods.Columns["PosSalesAmount"], focuseRow.PosSalesAmount);
                    }
                    else
                    {

                        focuseRow.PosSalesAmount = focuseRow.StockQuantity * goodsPrice;
                        gvGoods.SetRowCellValue(rowHander, gvGoods.Columns["PosSalesCount"], focuseRow.StockQuantity);
                        gvGoods.SetRowCellValue(rowHander, gvGoods.Columns["PosSalesAmount"], focuseRow.PosSalesAmount);
                    }
                }
            }
        }

        /// <summary>
        /// 顶部导航菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tile_ItemClick(object sender, TileItemEventArgs e)
        {
            var tileItem = sender as TileItem;
            XtraForm frm = null;
            switch (tileItem.Name)
            {
                case "tileSaleList":
                    frm = new frmSaleList();
                    break;
                case "tileStockQuery":
                    frm = new frmStockQuery();
                    break;
                case "tileReturnGoods":
                    frm = new frmReturnGoods();
                    break;
                case "tileTransferWork":
                    frm = new frmTransferWork();
                    break;
                case "tileSysconfig":
                    frm = new frmSysConfig();
                    break;
                case "tileLockScreen":
                    new frmLock().ShowDialog();
                    break;
                case "tileGoback":
                    if (gvGoods.RowCount > 0)
                    {
                        if (XtraMessageBox.Show("有正在销售的商品，是否要继续返回主页？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                        {
                            Close();
                        }
                    }
                    else { Close(); };
                    break;
                case "tileExchangePrice":
                    frmExchangePrice fm = new frmExchangePrice();
                    fm.ExchangeEvent += Fm_ExchangeEvent;
                    fm.ShowDialog(this);
                    break;
                default:
                    break;
            }
            if (!tileItem.Name.Equals("tileGoback")) frm?.Show(this);
        }

        /// <summary>
        /// 商品换购
        /// </summary>
        /// <param name="goodsGrantExt"></param>
        private void Fm_ExchangeEvent(GoodsGrantExt goodsGrantExt)
        {
            if (!(gvGoods.RowCount > 0))
            {
                ShowMessage("至少需要购买一件以上商品才能进行换购!");
                return;
            }
            if (null != goodsGrantExt)
            {
                FindAddGoods(goodsGrantExt.BarID, exchangeGoods: goodsGrantExt);
                gvGoods.RefreshData();
            }
        }

        /// <summary>
        /// 商品点击选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tileView1_ItemClick(object sender, TileViewItemClickEventArgs e)
        {
            var view = sender as TileView;
            var selectedRow = view.GetFocusedRow() as GoodsEntity;
            BeginAddGoods(selectedRow.BarID);
        }

        /// <summary>
        /// 初始化商品列表
        /// </summary>
        private void SetupView()
        {
            try
            {

                this.gvGoods.IndicatorWidth = 30;
                // Setup tiles options
                tileView1.BeginUpdate();
                tileView1.OptionsTiles.RowCount = 3;
                tileView1.OptionsTiles.Padding = new Padding(5);
                tileView1.OptionsTiles.ItemPadding = new Padding(5);
                tileView1.OptionsTiles.IndentBetweenItems = 10;
                tileView1.OptionsTiles.ItemSize = new Size(180, 100);
                tileView1.Appearance.ItemNormal.ForeColor = Color.White;
                tileView1.Appearance.ItemNormal.BorderColor = Color.Transparent;

                //Setup tiles template
                TileViewItemElement leftPanel = new TileViewItemElement();
                TileViewItemElement splitLine = new TileViewItemElement();
                TileViewItemElement addressCaption = new TileViewItemElement();
                TileViewItemElement addressValue = new TileViewItemElement();
                //TileViewItemElement yearBuiltCaption = new TileViewItemElement();
                //TileViewItemElement yearBuiltValue = new TileViewItemElement();
                TileViewItemElement price = new TileViewItemElement();
                TileViewItemElement image = new TileViewItemElement();

                tileView1.TileTemplate.Add(leftPanel);
                //tileView1.TileTemplate.Add(splitLine);
                tileView1.TileTemplate.Add(addressCaption);
                tileView1.TileTemplate.Add(addressValue);
                //tileView1.TileTemplate.Add(yearBuiltCaption);
                //tileView1.TileTemplate.Add(yearBuiltValue);
                tileView1.TileTemplate.Add(price);
                tileView1.TileTemplate.Add(image);

                leftPanel.StretchVertical = true;
                leftPanel.Width = 190;
                leftPanel.TextLocation = new Point(-10, 0);
                leftPanel.Appearance.Normal.BackColor = Color.FromArgb(173, 173, 173);

                splitLine.StretchVertical = true;
                splitLine.Width = 3;
                splitLine.TextAlignment = TileItemContentAlignment.Manual;
                splitLine.TextLocation = new Point(100, 0);
                splitLine.Appearance.Normal.BackColor = Color.White;


                //
                addressCaption.Text = "品名";
                addressCaption.TextAlignment = TileItemContentAlignment.TopLeft;
                addressCaption.Appearance.Normal.FontSizeDelta = -1;
                //
                addressValue.Column = tileView1.Columns["Name"];
                addressValue.AnchorElement = addressCaption;
                addressValue.AnchorIndent = 2;
                addressValue.MaxWidth = 180;
                addressValue.Appearance.Normal.FontStyleDelta = FontStyle.Bold;
                //
                //yearBuiltCaption.Text = "类别";
                //yearBuiltCaption.AnchorElement = addressValue;
                //yearBuiltCaption.AnchorIndent = 3;
                //yearBuiltCaption.Appearance.Normal.FontSizeDelta = -1;
                //
                //yearBuiltValue.Column = tileView1.Columns["Category"];
                //yearBuiltValue.AnchorElement = yearBuiltCaption;
                //yearBuiltValue.AnchorIndent = 2;
                //yearBuiltValue.Appearance.Normal.FontStyleDelta = FontStyle.Bold;
                //
                price.Column = tileView1.Columns["RetailPrice"];
                //price.AnchorElement = yearBuiltValue;
                price.TextAlignment = TileItemContentAlignment.BottomLeft;
                price.Appearance.Normal.Font = new Font("Segoe UI Semilight", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                //
                image.Column = tileView1.Columns["Image"];
                image.ImageSize = new Size(100, 100);
                image.ImageAlignment = TileItemContentAlignment.MiddleRight;
                image.ImageScaleMode = TileItemImageScaleMode.Stretch;
                image.ImageLocation = new Point(10, 0);

            }
            finally
            {
                tileView1.EndUpdate();


            }
        }

        private void InitData(int cateId = 0)
        {
            var permisionGoods = GoodsBLL.instance.GetGoodsListByCategoryID(UserInfo.Instance.StoreID, cateId);
            var dataList = permisionGoods == null ? null : permisionGoods.Where(item => item.StockQuantity > 0);

            if (dataList == null) { return; }
            var dataSource = new List<GoodsEntityExtend>();


            foreach (var item in dataList ?? new List<GoodsEntity>())
            {
                var goods = new GoodsEntityExtend();
                goods.AlarmAmount = item.AlarmAmount;
                goods.AllowDiscount = item.AllowDiscount;
                goods.AllowMemberScore = item.AllowMemberScore;

                goods.BarID = item.BarID;
                goods.BatchNo = item.BatchNo;
                goods.BuyingPrice = item.BuyingPrice;

                goods.Category = item.Category;
                goods.CodeNumber = item.CodeNumber;

                goods.DiscountRate = item.DiscountRate;

                goods.ID = item.ID;
                goods.ImageName = item.ImageName;
                goods.InQuantityStock = item.InQuantityStock;
                goods.InstockAmount = item.InstockAmount;

                goods.MemberPrice = item.MemberPrice;
                goods.MemberScoreCount = item.MemberScoreCount;
                goods.MemberScorePrice = item.MemberScorePrice;
                goods.ModelNumber = item.ModelNumber;

                goods.Name = item.Name;

                goods.NameAbbr = item.NameAbbr;

                goods.OutQuantityStock = item.OutQuantityStock;
                goods.OutstockAmount = item.OutstockAmount;

                goods.ProductionDate = item.ProductionDate;
                goods.ProductionPlace = item.ProductionPlace;
                goods.Profit = item.Profit;

                goods.RecordStatus = item.RecordStatus;
                goods.Remark = item.Remark;
                goods.RetailPrice = item.RetailPrice;

                goods.SaleAmount = item.SaleAmount;
                goods.SaleQuantity = item.SaleQuantity;
                goods.SPEC = item.SPEC;
                goods.StockQuantity = item.StockQuantity;

                goods.StoreID = item.StoreID;
                goods.Supplier = item.Supplier;
                goods.Unit = item.Unit;
                goods.Image = File.Exists("Images\\" + item.ImageName) ? Image.FromFile("Images\\" + item.ImageName) : Image.FromFile("Images\\ptznsh.jpg");
                dataSource.Add(goods);
            }

            gridNavGoods.DataSource = dataSource;
        }

        private void gvGoods_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        /// <summary>
        /// 清空数据
        /// </summary>
        public void Clear()
        {
            grdGoods.DataSource = new List<PosExt>();
            PosGoodsList = new List<PosExt>();
            gvGoods.RefreshData();
        }

        #region 挂单信息
        private void Frg_GetHandingEvent(RestPosEntity restPos, List<PosExt> listPosExt, string posID)
        {
            TicketCode = restPos.TicketCode;
            var posData = SysBLL.Instance.GetALL<PosEntity>(where: $"StoreID={UserInfo.Instance.StoreID.ToString()}");
            if (posData.Any(s => s.TicketCode == TicketCode))
            {
                TicketCode = PosBLL.instance.GetBatchNumber("TK");
            }
            RecordSerial = restPos.RecordSerial;
            cboGuider.EditValue = restPos.GuiderID;
            grdGoods.DataSource = listPosExt;
            PosBLL.instance.RemoveRestPos(posID);
        }
        /// <summary>
        /// 挂单明细
        /// </summary>
        /// <param name="posEntity"></param>
        /// <returns></returns>
        private List<RestPosDetailEntity> GetPosDetail(RestPosEntity posEntity)
        {
            List<RestPosDetailEntity> listPosDetail = new List<RestPosDetailEntity>();

            var restPosGoodsList = gvGoods.DataSource as List<PosExt>;
            restPosGoodsList.ForEach(item =>
            //PosGoodsList.ForEach(item =>
            {
                var price = item.PosDiscountPrice > 0 ? item.PosDiscountPrice : item.RetailPrice;
                var restPosDetail = new RestPosDetailEntity()
                {
                    RetailPrice = item.RetailPrice,
                    PosID = posEntity.Id,
                    ID = Guid.NewGuid(),
                    GoodsID = item.ID,
                    GoodsCategory = item.Category,
                    SaleDate = DateTime.Now,
                    StoreID = posEntity.StoreID,
                    BarID = item.BarID,
                    CashierID = posEntity.CashierID,
                    GoodsCount = item.PosSalesCount,
                    GoodsName = item.Name,
                    GoodsAmount = price * item.PosSalesCount,
                    DiscountPrice = item.PosDiscountPrice,
                    BuyingPrice = item.BuyingPrice
                };
                listPosDetail.Add(restPosDetail);
            });
            return listPosDetail;
        }

        /// <summary>
        /// 挂单主表
        /// </summary>
        /// <returns></returns>
        private RestPosEntity GetPostEntity()
        {
            TicketCode = TicketCode ?? PosBLL.instance.GetBatchNumber("TK");
            RecordSerial = RecordSerial ?? PosBLL.instance.GetBatchNumber("LS");
            RestPosEntity entity = new RestPosEntity();
            entity.RecordStatus = RecordType.Normal;
            entity.Id = Guid.NewGuid();
            entity.Cashier = UserInfo.Instance.UserCode;
            entity.CashierID = UserInfo.Instance.ID;
            entity.RecordSerial = RecordSerial;
            entity.TicketCode = TicketCode;
            entity.TotalAmount = (decimal)gvGoods.Columns["PosSalesAmount"].SummaryItem.SummaryValue;
            entity.ActualAmount = 0.0m;
            entity.TotalCount = (int)gvGoods.Columns["PosSalesCount"].SummaryItem.SummaryValue;
            entity.PayType = (int)PayMentType.None;
            entity.StoreID = (int)UserInfo.Instance.StoreID;
            entity.SaleDate = DateTime.Now;
            entity.GuiderID = (Guid)cboGuider.EditValue;
            entity.Guider = cboGuider.Text;
            //找零：实收-应收
            //entity.ChangeAmount = entity.ActualAmount - entity.TotalAmount;
            ////商品额度：实收-找零
            //entity.GoodsAmount = entity.ActualAmount - entity.ChangeAmount;
            return entity;
        }

        /// <summary>
        /// 挂单明细
        /// </summary>
        /// <param name="posEntity"></param>
        /// <returns></returns>
        private List<PosDetailEntity> GetPosCustomDetail(PosCustom posEntity)
        {
            List<PosDetailEntity> listPosDetail = new List<PosDetailEntity>();
            PosGoodsList.ForEach(item =>
            {
                var restPosDetail = new PosDetailEntity()
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
                    GoodsAmount = item.RetailPrice * item.PosSalesCount,
                    BuyingPrice = item.BuyingPrice
                };
                listPosDetail.Add(restPosDetail);
            });
            return listPosDetail;
        }

        #endregion

        /// <summary>
        /// 获取客显信息
        /// </summary>
        /// <returns></returns>
        public PosCustom GetPosCustomEntity()
        {
            TicketCode = TicketCode ?? PosBLL.instance.GetBatchNumber("TK");
            RecordSerial = RecordSerial ?? PosBLL.instance.GetBatchNumber("LS");
            PosCustom entity = new PosCustom();
            entity.RecordStatus = RecordType.Normal;
            entity.Id = Guid.NewGuid();
            entity.Cashier = UserInfo.Instance.UserCode;
            entity.CashierID = UserInfo.Instance.ID;
            entity.RecordSerial = TicketCode;
            entity.TicketCode = RecordSerial;
            entity.TotalAmount = (decimal)gvGoods.Columns["PosSalesAmount"].SummaryItem.SummaryValue;
            entity.ActualAmount = 0.0m;
            entity.TotalCount = (int)gvGoods.Columns["PosSalesCount"].SummaryItem.SummaryValue;
            entity.PayType = (int)PayMentType.None;
            entity.StoreID = UserInfo.Instance.StoreID;
            entity.SaleDate = DateTime.Now;
            entity.GuiderID = cboGuider.EditValue == null ? Guid.Empty : (Guid)cboGuider.EditValue;
            entity.Guider = cboGuider.Text;
            //找零：实收-应收
            entity.ChangeAmount = entity.ActualAmount - entity.TotalAmount;
            //商品额度：实收-找零
            entity.GoodsAmount = entity.ActualAmount - entity.ChangeAmount;

            entity.PosDetail = GetPosCustomDetail(entity);
            return entity;
        }

        /// <summary>
        /// 按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btns_Click(object sender, EventArgs e)
        {
            SimpleButton btn = sender as SimpleButton;
            switch (btn.Name)
            {
                case "btnHandingOrder":
                    if (!(gvGoods.RowCount > 0)) return;
                    if (cboGuider.EditValue == null)
                    {
                        XtraMessageBox.Show("请选择导购员！", "系统提示");
                        return;
                    }
                    if (XtraMessageBox.Show("您确认要进行挂单吗？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        List<PosExt> handingGoods = grdGoods.DataSource as List<PosExt>;
                        var entity = GetPostEntity();
                        int rs = PosBLL.instance.InsertRestPos(entity);
                        if (rs > 0)
                        {
                            List<RestPosDetailEntity> listPosDetail = GetPosDetail(entity);
                            listPosDetail.ForEach(item =>
                            {
                                var selectedGoods = PosGoodsList.Where(goods => goods.BarID == item.BarID && goods.StoreID == entity.StoreID).FirstOrDefault();
                                PosBLL.instance.InsertPosDetail(item);

                            });
                            grdGoods.DataSource = null;
                            PosGoodsList.Clear();
                        }
                    }
                    break;
                case "btnGetHanding":
                    frmGetHanding frg = new frmGetHanding(cboGuider.EditValue?.ToString());
                    frg.GetHandingEvent += Frg_GetHandingEvent;
                    frg.Show(this);
                    break;
                case "btnDelteSelected":
                    if (XtraMessageBox.Show("确定要删除选中商品吗？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int rowHander = gvGoods.FocusedRowHandle;
                        var selectedRow = gvGoods.GetRow(rowHander) as PosExt;
                        gvGoods.DeleteRow(rowHander);
                        PosGoodsList.Remove(selectedRow);
                    }
                    break;
                case "btnClearGrid":
                    if (XtraMessageBox.Show("确定要清空列表中所有商品吗？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        grdGoods.DataSource = null;
                        PosGoodsList.Clear();
                    }
                    break;
                case "btnCrasherDesk":
                    if (gvGoods.RowCount > 0)
                    {
                        var goodsList = grdGoods.DataSource as List<PosExt>;
                        bool IsCanSale = true;
                        foreach (var item in goodsList)
                        {
                            if (item.PosSalesCount > item.StockQuantity)
                            {
                                XtraMessageBox.Show($"{item.Name}：超过库存数量，请修改！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                IsCanSale = false;
                            }
                            break;
                        }
                        if (!IsCanSale) return;
                        if (cboGuider.EditValue == null)
                        {
                            XtraMessageBox.Show("请选择导购！", "系统提示");
                        }
                        else
                        {
                            crashierParams.Guider = cboGuider.GetSelectedDataRow() as GuiderInfo;
                            crashierParams.ticket_code = TicketCode;
                            crashierParams.recode_serial = RecordSerial;
                            frmCrashierDesk frmCrs = new frmCrashierDesk(goodsList, crashierParams);
                            frmCrs.ClearPostEvent += FrmCrs_ClearPostEvent;
                            frmCrs.Show(this);
                            TicketCode = null;
                            RecordSerial = null;
                        }
                    }
                    break;
                case "btnDiscount":
                    //var posExt=gvGoods.GetFocusedRow() as PosExt;
                    //frmDiscount frmDsc = new Presentation.frmDiscount(grdGoods.DataSource as List<PosExt>, posExt);
                    //frmDsc.ShowDialog(this);
                    //if (frmDsc.DialogResult == DialogResult.Cancel) {
                    //    grdGoods.DataSource = frmDsc.ListPosExt;
                    //    grdGoods.RefreshDataSource();
                    //    grdGoods.Refresh();
                    //}
                    break;
                case "btnModifyPrice":
                    if (gvGoods.RowCount == 0)
                        return;
                    else
                    {
                        var posExt = gvGoods.GetFocusedRow() as PosExt;
                        if (posExt != null)
                        {
                            frmModifyPrice frmMdy = new frmModifyPrice(posExt);
                            frmMdy.ModifyPriceEvent += FrmMdy_ModifyPriceEvent;
                            frmMdy.ShowDialog();
                        }
                        else
                        {
                            ShowMessage("请选中要修改价格的商品！");
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        private void FrmCrs_ClearPostEvent()
        {
            searchMember.Text = null;
            crashierParams.member_id = null;
            crashierParams.CouponcsResult = null;
            groupMemberInfo_CustomButtonClick(null, null);
        }

        /// <summary>
        /// 修改商品价格
        /// </summary>
        /// <param name="posExt"></param>
        private void FrmMdy_ModifyPriceEvent(PosExt posExt)
        {
            if (decimal.Parse(posExt.RetailPrice.ToString()) >= 0)
            {
                int rowHander = gvGoods.FocusedRowHandle;
                var focusRow = gvGoods.GetRow(rowHander) as PosExt;

                var totalAmount = posExt.RetailPrice * focusRow.SaleQuantity;
                gvGoods.SetFocusedRowCellValue("RetailPrice", posExt.RetailPrice);
                gvGoods.SetFocusedRowCellValue("PosSalesAmount", totalAmount);
                gvGoods.SetRowCellValue(rowHander, gvGoods.Columns["RetailPrice"], posExt.RetailPrice);
                gvGoods.SetRowCellValue(rowHander, gvGoods.Columns["PosSalesAmount"], totalAmount);
                gvGoods.UpdateCurrentRow();
                gvGoods.UpdateSummary();
                gvGoods.UpdateTotalSummary();

                if (PosGoodsList!=null && PosGoodsList.Any())
                {
                    var tk = PosGoodsList.FirstOrDefault(s => s.ID == posExt.ID);
                    if (tk != null)
                    {
                        tk.RetailPrice = posExt.RetailPrice;
                        tk.PosSalesAmount = totalAmount;
                    }
                }
            }
        }

        private void frmPos_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.UnregisterHotKeys();
        }

        private void tileItem_ItemClick(object sender, TileItemEventArgs e)
        {
            this.InitData(e.Item.Id);
        }
        /// <summary>
        /// 超过库存数量提示消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        ///
        private void gvGoods_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

            if (e.RowHandle >= 0 && e.Column == gvGoods.Columns["PosSalesCount"])
            {

                var focusRow = gvGoods.GetRow(e.RowHandle) as PosExt;
                if (focusRow.PosSalesCount > focusRow.StockQuantity)
                {
                    XtraMessageBox.Show($"{(focusRow as PosExt).Name}：超过库存数量，请修改销售数量！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }
        }

        #region 会员接口
        /// <summary>
        /// 会员查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void searchMember_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var member = new MemberParams { queryid = searchMember.Text.Trim() };
            Func<string, JObject> doSetdata = res =>
            {
                Newtonsoft.Json.Linq.JObject jobject = (Newtonsoft.Json.Linq.JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(res);
                int error_code = int.Parse(jobject["error_code"].ToString());
                if (!(error_code > 0))
                {
                    string name = jobject["name"].ToString() == "" ? jobject["nickname"].ToString() : jobject["name"].ToString();
                    lblMemberLevel.Text = $"会员等级：{jobject["level"].ToString()}";
                    lblMemberName.Text = $"会员姓名：{name}";
                    lblScore.Text = $"会员积分：{jobject["point"].ToString()}";
                    crashierParams.member_id = jobject["uid"].ToString();
                    crashierParams.member_name = jobject["name"].ToString();
                    splitContainerControl2.SplitterPosition = splitContainerControl2.Height - 70;
                }
                return jobject;
            };
            ExternalAPI.ValidMemberInfo(member, (response) =>
            {
                var jObject = doSetdata(response);
                int error_code = int.Parse(jObject["error_code"].ToString());
                if (error_code > 0)
                {
                    ExternalAPI.ValidMemberInfo(member, res =>
                     {
                         var obj = doSetdata(res);
                         error_code = int.Parse(jObject["error_code"].ToString());
                         if (error_code > 0)
                         {
                             ShowMessage(jObject["msg"].ToString());
                             lblMemberLevel.Text = "";
                             lblMemberName.Text = "";
                             lblScore.Text = "";
                         }
                         return true;
                     }, MemberQueryType.CardId);
                }
                return true;
            });
        }

        private void groupMemberInfo_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            splitContainerControl2.SplitterPosition = splitContainerControl2.Height;
        }
        #endregion
    }
}