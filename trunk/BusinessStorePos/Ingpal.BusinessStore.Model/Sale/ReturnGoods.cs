using Ingpal.BusinessStore.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingpal.BusinessStore.Model
{
    /// <summary>
    /// 退货主记录
    /// </summary>
    public class ReturnGoods
    {
        /// <summary>
        /// 主键
        /// </summary>
        public Guid ID { get; set; }

        /// <summary>
        /// 退货流水号
        /// </summary>
        public string RecordSerial { get; set; }

        /// <summary>
        /// 销售小票号
        /// </summary>
        public string TicketCode { get; set; }

        /// <summary>
        /// 退货金额
        /// </summary>
        public double RefundAmount { get; set; }

        /// <summary>
        /// 退货数量
        /// </summary>
        public int ReturnGoodsCount { get; set; }

        /// <summary>
        /// 退款方式
        /// </summary>
        public int PayType { get; set; }

        /// <summary>
        /// 退款时间
        /// </summary>
        public DateTime RefundTime { get; set; }

        /// <summary>
        /// 退款员ID
        /// </summary>
        public Guid CashierID { get; set; }

        /// <summary>
        /// 退款员名称
        /// </summary>
        public string Cashier { get; set; }

        /// <summary>
        /// 导购员ID
        /// </summary>
        public Guid GuiderID { get; set; }

        /// <summary>
        /// 导购员名称
        /// </summary>
        public string Guider { get; set; }

        /// <summary>
        /// 退货备注
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 退货详情列表
        /// </summary>
        public List<ReturnGoodsDetail> Details { get; set; }

    }

    /// <summary>
    /// 退货详情
    /// </summary>
    public class ReturnGoodsDetail
    {
        /// <summary>
        /// 主键
        /// </summary>
        public Guid ID { get; set; }

        /// <summary>
        /// 主记录ID
        /// </summary>
        public Guid PosID { get; set; }

        /// <summary>
        /// 退货数量
        /// </summary>
        public int ReturnCount { get; set; }

        /// <summary>
        /// 退款金额小计
        /// </summary>
        public double ReturnAmount { get; set; }
    }

}
