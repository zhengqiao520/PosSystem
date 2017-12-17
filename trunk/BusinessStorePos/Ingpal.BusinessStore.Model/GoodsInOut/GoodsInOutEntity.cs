using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingpal.BusinessStore.Model
{
    [Serializable]
    [Table(TableName ="GoodsIn")]
    public class GoodsInEntity
    {
        [Table(PrimaryKey = true)]
        /// <summary>
        /// ID
        /// </summary>		
        public string ID
        {
            get;
            set;
        }
        /// <summary>
        /// StoreID
        /// </summary>		
        public int StoreID
        {
            get;
            set;
        }
        /// <summary>
        /// 条码
        /// </summary>		
        public string BarID
        {
            get;
            set;
        }
        /// <summary>
        /// 商品guid
        /// </summary>		
        public Guid GoodsID
        {
            get;
            set;
        }
        /// <summary>
        /// GoodsName
        /// </summary>		
        public string GoodsName
        {
            get;
            set;
        }
        /// <summary>
        /// StockInCount
        /// </summary>		
        public int StockInCount
        {
            get;
            set;
        }
        /// <summary>
        /// 调拨入库日期
        /// </summary>		
        public DateTime StockInDate
        {
            get;
            set;
        }
        /// <summary>
        /// StockOutAmount
        /// </summary>		
        public decimal StockInAmount
        {
            get;
            set;
        }
        /// <summary>
        /// 进价
        /// </summary>		
        public decimal BuyingPrice
        {
            get;
            set;
        }
        /// <summary>
        /// 零售价
        /// </summary>		
        public decimal RetailPrice
        {
            get;
            set;
        }
        /// <summary>
        /// ProductionDate
        /// </summary>		
        public DateTime ProductionDate
        {
            get;
            set;
        }
        /// <summary>
        /// ProductionPlace
        /// </summary>		
        public string ProductionPlace
        {
            get;
            set;
        }
        /// <summary>
        /// Supplier
        /// </summary>		
        public string Supplier
        {
            get;
            set;
        }
        /// <summary>
        /// Remark
        /// </summary>		
        public string Remark
        {
            get;
            set;
        }
    }
    [Table(TableName = "GoodsOut")]
    public class GoodsOutEntity
    {

        [Table(PrimaryKey = true)]
        /// <summary>
        /// ID
        /// </summary>		
        public string ID
        {
            get;
            set;
        }
        /// <summary>
        /// StoreID
        /// </summary>		
        public int StoreID
        {
            get;
            set;
        }
        /// <summary>
        /// BarID
        /// </summary>		
        public string BarID
        {
            get;
            set;
        }
        /// <summary>
        /// GoodsID
        /// </summary>		
        public Guid GoodsID
        {
            get;
            set;
        }
        /// <summary>
        /// GoodsName
        /// </summary>		
        public string GoodsName
        {
            get;
            set;
        }
        /// <summary>
        /// StockOutCount
        /// </summary>		
        public int StockOutCount
        {
            get;
            set;
        }
        /// <summary>
        /// StockOutDate
        /// </summary>		
        public DateTime StockOutDate
        {
            get;
            set;
        }
        /// <summary>
        /// StockOutAmount
        /// </summary>		
        public decimal StockOutAmount
        {
            get;
            set;
        }
        /// <summary>
        /// BuyingPrice
        /// </summary>		
        public decimal BuyingPrice
        {
            get;
            set;
        }
        /// <summary>
        /// RetailPrice
        /// </summary>		
        public decimal RetailPrice
        {
            get;
            set;
        }
        /// <summary>
        /// ProductionDate
        /// </summary>		
        public DateTime ProductionDate
        {
            get;
            set;
        }
        /// <summary>
        /// ProductionPlace
        /// </summary>		
        public string ProductionPlace
        {
            get;
            set;
        }
        /// <summary>
        /// Supplier
        /// </summary>		
        public string Supplier
        {
            get;
            set;
        }
        /// <summary>
        /// Remark
        /// </summary>		
        public string Remark
        {
            get;
            set;
        }
    }
}