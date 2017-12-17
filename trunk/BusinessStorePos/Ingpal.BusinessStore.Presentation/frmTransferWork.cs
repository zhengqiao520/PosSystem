using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Ingpal.BusinessStore.Model.Entity;
using System.Diagnostics;
using Ingpal.BusinessStore.Business;
using Ingpal.BusinessStore.Model;

namespace Ingpal.BusinessStore.Presentation
{
    public partial class frmTransferWork : BaseForm
    {


        public frmTransferWork()
        {
            InitializeComponent();
            this.InitControls();
          //  this.LoadWordLog();
        }

        /// <summary>
        /// 初始化控件的默认值
        /// </summary>
        private void InitControls()
        {
            dteStartDutyDate.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 00, 00, 00);
            dteOffDutyDate.DateTime = DateTime.Now;

            txtPettyCash.Text = "";

            //销售统计
            txtOrderCount.Text = "0";
            txtDisMoney.Text = "0";
            txtTotalMoney.Text = "0";
            txtProductCount.Text = "0";

            //退货退款统计
            txtReturnMoney.Text = "0";
            txtReturnOrderCount.Text = "0";
            txtReturnProductCount.Text = "0";

            //综合统计
            txtSumAlipayMoney.Text = "0";
            txtSumBankMoney.Text = "0";
            txtSumCashMoney.Text = string.Format("{0:0.00}", 0);
            txtSumMarketMoney.Text = "0";
            txtSumWeixinPayMoney.Text = "0";

            //销售汇总
            txtSumOrderCount.Text = "0";
            txtSumProductCount.Text = "0";
            txtSumTotalMoney.Text = string.Format("{0:0.00}", 0);

            this.btnSubmit.Enabled = true;
            this.btnCommit.Enabled = false;
            this.btnClose.Enabled = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close(); //usp_QueryPosSummaryByCashier
        }

