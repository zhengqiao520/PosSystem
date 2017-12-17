using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingpal.BusinessStore.Model
{

    /// <summary>
    /// 优惠券信息
    /// </summary>
    public class CouponcsResult
    {
        public int http_code { get; set; }
        public CouponcsData data { get; set; }
    }
    /// <summary>
    /// 优惠券列表
    /// </summary>
    public class CouponcsData {
        public List<Couponcs> coupon { get; set; }
    }
    /// <summary>
    /// 优惠券明细信息
    /// </summary>
    public class Couponcs
    {
        public int id { get; set; }
        public string title { get; set; }
        public string subtitle { get; set; }
        public int full { get; set; }
        public int deduct { get; set; }
        public string note { get; set; }
        public string start_date { get; set; }
        public string end_date { get; set; }
        public int enable { get; set; }
        public int gap { get; set; }
        public int sort { get; set; }
    }
}
