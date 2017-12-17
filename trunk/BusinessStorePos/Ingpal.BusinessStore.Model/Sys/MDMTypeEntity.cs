using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingpal.BusinessStore.Model
{
    //MDMType
    [Table(TableName = "MDMType")]
    public class MDMTypeEntity
    {
        [Table(PrimaryKey =true,AutoIncrement =true)]
        /// <summary>
        /// ID
        /// </summary>		
        public int ID
        {
            get;
            set;
        }
        /// <summary>
        /// ParentID
        /// </summary>		
        public int ParentID
        {
            get;
            set;
        }
        /// <summary>
        /// TypeName
        /// </summary>		
        public string TypeName
        {
            get;
            set;
        }
        /// <summary>
        /// TypeValue
        /// </summary>		
        public string TypeValue
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
        public int? SortCode
        {
            get;
            set;
        }

    }
}
