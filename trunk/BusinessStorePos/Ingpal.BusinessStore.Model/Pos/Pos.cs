namespace Ingpal.BusinessStore.Model.Entity
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    //Pos
    [Serializable]
    [Table(TableName = "Pos")]

    public class PosEntity
    {

        /// <summary>
        /// -1退货，1：正常销售，0：挂单
        /// </summary>		
        public Guid Id
        {
            get;
            set;
        }
        /// <summary>
        /// 流水号
        /// </summary>		
        public string RecordSerial
        {
            get;
            set;
        }
        /// <summary>
        /// 小票号
        /// </summary>		
        public string TicketCode
        {
            get;
            set;
        }
        /// <summary>
        /// 门店编号
        /// </summary>		
        public int? StoreID
        {
            get;
            set;
        }
        /// <summary>
        /// 合计数量
        /// </summary>		
        public int TotalCount
        {
            get;
            set;
        }
        /// <summary>
        /// 合计金额
        /// </summary>		
        public decimal TotalAmount
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
        /// 商品金额
        /// </summary>		
        public decimal GoodsAmount
        {
            get;
            set;
        }
        /// <summary>
        /// 实收金额
        /// </summary>		
        public decimal ActualAmount
        {
            get;
            set;
        }
        /// <summary>
        /// 利润
        /// </summary>		
        public decimal TotalProfit
        {
            get;
            set;
        }
        /// <summary>
        /// 抹零
        /// </summary>		
        public decimal ChangeClear
        {
            get;
            set;
        }
        /// <summary>
        /// 找零金额
        /// </summary>		
        public decimal ChangeAmount
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
        /// <summary>
        /// 会员guid
        /// </summary>		
        public string MemberGuid
        {
            get;
            set;
        }
        /// <summary>
        /// 消费积分
        /// </summary>		
        public int BonusPoints
        {
            get;
            set;
        }
        /// <summary>
        /// 支付方式
        /// </summary>		
        public int PayType
        {
            get;
            set;
        }
        /// <summary>
        /// 收银员
        /// </summary>		
        public string Cashier
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
        /// 导购
        /// </summary>		
        public string Guider
        {
            get;
            set;
        }
        /// <summary>
        /// 导购
        /// </summary>		
        public Guid GuiderID
        {
            get;
            set;
        }
        /// <summary>
        /// 支付平台订单号
        /// </summary>
        public string PayOrderNo {
            get;set;
        }
        /// <summary>
        /// 记录状态 0：正常订单，1：挂单，-1作废
        /// </summary>		
        public int RecordStatus
        {
            get;
            set;
        }
        /// <summary>
        /// 备注
        /// </summary>		
        public string Remark
        {
            get;
            set;
        }

    }

    [Serializable]
    [Table(TableName = "PosDetail")]
    public class PosDetailEntity
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
        public string GoodsName
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
        /// 商品编号
        /// </summary>		
        public Guid GoodsID
        {
            get;
            set;
        }
        /// <summary>
        /// 商品类别编码
        /// </summary>		
        public int GoodsCategoryID
        {
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

    public class PosExt : GoodsEntity
    {
        /// <summary>
        /// 销售数量
        /// </summary>
        public int PosSalesCount { get; set; } = 0;
        /// <summary>
        /// 销售金额
        /// </summary>
        public decimal PosSalesAmount { get; set; } = 0.00m;
        /// <summary>
        /// 折扣金额
        /// </summary>
        public decimal PosDiscountAmount { get; set; } = 0.00m;

        public decimal PosDiscountPrice { get; set; }


    }

    public class PosSaleExtend: PosEntity
    {
        public string StoreName { get; set; }
    }
}

