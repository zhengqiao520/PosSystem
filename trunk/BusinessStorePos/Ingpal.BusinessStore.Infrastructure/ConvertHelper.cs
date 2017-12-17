using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Web;
using System.Linq;
using System.Reflection;
using System.Collections;
using System.Text;
using System.Text.RegularExpressions;
using Ingpal.BusinessStore.Model;
namespace Ingpal.BusinessStore.Infrastructure
{
    /// <summary>
    /// 转换帮助类
    /// </summary>
    public static class ConvertHelper
    {
        public static IList<T> ConvertTo<T>(IList<DataRow> rows)
        {
            IList<T> list = null;
            if (rows != null)
            {
                list = new List<T>();
                foreach (DataRow row in rows)
                {
                    T item = CreateItem<T>(row);
                    list.Add(item);
                }
            }
            return list;
        }
        public static T CreateItem<T>(DataRow row)
        {
            string columnName;
            T obj = default(T);
            if (row != null)
            {
                obj = Activator.CreateInstance<T>();
                foreach (DataColumn column in row.Table.Columns)
                {
                    columnName = column.ColumnName;
                    //Get property with same columnName
                    PropertyInfo prop = obj.GetType().GetProperty(columnName);
                    try
                    {
                        //Get value for the column
                        object value = (row[columnName].GetType() == typeof(DBNull))
                        ? null : row[columnName];
                        //Set property value
                        if (prop.CanWrite)    //判断其是否可写
                            prop.SetValue(obj, value, null);
                    }
                    catch
                    {
                        throw;
                        //Catch whatever here
                    }
                }
            }
            return obj;
        }
        /// <summary>
        /// 根据KeyValue集合转换datatable，包括位置和列名，多出的列将被移除
        /// </summary>
        /// <param name="sourceTable"></param>
        /// <param name="kv"></param>
        /// <returns></returns>
        public static DataTable RemoveColumn(DataTable dt, string name)
        {
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                if (dt.Columns[i].ColumnName == name)
                {
                    dt.Columns.RemoveAt(i);
                    break;
                }
            }
            return dt;
        }

        /// <summary>
        /// DataRow转换成DataTable
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>DataTable</returns>
        public static DataTable DataRowToDataTable(DataRow dr)
        {
            DataTable dt = dr.Table.Clone();
            dt.ImportRow(dr);

            return dt;
        }

        /// <summary>
        /// 根据KeyValue集合转换datatable，包括位置和列名，多出的列将被移除
        /// </summary>
        /// <param name="sourceTable"></param>
        /// <param name="kv"></param>
        /// <returns></returns>
        public static DataTable DataTableFilter(DataTable sourceTable, KeyValueModel[] kv)
        {
            DataTable dt = sourceTable.Copy();

            for (int i = 0; i < kv.Length; i++)
            {
                //修改datatable的位置
                dt.Columns[kv[i].Key].SetOrdinal(i);
                if (kv[i].Value != "")
                {
                    dt.Columns[kv[i].Key].ColumnName = kv[i].Value;
                }
            }

            for (int i = 0; i < sourceTable.Columns.Count - kv.Length; i++)
            {
                dt.Columns.RemoveAt(kv.Length);
            }
            return dt;
        }



        /// <summary>
        /// 将两个DataTable合并成一个
        /// </summary>
        /// <param name="targetTable"></param>
        /// <param name="sourceTable"></param>
        public static void DataTableAdd(DataTable targetTable, DataTable sourceTable)
        {
            foreach (DataRow dr in sourceTable.Rows)
            {
                targetTable.ImportRow(dr);
            }
        }

        /// <summary>
        /// 生成指定列的新DataTable
        /// </summary>
        /// <param name="sourceTable">源DataTable</param>
        /// <param name="aColumns">包含的列数组</param>
        public static DataTable DataTableFilter(DataTable sourceTable, params string[] aColumns)
        {
            DataTable targetDT = sourceTable.DefaultView.ToTable(false, aColumns);
            return targetDT;
        }

