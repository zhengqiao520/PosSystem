using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingpal.BusinessStore.Model
{
    public class SummarySale
    {

        /// <summary>
        /// -1退货，1：正常销售，0：挂单
        /// </summary>
        public Guid Id
        {
            get;
            set;
        }
        [Table(ColumnName ="小票号")]
        /// <summary>
        /// 小票号
        /// </summary>
        public string TicketCode
        {
            get;
            set;
        }
        [Table(ColumnName = "门店编号")]
        /// <summary>
        /// 门店编号
        /// </summary>
        public int? StoreID
        {
            get;
            set;
        }
        [Table(ColumnName = "门店名称")]
        /// <summary>
        /// 门店名称
        /// </summary>
        public string StoreName
        {
            get;
            set;
        }
        [Table(ColumnName = "销售数量")]
        /// <summary>
        /// 合计数量
        /// </summary>
        public int TotalCount
        {
            get;
            set;
        }
        [Table(ColumnName = "合计金额")]
        /// <summary>
        /// 合计金额
        /// </summary>
        public decimal TotalAmount
        {
            get;
            set;
        }
        [Table(ColumnName = "折扣金额")]
        /// <summary>
        /// 折扣金额
        /// </summary>
        public decimal DiscountAmount
        {
            get;
            set;
        }
        [Table(ColumnName = "商品金额")]
        /// <summary>
        /// 商品金额
        /// </summary>
        public decimal GoodsAmount
        {
            get;
            set;
        }
        [Table(ColumnName = "实收金额")]
        /// <summary>
        /// 实收金额
        /// </summary>
        public decimal ActualAmount
        {
            get;
            set;
        }
        [Table(ColumnName = "销售日期")]
        /// <summary>
        /// 销售日期
        /// </summary>
        public DateTime? SaleDate
        {
            get;
            set;
        }
        [Table(ColumnName = "支付方式")]
        /// <summary>
        /// 支付方式
        /// </summary>
        public string PayType
        {
            get;
            set;
        }
        [Table(ColumnName = "收银员")]
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
        [Table(ColumnName = "导购")]
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
        [Table(ColumnName = "退款金额")]
        /// <summary>
        /// 退款金额
        /// </summary>
        public decimal RefundAmount
        {
            get;
            set;
        }
        [Table(ColumnName = "退货数量")]
        /// <summary>
        /// 退货数量
        /// </summary>
        public string ReturnGoodsCount {
            get;
            set;
        }
    }

    public class SummerSaleList {

        [Table(ColumnName = "流水号")]
        public string TicketCode
        {
            get;
            set;
        }
        [Table(ColumnName = "门店编号")]
        /// <summary>
        /// 门店编号
        /// </summary>
        public string StoreID
        {
            get;
            set;
        }
        [Table(ColumnName = "门店名称")]
        /// <summary>
        /// 门店名称
        /// </summary>
        public string StoreName
        {
            get;
            set;
        }
        [Table(ColumnName = "商品名称")]
        /// <summary>
        /// 商品名称
        /// </summary>
        public string GoodsName
        {
            get;
            set;
        }
        [Table(ColumnName = "商品分类ID")]
        /// <summary>
        /// 商品分类
        /// </summary>
        public string GoodsCategoryID
        {
            get;
            set;
        }
        [Table(ColumnName = "商品分类")]
        /// <summary>
        /// 商品分类
        /// </summary>
        public string GoodsCategory
        {
            get;
            set;
        }
        [Table(ColumnName = "销售单价")]
        /// <summary>
        /// 销售单价
        /// </summary>
        public string RetailPrice
        {
            get;
            set;
        }
        [Table(ColumnName = "销售数量")]
        /// <summary>
        /// 合计数量
        /// </summary>
        public int GoodsCount
        {
            get;
            set;
        }
        [Table(ColumnName = "折扣金额")]
        /// <summary>
        /// 折扣金额
        /// </summary>
        public decimal DiscountAmount
        {
            get;
            set;
        }
        [Table(ColumnName = "商品金额")]
        /// <summary>
        /// 商品金额
        /// </summary>
        public decimal GoodsAmount
        {
            get;
            set;
        }
        /// <summary>
        /// 收银员id
        /// </summary>
        public string CashierID
        {
            get;
            set;
        }
        [Table(ColumnName = "导购")]
        /// <summary>
        /// 导购
        /// </summary>
        public string Guider
        {
            get;
            set;
        }
        [Table(ColumnName = "记录状态")]
        public int? RecordStatus
        {
            get;
            set;
        }
        [Table(ColumnName = "退货数量")]
        /// <summary>
        /// 退货数量
        /// </summary>
        public string ReturnCount
        {
            get;
            set;
        }
        [Table(ColumnName = "退货金额")]
        /// <summary>
        /// 退货金额
        /// </summary>
        public string ReturnAmount
        {
            get;
            set;
        }

        /// <summary>
        /// 导购
        /// </summary>
        public string GuiderID
        {
            get;
            set;
        }
        [Table(ColumnName = "销售日期")]
        /// <summary>
        /// 销售日期
        /// </summary>
        public string SaleDate
        {
            get;
            set;
        }
    }
}
