using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingpal.BusinessStore.Model
{
    /// <summary>
    /// 盘点参数
    /// </summary>
    public class StockTakingAgrs
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public Guid UserID { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 门店名称
        /// </summary>
        public string StoreName { get; set; }

        /// <summary>
        /// 门店ID
        /// </summary>
        public int StoreID { get; set; }

        /// <summary>
        /// 盘点记录ID
        /// </summary>
        public Guid ID { get; set; }
    }
}
