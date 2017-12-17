using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Ingpal.BusinessStore.Infrastructure;
using Ingpal.BusinessStore.Model;
namespace Ingpal.BusinessStore.Presentation
{
    public class ExternalAPI
    {
        /// <summary>
        /// 会员查询接口
        /// </summary>
        /// <param name="member"></param>
        /// <param name="doPost"></param>
        /// <param name="queryType"></param>
        public async static void ValidMemberInfo(MemberParams member, Func<string, bool> doPost, MemberQueryType queryType = MemberQueryType.Mobile)
        {
            using (var client = new HttpClient())
            {
                bool isMobileQuery = queryType == MemberQueryType.Mobile;
                var queryTypeName = isMobileQuery ? "mobile" : "cardid";
                var interfaceName = isMobileQuery ? MemberInterface.mobile : MemberInterface.card;
                var url = string.Format(ConfigHelper.GetAppConfig("MemberGateway"), interfaceName);
                member.url = url;
                member.appid = ConfigHelper.GetAppConfig("appid");
                member.secret_key = ConfigHelper.GetAppConfig("Secretkey");
                var sign = Encodetool.Md5_32($"appid={member.appid}&{queryTypeName}={member.queryid}{member.secret_key}");
                member.sign = sign;
                var values = new List<KeyValuePair<string, string>>();
                values.Add(new KeyValuePair<string, string>(queryTypeName, member.queryid));
                values.Add(new KeyValuePair<string, string>("appid", member.appid));
                values.Add(new KeyValuePair<string, string>("sign", sign));
                var content = new FormUrlEncodedContent(values);
                var response = await client.PostAsync(member.url, content);
                var resString = await response.Content.ReadAsStringAsync();
                doPost(resString);
            }
        }
           /// <summary>
        /// 优惠券接口(同步方法)
        /// 算法
        /// 1：key-value 降序排列（a-z）
        /// 2：对value url编码
        /// 3：value url编码结果小写全部转换为大写
        /// 4：url参数+key MD5 32加密生成sign作为参数
        /// </summary>
        /// <param name="memberOrder"></param>
        /// <param name="doPost"></param>
        public  static string ConfirmMemberOrder(ConfirmMemberOrder memberOrder)
        {
            using (var client = new HttpClient())
            {
                var url = ConfigHelper.GetAppConfig("MemberOrderConfirm");
                var paramaters = new List<KeyValuePair<string, string>>();
                paramaters.Add(new KeyValuePair<string, string>("appid", 1002.ToString()));
                paramaters.Add(new KeyValuePair<string, string>("product_fee", memberOrder.product_fee.ToString()));
                paramaters.Add(new KeyValuePair<string, string>("products", Newtonsoft.Json.JsonConvert.SerializeObject(memberOrder.products)));
                paramaters.Add(new KeyValuePair<string, string>("shop_name", memberOrder.shop_name));
                paramaters.Add(new KeyValuePair<string, string>("shop_sn", memberOrder.shop_sn));
                paramaters.Add(new KeyValuePair<string, string>("uid", memberOrder.uid.ToString()));
                paramaters = paramaters.OrderBy(item => item.Key).ToList();
                var paramString = string.Empty;
                paramaters.ForEach(item => {
                    paramString += $"{item.Key}={Ingpal.BusinessStore.Infrastructure.Encodetool.UrlEncode((item.Value??""))}&";
                });
                int pos=paramString.LastIndexOf("&");
                paramString=paramString.Remove(pos);
                var urlString = paramString.Trim() + $"6196248fb93d30b7de7553749857300c";
                var sign=Encodetool.Md5_32(urlString);
                paramString += $"&sign={sign}";
                Task<HttpResponseMessage> resonse =client.GetAsync(url+ paramString);
                var resString = resonse.Result.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                return resString;
            }
        }

