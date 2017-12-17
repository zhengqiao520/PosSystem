using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingpal.BusinessStore.Model
{
    /// <summary>
    /// 销售查询实体
    /// </summary>
    public class SaleQueryAgrs
    {
        /// <summary>
        /// 销售记录ID
        /// </summary>
        public Guid? PosID { get; set; }

        /// <summary>
        /// 门店编号
        /// </summary>
        public int? StoreID { get; set; }

        /// <summary>
        /// 小票编号
        /// </summary>
        public string TicketCode { get; set; }

        /// <summary>
        /// 销售开始时间
        /// </summary>
        public DateTime? SaleStartTime { get; set; }

        /// <summary>
        /// 销售结束时间
        /// </summary>
        public DateTime? SaleEndTime { get; set; }

        /// <summary>
        /// 订单状态
        /// </summary>
        public int? RecordStatus { get; set; }

        /// <summary>
        /// 条码
        /// </summary>
        public string BarID { get; set; }
    }

    public class SaleQueryEntity : SaleQueryAgrs
    {
        public string TicketCode { get; set; }
        public string RecordStatus { get; set; }
        public string Guider { get; set; }
        public string PayType { get; set; }
        public string Category { get; set; }

        public string GoodsName { get; set; }
    }
}
