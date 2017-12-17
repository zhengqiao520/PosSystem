using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingpal.BusinessStore.Model
{
    /// <summary>
    /// 提交交班记录参数
    /// </summary>
    public class SettlementAgrs
    {
        /// <summary>
        /// 支付宝收款金额
        /// </summary>
        public double AliPayAmount { get; set; }

        /// <summary>
        /// 微信支付收款金额
        /// </summary>
        public double WeixinPayAmount { get; set; }

        /// <summary>
        /// 银行卡收款金额
        /// </summary>
        public double BankCardAmount { get; set; }

        /// <summary>
        /// 收银员ID
        /// </summary>
        public Guid CashierID { get; set; }

        /// <summary>
        /// 收银员名称
        /// </summary>
        public string CashierName { get; set; }

        /// <summary>
        /// 现金收款金额
        /// </summary>
        public double CrashAmount { get; set; }

        /// <summary>
        /// 商场代收款金额
        /// </summary>
        public double MarketAmount { get; set; }

        /// <summary>
        /// 交班时间
        /// </summary>
        public DateTime OffDutyDateTime { get; set; }

        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime OperationDate { get; set; }

        /// <summary>
        /// 备用金
        /// </summary>
        public double PettyCash { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remarks { get; set; }

        /// <summary>
        /// 销售金额
        /// </summary>
        public double SalesAmount { get; set; }

        /// <summary>
        /// 销售数量
        /// </summary>
        public int SalesCount { get; set; }

        /// <summary>
        /// 退货金额
        /// </summary>
        public double SalesReturnAmount { get; set; }

        /// <summary>
        /// 退货数量
        /// </summary>
        public int SalesReturnCount { get; set; }

        /// <summary>
        /// 退货小票数量
        /// </summary>
        public int SalesReturnTickets { get; set; }

        /// <summary>
        /// 销售小票数量
        /// </summary>
        public int SalesTicketsCount { get; set; }

        /// <summary>
        /// 开始上班时间
        /// </summary>
        public DateTime StartDutyDateTime { get; set; }

        /// <summary>
        /// 入库金额
        /// </summary>
        public double StockInAmount { get; set; }

        /// <summary>
        /// 入库数量
        /// </summary>
        public int StockInCount { get; set; }

        /// <summary>
        /// 出库金额
        /// </summary>
        public double StockOutAmount { get; set; }

        /// <summary>
        /// 出库数量
        /// </summary>
        public int StockOutCount { get; set; }

        /// <summary>
        /// 门店ID
        /// </summary>
        public int StoreID { get; set; }

        /// <summary>
        /// 折扣金额
        /// </summary>
        public double SalesDiscountAmount { get; set; }
    }
}
