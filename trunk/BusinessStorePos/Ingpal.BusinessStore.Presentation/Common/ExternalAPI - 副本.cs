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
        public async static void ConfirmMemberOrder(ConfirmMemberOrder memberOrder, Func<string, bool> doPost)
        {
            using (var client = new HttpClient())
            {
                var url = $"http://test-api-store-park.ptdev.cn/cash/order/confirm?";
                var param = $"uid={ memberOrder.uid.ToString()}";
                param += $"&appid={1002}";
                param += $"&product_fee ={memberOrder.product_fee.ToString()}";
                param += $"&products ={Newtonsoft.Json.JsonConvert.SerializeObject(memberOrder.products)}";
                param += $"&shop_sn ={memberOrder.shop_sn}";
                param += $"&shop_name ={memberOrder.shop_name}";
                param += $"&sign_key =6196248fb93d30b7de7553749857300c";

                  // param += ConfigHelper.GetAppConfig("Secretkey");
                  //param += Encodetool.Md5_32(param);
                  HttpResponseMessage resonse = await client.GetAsync(url+param);
                var resString= await resonse.Content.ReadAsStringAsync();
                doPost(resString);
            }
        }
    }
}