        private void btnCommit_Click(object sender, EventArgs e)
        {

            SettlementAgrs agrs = new SettlementAgrs();
            agrs.StoreID = (int)UserInfo.Instance.StoreID;
            agrs.CashierID = UserInfo.Instance.ID;
            agrs.CashierName = UserInfo.Instance.Account;
            agrs.OffDutyDateTime = dteOffDutyDate.DateTime;
            agrs.StartDutyDateTime  = dteStartDutyDate.DateTime;
            agrs.SalesDiscountAmount = double.Parse(string.IsNullOrEmpty(txtDisMoney.Text) ? "0" : txtDisMoney.Text);
            agrs.SalesAmount = double.Parse(string.IsNullOrEmpty(txtTotalMoney.Text) ? "0" : txtTotalMoney.Text);
            agrs.SalesCount = int.Parse(string.IsNullOrEmpty(txtProductCount.Text) ? "0" : txtProductCount.Text);
            agrs.SalesTicketsCount = int.Parse(string.IsNullOrEmpty(txtOrderCount.Text) ? "0" : txtOrderCount.Text);
            agrs.SalesReturnCount = int.Parse(string.IsNullOrEmpty(txtReturnProductCount.Text) ? "0" : txtReturnProductCount.Text);
            agrs.SalesReturnAmount = double.Parse(string.IsNullOrEmpty(txtReturnMoney.Text) ? "0" : txtReturnMoney.Text);
            agrs.SalesReturnTickets = int.Parse(string.IsNullOrEmpty(txtReturnOrderCount.Text) ? "0" : txtReturnOrderCount.Text);
            agrs.StockInCount = 0;
            agrs.StockInAmount = 0;
            agrs.StockOutCount = 0;
            agrs.StockOutAmount = 0;
            agrs.Remarks = txtRemarks.Text.Trim();
            agrs.OperationDate = DateTime.Now;
            agrs.PettyCash = double.Parse(string.IsNullOrEmpty(txtPettyCash.Text) ? "0" : txtPettyCash.Text);
            agrs.WeixinPayAmount = double.Parse(string.IsNullOrEmpty(txtSumWeixinPayMoney.Text) ? "0" : txtSumWeixinPayMoney.Text);
            agrs.AliPayAmount = double.Parse(string.IsNullOrEmpty(txtSumAlipayMoney.Text) ? "0" : txtSumAlipayMoney.Text);
            agrs.BankCardAmount = double.Parse(string.IsNullOrEmpty(txtSumBankMoney.Text) ? "0" : txtSumBankMoney.Text);
            agrs.MarketAmount = double.Parse(string.IsNullOrEmpty(txtSumMarketMoney.Text) ? "0" : txtSumMarketMoney.Text);
            agrs.CrashAmount = double.Parse(string.IsNullOrEmpty(txtSumCashMoney.Text) ? "0" : txtSumCashMoney.Text);

            bool result = PosBLL.instance.SubmitSettlement(agrs);
            if (result)
            {
                if (XtraMessageBox.Show("交班成功,您是否要退出系统?", "系统提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Application.Exit();
                }
                else
                {
                    this.btnSubmit.Enabled = false;
                    this.btnCommit.Enabled = false;
                    this.btnClose.Enabled = false;

                    //Application.Exit();
                    //Process.Start(Application.ExecutablePath);
                }
            }


        }

        private void dteOffDutyDate_EditValueChanged(object sender, EventArgs e)
        {
           // this.LoadWordLog();
        }

        private void LoadWordLog()
        {
            var result = PosBLL.instance.QueryPosSummaryByCashier(UserInfo.Instance.UserCode, UserInfo.Instance.StoreID, dteStartDutyDate.DateTime, dteOffDutyDate.DateTime);
            var resultMoney = PosBLL.instance.QueryPayTypeMoneyByCashier(UserInfo.Instance.UserCode, UserInfo.Instance.StoreID, dteStartDutyDate.DateTime, dteOffDutyDate.DateTime);
            if (result != null && resultMoney != null)
            {
                var pettyCash = double.Parse(string.IsNullOrEmpty(txtPettyCash.Text.Trim())?"0": txtPettyCash.Text.Trim());
                var orderCount = int.Parse(result["OrderCount"].ToString());
                var disMoney = double.Parse(result["DiscountMoney"].ToString());
                var totalMoney = double.Parse(result["TotalMoney"].ToString());
                var totalCount = int.Parse(result["TotalCount"].ToString());

                var returnOrderCount = int.Parse(result["ReturnOrderCount"].ToString());
                var returnMoney = double.Parse(result["ReturnMoney"].ToString());
                var returnCount = int.Parse(result["ReturnCount"].ToString());

                var sumOrderCount = orderCount;
                var sumMoney = totalMoney;
                var sumCount = totalCount;

                var sumWeixin = double.Parse(resultMoney["WeChatMoney"].ToString());
                var sumAlipay = double.Parse(resultMoney["AlipayMoney"].ToString());
                var sumBank = double.Parse(resultMoney["BankCardMoney"].ToString());
                var sumCash = double.Parse(resultMoney["CashMoney"].ToString());
                var sumMarket = double.Parse(resultMoney["MarketMoney"].ToString());

                //销售统计
                txtOrderCount.Text = string.Format("{0}", orderCount);
                txtDisMoney.Text = string.Format("{0:0.00}", disMoney);
                txtTotalMoney.Text = string.Format("{0:0.00}", totalMoney);
                txtProductCount.Text = string.Format("{0}", totalCount);

                //退货退款统计
                txtReturnMoney.Text = string.Format("{0:0.00}", returnMoney);
                txtReturnOrderCount.Text = string.Format("{0}", returnOrderCount);
                txtReturnProductCount.Text = string.Format("{0}", returnCount);

                //综合统计
                txtSumAlipayMoney.Text = string.Format("{0:0.00}", sumAlipay);
                txtSumBankMoney.Text = string.Format("{0:0.00}", sumBank);
                txtSumCashMoney.Text = string.Format("{0:0.00}", sumCash );
                txtSumMarketMoney.Text = string.Format("{0:0.00}", sumMarket);
                txtSumWeixinPayMoney.Text = string.Format("{0:0.00}", sumWeixin);

                //销售汇总
                txtSumOrderCount.Text = string.Format("{0}", sumOrderCount);
                txtSumProductCount.Text = string.Format("{0}", sumCount);
                txtSumTotalMoney.Text = string.Format("{0:0.00}", sumMoney );
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("您确定要执行结算操作吗?", "系统提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.btnSubmit.Enabled = false;
                this.btnCommit.Enabled = true;
                this.btnClose.Enabled = true;

                this.LoadWordLog();
            }
        }
    }
}