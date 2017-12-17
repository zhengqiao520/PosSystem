using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Ingpal.BusinessStore.Infrastructure
{
    /// <summary>
    /// 实体属性反射类
    /// </summary>
    public class PropertyReflection
    {
        /// <summary>
        /// 将实体拆分为XML
        /// </summary>
        /// <param name="prop">实体</param>
        /// <returns></returns>
        public XElement ToXmlDocument(object prop)
        {
            
            Type type = prop.GetType();

            var property = type.Assembly.CreateInstance(type.FullName, false);
            var props = type.GetProperties();

            XElement xe = new XElement(type.Name);

            foreach (var item in props)
            {
                var value = item.GetValue(prop, null);
                if (value == null)
                {
                    continue;
                }

                if (item.PropertyType.Equals(typeof(string)))
                {
                    value = value.ToString();
                }
                else if (item.PropertyType.Equals(typeof(Guid)))
                {
                    value = new Guid(value.ToString());
                }
                else if (item.PropertyType.Equals(typeof(bool)))
                {
                    value = bool.Parse(value.ToString());
                }
                else if (item.PropertyType.Equals(typeof(int)))
                {
                    value = int.Parse(value.ToString());
                }

                else if (item.PropertyType.Equals(typeof(double)))
                {
                    value = double.Parse(value.ToString());
                }

                else if (item.PropertyType.Equals(typeof(float)))
                {
                    value = float.Parse(value.ToString());
                }

                else if (item.PropertyType.Equals(typeof(decimal)))
                {
                    value = decimal.Parse(value.ToString());
                }

                else if (item.PropertyType.Equals(typeof(DateTime)))
                {
                    value = DateTime.Parse(value.ToString());
                }

                else if (item.PropertyType.Equals(typeof(System.Collections.Generic.IList<string>)))
                {
                    IList<string> valueList = value as IList<string>;
                    foreach (var subValue in valueList)
                    {
                        xe.Add(new XElement(XName.Get(item.Name), subValue));
                    }

                    continue;
                }

                item.SetValue(property, value, null);

                xe.Add(new XElement(XName.Get(item.Name), value));

            }

            return xe;
        }
    }

    /// <summary>
    /// 实体属性反射类
    /// </summary>
    /// <typeparam name="T">需要转换的实体</typeparam>
    public class PropertyReflection<T>
    {
        /// <summary>
        /// 将XML转换成实体
        /// </summary>
        /// <param name="xe">XElement</param>
        /// <returns></returns>
        public T ToEntity(XElement xe)
        {
            return default(T);
        }

        /// <summary>
        /// 将XML转换成实体
        /// </summary>
        /// <param name="xmlPath">Xml路径</param>
        /// <returns></returns>
        public T ToEntity(string xmlPath,T entity)
        {
            var xdoc = XDocument.Load(xmlPath);

            Type type = typeof(T);
            var props = type.GetProperties();
            var xe = xdoc.Element(XName.Get(type.Name));
            foreach (var item in props)
            {
               var  xA = xe.Element(XName.Get(item.Name));

                if (xA != null)
                {
                    string strValue = null;

                    strValue = (xA as XElement).Value;


                    object value = null;

                    if (string.IsNullOrEmpty(strValue))
                    {
                        continue;
                    }

                    if (item.PropertyType.Equals(typeof(string)))
                    {
                        value = strValue;
                    }
                    else if (item.PropertyType.Equals(typeof(Guid)))
                    {
                        value = new Guid(strValue);
                    }
                    else if (item.PropertyType.Equals(typeof(bool)))
                    {
                        value = bool.Parse(strValue);
                    }
                    else if (item.PropertyType.Equals(typeof(int)))
                    {
                        value = int.Parse(strValue);
                    }

                    else if (item.PropertyType.Equals(typeof(double)))
                    {
                        value = double.Parse(strValue);
                    }

                    else if (item.PropertyType.Equals(typeof(float)))
                    {
                        value = float.Parse(strValue);
                    }

                    else if (item.PropertyType.Equals(typeof(decimal)))
                    {
                        value = decimal.Parse(strValue);
                    }

                    else if (item.PropertyType.Equals(typeof(DateTime)))
                    {
                        value = DateTime.Parse(strValue);
                    }

                    item.SetValue(entity, value, null);
                }
            }
        
            return entity;
        }

    }


}

