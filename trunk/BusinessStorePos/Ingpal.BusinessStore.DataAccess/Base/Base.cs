using Ingpal.BusinessStore.Infrastructure.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using Ingpal.BusinessStore.Model;

namespace Ingpal.BusinessStore.DataAccess
{
    public class BaseDAL
    {
        internal static DBUtility utity = new DBUtility();
        /// <summary>
        /// 根据主键删除记录
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public  static bool DeleteByKey<T>(object key) where T: class,new ()
        {
            return utity.DeleteByKey<T>(key) > 0;
        }
        /// <summary>
        /// 获取所有记录
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<T> GetALL<T>(string tableName="",string where="") where T :class,new()
        {
            return utity.GetAll<T>(tableName,where);
        }
        /// <summary>
        /// 根据主键查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public static List<T> GetByKey<T>(object key) where T : class, new()
        {
            return utity.GetByKey<T>(key);
        }
        /// <summary>
        /// 从所有记录中检索指定记录
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static List<T> GetBy<T>(Func<T, bool> expression) where T : class, new()
        {
            return utity.GetBy<T>(expression);
        }
        /// <summary>
        /// 根据主键更新
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static bool UpdateByKey<T>(T t) where T : class, new()
        {
            return utity.UpdateByKey(t)>0;
        }
        /// <summary>
        /// 根据条件删除记录
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="where"></param>
        /// <returns></returns>
        public static bool DeleteByWhere<T>(string where) where T : class, new()
        {
            return utity.GetSqlDeleteByWhere<T>(where) > 0;
        }
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static bool Insert<T>(T t) where T : class, new()
        {
            return utity.Insert(t) > 0;
        }
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="paging"></param>
        /// <returns></returns>
        public static List<T> GetPagingSP<T>(PagingParams paging) where T : class, new()
        {
            return utity.ExecuteListSp<T>("usp_Paging", new object[] {
                 paging.TableName,
                 paging.PrimaryKey,
                 paging.Sort,
                 paging.PageIndex,
                 paging.PageSize,
                 paging.Fields,
                 paging.Filter,
                 paging.Group,
                 paging.TotalCount
            });
        }
    }
}
