using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingpal.BusinessStore.Model
{
    /// <summary>
    /// 盘点数据查询参数
    /// </summary>
    public class StockTakingQueryAgrs
    {
        /// <summary>
        /// 盘点记录ID
        /// </summary>
        public Guid MasterID { get; set; }

        /// <summary>
        /// 商品编码
        /// </summary>
        public string Barcode { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// 商品简写
        /// </summary>
        public string ProductNameAbbr { get; set; }

        /// <summary>
        /// 是否只显示具有盈亏的数据
        /// </summary>
        public bool OnlyDifference { get; set; }

    }
}
