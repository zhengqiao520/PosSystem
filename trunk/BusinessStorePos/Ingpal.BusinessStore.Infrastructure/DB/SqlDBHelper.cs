
using Ingpal.BusinessStore.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ingpal.BusinessStore.Infrastructure.DB
{
    public class SqlDBHelper
    {
        private static readonly  string connectionString = Encodetool.ConnctionString;
        /// <summary>
        /// 保存记录
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static string GetSqlInsert<T>(T t)
        {
            Type type = t.GetType();
            var tableName = GetTableName(type);
            PropertyInfo[] properties = type.GetProperties();
            string str = "Insert into " + tableName + " ( ";
            foreach (var proper in properties)
            {
                if (IsPrimaryKey(proper)&& AutoIncrement(proper)|| IsIgnor(proper))
                {
                    continue;
                }
                else
                {
                    str += proper.Name + ",";
                }
            }
            str = str.Substring(0, str.LastIndexOf(","));
            str += " ) values ( ";
            foreach (var proper in properties)
            {
                if (IsIgnor(proper))
                {
                    continue;
                }
                if (IsPrimaryKey(proper) && AutoIncrement(proper))
                {
                    continue;
                }
                else
                {
                    object val = proper.GetValue(t, null);
                    if (val is int || val is float || val is decimal || val is double)
                    {
                        str += proper.GetValue(t, null) + ",";
                    }
                    else
                    {
                        if (val == null)
                        {
                            str += "null,";
                        }
                        else
                        {
                            str += "'" + proper.GetValue(t, null) + "'" + ",";
                        }

                    }
                }
            }
            str = str.Substring(0, str.LastIndexOf(","));
            str += " )";
            return str;
        }

        /// <summary>
        /// 更新记录
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static string GetSqlUpdate<T>(T t)
        {
            Type type = t.GetType();
            var tableName = GetTableName(type);
            PropertyInfo[] properties = type.GetProperties();
            string str = $"update {tableName} set ";
            var whereStr = string.Empty;
            foreach (var proper in properties)
            {
                if (IsPrimaryKey(proper))
                {
                    whereStr = $"where { proper.Name }='{proper.GetValue(t, null)}' ";
                }
                else
                {
                    if (IsIgnor(proper)) {
                        continue;
                    }
                    var value = proper.GetValue(t, null) ?? "";
                    if (!string.IsNullOrEmpty(value.ToString()))
                    {
                        var pType = proper.PropertyType;
                        if (pType.Equals(typeof(System.DateTime?)) || pType.Equals(typeof(System.DateTime)))
                        {
                            if (!(((DateTime)value) > DateTime.MinValue))
                                continue;
                        }
                        str += $"{proper.Name}='{ proper.GetValue(t, null)}',";
                    }
                }
            }
            str = str.TrimEnd(',');
            str += whereStr;
            return str.ReplaceSQL();
        }

        public static string GetSqlDeleteByKey<T>(object key,string tableName=null)
        {
            string table = tableName ?? GetTableName(typeof(T));
            return  string.Format("Delete  from {0} where {1}='{2}'",table, GetPrimaryKey(typeof(T)), key);
        }
        public static string GetSqlDeleteByWhere<T>(string where,string tableName=null)
        {
            string table = tableName ?? GetTableName(typeof(T));
            where = string.IsNullOrEmpty(where) ? "1=2" : where;
            return $" Delete from {table} where {where}";
        }

        public static string GetSqlGetByKey<T>(object key, string tableName=null)
        {
            string table = tableName ?? GetTableName(typeof(T));
            return string.Format("select * from {0} where {1}='{2}'", table, GetPrimaryKey(typeof(T)), key);
        }
        public static string GetSqlALL<T>(string tableName = null,string where="")
        {
            where = !string.IsNullOrEmpty(where) ? $" where {where}" : where;
            return $"select * from {tableName.ToNull() ?? GetTableName(typeof(T))}{where}";
        }
        /// <summary>
        /// 获取obj_T对象AttributeType类型标签Attribute属性中的值
        /// </summary>
        /// <typeparam name="RType">返回类型</typeparam>
        /// <param name="obj_Type">类Type</param>
        /// <param name="AttributeType">标签Type</param>
        /// <param name="aTypePropertyName">标签属性名称</param>
        /// <returns>值</returns>
        public static RType GetObjAttriVal<RType>(Type obj_Type, Type AttributeType, string aTypePropertyName)
        {
            RType retStr = default(RType);
            object[] memberInfo = obj_Type.GetCustomAttributes(AttributeType, true);
            if (null != memberInfo && memberInfo.Length > 0)
            {
                System.Reflection.MemberInfo[] memberInfosAttr = AttributeType.GetMember(aTypePropertyName);
                if (null != memberInfosAttr && memberInfosAttr.Length > 0 && memberInfosAttr[0].MemberType == System.Reflection.MemberTypes.Property)
                {
                    System.Reflection.PropertyInfo propertyInfo = memberInfosAttr[0] as System.Reflection.PropertyInfo;
                    retStr = (RType)Convert.ChangeType(propertyInfo.GetValue(memberInfo[0], null), propertyInfo.PropertyType);
                }
            }
            return retStr;

        }
        ///// <summary>
        ///// 根据dto拼接查询条件并返回datatable
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="dto"></param>
        ///// <returns></returns>
        //public static DataTable GetTable<T>(T dto)
        //{
        //    int pageSize = Words.GetPageSize();
        //    return GetTable(dto, pageSize);
        //}


        /// <summary>
        ///判断是否是主键
        /// </summary>
        /// <param name="proper"></param>
        /// <returns></returns>
        public static bool IsPrimaryKey(PropertyInfo proper)
        {
            object[] objs = proper.GetCustomAttributes(typeof(TableAttribute), true);
            bool f = false;
            foreach (var obj in objs)
            {
                if (obj is TableAttribute)
                {
                    TableAttribute alltarget = (TableAttribute)obj;
                    if (alltarget.PrimaryKey)
                    {
                        f = true;
                        break;
                    }
                }
            }
            return f;
        }
        public static bool AutoIncrement(PropertyInfo proper)
        {
            object[] objs = proper.GetCustomAttributes(typeof(TableAttribute), true);
            bool f = false;
            foreach (var obj in objs)
            {
                if (obj is TableAttribute)
                {
                    TableAttribute alltarget = (TableAttribute)obj;
                    if (alltarget.AutoIncrement)
                    {
                        f = true;
                        break;
                    }
                }
            }
            return f;
        }

        public static bool IsIgnor(PropertyInfo proper)
        {
            object[] objs = proper.GetCustomAttributes(typeof(TableAttribute), true);
            bool f = false;
            foreach (var obj in objs)
            {
                if (obj is TableAttribute)
                {
                    TableAttribute alltarget = (TableAttribute)obj;
                    if (alltarget.Ignor)
                    {
                        f = true;
                        break;
                    }
                }
            }
            return f;
        }
        public static string GetPrimaryKey(Type type)
        {
            string primaryKey = string.Empty;
            PropertyInfo[] properties = type.GetProperties();
            foreach (var proper in properties)
            {
                if (IsPrimaryKey(proper))
                {
                    primaryKey = proper.Name;
                    break;
                }
            }
            return primaryKey;
        }
        public static string GetTableName(Type type)
        {
            var tableName = string.Empty;

                object[] objs = type.GetCustomAttributes(typeof(TableAttribute), true);

                foreach (var obj in objs)
                {
                    if (obj is TableAttribute)
                    {
                        TableAttribute alltarget = (TableAttribute)obj;
                        if (alltarget != null)
                        {
                            tableName = alltarget.TableName;
                            break;
                        }
                    }
                }
                //if (!string.IsNullOrEmpty(tableName)) break;
            return tableName;
        }
        public static int ExecuteCommand(string safeSql)
        {
            int result = 0;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(safeSql, con))
                {
                    con.Open();
                    SqlTransaction trans = con.BeginTransaction();
                    try
                    {
                        cmd.Transaction = trans;
                        result= cmd.ExecuteNonQuery();
                        trans.Commit();
                    }
                    catch {
                        trans.Rollback();
                    }
                    return result;
                }
            }

        }

        public static int ExecuteCommand(string sql, params SqlParameter[] values)
        {
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i].Value == null)
                {
                    values[i].Value = DBNull.Value;
                }
                if (values[i].Value.ToString() == "0001/1/1 0:00:00" && values[i].SqlDbType == SqlDbType.DateTime)
                {
                    values[i].Value = DBNull.Value;
                }
            }
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    con.Open();
                    cmd.Parameters.AddRange(values);
                    return cmd.ExecuteNonQuery();
                }
            }

        }

        public static int ExecuteCommandWithTransaction(string sql, SqlTransaction stn, params SqlParameter[] values)
        {
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i].Value == null)
                {
                    values[i].Value = DBNull.Value;
                }
                if (values[i].Value.ToString() == "0001/1/1 0:00:00" && values[i].SqlDbType == SqlDbType.DateTime)
                {
                    values[i].Value = System.Data.SqlTypes.SqlDateTime.MinValue;
                    //values[i].Value = DBNull.Value;
                }
            }
            SqlConnection con;
            var result = 0;
            if (stn != null && stn.Connection != null)
            {
                con = stn.Connection;
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddRange(values);
                    if (stn != null && stn.Connection != null)
                    {
                        cmd.Transaction = stn;
                    }
                    cmd.CommandTimeout = 600;
                    result = cmd.ExecuteNonQuery();
                }
            }
            return result;
        }


        public static int GetScalar(string safeSql)
        {


            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(safeSql, con))
                {
                    con.Open();
                    int result = Convert.ToInt32(cmd.ExecuteScalar());
                    return result;
                }
            }
        }

        public static object GetScalar(string sql, params SqlParameter[] values)
        {

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    con.Open();
                    cmd.Parameters.AddRange(values);
                    var result = cmd.ExecuteScalar();
                    return result;
                }
            }

        }

        /// <summary>
        /// 查看新的数量
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static object GetScalarWithNewCon(string sql, params SqlParameter[] values)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {

                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    con.Open();
                    cmd.Parameters.AddRange(values);
                    return cmd.ExecuteScalar();

                }
            }
        }

        public static string GetScalarString(string sql)
        {

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    con.Open();
                    string result = cmd.ExecuteScalar().ToString();
                    return result;
                }
            }

        }

        public static SqlDataReader GetReader(string safeSql)
        {
            SqlConnection con = new SqlConnection(connectionString);
            using (SqlCommand cmd = new SqlCommand(safeSql, con))
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                return reader;
            }

        }

        public static SqlDataReader GetReader(string sql, params SqlParameter[] values)
        {
            SqlConnection con = new SqlConnection(connectionString);
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                con.Open();
                cmd.Parameters.AddRange(values);
                SqlDataReader reader = cmd.ExecuteReader();
                return reader;
            }


        }

        public static DataTable GetTable(string safeSql)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {

                using (SqlCommand cmd = new SqlCommand(safeSql.ToSafeSql(), con))
                {
                    con.Open();
                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    return ds.Tables[0];
                }
            }
        }


        public static DataTable GetTable(string sql, params SqlParameter[] values)
        {

            using (SqlConnection con = new SqlConnection(connectionString))
            {

                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    con.Open();
                    DataSet ds = new DataSet();
                    cmd.Parameters.AddRange(values);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    return ds.Tables[0];
                }
            }

        }

        public static DataSet GetDataSet(string sql)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    con.Open();
                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    return ds;
                }

            }

        }

        public static DataSet GetDataSet(string sql, params SqlParameter[] values)
        {
            try
            {
                for (int i = 0; i < values.Length; i++)
                {
                  if (values[i].SqlDbType == SqlDbType.DateTime && values[i].Value.ToString() == "0001/1/1 0:00:00")
                    {
                        values[i].Value = System.Data.SqlTypes.SqlDateTime.MinValue;
                        //values[i].Value = DBNull.Value;
                    }
                }
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(sql.ToSafeSql(), con))
                    {
                        con.Open();
                        DataSet ds = new DataSet();
                        cmd.Parameters.AddRange(values);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);
                        return ds;
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="storedProcName"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static SqlDataReader RunProcedure(string storedProcName, IDataParameter[] parameters)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlDataReader returnReader;
            con.Open();
            SqlCommand command = BuildQueryCommand(con, storedProcName, parameters);
            command.CommandType = CommandType.StoredProcedure;

            returnReader = command.ExecuteReader();
            return returnReader;
        }
        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="storedProcName"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static DataTable RunProcedureTable(string storedProcName, IDataParameter[] parameters)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    DataSet dsSet = new DataSet();
                    SqlDataAdapter sqlDa = new SqlDataAdapter(storedProcName, con);
                    sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sqlDa.SelectCommand.Parameters.AddRange(parameters);
                    sqlDa.Fill(dsSet);

                    return dsSet.Tables[0];
                }
            }
            catch
            {
                return new DataTable();
            }
        }
        /// <summary>
        /// 为存储过程添加参数
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="storedProcName"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        private static SqlCommand BuildQueryCommand(SqlConnection connection, string storedProcName, IDataParameter[] parameters)
        {

            using (SqlCommand command = new SqlCommand(storedProcName, connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                if (parameters != null)
                {
                    foreach (SqlParameter parameter in parameters)
                    {
                        command.Parameters.Add(parameter);
                    }
                }
                return command;
            }

        }

        /// <summary>
        /// 执行存储过程，返回影响的行数		
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns></returns>
        public static int ExecuteProcedure(string storedProcName, IDataParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                int rs = 0;
                SqlCommand command = BuildQueryCommand(connection, storedProcName, parameters);
                SqlTransaction trans = connection.BeginTransaction();
                try
                {
                    rs=command.ExecuteNonQuery();
                    trans.Commit();
                }
                catch(Exception ee) {
                    trans.Rollback();
                }
                return rs;
            }
        }

        #region 事务
        /// <summary>
        /// 获取一个事务对象。
        /// </summary>
        /// <param name="connectionString">连接字符串。</param>
        public static SqlTransaction LockTransaction()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlTransaction Tran = conn.BeginTransaction();
            return Tran;
        }

        /// <summary>
        /// 释放一个事务对象。该方法将会自动提交未提交的事务。
        /// </summary>
        /// <param name="tran">要释放的事务对象。</param>
        public static void UnLockTransaction(SqlTransaction tran)
        {
            SqlConnection conn = tran.Connection;
            tran.Dispose();
            if (conn != null) conn.Dispose();
        }
        #endregion
    }
}
