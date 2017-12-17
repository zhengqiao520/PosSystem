using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingpal.BusinessStore.Model
{

    [Serializable]
    [Table(TableName = "Users")]
    public  class UserEntity
    {
        [Table(PrimaryKey =true, AutoIncrement=false)]
        /// <summary>
        /// 用户主键
        /// </summary>		
        public Guid ID
        {
            get;
            set;
        }
        /// <summary>
        /// 机构主键
        /// </summary>		
        public int? StoreID
        {
            get;
            set;
        }
        /// <summary>
        /// 登录账户
        /// </summary>		
        public string Account
        {
            get;
            set;
        }
        /// <summary>
        /// 登录密码
        /// </summary>		
        public string Password
        {
            get;
            set;
        }
        /// <summary>
        /// 真实姓名
        /// </summary>		
        public string RealName
        {
            get;
            set;
        }
        /// <summary>
        /// 呢称
        /// </summary>		
        public string UserCode
        {
            get;
            set;
        }
        /// <summary>
        /// 头像
        /// </summary>		
        public string HeadIcon
        {
            get;
            set;
        }
        /// <summary>
        /// 性别
        /// </summary>		
        public bool Gender
        {
            get;
            set;
        }
        /// <summary>
        /// 生日
        /// </summary>		
        public DateTime? Birthday
        {
            get;
            set;
        }
        /// <summary>
        /// 电话
        /// </summary>		
        public string Telephone
        {
            get;
            set;
        }
        /// <summary>
        /// 电子邮件
        /// </summary>		
        public string Email
        {
            get;
            set;
        }
        /// <summary>
        /// 角色主键
        /// </summary>		
        public string RoleId
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
        /// <summary>
        /// 岗位id
        /// </summary>		
        public string PostId
        {
            get;
            set;
        }
        /// <summary>
        /// 岗位名称
        /// </summary>		
        public string PostName
        {
            get;
            set;
        }
        /// <summary>
        /// 是否管理员
        /// </summary>
        public bool IsAdmin { get; set; }
        /// <summary>
        /// 最后访问时间
        /// </summary>		
        public DateTime? LastVisit
        {
            get;
            set;
        }
        /// <summary>
        /// 登录次数
        /// </summary>		
        public int LogOnCount
        {
            get;
            set;
        }
        /// <summary>
        /// 排序码
        /// </summary>		
        public int SortCode
        {
            get;
            set;
        }
        /// <summary>
        /// 有效标志 0正常，-1作废
        /// </summary>		
        public int RecordStatus
        {
            get;
            set;
        }
        /// <summary>
        /// 备注
        /// </summary>		
        public string Description
        {
            get;
            set;
        }
        /// <summary>
        /// 创建日期
        /// </summary>		
        public DateTime CreateDate
        {
            get;
            set;
        }
    }

    /// <summary>
    /// 用户信息扩展
    /// </summary>
    public class UserInfo:UserEntity {
        public UserInfo()
        {

        }
        private static UserInfo userInfo = null;
        public static UserInfo Instance
        {
            get
            {
                if (userInfo == null)
                {
                    userInfo = new UserInfo();
                }
                return userInfo;
            }
            set {
                userInfo = value;
            }
        }
        public string StoreName { get; set; }
        public string StorePhone { get; set; }
        public string Address { get; set; }
        public string Area { get; set; }
        public bool IsBackstage { get; set; }

        public int? ExpectedAchievement { get; set; }


        public List<UserRoleRealationView> UserRoles {
            get;
            set;
        }
        public bool IsShopManager
        {
            get {
                if (UserRoles != null)
                {
                    return UserRoles.FindIndex(item => item.RoleName == "店长"||item.RoleID.ToString()== "e65afece-7f7f-42e5-bfa9-57fb0c28d3d5") > -1;
                }
                return false;
            }
        }

    }
}
