using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingpal.BusinessStore.Model
{
    [Table(TableName = "UserRoleRelation")]

    //用户关系表
    public class UserRoleRelationEntity
    {
        [Table(PrimaryKey = true, AutoIncrement = false)]
        /// <summary>
        /// 用户关系主键
        /// </summary>		
        public Guid ID
        {
            get;
            set;
        }
        /// <summary>
        /// 用户主键
        /// </summary>		
        public Guid UserID
        {
            get;
            set;
        }
        /// <summary>
        /// 分类:
        /// </summary>		
        public int RoleType
        {
            get;
            set;
        }
        /// <summary>
        /// BaseRoleID
        /// </summary>		
        public Guid BaseRoleID
        {
            get;
            set;
        }
        /// <summary>
        /// RecordStatus
        /// </summary>		
        public int RecordStatus
        {
            get;
            set;
        }
    }

    [Table(TableName = "V_UserRoleRealation")]
    public class UserRoleRealationView {


        public Guid? UserRoleRelationID { get; set; }
        public int StoreID { get; set; }

        /// <summary>
        /// ID
        /// </summary>		
        public Guid UserID
        {
            get;
            set;
        }
        /// <summary>
        /// UserCode
        /// </summary>		
        public string UserCode
        {
            get;
            set;
        }
        /// <summary>
        /// RealName
        /// </summary>		
        public string RealName
        {
            get;
            set;
        }
        /// <summary>
        /// BaseRoleID
        /// </summary>		
        public Guid? RoleID
        {
            get;
            set;
        }
        /// <summary>
        /// RoleName
        /// </summary>		
        public string RoleName
        {
            get;
            set;
        }
    }


}
