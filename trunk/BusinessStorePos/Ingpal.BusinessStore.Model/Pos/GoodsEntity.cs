using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingpal.BusinessStore.Model
{
        //Goods
        [Serializable]
        [Table(TableName = "Goods")]
        public class GoodsEntity
        {

            /// <summary>
            /// ID
            /// </summary>		
            public Guid ID
            {
                get;
                set;
            }
           [Table(ColumnName = "门店编号")]
            /// <summary>
            /// 门店编号
            /// </summary>		
            public int StoreID
            {
                get;
                set;
            }
        [Table(ColumnName = "商品条码")]
        /// <summary>
        /// 条码
        /// </summary>		
        public string BarID
            {
                get;
                set;
            }
        [Table(ColumnName = "商品名称")]
            /// <summary>
            /// 商品名称
            /// </summary>		
           public string Name
            {
                get;
                set;
            }
        [Table(ColumnName = "商品简写")]
        /// <summary>
        /// 商品简写
        /// </summary>		
        public string NameAbbr
            {
                get;
                set;
            }
            /// <summary>
            /// 规格
            /// </summary>		
            public string SPEC
            {
                get;
                set;
            }
            /// <summary>
            /// 型号
            /// </summary>		
            public string ModelNumber
            {
                get;
                set;
            }
        [Table(ColumnName = "商品类别编号")]
        /// <summary>
        /// 类别
        /// </summary>		
        public int CategoryID
        {
            get;
            set;
        }
        [Table(ColumnName = "商品类别")]
        /// <summary>
        /// 类别
        /// </summary>		
        public string Category
            {
                get;
                set;
            }
            /// <summary>
            /// 货号
            /// </summary>		
            public string CodeNumber
            {
                get;
                set;
            }
            /// <summary>
            /// 生产批号
            /// </summary>		
            public string BatchNo
            {
                get;
                set;
            }
        [Table(ColumnName = "单位")]
        /// <summary>
        /// 单位
        /// </summary>		
        public string Unit
            {
                get;
                set;
            }
            /// <summary>
            /// 供应商
            /// </summary>		
            public string Supplier
            {
                get;
                set;
            }
            /// <summary>
            /// 进价/成本价
            /// </summary>		
            public decimal BuyingPrice
            {
                get;
                set;
            }
           [Table(ColumnName = "零售价")]
           /// <summary>
        /// 零售价
        /// </summary>		
           public decimal RetailPrice
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
            /// 入库数量
            /// </summary>		
            public int InQuantityStock
            {
                get;
                set;
            }
            /// <summary>
            /// 入库金额
            /// </summary>		
            public decimal InstockAmount
            {
                get;
                set;
            }
            /// <summary>
            /// 出库数量
            /// </summary>		
            public int OutQuantityStock
            {
                get;
                set;
            }
            /// <summary>
            /// 出库金额
            /// </summary>		
            public decimal OutstockAmount
            {
                get;
                set;
            }
        [Table(ColumnName = "销售数量")]
        /// <summary>
        /// 销售数量
        /// </summary>		
        public int SaleQuantity
            {
                get;
                set;
            }
        [Table(ColumnName = "销售金额")]
        /// <summary>
        /// 销售金额
        /// </summary>		
        public decimal SaleAmount
            {
                get;
                set;
            }
            /// <summary>
            /// Profit
            /// </summary>		
            public decimal Profit
            {
                get;
                set;
            }
        [Table(ColumnName = "库存数量")]
        /// <summary>
        /// 库存数量
        /// </summary>		
        public int StockQuantity
            {
                get;
                set;
            }
            /// <summary>
            /// 会员价
            /// </summary>		
            public decimal MemberPrice
            {
                get;
                set;
            }
            /// <summary>
            /// 是否允许参与积分
            /// </summary>		
            public bool AllowMemberScore
            {
                get;
                set;
            }
            /// <summary>
            /// 消费数量积分规则（消费几元集多少积分）
            /// </summary>		
            public decimal MemberScoreCount
            {
                get;
                set;
            }
            /// <summary>
            /// 消费数量积分规则（消费几元集多少积分）
            /// </summary>		
            public decimal MemberScorePrice
            {
                get;
                set;
            }
            /// <summary>
            /// 是否允许打折 0:不允许，1：允许
            /// </summary>		
            public bool AllowDiscount
            {
                get;
                set;
            }
            /// <summary>
            /// 生产日期
            /// </summary>		
            public DateTime? ProductionDate
            {
                get;
                set;
            }
            /// <summary>
            /// 产地
            /// </summary>		
            public string ProductionPlace
            {
                get;
                set;
            }
        [Table(ColumnName = "预警数量")]
        /// <summary>
        /// 库存预警数量
        /// </summary>		
        public int AlarmAmount
            {
                get;
                set;
            }
            /// <summary>
            /// 状态信息
            /// </summary>		
            public int RecordStatus
            {
                get;
                set;
            }
            /// <summary>
            /// 备注信息
            /// </summary>		
            public string Remark
            {
                get;
                set;
            }

            /// <summary>
            /// 图片名称
            /// </summary>
            public string ImageName { get; set; }

           [Table(Ignor =true)]
           public string OutBarID { get; set; }
    }

    public class GoodsEntityExtend : GoodsEntity
    {
        public Image Image { get; set; }
    }

    public class GoodsStockExtend : GoodsEntity
    {
        public string StoreName { get; set; }
    }
}
