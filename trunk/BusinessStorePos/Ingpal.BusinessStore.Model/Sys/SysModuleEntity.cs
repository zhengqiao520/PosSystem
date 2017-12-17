using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingpal.BusinessStore.Model
{
    [Serializable]
    public class SysModule
    {

        /// <summary>
        /// 模块主键
        /// </summary>		
        public string ID
        {
            get;
            set;
        }
        /// <summary>
        /// 父级
        /// </summary>		
        public string ParentId
        {
            get;
            set;
        }
        /// <summary>
        /// 层次
        /// </summary>		
        public int Layers
        {
            get;
            set;
        }
        /// <summary>
        /// 编码
        /// </summary>		
        public string EnCode
        {
            get;
            set;
        }
        /// <summary>
        /// 名称
        /// </summary>		
        public string FullName
        {
            get;
            set;
        }
        /// <summary>
        /// 图标
        /// </summary>		
        public string Icon
        {
            get;
            set;
        }
        /// <summary>
        /// 连接
        /// </summary>		
        public string UrlAddress
        {
            get;
            set;
        }
        /// <summary>
        /// 目标
        /// </summary>		
        public string Target
        {
            get;
            set;
        }
        /// <summary>
        /// 菜单
        /// </summary>		
        public bool IsMenu
        {
            get;
            set;
        }
        /// <summary>
        /// 展开
        /// </summary>		
        public bool IsExpand
        {
            get;
            set;
        }
        /// <summary>
        /// 公共
        /// </summary>		
        public bool IsPublic
        {
            get;
            set;
        }
        /// <summary>
        /// 允许编辑
        /// </summary>		
        public bool AllowEdit
        {
            get;
            set;
        }
        /// <summary>
        /// 允许删除
        /// </summary>		
        public bool AllowDelete
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
        /// 有效标志
        /// </summary>		
        public bool EnabledMark
        {
            get;
            set;
        }
        /// <summary>
        /// 描述
        /// </summary>		
        public string Description
        {
            get;
            set;
        }
        /// <summary>
        /// 最后修改时间
        /// </summary>		
        public DateTime LastModifyTime
        {
            get;
            set;
        }
        /// <summary>
        /// 最后修改用户
        /// </summary>		
        public string LastModifyUserId
        {
            get;
            set;
        }
    }
}
