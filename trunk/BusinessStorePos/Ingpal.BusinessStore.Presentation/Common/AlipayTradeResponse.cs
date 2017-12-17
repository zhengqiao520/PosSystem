using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingpal.BusinessStore.Presentation.Common
{
    /// <summary>
    /// 支付宝条码支付交易响应
    /// </summary>
    public class AlipayTradeResponse
    {
        /// <summary>
        /// 支付宝交易查询响应参数
        /// </summary>
        public AlipayTradeQueryResponse alipay_trade_query_response { get; set; }
    }

    /// <summary>
    /// 支付宝参数响应
    /// </summary>
    public class AlipayTradeQueryResponse
    {
        public string code { get; set; }

        public string msg { get; set; }

        public string buyer_logon_id { get; set; }

        public string buyer_pay_amount { get; set; }

        public string buyer_user_id { get; set; }

        public List<AlipayTradeFundBill> fund_bill_list{ get; set; }

        public string invoice_amount { get; set; }

        public string open_id { get; set; }

        public string out_trade_no { get; set; }

        public string point_amount { get; set; }

        public string receipt_amount { get; set; }

        public string total_amount { get; set; }

        public string trade_no { get; set; }

        public string trade_status { get; set; }
    }

    public class AlipayTradeFundBill
    {
        public string amount { get; set; }

        public string fund_channel { get; set; }
    }

}
