using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingpal.BusinessStore.Model
{
    [Table(TableName = "MDMTypeSub")]
    public class MDMTypeSubEntity
    {
        [Table(AutoIncrement =true)]
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
        /// MDMTypeID
        /// </summary>		
        public int MDMTypeID
        {
            get;
            set;
        }
        /// <summary>
        /// MDMTypeName
        /// </summary>		
        public string MDMTypeName
        {
            get;
            set;
        }
        /// <summary>
        /// SubName
        /// </summary>		
        public string SubName
        {
            get;
            set;
        }
        /// <summary>
        /// SubValue
        /// </summary>		
        public string SubValue
        {
            get;
            set;
        }
        /// <summary>
        /// IsDefault
        /// </summary>		
        public bool IsDefault
        {
            get;
            set;
        }
        /// <summary>
        /// Description
        /// </summary>		
        public string Description
        {
            get;
            set;
        }
        public int? SortCode
        {
            get;
            set;
        }


    }
}
