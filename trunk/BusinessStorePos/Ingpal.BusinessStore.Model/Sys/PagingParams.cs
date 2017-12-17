using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingpal.BusinessStore.Model
{
    /// <summary>
    /// 通用查询分页参数
    /// </summary>
   public class PagingParams
    {
        /// <summary>
        /// 表名
        /// </summary>
        public string TableName {get;set;}
        /// <summary>
        /// 主键
        /// </summary>
        public string PrimaryKey{ get; set; }
        /// <summary>
        /// 排序 不包含order by
        /// </summary>
        public string Sort { get; set; }
        /// <summary>
        /// 当前页码
        /// </summary>
        public int PageIndex { get; set; }
        /// <summary>
        /// 每页记录数
        /// </summary>
        public int PageSize { get;set;}
        /// <summary>
        /// 输出字段 
        /// </summary>
        public string Fields { get;
            set;
        }
        /// <summary>
        /// where过滤条件(不带where)
        /// </summary>
        public string Filter { get; set; }
        /// <summary>
        /// 不包含group by
        /// </summary>
        public string Group { get; set; }
        /// <summary>
        /// 总记录数
        /// </summary>
        public int TotalCount { get; set; } 

    }
}
