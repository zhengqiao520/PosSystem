using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ingpal.BusinessStore.Infrastructure
{
    public class ValidateUtil
    {
        public static bool IsGreaterZero(String input)
        {
            try
            {
                return float.Parse(input) > 0;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsInt(String input)
        {
            try
            {
                int.Parse(input);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static decimal GetDecimal(String input)
        {
            try
            {
                return decimal.Parse(input);
            }
            catch
            {
                return 0;
            }
        }

        public static DateTime GetDateTime(String input)
        {
            try
            {
                return DateTime.Parse(input);
            }
            catch
            {
                return DateTime.Now;
            }
        }

        public static int GetInt(String input)
        {
            try
            {
                return int.Parse(input);
            }
            catch
            {
                return 0;
            }
        }


        //计算文件的MD5码
        public static string MD5Hash(string pathName)
        {
            string strResult = "";
            string strHashData = "";

            byte[] arrbytHashValue;
            System.IO.FileStream oFileStream = null;

            System.Security.Cryptography.MD5CryptoServiceProvider oMD5Hasher =
                       new System.Security.Cryptography.MD5CryptoServiceProvider();

            try
            {
                oFileStream = new System.IO.FileStream(pathName, System.IO.FileMode.Open,
                      System.IO.FileAccess.Read, System.IO.FileShare.ReadWrite);
                arrbytHashValue = oMD5Hasher.ComputeHash(oFileStream);//计算指定Stream 对象的哈希值
                oFileStream.Close();
                //由以连字符分隔的十六进制对构成的String，其中每一对表示value 中对应的元素；例如“F-2C-4A”
                strHashData = System.BitConverter.ToString(arrbytHashValue);
                //替换-
                strHashData = strHashData.Replace("-", "");
                strResult = strHashData;
            }
            catch
            {
                //MessageBox.Show(ex.Message);
            }

            return strResult;
        }
    }
}
