using Com.Alipay;
using Com.Alipay.Domain;
using DevExpress.XtraEditors;
using Ingpal.BusinessStore.Business;
using Ingpal.BusinessStore.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Com.Alipay.Business;
using Aop.Api.Response;
using WxPayAPI;
namespace Ingpal.BusinessStore.Presentation
{
    public partial class frmReturnGoods : BaseForm
    {
        SaleBusiness sale = new SaleBusiness();
        public frmReturnGoods()
        {
            InitializeComponent();
            this.Load += FrmReturnGoods_Load;
        }

        private void FrmReturnGoods_Load(object sender, EventArgs e)
        {
            ItemSpinGoodsCount.EditValueChanged += RepositoryItem_EditValueChanged;
            //throw new NotImplementedException();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReturnGoods_Click(object sender, EventArgs e)
        {
            if (!IsShopManager)
            {
                ShowMessage("当前用户无退货权限！", ico: MessageBoxIcon.Warning);
                return;
            }
            DataTable dataSource = this.gridControlReturnGoods.DataSource as DataTable;
            if (null != dataSource)
            {
                var rows = dataSource.Select("ReturnCount>0"); //过滤数据
                if (null != rows && rows.Length > 0)
                {
                    if (XtraMessageBox.Show("确定要执行退货操作吗?一张小票只能执行一次退货操作!", "系统提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        ReturnGoods returnGoods = new ReturnGoods();
                        returnGoods.ID = new Guid(rows[0]["PosID"].ToString());
                        returnGoods.Cashier = UserInfo.Instance.RealName;
                        returnGoods.CashierID = UserInfo.Instance.ID;
                        returnGoods.Description = txtDescription.Text;
                        returnGoods.Details = new List<ReturnGoodsDetail>();
                        returnGoods.Guider = txtGuider.Text;
                        returnGoods.GuiderID = new Guid(labelGuider.Tag.ToString());
                        returnGoods.PayType = int.Parse(labelPaytype.Tag.ToString());
                        returnGoods.RecordSerial = PosBLL.instance.GetBatchNumber("LS");
                        returnGoods.RefundAmount = double.Parse(labelReturnAmount.Text);
                        returnGoods.RefundTime = DateTime.Now;
                        returnGoods.ReturnGoodsCount = int.Parse(labelReturnCount.Text);
                        returnGoods.TicketCode = labelLS.Tag.ToString();

                        for (int i = 0; i < rows.Length; i++)
                        {
                            ReturnGoodsDetail detail = new ReturnGoodsDetail();
                            detail.ID = new Guid(rows[i]["ID"].ToString());
                            detail.PosID = returnGoods.ID;
                            detail.ReturnAmount = double.Parse(rows[i]["ReturnAmount"].ToString());
                            detail.ReturnCount = int.Parse(rows[i]["ReturnCount"].ToString());
                            returnGoods.Details.Add(detail);
                        }
                        var returnAmount = returnGoods.Details.Sum(item => item.ReturnAmount).ToString();
                        bool hasError = false;
                        string msg = null;
                        int payTypeCode = int.Parse(PosRow["PayType"].ToString());
                        var refoundAmount = returnGoods.Details.Sum(item => item.ReturnAmount).ToString();
                        //if (payTypeCode == (int)PayMentType.Alipay)
                        //{
                        //    IAlipayTradeService services = AlipayServices.CreateServiceClient();
                        //    AlipayF2FQueryResult queryResult = services.tradeQuery(PosRow["TicketCode"].ToString());
                        //    AlipayTradeQueryResponse response = queryResult.response;
                        //    if (response.TradeStatus.ToUpper() == "TRADE_CLOSED")
                        //    {
                        //        ShowMessage($"支付宝订单为关闭状态，无法退款，请走人工方式！");
                        //        return;
                        //    }
                        //    if (response.TradeStatus.ToUpper() == "TRADE_SUCCESS")
                        //    {
                        //        var refoundContent = new AlipayTradeRefundContentBuilder();
                        //        refoundContent.refund_reason = txtDescription.Text.Trim();
                        //        refoundContent.out_trade_no = PosRow["TicketCode"].ToString();
                        //        refoundContent.refund_amount = refoundAmount;
                        //        refoundContent.out_request_no = PosRow["PayOrderNo"].ToString();
                        //        AlipayF2FRefundResult refoundResult = services.tradeRefund(refoundContent);
                        //        switch (refoundResult.Status)
                        //        {
                        //            case Com.Alipay.Model.ResultEnum.SUCCESS:
                        //                msg = $"支付宝退款成功，退款金额：{refoundResult.response.RefundFee}";
                        //                break;
                        //            case Com.Alipay.Model.ResultEnum.FAILED:
                        //            case Com.Alipay.Model.ResultEnum.UNKNOWN:
                        //                msg = $"支付宝退款失败,失败原因：{refoundResult.response.SubMsg}";
                        //                hasError = true;
                        //                break;
                        //            default:
                        //                break;
                        //        }
                        //    }
                        //}
                        //else if (payTypeCode == (int)PayMentType.WeChat)
                        //{
                        //    int successCode = 0;
                        //    var res = MicroPay.Query(PosRow["TicketCode"].ToString(), out successCode);
                        //    decimal _goodsAmount = decimal.Parse(PosRow["GoodsAmount"].ToString()) * 100;
                        //    decimal _refoundAmount = decimal.Parse(refoundAmount) * 100;
                        //    string refoundResult = Refund.Run(PosRow["PayOrderNo"].ToString(), PosRow["TicketCode"].ToString(), 1.ToString(), 1.ToString());
                        //    //string refoundResult=Refund.Run(PosRow["PayOrderNo"].ToString(), PosRow["TicketCode"].ToString(), _goodsAmount.ToString(), _refoundAmount.ToString());

                        //}
                        if (!hasError)
                        {
                            var result = PosBLL.instance.SubmitRetunGoods(returnGoods);
                            if (result)
                            {
                                List<ReturnGoodsDetail> returnGoodsDetails = returnGoods.Details;

                                ShowMessage(msg ?? $"退款成功,退款金额：{returnAmount}");
                                Clear();
                            }
                        }
                    }
                }
                else
                {
                    ShowMessage("请修改列表中需退货商品的数量", "系统提示");
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtTicketCode_EditValueChanged(object sender, EventArgs e)
        {
            this.BindDataSource();
        }
        private void Clear()
        {
            PosRow = null;
            labelReturnCount.Text = "0";
            labelReturnAmount.Text = "0.00";
            txtBarID.Text = "";
            txtDescription.Text = "";
            gridControlReturnGoods.DataSource = null;
        }
        private void BindDataSource()
        {
            var agrs = new Model.SaleQueryAgrs();
            agrs.TicketCode = txtTicketCode.Text;
            agrs.StoreID = UserInfo.Instance.StoreID;
            agrs.RecordStatus = 0;
            var result = sale.SaleListQuery(agrs);

            if (result.Rows.Count == 1)
            {
                PosRow = result.Rows[0];
                agrs.PosID = new Guid(result.Rows[0]["ID"].ToString());
                txtGuider.Text = result.Rows[0]["Guider"].ToString();

                labelLS.Text = result.Rows[0]["RecordSerial"].ToString();
                labelLS.Tag = result.Rows[0]["TicketCode"];
                labelSaleDate.Text = result.Rows[0]["SaleDate"].ToString();
                labelPaytype.Text = result.Rows[0]["PayTypeName"].ToString();
                labelPaytype.Tag = result.Rows[0]["PayType"];
                labelGuider.Text = result.Rows[0]["Guider"].ToString();
                labelGuider.Tag = result.Rows[0]["GuiderID"];

                if (!string.IsNullOrEmpty(txtBarID.Text))
                {
                    agrs.BarID = txtBarID.Text;
                }

                var data = sale.SaleDetailQuery(agrs);

                data.Columns.Add(new DataColumn() { Caption = "退货金额", ColumnName = "ReturnAmount", DefaultValue = 0.00, DataType = typeof(double) });
                gridControlReturnGoods.DataSource = data;
            }
            else
            {
                XtraMessageBox.Show("您输入的小票不可进行退货操作!", "系统提示", MessageBoxButtons.OK);
                txtTicketCode.Text = string.Empty;
                txtTicketCode.Focus();
            }
        }

        private void RepositoryItem_EditValueChanged(object sender, EventArgs e)
        {
            var textEdit = sender as DevExpress.XtraEditors.SpinEdit;
            var count = int.Parse(textEdit.EditValue.ToString());
            var maxCount = (int)gridViewReturnGoods.GetFocusedDataRow()["GoodsCount"];
            if (count > maxCount)
            {
                XtraMessageBox.Show("超过最大可退货商品数量!", "系统提示", MessageBoxButtons.OK);
                textEdit.EditValue = maxCount;
            }
        }

        private void gridViewReturnGoods_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                var focus_row = e.Row as DataRowView;
                if (focus_row != null)
                {
                    var retailPrice = double.Parse(focus_row.Row["RetailPrice"].ToString());
                    var returnCount = int.Parse(focus_row.Row["ReturnCount"].ToString());
                    focus_row.Row["ReturnAmount"] = returnCount * retailPrice;
                }

                DataTable sourceTable = gridControlReturnGoods.DataSource as DataTable;
                if (sourceTable != null)
                {
                    var sumCount = sourceTable.Compute("Sum(ReturnCount)", "");
                    var sumMoney = sourceTable.Compute("Sum(ReturnAmount)", "");
                    labelReturnAmount.Text = sumMoney.ToString();
                    labelReturnCount.Text = sumCount.ToString();
                }
            }
        }

        private void txtBarID_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTicketCode.Text))
            {
                XtraMessageBox.Show("未输入退货小票不可进行退货操作!", "系统提示", MessageBoxButtons.OK);
                txtTicketCode.Focus();
                return;
            }
            this.BindDataSource();
        }

        private void txtTicketCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                BindDataSource();
            }
        }

        private void txtBarID_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtTicketCode_KeyPress(sender, e);
        }


        public DataRow PosRow
        {
            get;
            set;
        }
    }
}
