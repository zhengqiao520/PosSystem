

namespace Ingpal.BusinessStore.Model
{
    using System;
    [Serializable]
    [Table(TableName = "RestPosDetail")]
    public class RestPosDetailEntity
    {

        /// <summary>
        /// ID
        /// </summary>		
        public Guid ID
        {
            get;
            set;
        }
        /// <summary>
        /// pos表主键
        /// </summary>		
        public Guid PosID
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
        /// 门店id
        /// </summary>		
        public int StoreID
        {
            get;
            set;
        }
        /// <summary>
        /// 零售价（单价）
        /// </summary>		
        public decimal RetailPrice
        {
            get;
            set;
        }
        /// <summary>
        /// 数量
        /// </summary>		
        public int GoodsCount
        {
            get;
            set;
        }
        /// <summary>
        /// 金额
        /// </summary>		
        public decimal GoodsAmount
        {
            get;
            set;
        }
        /// <summary>
        /// 折扣率
        /// </summary>		
        public decimal DiscountRate
        {
            get;
            set;
        }
        /// <summary>
        /// 折扣单价
        /// </summary>		
        public decimal DiscountPrice
        {
            get;
            set;
        }
        /// <summary>
        /// 折扣金额
        /// </summary>		
        public decimal DiscountAmount
        {
            get;
            set;
        }
        /// <summary>
        /// 成本价
        /// </summary>		
        public decimal BuyingPrice
        {
            get;
            set;
        }
        /// <summary>
        /// 商品利润
        /// </summary>		
        public decimal GoodsProfit
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
        /// 商品编号
        /// </summary>		
        public Guid GoodsID
        {
            get;
            set;
        }
        public int GoodsCategoryID {
            get;
            set;
        }
        /// <summary>
        /// 商品类别
        /// </summary>		
        public string GoodsCategory
        {
            get;
            set;
        }
        /// <summary>
        /// 收银员id
        /// </summary>		
        public Guid CashierID
        {
            get;
            set;
        }
        /// <summary>
        /// 销售日期
        /// </summary>		
        public DateTime SaleDate
        {
            get;
            set;
        }

    }
}
