using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
namespace Ingpal.BusinessStore.Model.DTO
{
    [Serializable]
    [Table(TableName = "Sys_Items")]
   public class UserDTO
    {
        [Table(ColumnName= "F_EnCode")]
        public string F_EnCode { get; set; }
        public string F_FullName { get; set; }

        [Table(PrimaryKey =true)]
        public string F_id { get; set; }
    }
}
