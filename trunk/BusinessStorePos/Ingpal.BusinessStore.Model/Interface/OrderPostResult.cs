using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingpal.BusinessStore.Model.Interface
{
    /// <summary>
    /// 订单回传结果
    ///{"http_code":200,"data":{"order_sn":"2017092617054012250600","product_fee":299,"payment_fee":235}}
    /// </summary>
    public class OrderPostResult
    {
        public int http_code { get; set; }
        public data data { get; set; }

    }
    public class data {
        public string order_sn { get; set; }
        public string product_fee { get; set; }
        public string payment_fee { get; set; }
    }
}
