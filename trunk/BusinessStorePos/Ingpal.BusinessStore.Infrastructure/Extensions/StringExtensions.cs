using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ingpal.BusinessStore.Infrastructure
{
    public static class StringExtensions
    {
        internal const string TRUE = "TRUE";
        internal const string FALSE = "FALSE";
        internal const char TRIM_CHAR = '\\';
        internal const string SLASH = "/";
        internal const string BACKSLASH = "\\";

        public static bool ToBoolean(this string trueOrFalse)
        {
            var ret = false;
            if (string.IsNullOrEmpty(trueOrFalse) == false)
            {
                ret = trueOrFalse.Trim().EqualsOrdinalIgnoreCase(TRUE);
            }

            return ret;
        }
        static public string ToSafeSql(this string str)
        {
            str = string.IsNullOrEmpty(str) ? "" : str.Replace("'", "''");
            str = new Regex("exec", RegexOptions.IgnoreCase).Replace(str, "&#101;xec");
            str = new Regex("xp_cmdshell", RegexOptions.IgnoreCase).Replace(str, "&#120;p_cmdshell");
            str = new Regex("select", RegexOptions.IgnoreCase).Replace(str, "&#115;elect");
            str = new Regex("insert", RegexOptions.IgnoreCase).Replace(str, "&#105;nsert");
            str = new Regex("update", RegexOptions.IgnoreCase).Replace(str, "&#117;pdate");
            str = new Regex("delete", RegexOptions.IgnoreCase).Replace(str, "&#100;elete");

            str = new Regex("drop", RegexOptions.IgnoreCase).Replace(str, "&#100;rop");
            str = new Regex("create", RegexOptions.IgnoreCase).Replace(str, "&#99;reate");
            str = new Regex("rename", RegexOptions.IgnoreCase).Replace(str, "&#114;ename");
            str = new Regex("truncate", RegexOptions.IgnoreCase).Replace(str, "&#116;runcate");
            str = new Regex("alter", RegexOptions.IgnoreCase).Replace(str, "&#97;lter");
            str = new Regex("exists", RegexOptions.IgnoreCase).Replace(str, "&#101;xists");
            str = new Regex("master.", RegexOptions.IgnoreCase).Replace(str, "&#109;aster.");
            str = new Regex("restore", RegexOptions.IgnoreCase).Replace(str, "&#114;estore");
            return str;
        }

        public static double ToDouble(this string doubleString)
        {
            double dValue = 0.0;
            double.TryParse(doubleString, out dValue);
            return dValue;
        }
        public static decimal ToDecimal(this string doubleString)
        {
            decimal dValue = 0.0m;
            decimal.TryParse(doubleString, out dValue);
            return dValue;
        }
        public static double? ToNullableDouble(this string doubleString)
        {
            double? dValue = null;
            double Value = 0.0;
            double.TryParse(doubleString, out Value);
            return Value == 0.0 ? dValue : Value;
        }

        public static float ToFloat(this string floatString)
        {
            float dValue = 0.0f;
            float.TryParse(floatString, out dValue);
            return dValue;
        }

        /// <summary>
        /// 确定两个指定的 System.String 对象是否具有相同的值,不区分大小写
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static bool EqualsOrdinalIgnoreCase(this string A, string B)
        {
            return string.Equals(A, B, StringComparison.OrdinalIgnoreCase);
        }
        /// <summary>
        /// 从配置文件中读取对应字段的值
        /// </summary>
        /// <param name="configKey"></param>
        /// <returns></returns>
        public static string ConfigValue(this string configKey)
        {
            string configValue = null;
            if (ConfigurationManager.AppSettings.AllKeys.Contains<string>(configKey))
            {
                configValue = ConfigurationManager.AppSettings[configKey];
            }
            return configValue;
        }

        /// <summary>
        /// yyyyMMddHHmmss
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static DateTime? ToLongDateTimeFormat(this String str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return null;
            }
            else
            {
                return DateTime.ParseExact(str, "yyyyMMddHHmmss", System.Globalization.CultureInfo.CurrentCulture);
            }
        }

        public static String ToMinuteSecond(this String str)
        {
            var timeString = string.Empty;

            if (string.IsNullOrWhiteSpace(str) == false)
            {
                var timeSpan = new TimeSpan(0, 0, int.Parse(str));

                if (timeSpan.Hours < 1) timeString = timeSpan.ToString().Remove(0, 3);
                else timeString = timeSpan.ToString();
            }

            return timeString;
        }
        public static string ToNull(this String str)
        {
            if (string.IsNullOrEmpty(str)) {
                return null;
            }
            return str;
        }

        public static DateTime? ToDateTime(this String str)
        {
            if (string.IsNullOrWhiteSpace(str)) return null;

            DateTime res;
            if (DateTime.TryParse(str, out res))
            {
                return res;
            }
            return null;
        }
        public static DateTime? ToDateTime(this object str)
        {
            if (str==null) return null;

            DateTime res;
            if (DateTime.TryParse(str.ToString(), out res))
            {
                return res;
            }
            return null;
        }
        public static string ToDateTimeString(this String str,string format="")
        {
            string dtString = string.Empty;
            if (string.IsNullOrWhiteSpace(str)) return null;

            DateTime res;
            if (DateTime.TryParse(str, out res))
            {
                if (!string.IsNullOrEmpty(format))
                {
                    dtString=res.ToString(format);
                }
                return dtString;
            }
            return null;
        }

        public static int ToInt32(this string strValue)
        {
            int iValue;
            int.TryParse(strValue, out iValue);
            return iValue;
        }

        public static int? ToNullableInt32(this string strValue)
        {
            if (string.IsNullOrEmpty(strValue)) return null;

            int iValue;
            int.TryParse(strValue, out iValue);
            return iValue;
        }

        public static decimal? ToNullableDecimal(this string strValue)
        {
            if (string.IsNullOrEmpty(strValue)) return null;

            decimal iValue;
            decimal.TryParse(strValue, out iValue);
            return iValue;
        }

        public static string ReplaceWhiteSpacesWithOneSpace(this string strValue)
        {
            Regex r = new Regex(@"\s+");

            return r.Replace(strValue, " ");
        }

        public static string SubStringBySDBC(this string strData, int startindex, int length, int codepage = 0)
        {
            string strRtn = string.Empty;
            byte[] arybytData = Encoding.GetEncoding(codepage).GetBytes(strData);
            byte[] arybytTemp = new byte[length];
            Array.Copy(arybytData, startindex, arybytTemp, 0, length);
            strRtn = Encoding.GetEncoding(codepage).GetString(arybytTemp, 0, length);
            if (Encoding.GetEncoding(codepage).GetByteCount(strRtn) > length)
            {
                strRtn = strRtn.Substring(0, strRtn.Length - 1); ;
            }
            return strRtn;
        }
        public static string ReplaceSQL(this string sql)
        {
            return sql.Replace("&nbsp;", "").Replace("-99999", "");
        }
        public static T ToObject<T>(this string Json)
        {
            return Json == null ? default(T) : JsonConvert.DeserializeObject<T>(Json);
        }

        #region 获取本地配置密钥
        /// <summary>
        /// 获取本地配置密钥
        /// </summary>
        /// <returns></returns>
        public static string GetConfigKey()
        {
            //一获取加密的key
            string key = System.Configuration.ConfigurationManager.AppSettings["SHA_Key"];

            return key;
        }
        #endregion

        public static string HMACSHA1(this  string text, string secretKey)
        {
            HMACSHA1 hmacsha1 = new HMACSHA1();
            hmacsha1.Key = Encoding.UTF8.GetBytes(secretKey);
            byte[] dataBuffer = Encoding.UTF8.GetBytes(text);
            byte[] hashBytes = hmacsha1.ComputeHash(dataBuffer);
            return Convert.ToBase64String(hashBytes);
        }
    }
}
