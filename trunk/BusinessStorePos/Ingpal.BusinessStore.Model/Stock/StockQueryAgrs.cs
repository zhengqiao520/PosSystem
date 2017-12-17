using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingpal.BusinessStore.Model
{
    /// <summary>
    /// 库存查询
    /// </summary>
    public class StockQueryAgrs
    {
        /// <summary>
        /// 门店ID
        /// </summary>
        public int? StoreID { get; set; }
        
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

        public string Category {
            get;set;
        }

    }
}