using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingpal.BusinessStore.Model
{
    /// <summary>
    /// 盘点记录查询
    /// </summary>
    public class StockTakingMasterQueryAgrs
    {
        /// <summary>
        /// 开始盘点时间
        /// </summary>
        public DateTime? StartTime { get; set; }

        /// <summary>
        /// 结束盘点时间
        /// </summary>
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// 收银员用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 盘点编号
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 盘点状态
        /// </summary>
        public int? Status { get; set; }

        /// <summary>
        /// 门店ID
        /// </summary>
        public int? StoreID { get; set; }

    }
}
