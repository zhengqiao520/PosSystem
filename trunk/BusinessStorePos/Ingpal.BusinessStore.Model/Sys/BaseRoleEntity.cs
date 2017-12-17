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
        public bool IsPublic { get; set; }
        public int SortCode { get; set; }
        public string Description { get; set; }
        public int RecordStatus { get; set; }
    }

    [Table(TableName = "UserRoleRelation")]
    public class RoleUserRoleRelation
    {
        [Table(PrimaryKey = true,AutoIncrement =false)]
        public Guid ID { get; set; }
        public Guid? UserID { get; set; }
        public int RoleType { get; set; }
        public Guid? BaseRoleID { get; set; }
        public int RecordStatus { get; set; }
    }
}
