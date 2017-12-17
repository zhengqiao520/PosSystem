using System;
using System.Collections.Generic;
using System.IO;
//using System.Linq;
using System.Web;

/// <summary>
/// 基础配置类
/// </summary>
namespace Com.Alipay
{
    public class Config
    {
        public static string alipay_public_key = @"MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQDIgHnOn7LLILlKETd6BFRJ0GqgS2Y3mn1wMQmyh9zEyWlz5p1zrahRahbXAfCfSqshSNfqOmAQzSHRVjCqjsAw1jyqrXaPdKBmr90DIpIxmIyKXv4GGAkPyJ/6FTFY99uhpiq0qadD/uSzQsefWo0aTvP/65zi3eof7TcZ32oWpwIDAQAB";


        ////这里要配置没有经过的原始私钥

        ////开发者私钥
        //public static string merchant_private_key = @"此处填写开发者私钥";

        ////开发者公钥
        //public static string merchant_public_key = @"此处填写开发者公钥";

        ////应用ID
        //public static string appId = "此处填写应用APPID";

        ////合作伙伴ID：partnerID
        //public static string pid = "此处填写账号PID（partner id）";


        //这里要配置没有经过的原始私钥

        //开发者私钥
        public static string merchant_private_key = @"MIICXgIBAAKBgQDLMboprRKRyu276PmuZc4rS6tIoe81aKYk1LorYfUoiova4Grh
5994lF4lnfnjHIkUlgZ6O5+FcuYskI7hnDm3CIsQSRRyt4jgYkFVY89NIj7Cv+LT
SQLagqcD4hxKtQQJJg+X9Cs8zzpGO+nfGB53PLE+Vjozv9Yhs0HXQwCAZQIDAQAB
AoGBALr+kGw6MpSpRA9iYCT2271Mbdzx6cok/IF4o7u48nzUw9AyJyqu0SGOqPXF
ZGp1oFGpn1xt8mhFTT5F6rgFpbX9UgUxQG4VU4LA7bUbmluZnhM2IF8Uvllw6sK9
M+4nOWFbLnIJODZe4MrUb2bSMD8rbhuNS6IsmmOkWtC3ES8BAkEA/3LUUgWXSCDn
HJphpCOaNDwweC058xpYvcFM21mXxjZDOCItXpfHgoXQajVoecIl6H4kMv5yCCOq
Aa6CkOxpOQJBAMuiBSUdDc11qG+nmwxQOQrDqbn1amK4iKGqlKmODT6R+QyF9j/2
I2ZYiDOXwY3t89SRVh/xbXhHzu8T51Aa7I0CQQCxKGb9l2kKmd8OZDbxScupDFEl
F2CIK659szBlM6ZhzcIijPlgD+1KpRkcf3u8bZwyuEDMqNBWur0tu2RLs9lpAkAq
tfcCS8/DUnRbxvncYU81lMiauoDv5+iwkAjSb3sTrqZgHBEEZWoTY2pd9+yfClPk
N/+qf4cIfXdH6hLQWHVZAkEAwAP5AsuI8Qp7CEmWdNernyc6HkDKkS+0QhuTpznS
57jMDYqR1bPX9TafS3z5pg4zn9/mRTNqHxqYczE50gV1pw==";

        //开发者公钥
        public static string merchant_public_key = @"MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQDLMboprRKRyu276PmuZc4rS6tI oe81aKYk1LorYfUoiova4Grh5994lF4lnfnjHIkUlgZ6O5+FcuYskI7hnDm3CIsQ SRRyt4jgYkFVY89NIj7Cv+LTSQLagqcD4hxKtQQJJg+X9Cs8zzpGO+nfGB53PLE+ Vjozv9Yhs0HXQwCAZQIDAQAB";

        //应用ID
        public static string appId = "2016080700188911";

        //合作伙伴ID：partnerID
        public static string pid = "2088102170362572";

        //支付宝网关
        public static string serverUrl = "https://openapi.alipaydev.com/gateway.do";
        public static string mapiUrl = "https://mapi.alipay.com/gateway.do";
        public static string monitorUrl = "http://mcloudmonitor.com/gateway.do";

        //编码，无需修改
        public static string charset = "utf-8";
        //签名类型，支持RSA2（推荐！）、RSA
        public static string sign_type = "RSA";
        //public static string sign_type = "RSA2";

        //版本号，无需修改
        public static string version = "1.0";
         

        /// <summary>
        /// 公钥文件类型转换成纯文本类型
        /// </summary>
        /// <returns>过滤后的字符串类型公钥</returns>
        public static string getMerchantPublicKeyStr()
        {
            StreamReader sr = new StreamReader(merchant_public_key);
            string pubkey = sr.ReadToEnd();
            sr.Close();
            if (pubkey != null)
            {
              pubkey=  pubkey.Replace("-----BEGIN PUBLIC KEY-----", "");
              pubkey = pubkey.Replace("-----END PUBLIC KEY-----", "");
              pubkey = pubkey.Replace("\r", "");
              pubkey = pubkey.Replace("\n", "");
            }
            return pubkey;
        }

        /// <summary>
        /// 私钥文件类型转换成纯文本类型
        /// </summary>
        /// <returns>过滤后的字符串类型私钥</returns>
        public static string getMerchantPriveteKeyStr()
        {
            StreamReader sr = new StreamReader(merchant_private_key);
            string pubkey = sr.ReadToEnd();
            sr.Close();
            if (pubkey != null)
            {
                pubkey = pubkey.Replace("-----BEGIN PUBLIC KEY-----", "");
                pubkey = pubkey.Replace("-----END PUBLIC KEY-----", "");
                pubkey = pubkey.Replace("\r", "");
                pubkey = pubkey.Replace("\n", "");
            }
            return pubkey;
        }

    }
}