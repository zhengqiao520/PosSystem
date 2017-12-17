using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingpal.BusinessStore.Model
{
   public class CrashierParams
    {
        /// <summary>
        /// 小票编号
        /// </summary>
        public string ticket_code { get; set; }

        /// <summary>
        /// 流水号
        /// </summary>
        public string recode_serial { get; set; }

        /// <summary>
        /// 会员名称
        /// </summary>
        public string member_name { get; set; }
        /// <summary>
        /// 会员id
        /// </summary>
        public string member_id { get; set; }
        /// <summary>
        /// 收银员id
        /// </summary>
        public GuiderInfo Guider { get; set; }

        /// <summary>
        /// 会员优惠券信息
        /// </summary>
        public CouponcsResult CouponcsResult { get; set; }

    }
}
