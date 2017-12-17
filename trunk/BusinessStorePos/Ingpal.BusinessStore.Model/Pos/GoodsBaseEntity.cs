using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingpal.BusinessStore.Model
{
    /// <summary>
    ///
    /// </summary>
    ///
    [Table(TableName = "GoodsBase")]
    public class GoodsBaseEntity
    {
        [Table(PrimaryKey = true)]
        /// <summary>
        /// ID
        /// </summary>
        public Guid ID
        {
            get;
            set;
        }
        [Table(ColumnName ="商品条码")]
        /// <summary>
        /// BarID
        /// </summary>
        public string BarID
        {
            get;
            set;
        }
        [Table(ColumnName = "ERP编码")]
        /// <summary>
        /// 外部编号
        /// </summary>
        public string OuterBarID
        {
            get;
            set;
        }
        [Table(ColumnName = "商品名称")]
        /// <summary>
        /// Name
        /// </summary>
        public string Name
        {
            get;
            set;
        }
        /// <summary>
        /// NameAbbr
        /// </summary>
        public string NameAbbr
        {
            get;
            set;
        }
        /// <summary>
        /// SPEC
        /// </summary>
        public string SPEC
        {
            get;
            set;
        }
        /// <summary>
        /// ModelNumber
        /// </summary>
        public string ModelNumber
        {
            get;
            set;
        }
        [Table(ColumnName = "分类ID")]
        /// <summary>
        /// CategoryID
        /// </summary>
        public int CategoryID
        {
            get;
            set;
        }
        [Table(ColumnName = "分类名称")]
        /// <summary>
        /// Category
        /// </summary>
        public string Category
        {
            get;
            set;
        }
        /// <summary>
        /// CodeNumber
        /// </summary>
        public string CodeNumber
        {
            get;
            set;
        }
        /// <summary>
        /// BatchNo
        /// </summary>
        public string BatchNo
        {
            get;
            set;
        }
        [Table(ColumnName = "单位")]
        /// <summary>
        /// Unit
        /// </summary>
        public string Unit
        {
            get;
            set;
        }
        [Table(ColumnName = "供应商")]
        /// <summary>
        /// Supplier
        /// </summary>
        public string Supplier
        {
            get;
            set;
        }
        [Table(ColumnName = "成本价")]
        /// <summary>
        /// BuyingPrice
        /// </summary>
        public decimal BuyingPrice
        {
            get;
            set;
        }
        [Table(ColumnName = "零售价")]
        /// <summary>
        /// RetailPrice
        /// </summary>
        public virtual decimal RetailPrice
        {
            get;
            set;
        }
        /// <summary>
        /// MemberPrice
        /// </summary>
        public decimal MemberPrice
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
        /// RecordStatus
        /// </summary>
        public int RecordStatus
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
        /// <summary>
        /// ImageName
        /// </summary>
        public string ImageName
        {
            get;
            set;
        }
    }

    /// <summary>
    /// 商品更新参数
    /// </summary>
    public class GoodsBaseUpdateModel
    {
        public string BarID { get; set; }
        public string GoodsBaseGuid { get; set; }
        public string CategoryID { get; set; }
        public string RetailPrice { get; set; }
    }

    /// <summary>
    /// 商品更新模型
    /// </summary>
    public class GoodsBaseUpdateEntity
    {
        public Guid GoodsBaseGuid { get; set; }
        public string BarID { get; set; }
        public int CategoryID { get; set; }
        public string Category { get; set; }
        public decimal RetailPrice { get; set; }
    }
}