using System.Collections.Generic;

namespace Ingpal.BusinessStore.Model
{
    public class MemberParams
    {
        /// <summary>
        /// 应用程序id
        /// </summary>
        public string appid { get; set; }
        /// <summary>
        /// md5算法签名
        /// </summary>
        public string sign { get; set; }
        
        /// <summary>
        /// 手机/会员卡
        /// </summary>
        public string queryid { get; set; }
        /// <summary>
        /// post请求地址
        /// </summary>
        public string url { get; set; }
        /// <summary>
        /// 安全码
        /// </summary>
        public string secret_key { get; set; }

    }
    /// <summary>
    /// 确认订单(获取优惠券)
    /// </summary>

    public class ConfirmMemberOrder
    {
        /// <summary>
        /// 会员ID
        /// </summary>
        public int uid { get; set; }
        /// <summary>
        /// 产品总价 单位分
        /// </summary>
        public string product_fee { get; set; }
        /// <summary>
        /// 实付金额 单位分
        /// </summary>
        public string payment_fee { get; set; }

        /// <summary>
        /// 优惠金额（除优惠券以外）单位分
        /// </summary>
        public string discount_fee { get; set; }
        /// <summary>
        /// 门店号
        /// </summary>
        public string shop_sn { get; set; }
        /// <summary>
        /// 门店名称
        /// </summary>
        public string shop_name { get; set; }
        /// <summary>
        /// 商品信息json格式
        /// </summary>
        public List<products> products { get; set; }
    }
    /// <summary>
    /// 商品信息
    /// </summary>
    public class products
    {
        public string product_number { get; set; }
        public int price { get; set; }
        public int quantity { get; set; }
    }
}
