using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingpal.BusinessStore.Model
{
    public class GoodsInFullInfo
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
        /// GoodsOutQuantity
        /// </summary>		
        public int InQuantityStock
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

        public string Remrks
        {
            get;
            set;
        }

        public string Name
        {
            get; set;
        }

        public string BarID
        {
            get;set;
        }

        public string GoodsInTypeName
        {
            get;set;
        }
    }
}
