﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Net;
using System.IO;
using System.Diagnostics;
using System.Web;
using System.Net.Sockets;
using System.Net.NetworkInformation;

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


        /// <summary>
        /// 网络操作
        /// </summary>
        
    }
    public class Net
    {
        #region Ip(获取Ip)
        /// <summary>
        /// 获取Ip
        /// </summary>
        public static string Ip
        {
            get
            {
                var result = string.Empty;
                if (HttpContext.Current != null)
                    result = GetWebClientIp();
                if (string.IsNullOrEmpty(result))
                    result = GetLanIp();
                return result;
            }
        }

        /// <summary>
        /// 获取Web客户端的Ip
        /// </summary>
        private static string GetWebClientIp()
        {
            var ip = GetWebRemoteIp();
            foreach (var hostAddress in Dns.GetHostAddresses(ip))
            {
                if (hostAddress.AddressFamily == AddressFamily.InterNetwork)
                    return hostAddress.ToString();
            }
            return string.Empty;
        }

        /// <summary>
        /// 获取Web远程Ip
        /// </summary>
        private static string GetWebRemoteIp()
        {
            return HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] ?? HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
        }

        /// <summary>
        /// 获取局域网IP
        /// </summary>
        private static string GetLanIp()
        {
            foreach (var hostAddress in Dns.GetHostAddresses(Dns.GetHostName()))
            {
                if (hostAddress.AddressFamily == AddressFamily.InterNetwork)
                    return hostAddress.ToString();
            }
            return string.Empty;
        }

        #endregion

        #region Host(获取主机名)

        /// <summary>
        /// 获取主机名
        /// </summary>
        public static string Host
        {
            get
            {
                return HttpContext.Current == null ? Dns.GetHostName() : GetWebClientHostName();
            }
        }

        /// <summary>
        /// 获取Web客户端主机名
        /// </summary>
        private static string GetWebClientHostName()
        {
            if (!HttpContext.Current.Request.IsLocal)
                return string.Empty;
            var ip = GetWebRemoteIp();
            var result = Dns.GetHostEntry(IPAddress.Parse(ip)).HostName;
            if (result == "localhost.localdomain")
                result = Dns.GetHostName();
            return result;
        }

        #endregion

        #region 获取mac地址
        /// <summary>
        /// 返回描述本地计算机上的网络接口的对象(网络接口也称为网络适配器)。
        /// </summary>
        /// <returns></returns>
        public static NetworkInterface[] NetCardInfo()
        {
            return NetworkInterface.GetAllNetworkInterfaces();
        }
        ///<summary>
        /// 通过NetworkInterface读取网卡Mac
        ///</summary>
        ///<returns></returns>
        public static List<string> GetMacByNetworkInterface()
        {
            List<string> macs = new List<string>();
            NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface ni in interfaces)
            {
                macs.Add(ni.GetPhysicalAddress().ToString());
            }
            return macs;
        }
        #endregion

        #region Ip城市(获取Ip城市)
        /// <summary>
        /// 获取IP地址信息
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static string GetLocation(string ip)
        {
            string res = "";
            try
            {
                string url = "http://apis.juhe.cn/ip/ip2addr?ip=" + ip + "&dtype=json&key=b39857e36bee7a305d55cdb113a9d725";
                res = HttpMethods.HttpGet(url);
                var resjson = res.ToObject<objex>();
                res = resjson.result.area + " " + resjson.result.location;
            }
            catch
            {
                res = "";
            }
            if (!string.IsNullOrEmpty(res))
            {
                return res;
            }
            try
            {
                string url = "https://sp0.baidu.com/8aQDcjqpAAV3otqbppnN2DJv/api.php?query=" + ip + "&resource_id=6006&ie=utf8&oe=gbk&format=json";
                res = HttpMethods.HttpGet(url, Encoding.GetEncoding("GBK"));
                var resjson = res.ToObject<obj>();
                res = resjson.data[0].location;
            }
            catch
            {
                res = "";
            }
            return res;
        }
        /// <summary>
        /// 百度接口
        /// </summary>
        public class obj
        {
            public List<dataone> data { get; set; }
        }
        public class dataone
        {
            public string location { get; set; }
        }
        /// <summary>
        /// 聚合数据
        /// </summary>
        public class objex
        {
            public string resultcode { get; set; }
            public dataoneex result { get; set; }
            public string reason { get; set; }
            public string error_code { get; set; }
        }
        public class dataoneex
        {
            public string area { get; set; }
            public string location { get; set; }
        }
        #endregion

        #region Browser(获取浏览器信息)
        /// <summary>
        /// 获取浏览器信息
        /// </summary>
        public static string Browser
        {
            get
            {
                if (HttpContext.Current == null)
                    return string.Empty;
                var browser = HttpContext.Current.Request.Browser;
                return string.Format("{0} {1}", browser.Browser, browser.Version);
            }
        }
        #endregion
    }
}
