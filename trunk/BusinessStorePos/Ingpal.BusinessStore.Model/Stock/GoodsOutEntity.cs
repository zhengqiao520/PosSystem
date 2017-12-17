using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingpal.BusinessStore.Model
{
    [Serializable]
    [Table(TableName = "GoodsOut")]
    public class GoodsOutEntity
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
        public int StoreID
        {
            get;
            set;
        }

        public string StoreName
        {
            get;set;
        }
        /// <summary>
        /// ReceiverStoreID
        /// </summary>
        /// 

        public int ReceiverStoreID
        {
            get;set;
        }

        /// <summary>
        /// StatusName
        /// </summary>
        public string StatusName
        {
            get;set;
        }

        public int Status
        {
            get;set;
        }

        /// <summary>
        /// ReceiverStoreName
        /// </summary>
        public string ReceiverStoreName
        {
            get;set;
        }

        public string ReceiverUserName
        {
            get;set;
        }
        /// <summary>
        /// GoodsOutCode
        /// </summary>		
        public string GoodsOutCode
        {
            get;
            set;
        }
        /// <summary>
        /// GoodsOutDate
        /// </summary>		
        public DateTime GoodsOutDate
        {
            get;
            set;
        }
        /// <summary>
        /// GoodsOutQuantity
        /// </summary>		
        public int GoodsOutQuantity
        {
            get;
            set;
        } 
        /// <summary>
        /// GoodsOutHumanID
        /// </summary>		
        public Guid GoodsOutHumanID
        {
            get;
            set;
        }
        /// <summary>
        /// GoodsOutHumanName
        /// </summary>		
        public string GoodsOutHumanName
        {
            get;
            set;
        }
        public int? GoodsOutType
        {
            get;
            set;
        }
        public string GoodsOutTypeName
        {
            get;set;
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
    [Table(TableName = "GoodsOutDetail")]
    public class GoodsOutDetailEntity
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
        /// GoodsOutCode
        /// </summary>		
        public string GoodsOutCode
        {
            get;
            set;
        }
       
        public Guid GoodsId
        {
            get;set;
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
        /// Unit
        /// </summary>		
        public string Unit
        {
            get;
            set;
        }
        
       
        /// <summary>
        /// InQuantityStock
        /// </summary>		
        public int OutQuantityStock
        {
            get;
            set;
        }

        public int StockQuantity
        {
            get;set;
        }

        public string BarID
        {
            get; set;
        }

        public int ReceiverStoreId
        {
            get;set;
        }
    }
}