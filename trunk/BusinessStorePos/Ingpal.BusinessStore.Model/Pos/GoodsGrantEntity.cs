using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingpal.BusinessStore.Model
{
    /// <summary>
    /// 商品授权
    /// </summary>
    [Table(TableName = "GoodsGrant")]
    public class GoodsGrantEntity
    {
       [Table(PrimaryKey =true,AutoIncrement =true)]
        public int ID {
            get;
            set;
        }
        [Table(ColumnName = "商品条码")]
        public string BartID { get; set; }
        [Table(ColumnName = "ERP编码")]
        public string OuterBarID { get; set; }
        [Table(ColumnName = "商品名称")]
        public string GoodsName { get; set; }
        [Table(ColumnName = "门店编号")]
        public int StoreID { get; set; }


        [Table(ColumnName = "授权标志")]
        /// <summary>
        /// 是否授权
        /// </summary>
        public bool IsGrant { get; set; }

        public decimal DiscountPrice { get; set; } = 0.00m;
        public decimal GroupPrice { get; set; } = 0.00m;
        public decimal ExchangePrice { get; set; } = 0.00m;
        public bool IsAllowDiscount { get; set; }
        public bool IsAllowGroup { get; set; }
        public bool IsAllowExchange { get; set; }
    }
    /// <summary>
    /// 授权商品信息
    /// </summary>

    public class GoodsGrantExt : GoodsBaseEntity
    {
        [Table(ColumnName ="授权标志")]
        /// <summary>
        /// 是否授权
        /// </summary>
        public bool IsGrant { get; set; }
        [Table(ColumnName = "是否授权")]
        public string IsGrantText {
            get {
                return IsGrant ? "√" : "×";
            }
        }
        public decimal DiscountPrice { get; set; } = 0.00m; 
        public decimal GroupPrice { get; set; } = 0.00m;
        public decimal ExchangePrice { get; set; } = 0.00m;
        public bool IsAllowGroup { get; set; }
        public bool IsAllowDiscount { get; set; }
        public bool IsAllowExchange { get; set; }
        public string StoreID { get; set; }
        public string StockQuantity { get; set; }

    }
}