        /// <summary>
        /// 会员订单回传（异步）-->2017.9.27改成同步
        /// </summary>
        /// <param name="memberOrder"></param>
        /// <param name="ticketCode"></param>
        /// <param name="doPost"></param>
        public  static string PostOrderInfo(ConfirmMemberOrder memberOrder,string ticketCode,string coupon_id) {
            using (var client = new HttpClient())
            {
                var url = ConfigHelper.GetAppConfig("MemberPostOrder");
                var paramaters = new List<KeyValuePair<string, string>>();
                paramaters.Add(new KeyValuePair<string, string>("appid", 1002.ToString()));
                paramaters.Add(new KeyValuePair<string, string>("product_fee", memberOrder.product_fee.ToString()));
                paramaters.Add(new KeyValuePair<string, string>("payment_fee", memberOrder.payment_fee.ToString()));
                paramaters.Add(new KeyValuePair<string, string>("discount_fee", memberOrder.discount_fee.ToString()));
                paramaters.Add(new KeyValuePair<string, string>("products", Newtonsoft.Json.JsonConvert.SerializeObject(memberOrder.products)));
                paramaters.Add(new KeyValuePair<string, string>("shop_name", memberOrder.shop_name));
                paramaters.Add(new KeyValuePair<string, string>("shop_sn", memberOrder.shop_sn));
                paramaters.Add(new KeyValuePair<string, string>("uid", memberOrder.uid.ToString()));
                paramaters.Add(new KeyValuePair<string, string>("order_trade_sn", ticketCode));
                if (!string.IsNullOrEmpty(coupon_id)) {
                    paramaters.Add(new KeyValuePair<string, string>("coupon_id", coupon_id));
                }
                paramaters = paramaters.OrderBy(item => item.Key).ToList();
                var paramString = string.Empty;
                paramaters.ForEach(item => {
                    paramString += $"{item.Key}={Ingpal.BusinessStore.Infrastructure.Encodetool.UrlEncode((item.Value ?? ""))}&";
                });
                int pos = paramString.LastIndexOf("&");
                paramString = paramString.Remove(pos);
                var urlString = paramString.Trim() + $"6196248fb93d30b7de7553749857300c";
                var sign = Encodetool.Md5_32(urlString);
                paramString += $"&sign={sign}";

                Task<HttpResponseMessage> resonse = client.GetAsync(url + paramString);
                var resString = resonse.Result.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                return resString;
                //  HttpResponseMessage resonse = await client.GetAsync(url + paramString);
                // var resString = await resonse.Content.ReadAsStringAsync();
                // doPost(resString);
            }
        }

        /// <summary>
        /// 会员退货接口(同步方法)
        /// 算法
        /// 1：key-value 降序排列（a-z）
        /// 2：对value url编码
        /// 3：value url编码结果小写全部转换为大写
        /// 4：url参数+key MD5 32加密生成sign作为参数
        /// </summary>
        /// <param name="memberOrder"></param>
        /// <param name="doPost"></param>
        public static string MemberReturnGoods(ConfirmMemberOrder memberOrder)
        {
            using (var client = new HttpClient())
            {
                var url = ConfigHelper.GetAppConfig("MemberReturnGoods");
                var paramaters = new List<KeyValuePair<string, string>>();
                paramaters.Add(new KeyValuePair<string, string>("appid", 1002.ToString()));
                paramaters.Add(new KeyValuePair<string, string>("products", Newtonsoft.Json.JsonConvert.SerializeObject(memberOrder.products)));
                paramaters.Add(new KeyValuePair<string, string>("uid", memberOrder.uid.ToString()));
                paramaters = paramaters.OrderBy(item => item.Key).ToList();
                var paramString = string.Empty;
                paramaters.ForEach(item => {
                    paramString += $"{item.Key}={Ingpal.BusinessStore.Infrastructure.Encodetool.UrlEncode((item.Value ?? ""))}&";
                });
                int pos = paramString.LastIndexOf("&");
                paramString = paramString.Remove(pos);
                var urlString = paramString.Trim() + $"6196248fb93d30b7de7553749857300c";
                var sign = Encodetool.Md5_32(urlString);
                paramString += $"&sign={sign}";
                Task<HttpResponseMessage> resonse = client.GetAsync(url + paramString);
                var resString = resonse.Result.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                return resString;
            }
        }
    }
}
