using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingpal.BusinessStore.Model
{
    //角色授权表
    public class SysRoleAuthorizeEntity
    {

        /// <summary>
        /// 主键
        /// </summary>		
        public string Id
        {
            get;
            set;
        }
        /// <summary>
        /// 菜单id
        /// </summary>		
        public string SysModuleID
        {
            get;
            set;
        }
        /// <summary>
        /// 角色编号
        /// </summary>		
        public string BaseRoleID
        {
            get;
            set;
        }
        /// <summary>
        /// 排序码
        /// </summary>		
        public int? SortCode
        {
            get;
            set;
        }
        /// <summary>
        /// 创建时间
        /// </summary>		
        public DateTime? CreatorTime
        {
            get;
            set;
        }

    }
}
