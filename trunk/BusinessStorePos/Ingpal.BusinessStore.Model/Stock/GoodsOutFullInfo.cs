using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingpal.BusinessStore.Model
{
    public class GoodsOutFullInfo
    {
        	
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
            get; set;
        }
        /// <summary>
        /// ReceiverStoreID
        /// </summary>
        /// 

        public int ReceiverStoreID
        {
            get; set;
        }

        /// <summary>
        /// StatusName
        /// </summary>
        public string StatusName
        {
            get; set;
        }

        public int Status
        {
            get; set;
        }

        /// <summary>
        /// ReceiverStoreName
        /// </summary>
        public string ReceiverStoreName
        {
            get; set;
        }

        public string ReceiverUserName
        {
            get; set;
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
        public int OutQuantityStock
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
        public string Operator
        {
            get;
            set;
        }

        public string ReceiverOperator
        {
            get;
            set;
        }
        public int? GoodsOutType
        {
            get;
            set;
        }
        public string GoodOutTypeName
        {
            get; set;
        }
        /// <summary>
        /// Remrks
        /// </summary>		
        public string Remrks
        {
            get;
            set;
        }

        public string Name
        {
            get;set;
        }

        public string Unit
        {
            get;set;
        }
    }
}