        /// <summary>
        /// 增加同样的列去Datatable，主要用于数据绑定
        /// </summary>
        /// <param name="dt">单列的DataTable</param>
        /// <returns>DataTable</returns>
        public static DataTable AddColumn(DataTable dt)
        {
            DataTable newDt = dt.Clone();
            newDt.Columns.Add("value");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = newDt.NewRow();
                dr[0] = dt.Rows[i][0];
                dr["value"] = dt.Rows[i][0];
                newDt.Rows.Add(dr);
            }
            newDt.AcceptChanges();
            return newDt;
        }

        /// <summary>
        /// 添加ID列
        /// </summary>
        /// <param name="dt">DataTable</param>
        public static void AddRowNumber(DataTable dt)
        {
            dt.Columns.Add(new DataColumn("ROWNUM_", typeof(int)));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i][dt.Columns.Count - 1] = i + 1;
            }
        }

        /// <summary>
        /// 添加ID列
        /// </summary>
        /// <param name="dt">DataTable</param>
        /// <param name="colName">列名</param>
        public static void AddRowNumber(DataTable dt, string colName)
        {
            dt.Columns.Add(new DataColumn(colName, typeof(int)));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i][dt.Columns.Count - 1] = i + 1;
            }
        }

        /// <summary>
        /// 筛选DataTable
        /// </summary>
        /// <param name="resTable">源DataTable</param>
        /// <param name="filter">筛选条件</param>
        /// <param name="sortStr">排序条件</param>
        /// <returns></returns>
        public static DataTable TableSelect(DataTable resTable, string filter, string sortStr)
        {
            DataTable retTable = resTable.Clone();
            foreach (DataRow dr in resTable.Select(filter, sortStr))
            {
                retTable.ImportRow(dr);
            }
            return retTable;
        }

        /// <summary>
        /// 将DataTable转换为List
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="datatable"></param>
        /// <returns></returns>
        public static List<T> ConvertTo<T>(DataTable datatable) where T : new()
        {

            List<T> temp = new List<T>();
            try
            {
                List<string> columnsNames = new List<string>();
                foreach (DataColumn DataColumn in datatable.Columns)
                    columnsNames.Add(DataColumn.ColumnName);
                temp = datatable.AsEnumerable().ToList().ConvertAll<T>(row => GetEntity<T>(row, columnsNames));
                return temp;
            }
            catch
            {
                return temp;
            }
        }

        /// <summary>
        /// 将DataTable转换为List,转换时不将%和$替换成空
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="datatable"></param>
        /// <returns></returns>
        public static List<T> ConvertToNew<T>(DataTable datatable) where T : new()
        {

            List<T> temp = new List<T>();
            try
            {
                List<string> columnsNames = new List<string>();
                foreach (DataColumn DataColumn in datatable.Columns)
                    columnsNames.Add(DataColumn.ColumnName);
                temp = datatable.AsEnumerable().ToList().ConvertAll<T>(row => GetEntityNew<T>(row, columnsNames));
                return temp;
            }
            catch
            {
                return temp;
            }
        }
        /// <summary>
        /// 将DataTable转换为HashTable
        /// </summary>
        /// <typeparam name="T">HashTable保存数据的类型</typeparam>
        /// <param name="dataTable">需要转换的表</param>
        /// <param name="key">HashTable关键字</param>
        /// <param name="obj">数据类型</param>
        /// <returns>转换后的HashTable</returns>
        public static Hashtable TableConvertToHashtable<T>(DataTable dataTable, string key) where T : new()
        {
            Hashtable ht = new Hashtable();
            string keyValue = "";
            List<T> list = ConvertTo<T>(dataTable);
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                T obj = new T();
                //obj = ConvertDataTable<T>(dataTable, i, obj);
                keyValue = dataTable.Rows[i][key].ToString();
                if (!ht.ContainsKey(keyValue))
                    ht.Add(keyValue, (T)list[i]);
            }
            return ht;
        }

        /// <summary>
        /// 属性 copy
        /// </summary>
        /// <param name="tagetClass">目标类</param>
        /// <param name="sourceClass">数据类</param>
        /// <returns></returns>
        public static bool PropertiesCopy(object tagetClass, object sourceClass)
        {
            return PropertiesCopy(tagetClass, sourceClass, false);
        }


        /// <summary>
        /// 属性 copy
        /// </summary>
        /// <param name="tagetClass">目标类</param>
        /// <param name="sourceClass">数据类</param>
        /// <param name="ignoreCase">忽略大小写</param>
        /// <returns>属性 copy是否成功</returns>
        public static bool PropertiesCopy(object tagetClass, object sourceClass, bool ignoreCase)
        {
            try
            {
                PropertyInfo[] tagetPropertyInfos = tagetClass.GetType().GetProperties();
                PropertyInfo[] sourcePropertyInfos = sourceClass.GetType().GetProperties();
                object valueTemp;
                bool flage;
                foreach (PropertyInfo propertyInfo1 in tagetPropertyInfos)
                {
                    valueTemp = null;
                    flage = false;
                    foreach (PropertyInfo propertyInfo2 in sourcePropertyInfos)
                    {
                        if (propertyInfo2.Name.Equals(propertyInfo1.Name, ignoreCase ? StringComparison.CurrentCultureIgnoreCase : StringComparison.CurrentCulture))
                        {
                            valueTemp = propertyInfo2.GetValue(sourceClass, null);
                            flage = true;
                            break;
                        }
                    }
                    if (flage)
                    {

                        Type typeValueTaget = propertyInfo1.PropertyType;
                        Type typeValue = null;
                        if (null == valueTemp)
                        {
                            if (!typeValueTaget.IsGenericType)
                                continue;
                            else
                                propertyInfo1.SetValue(tagetClass, valueTemp, null);
                        }
                        else
                        {
                            typeValue = valueTemp.GetType();
                            if (typeValueTaget != typeValue)
                            {
                                if (typeValue.IsGenericType)
                                    typeValue = typeValue.GetGenericArguments()[0];
                                propertyInfo1.SetValue(tagetClass, Convert.ChangeType(valueTemp, typeValue), null);
                            }
                            else
                            {
                                propertyInfo1.SetValue(tagetClass, valueTemp, null);
                            }
                        }
                    }
                }

                return true;
            }
            catch (Exception e)
            {
                string message = e.Message;
                return false;
            }
        }



        /// <summary>
        /// 属性 copy
        /// </summary>
        /// <param name="tagetClass">目标类</param>
        /// <param name="sourceClass">数据类</param>
        /// <param name="ignoreCase">忽略大小写</param>
        /// <param name="ignoreCase">忽略属性</param>
        /// <returns>属性 copy是否成功</returns>
        public static bool PropertiesCopy(object tagetClass, object sourceClass, bool ignoreCase, List<string> exceptionPrpertyNames)
        {
            try
            {
                PropertyInfo[] tagetPropertyInfos = tagetClass.GetType().GetProperties();
                PropertyInfo[] sourcePropertyInfos = sourceClass.GetType().GetProperties();
                object valueTemp;
                bool flage;
                foreach (PropertyInfo propertyInfo1 in tagetPropertyInfos)
                {
                    if (null != exceptionPrpertyNames && exceptionPrpertyNames.IndexOf(propertyInfo1.Name) >= 0)
                    {
                        continue;
                    }
                    valueTemp = null;
                    flage = false;
                    foreach (PropertyInfo propertyInfo2 in sourcePropertyInfos)
                    {
                        if (propertyInfo2.Name.Equals(propertyInfo1.Name, ignoreCase ? StringComparison.CurrentCultureIgnoreCase : StringComparison.CurrentCulture))
                        {
                            valueTemp = propertyInfo2.GetValue(sourceClass, null);
                            flage = true;
                            break;
                        }
                    }
                    if (flage)
                    {

                        Type typeValueTaget = propertyInfo1.PropertyType;
                        Type typeValue = null;
                        if (null == valueTemp)
                        {
                            if (!typeValueTaget.IsGenericType)
                                continue;
                            else
                                propertyInfo1.SetValue(tagetClass, valueTemp, null);
                        }
                        else
                        {
                            typeValue = valueTemp.GetType();
                            if (typeValueTaget != typeValue)
                            {
                                if (typeValue.IsGenericType)
                                    typeValue = typeValue.GetGenericArguments()[0];
                                propertyInfo1.SetValue(tagetClass, Convert.ChangeType(valueTemp, typeValue), null);
                            }
                            else
                            {
                                propertyInfo1.SetValue(tagetClass, valueTemp, null);
                            }
                        }
                    }
                }

                return true;
            }
            catch (Exception e)
            {
                string message = e.Message;
                return false;
            }
        }

        /// <summary>
        /// 将DataRow转换为Entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="row"></param>
        /// <param name="columnsName"></param>
        /// <returns></returns>
        public static T GetEntity<T>(DataRow row, List<string> columnsName) where T : new()
        {
            T obj = new T();
            try
            {
                string columnname = "";
                string value = "";
                PropertyInfo[] Properties;
                Properties = typeof(T).GetProperties();
                foreach (PropertyInfo objProperty in Properties)
                {
                    columnname = columnsName.Find(name => name.ToLower() == objProperty.Name.ToLower());
                    if (!string.IsNullOrEmpty(columnname))
                    {
                        value = row[columnname].ToString();
                        if (!string.IsNullOrEmpty(value))
                        {
                            if (Nullable.GetUnderlyingType(objProperty.PropertyType) != null)
                            {
                                value = row[columnname].ToString().Replace("$", "").Replace(",", "");
                                objProperty.SetValue(obj, Convert.ChangeType(value, Type.GetType(Nullable.GetUnderlyingType(objProperty.PropertyType).ToString())), null);
                            }
                            else
                            {
                                value = row[columnname].ToString().Replace("%", "");
                                objProperty.SetValue(obj, Convert.ChangeType(value, Type.GetType(objProperty.PropertyType.ToString())), null);
                            }
                        }
                    }
                }
                return obj;
            }
            catch
            {
                return obj;
            }
        }

        /// <summary>
        /// 将DataRow转换为Entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="row"></param>
        /// <param name="columnsName"></param>
        /// <returns></returns>
        public static T GetEntity1<T>(DataRow row, List<string> columnsName) where T : new()
        {
            T obj = new T();
            try
            {
                string columnname = "";
                string value = "";
                PropertyInfo[] Properties;
                Properties = typeof(T).GetProperties();
                foreach (PropertyInfo objProperty in Properties)
                {
                    columnname = columnsName.Find(name => name.ToLower() == objProperty.Name.ToLower());
                    if (!string.IsNullOrEmpty(columnname))
                    {
                        value = row[columnname].ToString();
                        if (!string.IsNullOrEmpty(value))
                        {
                            if (Nullable.GetUnderlyingType(objProperty.PropertyType) != null)
                            {
                                value = row[columnname].ToString().Replace("$", "").Replace(",", "");
                                objProperty.SetValue(obj, Convert.ChangeType(value, Type.GetType(Nullable.GetUnderlyingType(objProperty.PropertyType).ToString())), null);
                            }
                            else
                            {
                                value = row[columnname].ToString();
                                objProperty.SetValue(obj, Convert.ChangeType(value, Type.GetType(objProperty.PropertyType.ToString())), null);
                            }
                        }
                    }
                }
                return obj;
            }
            catch
            {
                return obj;
            }
        }
        /// <summary>
        /// 将DataRow转换为Entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="row"></param>
        /// <param name="columnsName"></param>
        /// <returns></returns>
        public static T GetEntityNew<T>(DataRow row, List<string> columnsName) where T : new()
        {
            T obj = new T();
            try
            {
                string columnname = "";
                string value = "";
                PropertyInfo[] Properties;
                Properties = typeof(T).GetProperties();
                foreach (PropertyInfo objProperty in Properties)
                {
                    columnname = columnsName.Find(name => name.ToLower() == objProperty.Name.ToLower());
                    if (!string.IsNullOrEmpty(columnname))
                    {
                        value = row[columnname].ToString();
                        if (!string.IsNullOrEmpty(value))
                        {
                            if (Nullable.GetUnderlyingType(objProperty.PropertyType) != null)
                            {
                                value = row[columnname].ToString();
                                objProperty.SetValue(obj, Convert.ChangeType(value, Type.GetType(Nullable.GetUnderlyingType(objProperty.PropertyType).ToString())), null);
                            }
                            else
                            {
                                value = row[columnname].ToString();
                                objProperty.SetValue(obj, Convert.ChangeType(value, Type.GetType(objProperty.PropertyType.ToString())), null);
                            }
                        }
                    }
                }
                return obj;
            }
            catch
            {
                return obj;
            }
        }

        /// <summary>
        /// 将Entity增加到表
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="dt">表</param>
        /// <param name="entity">实体</param>
        public static void EntityAddToDataTable<T>(DataTable dt, T entity)
        {
            DataTable newDataTable = new DataTable();
            Type impliedType = typeof(T);
            PropertyInfo[] _propInfo = impliedType.GetProperties();
            DataRow dr = dt.NewRow();
            dr.BeginEdit();
            foreach (PropertyInfo pi in _propInfo)
            {
                try
                {
                    dr[pi.Name] = pi.GetValue(entity, null);
                }
                catch
                {
                }
            }
            dr.EndEdit();
            dt.Rows.Add(dr);
        }


        /// <summary>
        /// 将集合转换成DataTable
        /// </summary>
        /// <typeparam name="T">类实体</typeparam>
        /// <param name="collection">实体集合</param>
        /// <returns>数据集合</returns>
        public static DataTable ToDataTable<T>(IEnumerable<T> collection)
        {
            DataTable newDataTable = new DataTable();
            Type impliedType = typeof(T);
            PropertyInfo[] _propInfo = impliedType.GetProperties();
            foreach (PropertyInfo pi in _propInfo)
                newDataTable.Columns.Add(pi.Name, pi.PropertyType);

            foreach (T item in collection)
            {
                DataRow newDataRow = newDataTable.NewRow();
                newDataRow.BeginEdit();
                foreach (PropertyInfo pi in _propInfo)
                    newDataRow[pi.Name] = pi.GetValue(item, null);
                newDataRow.EndEdit();
                newDataTable.Rows.Add(newDataRow);
            }
            return newDataTable;
        }

        /// <summary>
        /// TList转换为DataTable
        /// </summary>
        /// <typeparam name="T">List类型</typeparam>
        /// <param name="list">需要转换的List</param>
        /// <returns>转换后的DataTable</returns>
        public static DataTable ListToDataTable<T>(List<T> list)
        {
            DataRow dr;

            Type type = list[0].GetType();

            DataTable dt = new DataTable(type.Name);
            // 根据实体建立表的列结构
            foreach (System.Reflection.PropertyInfo p in type.GetProperties())
            {
                Type t = p.PropertyType;

                if (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>))
                    t = t.GetGenericArguments()[0];
                dt.Columns.Add(new DataColumn(p.Name, t));
            }

            // 增加记录
            foreach (T newEntity in list)
            {
                dr = dt.NewRow();
                foreach (System.Reflection.PropertyInfo p in type.GetProperties())
                {
                    object o = p.GetValue(newEntity, null);
                    if (null == o)
                        o = System.DBNull.Value;
                    dr[p.Name] = o;
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }

        /// <summary>
        /// Enum转换
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <param name="entity1"></param>
        /// <param name="entity2"></param>
        /// <returns></returns>
        public static T1 GetEnumValueFromString<T, T1>(T entity1, T1 entity2)
        {
            if (string.IsNullOrEmpty(entity1.ToString())) return default(T1);
            Type type = typeof(T1);
            foreach (string key in Enum.GetNames(type))
            {
                if (key.ToLower().Trim().Equals(entity1.ToString().ToLower().Trim()))
                {
                    return (T1)Enum.Parse(type, key, true);
                }
            }
            return default(T1);
        }

        /// <summary>
        /// 将DataTable指定行转换为Entity
        /// brant
        /// </summary>
        /// <typeparam name="T">Entity类型</typeparam>
        /// <param name="dt">DataTable</param>
        /// <param name="iRow">行号</param>
        /// <param name="entity">转换前的Entity</param>
        /// <returns>转换后的Entity</returns>
        public static T ConvertDataTable<T>(DataTable dt, int iRow, T entity)
        {
            Type type = entity.GetType();

            DataRow dr = dt.Rows[iRow];
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                object o = dr[i];
                string name = dt.Columns[i].ColumnName;
                if (o != DBNull.Value)
                {
                    try
                    {
                        //给属性赋值
                        Type t = type.GetProperty(name).PropertyType;

                        if (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>))
                            t = t.GetGenericArguments()[0];

                        type.GetProperty(name).SetValue(entity, Convert.ChangeType(o, t), null);
                    }
                    catch //如果有错误,继续下一个属性的赋值   
                    {
                        continue;
                    }
                }
            }
            return entity;
        }


        /// <summary>
        /// 感觉没有意义，现在加了一个格式化日期的方法
        /// 获得默认区域信息
        /// </summary>
        public static CultureInfo DefaultCultureInfo
        {
            get
            {
                return CultureInfo.InvariantCulture;
            }
        }

        /// <summary>
        /// 默认数字格式
        /// </summary>
        public static NumberFormatInfo DefaultNumberFormat
        {
            get
            {
                return CultureInfo.InvariantCulture.NumberFormat;
            }
        }

        /// <summary>
        /// 格式化日期
        /// </summary>
        public static DateTimeFormatInfo DefaultDateTimeFormat
        {
            get
            {
                return CultureInfo.InvariantCulture.DateTimeFormat;
            }
        }

        /// <summary>
        /// 从DataTable的指定列中获取不重复的字符串列表，字符串用
        /// </summary>
        /// <param name="dataTable">表名</param>
        /// <param name="fieldName">字段名</param>
        /// <param name="kuoQiFH">字段两边的括号字符串，例如',",]等等</param>
        /// <param name="maxLength">每个字符串的最大长度</param>
        /// <returns>字符串</returns>
        public static List<String> GetUniqueFieldList(DataTable dataTable, string fieldName, string kuoQiFH, int maxLength)
        {
            List<String> list = new List<string>();
            StringBuilder sb = new StringBuilder();
            if (null == kuoQiFH)
                kuoQiFH = "";
            DataTable dtNew = dataTable.DefaultView.ToTable(true, new string[] { fieldName });
            for (int i = 0; i < dtNew.Rows.Count; i++)
            {
                if (maxLength == 0 || sb.ToString().Length + dtNew.Rows[i][fieldName].ToString().Length + 3 < maxLength)
                    sb.Append("," + kuoQiFH + dtNew.Rows[i][fieldName].ToString().Trim() + kuoQiFH);
                else
                {
                    list.Add(sb.ToString().Substring(1, sb.ToString().Length - 1));
                    sb = new StringBuilder();
                }
            }
            if (sb.ToString().Length > 1)
                list.Add(sb.ToString().Substring(1, sb.ToString().Length - 1));
            return list;
        }

        /// <summary>
        /// 格式化数字
        /// </summary>
        /// <param name="d">数字</param>
        /// <param name="Format">格式化类型 例:f2</param>
        /// <returns>格式化数字</returns>
        public static string FormatDecmail(decimal? d, string Format)
        {
            if (d.HasValue)
            {
                return d.Value.ToString(Format);
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// 格式化数字
        /// </summary>
        /// <param name="d">数字</param>
        /// <returns>格式化数字</returns>
        public static string FormatDecmail(decimal? d)
        {
            if (d.HasValue)
            {
                return d.Value.ToString("F2");
            }
            else
            {
                return "";
            }
        }



        /// <summary>
        /// 格式化日期
        /// </summary>
        /// <param name="d">日期</param>
        /// <param name="Format">yyyy-MM-dd</param>
        /// <returns>被格式化的日期字符串</returns>
        public static string FormatDate(DateTime? d, string Format)
        {
            if (d.HasValue)
            {
                System.Globalization.CultureInfo cInfo = new System.Globalization.CultureInfo("zh-CN", false);
                return d.Value.ToString(Format, cInfo);
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// 格式化日期
        /// </summary>
        /// <param name="d">日期</param>
        /// <returns>被格式化的日期字符串</returns>
        public static string FormatDate(DateTime? d)
        {
            return FormatDate(d, "yyyy-MM-dd");
        }

        /// <summary>
        /// 转换为日期型
        /// </summary>
        /// <param name="dt">字符串</param>
        /// <returns>被格式化后的日期字符串</returns>
        public static DateTime? ToDateTime(string dt)
        {
            try
            {
                if (IsEmpty(dt))
                    return null;
                else
                    return Convert.ToDateTime(dt);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 将字符串转换为日期型
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        public static DateTime? ToDateTime(string dt, IFormatProvider provider)
        {
            try
            {
                if (IsEmpty(dt))
                    return null;
                else
                    return Convert.ToDateTime(dt, provider);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 将字符串转为整型
        /// </summary>
        /// <param name="target">字符串，可接受空值</param>
        /// <param name="defaultReturnValue">默认返回值</param>
        /// <returns>the integer value as defined as passed in value</returns>
        public static int? ToInt(string target, int? defaultReturnValue)
        {
            double d;
            if (target.Contains("."))
            {
                target = target.Split('.')[0].ToString();
            }
            return (double.TryParse(target, NumberStyles.Integer, System.Globalization.CultureInfo.CurrentCulture, out d)) ? (int)d : defaultReturnValue;
        }

        /// <summary>
        /// 将字符串转为整型r
        /// </summary>
        /// <param name="target">字符串，可接受空值</param>
        /// <returns>the integer value as defined as passed in value</returns>
        public static int? ToInt(string target)
        {
            return ToInt(target, null);
        }

        /// <summary>
        /// 将字符串转为长整型
        /// </summary>
        /// <param name="target">字符串，可接受空值</param>
        /// <param name="defaultvalue"></param>
        /// <returns>长整型</returns>
        public static long? ToLong(string target, long? defaultvalue)
        {
            double d;
            return (double.TryParse(target, NumberStyles.Integer, System.Globalization.CultureInfo.CurrentCulture, out d)) ? (long)d : defaultvalue;
        }

        /// <summary>
        /// 将字符串转为长整型
        /// </summary>
        /// <param name="target">字符串，可接受空值</param>
        /// <returns>长整型</returns>
        public static long? ToLong(string target)
        {
            return ToLong(target, null);
        }

        /// <summary>
        /// 将字符串转换为Double型
        /// </summary>
        /// <param name="target">字符串，可接受空值</param>
        /// <param name="defaultvalue"></param>
        /// <returns>Double型</returns>
        public static double? ToDouble(string target, double? defaultvalue)
        {
            double d;
            return (double.TryParse(target, NumberStyles.Float, System.Globalization.CultureInfo.CurrentCulture, out d)) ? d : defaultvalue;
        }

        /// <summary>
        /// 将字符串转换为Double型
        /// </summary>
        /// <param name="target">字符串，可接受空值</param>
        /// <returns>Double型</returns>
        public static double? ToDouble(string target)
        {
            return ToDouble(target, null);
        }

        /// <summary>
        /// 将字符串转换为Decimal
        /// </summary>
        /// <param name="target">字符串，可接受空值</param>
        /// <returns>数值型</returns>
        public static Decimal? ToDecimal(string target)
        {
            return ToDecimal(target, null);
        }
        /// <summary>
        /// 将字符串转换为Decimal，如转换失败则返回默认值
        /// </summary>
        /// <param name="target">字符串，可接受空值</param>
        /// <param name="defaultvalue">返回的默认值</param>
        /// <returns>数值型</returns>
        public static Decimal? ToDecimal(string target, decimal? defaultvalue)
        {
            double d;
            return (double.TryParse(target, NumberStyles.Float, System.Globalization.CultureInfo.CurrentCulture, out d)) ? (decimal)d : defaultvalue;
        }

        public static string ToNullableDt(DateTime? dt, bool isAdd = false)
        {
            var str = "yyyy-MM-dd";
            return dt.HasValue ? (isAdd ? dt.Value.AddDays(1).ToString(str) : dt.Value.ToString(str)) : string.Empty;
        }

        /// <summary>
        /// 将字符串转换字符串，注意转换成""
        /// </summary>
        /// <param name="obj">需要转换类型</param>
        /// <returns>字符串</returns>
        public static string ToString(object obj)
        {
            if (obj == null)
            {
                return "";
            }
            else
            {
                if (obj.GetType() == typeof(Decimal) || obj.GetType() == typeof(Double) || obj.GetType() == typeof(Single))
                {
                    return FormatDecmail((Decimal)obj);
                }
                else if (obj.GetType() == typeof(DateTime))
                {
                    return FormatDate((DateTime)obj);
                }
                return obj.ToString();
            }
        }

        /// <summary>
        /// Base64编码
        /// </summary>
        /// <param name="str">待编码的字符串</param>
        /// <returns>编码后的字符串</returns>
        public static string ConvertToBase64String(string str)
        {
            byte[] _Data = System.Text.Encoding.Default.GetBytes(str);
            return Convert.ToBase64String(_Data);
        }

        /// <summary>
        /// UTF8解码
        /// </summary>
        /// <param name="str">待解码的字符串</param>
        /// <returns>解码后的字符串</returns>
        public static string GetStringFromUTF8(string str)
        {
            return HttpUtility.UrlDecode(str);
        }

        /// <summary>
        /// UTF8编码
        /// </summary>
        /// <param name="str">待编码的字符串</param>
        /// <returns>编码后的字符串</returns>
        public static string ConvertToUTF8String(string str)
        {
            byte[] _Data = System.Text.Encoding.Default.GetBytes(str);
            return HttpUtility.UrlEncode(_Data);
        }

        /// <summary>
        /// Base64解码
        /// </summary>
        /// <param name="str">待解码的字符串</param>
        /// <returns>解码后的字符串</returns>
        public static string GetStringFromBase64(string str)
        {
            byte[] _data = Convert.FromBase64String(str);
            return System.Text.Encoding.Default.GetString(_data);
        }

        /// <summary>
        /// 把空字符串变为空字符串
        /// </summary>
        /// <param name="str">要转换的字符串</param>
        /// <returns>转换之后的字符串</returns>
        public static string ConvertEmptyString(string str)
        {
            if (str == string.Empty)
            {
                return "&nbsp;";
            }
            return str;
        }

        /// <summary> 
        /// 转换人民币大小金额 
        /// </summary> 
        /// <param name="num">金额</param> 
        /// <returns>返回大写形式</returns> 
        public static string ToRMB(decimal num)
        {
            string str1 = "零壹贰叁肆伍陆柒捌玖";            //0-9所对应的汉字 
            string str2 = "万仟佰拾亿仟佰拾万仟佰拾元角分"; //数字位所对应的汉字 
            string str3 = "";    //从原num值中取出的值 
            string str4 = "";    //数字的字符串形式 
            string str5 = "";  //人民币大写金额形式 
            int i;    //循环变量 
            int j;    //num的值乘以100的字符串长度 
            string ch1 = "";    //数字的汉语读法 
            string ch2 = "";    //数字位的汉字读法 
            int nzero = 0;  //用来计算连续的零值是几个 
            int temp;            //从原num值中取出的值 

            num = Math.Round(Math.Abs(num), 2);    //将num取绝对值并四舍五入取2位小数 
            str4 = ((long)(num * 100)).ToString();        //将num乘100并转换成字符串形式 
            j = str4.Length;      //找出最高位 
            if (j > 15) { return "溢出"; }
            str2 = str2.Substring(15 - j);   //取出对应位数的str2的值。如：200.55,j为5所以str2=佰拾元角分 

            //循环取出每一位需要转换的值 
            for (i = 0; i < j; i++)
            {
                str3 = str4.Substring(i, 1);          //取出需转换的某一位的值 
                temp = Convert.ToInt32(str3);      //转换为数字 
                if (i != (j - 3) && i != (j - 7) && i != (j - 11) && i != (j - 15))
                {
                    //当所取位数不为元、万、亿、万亿上的数字时 
                    if (str3 == "0")
                    {
                        ch1 = "";
                        ch2 = "";
                        nzero = nzero + 1;
                    }
                    else
                    {
                        if (str3 != "0" && nzero != 0)
                        {
                            ch1 = "零" + str1.Substring(temp * 1, 1);
                            ch2 = str2.Substring(i, 1);
                            nzero = 0;
                        }
                        else
                        {
                            ch1 = str1.Substring(temp * 1, 1);
                            ch2 = str2.Substring(i, 1);
                            nzero = 0;
                        }
                    }
                }
                else
                {
                    //该位是万亿，亿，万，元位等关键位 
                    if (str3 != "0" && nzero != 0)
                    {
                        ch1 = "零" + str1.Substring(temp * 1, 1);
                        ch2 = str2.Substring(i, 1);
                        nzero = 0;
                    }
                    else
                    {
                        if (str3 != "0" && nzero == 0)
                        {
                            ch1 = str1.Substring(temp * 1, 1);
                            ch2 = str2.Substring(i, 1);
                            nzero = 0;
                        }
                        else
                        {
                            if (str3 == "0" && nzero >= 3)
                            {
                                ch1 = "";
                                ch2 = "";
                                nzero = nzero + 1;
                            }
                            else
                            {
                                if (j >= 11)
                                {
                                    ch1 = "";
                                    nzero = nzero + 1;
                                }
                                else
                                {
                                    ch1 = "";
                                    ch2 = str2.Substring(i, 1);
                                    nzero = nzero + 1;
                                }
                            }
                        }
                    }
                }
                if (i == (j - 11) || i == (j - 3))
                {
                    //如果该位是亿位或元位，则必须写上 
                    ch2 = str2.Substring(i, 1);
                }
                str5 = str5 + ch1 + ch2;

                if (i == j - 1 && str3 == "0")
                {
                    //最后一位（分）为0时，加上“整” 
                    str5 = str5 + '整';
                }
            }
            if (num == 0)
            {
                str5 = "零元整";
            }
            return str5;
        }

        /// <summary>
        /// 防SQL注入式攻击
        /// </summary>
        /// <param name="s">要处理的字符串</param>
        /// <returns>处理过的字符串</returns>
        public static string SafeSQL(string s)
        {
            s = s.Replace("'", "''");
            s = s.Replace("-", "");
            s = s.Replace("*", "");
            s = s.Replace(" ", "");
            s = s.Replace("\"", "");
            s = s.Replace("[", "");
            s = s.Replace("]", "");
            s = s.Replace("%", "");
            s = s.Replace(";", "");
            s = s.Replace(":", "");
            s = s.Replace("+", "");
            s = s.Replace("{", "");
            s = s.Replace("}", "");

            return s;
        }

        /// <summary>
        /// 防SQL注入式攻击
        /// </summary>
        /// <param name="s">要处理的字符串</param>
        /// <param name="type">1 sql;2 orcale</param>
        /// <returns>处理过的字符串</returns>
        public static string SafeSQL(string s, int type)
        {
            if (type == 2)//orcale
            {
                //s = s.Replace("'", "/'");
                s = s.Replace("-", "/-");
                s = s.Replace("*", "/*");
                //s = s.Replace(" ", "/");
                s = s.Replace("\"", "/\"");
                s = s.Replace("[", "/[");
                s = s.Replace("]", "/]");
                s = s.Replace("%", "/%");
                s = s.Replace(";", "/;");
                s = s.Replace(":", "/:");
                s = s.Replace("+", "/+");
                s = s.Replace("{", "/{");
                s = s.Replace("}", "/}");
                s = s.Replace("/", "//");
                return s;
            }
            else if (type == 1)//sql
            {
                return SafeSQL(s);
            }
            return string.Empty;
        }

        /// <summary>
        /// Undo防SQL注入式攻击
        /// </summary>
        /// <param name="s">要处理的字符串</param>
        /// <returns>处理过的字符串</returns>
        public static string UndoSafeSQL(string s)
        {
            s = s.Replace("''", "'");
            //s = s.Replace("'_", "_");
            //s = s.Replace("'*", "*");
            //s = s.Replace("'\"", "\"");
            //s = s.Replace("'[", "[");
            //s = s.Replace("']", "]");
            //s = s.Replace("'%", "%");
            //s = s.Replace("';", ";");
            //s = s.Replace("':", ":");
            //s = s.Replace("'+", "+");
            //s = s.Replace("'{", "{");
            //s = s.Replace("'}", "}");

            return s;
        }

        /// <summary>
        /// 检查字符串是否为空
        /// </summary>
        /// <param name="s">字符串</param>
        /// <returns>是否为空</returns>
        private static bool IsEmpty(string s)
        {
            return (s == null || s.Length <= 0);
        }

        /// <summary>
        /// 将Hashtable转为DictionaryEntry
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public static DictionaryEntry[] ConvertHashtableToDictionaryEntry(Hashtable ht)
        {
            DictionaryEntry[] de = new DictionaryEntry[ht.Count];
            int i = 0;
            foreach (DictionaryEntry entry in ht)
            {
                de[i].Key = entry.Key;
                de[i].Value = entry.Value;
                i++;
            }
            return de;
        }

        public static IList<T> ConvertToModel<T>(DataTable dt) where T : new()
        {

            IList<T> ts = new List<T>();// 定义集合
            Type type = typeof(T); // 获得此模型的类型
            string tempName = "";
            foreach (DataRow dr in dt.Rows)
            {
                T t = new T();
                PropertyInfo[] propertys = t.GetType().GetProperties();// 获得此模型的公共属性
                foreach (PropertyInfo pi in propertys)
                {
                    tempName = pi.Name;
                    if (dt.Columns.Contains(tempName))
                    {
                        if (!pi.CanWrite) continue;
                        object value = dr[tempName];
                        if (value != DBNull.Value)
                            pi.SetValue(t, value, null);
                    }
                }
                ts.Add(t);
            }
            return ts;
        }

        /// <summary>
        /// 将DataTable的指定行转换为Entity
        /// </summary>
        /// <typeparam name="T">需转换的实体类型</typeparam>
        /// <param name="dataTable">转换的源DataTable</param>
        /// <param name="rowIndex">行</param>
        /// <returns>转换后的实体</returns>
        public static T ConvertDataTable<T>(DataTable dataTable, int rowIndex)
        {
            if (rowIndex >= dataTable.Rows.Count || rowIndex < 0)
            {
                return default(T);
            }
            return ConvertDataRow<T>(dataTable.Rows[rowIndex]);
        }

        /// <summary>
        /// 将DataTable的指定行转换为Entity
        /// </summary>
        /// <typeparam name="T">需转换的实体类型</typeparam>
        /// <param name="dataTable">转换的源DataTable</param>
        /// <param name="beginRowIndex">开始行</param>
        /// <param name="endRowIndex">结束行</param>
        /// <returns>转换后的实体list</returns>
        public static List<T> ConvertDataTable<T>(DataTable dataTable, int beginRowIndex, int endRowIndex)
        {
            List<T> list = new List<T>();
            int temp;
            if (beginRowIndex > endRowIndex)
            {
                temp = beginRowIndex;
                beginRowIndex = endRowIndex;
                endRowIndex = temp;
            }
            if (beginRowIndex < 0)
            {
                beginRowIndex = 0;
            }
            if (endRowIndex > dataTable.Rows.Count - 1)
            {
                endRowIndex = dataTable.Rows.Count - 1;
            }
            for (temp = beginRowIndex; temp <= endRowIndex; temp++)
            {
                list.Add(ConvertDataRow<T>(dataTable.Rows[temp]));
            }
            return list;
        }

        /// <summary>
        /// 根据筛选条件将单行DataTable转Entity
        /// </summary>
        /// <typeparam name="T">Entity类型</typeparam>
        /// <param name="dt">DataTable</param>
        /// <param name="filter">筛选条件</param>
        /// <param name="entity">转换前的Entity</param>
        /// <returns>转换后的Entity</returns>
        public static T ConvertDataTable<T>(DataTable dt, string filter, T entity)
        {
            Type type = entity.GetType();
            DataRow[] adr = dt.Select(filter);

            for (int i = 0; i < dt.Columns.Count; i++)
            {
                object o = adr[0][i];
                string name = dt.Columns[i].ColumnName;
                if (o != DBNull.Value)
                {
                    try
                    {
                        //给属性赋值
                        Type t = type.GetProperty(name).PropertyType;

                        if (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>))
                            t = t.GetGenericArguments()[0];

                        type.GetProperty(name).SetValue(entity, Convert.ChangeType(o, t), null);
                    }
                    catch //如果有错误,继续下一个属性的赋值   
                    {
                        continue;
                    }
                }
            }
            return entity;
        }

        /// <summary>
        /// 将DataRow的指定行转换为Entity
        /// </summary>
        /// <typeparam name="T">需转换的实体类型</typeparam>
        /// <param name="dataRow">转换的源dataRow</param>
        /// <returns>转换后的实体</returns>
        public static T ConvertDataRow<T>(DataRow dataRow)
        {
            Type type = typeof(T);
            T entity = (T)type.Assembly.CreateInstance(type.FullName);
            for (int i = 0; i < dataRow.Table.Columns.Count; i++)
            {
                object o = dataRow[i];
                string name = dataRow.Table.Columns[i].ColumnName;
                if (o != DBNull.Value)
                {
                    try
                    {
                        //给属性赋值
                        Type t = type.GetProperty(name).PropertyType;

                        if (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>))
                            t = t.GetGenericArguments()[0];

                        type.GetProperty(name).SetValue(entity, Convert.ChangeType(o, t), null);
                    }
                    catch //如果有错误,继续下一个属性的赋值   
                    {
                        continue;
                    }
                }
            }
            return entity;
        }

        /// <summary>
        /// 将DataTable转换为List
        /// </summary>
        /// <typeparam name="T">类别</typeparam>
        /// <param name="dataTable">数据</param>
        /// <returns></returns>
        public static System.Collections.Generic.List<T> ConvertDataTable<T>(DataTable dataTable)
        {
            List<T> list = new List<T>();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                list.Add(ConvertDataRow<T>(dataRow));
            }
            return list;
        }


        /// <summary>
        /// 过滤用户输入非法字符
        /// </summary>
        /// <param name="text">用户输入的字符</param>
        /// <returns>过滤后内容</returns>
        public static string InputText(string text)
        {
            text = text.Trim();
            if (string.IsNullOrEmpty(text))
                return string.Empty;
            text = Regex.Replace(text, "[\\s]{2,}", " ");   //two or more spaces
            text = Regex.Replace(text, "(<[b|B][r|R]/*>)+|(<[p|P](.|\\n)*?>)", "\n");   //<br>
            text = Regex.Replace(text, "(\\s*&[n|N][b|B][s|S][p|P];\\s*)+", " ");   //&nbsp;
            text = Regex.Replace(text, "<(.|\\n)*?>", string.Empty);    //any other tags
            text = text.Replace("'", "''");
            return text;
        }

        /// <summary>
        /// 检测字符串中是否有非法的字符，如果有，返回true
        /// </summary>
        /// <param name="inputWord">用户输入字符</param>
        /// <returns></returns>
        public static bool CheckBadWord(string inputWord)
        {
            string[] arryWord = ArryBadWord();
            bool isok = false;
            foreach (string str in arryWord)
            {
                if (!string.IsNullOrEmpty(str))
                {
                    if (inputWord.IndexOf(str) > -1)
                    {
                        isok = true;
                        return isok;
                    }
                }
            }
            return isok;
        }

        /// <summary>
        /// 非法字符存储数组
        /// </summary>
        /// <returns></returns>
        private static string[] ArryBadWord()
        {
            string[] bad = new string[64];
            bad[0] = "'";  //英文单引号
            bad[1] = "\"";
            bad[2] = ";";
            bad[3] = "--";
            bad[4] = ",";
            bad[5] = "!";
            bad[6] = "~";
            bad[7] = "@";
            bad[8] = "#";
            bad[9] = "$";
            bad[10] = "%";
            bad[11] = "^";
            bad[12] = "&";
            bad[13] = "  ";
            bad[14] = "_";
            bad[15] = "'";  //全角单引号
            bad[16] = "‘"; //中文左单引号
            bad[17] = "’"; //中文有单引号
            return bad;
        }

        /// <summary>
        /// 将DataRow转换成指定类型
        /// </summary>
        /// <param name="pDataRow">pDataRow</param>
        /// <param name="pType">pType</param>
        /// <returns>返回转换对象</returns>
        private static Object ConvertToEntity(DataRow pDataRow, Type pType)
        {
            Object entity = null;
            Object proValue = null;
            PropertyInfo propertyInfo = null;
            try
            {
                if (pDataRow != null)
                {
                    //动态创建类的实例
                    entity = Activator.CreateInstance(pType);
                    foreach (DataColumn dc in pDataRow.Table.Columns)
                    {
                        //忽略绑定时的大小写
                        propertyInfo = pType.GetProperty(dc.ColumnName, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
                        proValue = pDataRow[dc];
                        //当值不为空时[Page]
                        if (proValue != DBNull.Value)
                        {
                            try
                            {   //给属性赋值
                                propertyInfo.SetValue(entity, Convert.ChangeType(proValue, dc.DataType), null);
                            }
                            catch //如果有错误,继续下一个属性的赋值
                            {
                                continue;
                            }
                        }
                    }
                }
            }
            catch
            {
                entity = new object();
            }
            return entity;
        }

    }
}
