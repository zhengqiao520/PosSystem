using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Reflection;
using DevLib.Data;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Data.Common;

namespace Ingpal.BusinessStore.Infrastructure.DB
{
    public class DBUtility : DbHelper
    {
        public DBUtility() : base(Encodetool.ConnctionString, DbProvider.SqlServer)
        {

        }

        public List<T> GetByKey<T>(object key) where T : new()
        {
            var tableName = GetTableName<T>();
            string sql = SqlDBHelper.GetSqlGetByKey<T>(key);
            var dbResult = SqlDBHelper.GetDataSet(sql).Tables[0];
            var result = MakeTablePackage<T>(dbResult);
            return result;
        }
        public List<T> GetAll<T>(string tableName="",string where="") where T : new()
        {
            string sql = SqlDBHelper.GetSqlALL<T>(tableName, where);
            var dbResult = SqlDBHelper.GetDataSet(sql).Tables[0];
            var result = MakeTablePackage<T>(dbResult);
            return result;
        }

        public List<T> GetAllByPageing<T>(int pageSize = 0, int pageIndex = 0) where T : new()
        {
            return GetAll<T>().Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList();
        }
        public int ExecuteProcedure(string spName, IDataParameter[] parameters)
        {
            return SqlDBHelper.ExecuteProcedure(spName, parameters);
        }
        /// <summary>
        /// 性能较差数据量少时使
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        public List<T> GetBy<T>(Func<T, bool> expression) where T : new()
        {
            return GetAll<T>().Where(expression).ToList();
        }
        public int Insert<T>(T t)
        {
            var sql = SqlDBHelper.GetSqlInsert(t);
            var result = SqlDBHelper.ExecuteCommand(sql);
            return result;
        }
        public int UpdateByKey<T>(T t)
        {
            var sql = SqlDBHelper.GetSqlUpdate(t);
            var result = SqlDBHelper.ExecuteCommand(sql);
            return result;
        }
        public int DeleteByKey<T>(object key)
        {
            var tableName = GetTableName<T>();
            var sql = SqlDBHelper.GetSqlDeleteByKey<T>(key);
            var result = SqlDBHelper.ExecuteCommand(sql);
            return result;
        }
        public int GetSqlDeleteByWhere<T>(string where)
        {
            var sql = SqlDBHelper.GetSqlDeleteByWhere<T>(where, GetTableName<T>());
            var result = SqlDBHelper.ExecuteCommand(sql);
            return result;
        }
        private List<T> MakeTablePackage<T>(DataTable _dtGet) where T : new()
        {
            //try
            //{
            List<T> _lstReturn = new List<T>();

            //获得属性集合
            Type _type = typeof(T);
            PropertyInfo[] _properties = _type.GetProperties();
            for (int i = 0; i < _dtGet.Rows.Count; i++)
            {
                T _item = new T();
                foreach (DataColumn cloum in _dtGet.Columns)
                {
                    foreach (PropertyInfo _property in _properties)
                    {
                        if (cloum.ColumnName == _property.Name)
                        {
                            object _value = _dtGet.Rows[i][cloum.ColumnName].ToString();
                            _property.SetValue(_item, _value.ChangeType(_property.PropertyType)
                                , null);
                        }
                    }
                }
                _lstReturn.Add(_item);
            }
            return _lstReturn;
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception("打包数据出错-MakeTablePackage");
            //}
        }

        protected string GetTableName<T>()
        {
            Type type = typeof(T);
            var tableName = SqlDBHelper.GetTableName(type);
            return tableName;
        }
        public DbTransaction Transation
        {
            get
            {
                return BeginTransaction();
            }
        }
    }
}

