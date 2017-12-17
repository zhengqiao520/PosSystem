using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ingpal.BusinessStore.DataAccess;
using Ingpal.BusinessStore.Model;

namespace Ingpal.BusinessStore.Business
{
    public abstract class BaseBLL
    {
        public bool DeteleByKey<T>(object key) where T : class, new()
        {
            return BaseDAL.DeleteByKey<T>(key);
        }

        public bool DeleteByWhere<T>(string where) where T : class, new()
        {
            return BaseDAL.DeleteByWhere<T>(where);
        }
        public List<T> GetALL<T>(string tableName="",string where="") where T : class, new()
        {
            return BaseDAL.GetALL<T>(tableName, where);
        }
        public List<T> GetBy<T>(Func<T, bool> expression) where T : class, new()
        {
            return BaseDAL.GetBy(expression);
        }
        public bool UpdateByKey<T>(T key) where T : class, new()
        {
            return BaseDAL.UpdateByKey(key);
        }
        public bool Insert<T>(T t) where T : class, new() {
            return BaseDAL.Insert(t);
        }
        public  List<T> GetPagingSP<T>(PagingParams paging) where T : class, new()
        {
            return BaseDAL.GetPagingSP<T>(paging);
        }
    }
}
