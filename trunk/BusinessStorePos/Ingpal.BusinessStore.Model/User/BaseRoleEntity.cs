using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingpal.BusinessStore.Model
{
    [Table(TableName = "BaseRole")]
    [Serializable]
    public class BaseRoleEntity
    {
        [Table(PrimaryKey =true)]
        public string ID { get; set; }
        public int RoleCode { get; set; }
        public string RoleName { get; set; }
        public int StoreID { get; set; }
        public bool IsBackstage { get; set; }
        public int SortCode { get; set; }
        public string Description { get; set; }
        public int RecordStatus { get; set; }

        [Table(Ignor =true)]
        public string PermissionIds { get; set; }
    }
}
