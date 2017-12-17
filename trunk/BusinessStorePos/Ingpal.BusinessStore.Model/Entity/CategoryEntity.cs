using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingpal.BusinessStore.Model
{
    [Serializable]
    [Table(TableName ="GoodsCategory")]
    public class CategoryEntity
    {

        [Table(PrimaryKey =true)]
        /// <summary>
        /// ID
        /// </summary>		
        public int ID
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
        /// ParentCategoryID
        /// </summary>		
        public int ParentCategoryID
        {
            get;
            set;
        }
        /// <summary>
        /// ParentCategoryName
        /// </summary>		
        public string ParentCategoryName
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
        /// Remark
        /// </summary>		
        public string Remark
        {
            get;
            set;
        }

    }
}
