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
            public int ID
            {
                get;
                set;
            }
            /// <summary>
            /// StoreID
            /// </summary>		
            public int? StoreID
            {
                get;
                set;
            }
            /// <summary>
            /// GoodsInCode
            /// </summary>		
            public string GoodsInCode
            {
                get;
                set;
            }
            /// <summary>
            /// GoodsInDate
            /// </summary>		
            public DateTime GoodsInDate
            {
                get;
                set;
            }
            /// <summary>
            /// GoodsInQuantity
            /// </summary>		
            public int GoodsInQuantity
            {
                get;
                set;
            }
            /// <summary>
            /// GoodsInAmount
            /// </summary>		
            public decimal GoodsInAmount
            {
                get;
                set;
            }
            /// <summary>
            /// GoodsInHumanID
            /// </summary>		
            public Guid GoodsInHumanID
            {
                get;
                set;
            }
            /// <summary>
            /// GoodsInHumanName
            /// </summary>		
            public string GoodsInHumanName
            {
                get;
                set;
            }
            public int? GoodsInType {
                get;
                set;
            }
            public string GoodsInTypeName
            {
                get;
                set;
            }
        /// <summary>
        /// Remrks
        /// </summary>		
        public string Remrks
            {
                get;
                set;
            }

    }
    [Serializable]
    [Table(TableName = "GoodsInDetail")]
    public class GoodsInDetailEntity
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
        /// <summary>
        /// GoodsInCode
        /// </summary>		
        public string GoodsInCode
        {
            get;
            set;
        }
        /// <summary>
        /// StoreID
        /// </summary>		
        public int? StoreID
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
        /// <summary>
        /// CategoryID
        /// </summary>		
        public int CategoryID
        {
            get;
            set;
        }
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
        /// <summary>
        /// Unit
        /// </summary>		
        public string Unit
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
        /// InQuantityStock
        /// </summary>		
        public int InQuantityStock
        {
            get;
            set;
        }
        /// <summary>
        /// InstockAmount
        /// </summary>		
        public decimal InstockAmount
        {
            get;
            set;
        }
        /// <summary>
        /// ProductionDate
        /// </summary>		
        public DateTime? ProductionDate
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

    }
}