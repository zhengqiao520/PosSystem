using Com.Alipay;
using Ingpal.BusinessStore.Model;
using System.Collections.Generic;
using Ingpal.BusinessStore.Business;
using Ingpal.BusinessStore.Infrastructure;
namespace Ingpal.BusinessStore.Presentation
{
    public  class AlipayServices
    {
        private static List<MDMTypeSubEntity> MDMSubList = MdmBLL.Instance.MDMSubList;
        public static IAlipayTradeService CreateServiceClient()
        {
            var serverUrl = MDMSubList.GetOneName("支付宝接口", "AplipayGetWay");
            var appId = MDMSubList.GetOneName("支付宝接口", "AppID");
            var merchant_private_key = MDMSubList.GetOneName("支付宝接口", "MerchantPrivateKey");
            var sign_type = MDMSubList.GetOneName("支付宝接口", "SignType");
            var alipay_public_key = MDMSubList.GetOneName("支付宝接口", "AlipayPublicKey");
            return F2FBiz.CreateClientInstance(serverUrl, appId, merchant_private_key, "1.0",
                        sign_type, alipay_public_key, "utf-8");
        }
    }
}
