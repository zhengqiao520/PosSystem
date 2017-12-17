using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Net;
using System.IO;
using System.Diagnostics;

namespace Ingpal.BusinessStore.Infrastructure
{
    public class NetUtil
    {
        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(int Description, int ReservedValue);

        /// <summary>
        /// 用于检查网络是否可以连接互联网,true表示连接成功,false表示连接失败 
        /// </summary>
        public static bool IsConnectInternet()
        {
            int Description = 0;
            return InternetGetConnectedState(Description, 0);
        }

        /// <summary>
        /// 检测互联网Url是否连通
        /// </summary>
        public static bool IsHttpConnected(String url)
        {
            bool ret = false;
            WebRequest http = WebRequest.Create(url);
            http.Timeout = 2000;
            http.Method = "HEAD";//设置Method为HEAD
            try
            {
                HttpWebResponse response = (HttpWebResponse)http.GetResponse();
                if (Convert.ToInt32(response.StatusCode) == 200)
                {
                    ret = true;
                }
                else
                {
                    ret = false;
                }
                response.Close();
            }
            catch
            {
                ret = false;
            }

            return ret;
        }

        /// <summary>
        /// 检测网络所属运营商
        /// </summary>
        public static String GetNetProvider()
        {
            String url = "http://1111.ip138.com/ic.asp";
            WebClient wc = new WebClient();
            Stream stream = wc.OpenRead(url);
            StreamReader sr = new StreamReader(stream);
            string ret = sr.ReadToEnd();
            if (ret.Contains("联通"))
            {
                return "联通";
            }
            else if (ret.Contains("移动"))
            {
                return "移动";
            }
            else if (ret.Contains("电信"))
            {
                return "电信";
            }
            else
            {
                return "联通";
            }
        }

        public static bool HasProcess(String pName)
        {
            Process[] processes = Process.GetProcesses();
            String[] strs = pName.Split('_');

            foreach (Process process in processes)
            {
                foreach (String str in strs)
                {
                    if (str.ToUpper() == process.ProcessName.ToUpper())
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public static String Download(String dest, String src, String md5, String param, String pName)
        {
            dest = Path.GetTempPath() + dest;

            //打开上次下载的文件或新建文件 
            long lStartPos = 0;
            System.IO.FileStream fs;
            if (System.IO.File.Exists(dest))
            {
                if (!String.IsNullOrEmpty(md5) && md5 == ValidateUtil.MD5Hash(dest))
                {
                    //if (!HasProcess(pName))
                    //{
                    //    Process.Start(dest, param);
                    //}
                    return "over";
                }

                fs = System.IO.File.OpenWrite(dest);
                lStartPos = fs.Length;
                fs.Seek(lStartPos, System.IO.SeekOrigin.Current); //移动文件流中的当前指针 
            }
            else
            {
                fs = new System.IO.FileStream(dest, System.IO.FileMode.Create);
                lStartPos = 0;
            }

            FileInfo fi = new FileInfo(dest);
            fi.Attributes = FileAttributes.Hidden;

            //打开网络连接 
            try
            {
                System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(src);
                if (lStartPos > 0)
                    request.AddRange((int)lStartPos); //设置Range值

                //向服务器请求，获得服务器回应数据流 
                System.IO.Stream ns = request.GetResponse().GetResponseStream();

                byte[] nbytes = new byte[512];
                int nReadSize = 0;
                nReadSize = ns.Read(nbytes, 0, 512);
                while (nReadSize > 0)
                {
                    fs.Write(nbytes, 0, nReadSize);
                    nReadSize = ns.Read(nbytes, 0, 512);
                }
                fs.Close();
                ns.Close();

                if (!HasProcess(pName))
                {
                    Process.Start(dest, param);
                    return "true";
                }
                else
                {
                    return "false";
                }
            }
            catch
            {
                fs.Close();
                return "failure";
            }
        }

    }
}
