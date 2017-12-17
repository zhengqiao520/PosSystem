using System;
using System.Collections.Generic;
using System.Linq;
namespace Ingpal.BusinessStore.Model
{

    [Serializable]
    [Table(TableName = "PosMDM")]
   public class MDMEntity
    {
        [Table(PrimaryKey =true)]
        public Guid ID { get;
            set;
        }
        public string MDMName{ get; set; }
        public string MDMCode { get; set; }
        public string MDMValue { get; set; }
        public DateTime UpdateDate { get; set;}
        public bool RecordStatus { get; set; }
        public string Description { get; set; }
        public static List<MDMEntity> ListMDM { get; set; }

    }
}
