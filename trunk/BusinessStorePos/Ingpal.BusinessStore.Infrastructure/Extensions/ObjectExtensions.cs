using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ingpal.BusinessStore.Model;
using System.Reflection;

namespace Ingpal.BusinessStore.Infrastructure
{
    public static class ObjectExtensions
    {
        public static object ChangeType(this object value, Type conversionType)          //第一个参数加this,表示该ChangeType方法将为object的扩展方法
        {
            if (conversionType.IsGenericType &&
                    conversionType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {
                if (value != null)
                {
                    NullableConverter nullableConverter = new NullableConverter(conversionType);
                    conversionType = nullableConverter.UnderlyingType;
                }
                else
                {
                    return null;
                }
            }
            //return Convert.ChangeType(value, conversionType);
            if (conversionType.Equals(typeof(System.DateTime)) && (value.Equals("")))
            {
                return null;
            }
            else if (conversionType.Equals(typeof(System.Boolean)) && (value.Equals("")))//如果为bool类型，值为空，返回false
            {
                return false;
            }
            else if (conversionType.Equals(typeof(System.Guid)))
            {
                if (value == null || value == "")
                {
                    return null;
                }
                else
                {
                    return new Guid(value.ToString());
                }
            }
            else if (conversionType.Equals(typeof(System.Decimal)) && (value.Equals("")))
            {
                return null;
            }
            else if (conversionType.Equals(typeof(System.Int32)) && (value.Equals("")))
            {
                return null;
            }
            else if (conversionType.Equals(typeof(System.Single)) && (value.Equals("")))
            {
                return null;
            }
            else
            {
                return Convert.ChangeType(value, conversionType);
            }
        }
        public static MDMEntity GetOne(this List<MDMEntity> list, Func<MDMEntity, bool> expression)
        {
            return list.Where(expression).ToList().FirstOrDefault();
        }
        //public static string GetOneName(this List<MDMEntity> list, string name, string code)
        //{
        //    var rs = list.Where(item => item.MDMName == name && item.MDMCode == code);
        //    return rs.Count() > 0 ? rs.FirstOrDefault().MDMValue : null;
        //}
        public static string GetOneName(this List<MDMTypeSubEntity> list, string name, string code)
        {
            var rs = list.Where(item => item.MDMTypeName == name && item.SubName == code);
            return rs.Count() > 0 ? rs.FirstOrDefault().SubValue : null;
        }
        /// <summary>
        /// 实体类型转换为object数组
        /// </summary>
        /// <param name="entityObject"></param>
        /// <returns></returns>
        public static object[] ToObjectArray(this object entityObject)
        {
            List<object> objects = new List<object>();
            Type type = entityObject.GetType();
            PropertyInfo[] properties = type.GetProperties();
            foreach (var proper in properties)
            {
                var pType = proper.PropertyType;
                var value = proper.GetValue(entityObject, null) ?? "";
                if (pType.Equals(typeof(System.DateTime?)) || pType.Equals(typeof(System.DateTime)))
                {
                    if (value == (object)"" || !(((DateTime)value) > DateTime.MinValue))
                        value = null;
                }
                objects.Add(value);
            }
            return objects.ToArray();
        }
    }
}
