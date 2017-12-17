using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingpal.BusinessStore.Model
{
    /// <summary>
    /// 盘点数据更新
    /// </summary>
    public class UpdateStockTakingAgrs
    {
        /// <summary>
        /// 盘点记录ID
        /// </summary>
        public Guid StockTakingID { get; set; }

        /// <summary>
        /// 盘点数量
        /// </summary>
        public double InventoryQty { get; set; }

        /// <summary>
        /// 差异数量
        /// </summary>
        public int DifferenceQty { get; set; }

        /// <summary>
        /// 差异金额
        /// </summary>
        public int DiffAmount { get; set; }

    }
}
