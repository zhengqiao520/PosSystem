using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingpal.BusinessStore.Model
{

    /// <summary>
    /// 数据有效性状态
    /// </summary>
    public class RecordStatus {
        /// <summary>
        /// 正常
        /// </summary>
        public const int Normal = 0;
        /// <summary>
        /// 作废
        /// </summary>
        public const int Invalid = -1;
    }
    public class RecordType
    {
        /// <summary>
        /// 正常订单
        /// </summary>
        public const int Normal = 0;
        /// <summary>
        /// 挂单
        /// </summary>
        public const int Pending = 1;
        /// <summary>
        /// 作废无效
        /// </summary>
        public const int Invalid = -2;
        /// <summary>
        /// 退货
        /// </summary>
        public const int SalesReturn = -1;
    }
    /// <summary>
    /// 操作类型
    /// </summary>
    public enum OperationType
    {
        Insert,
        Update,
        Delete,
        Select,
        Other
    }
    public enum LogType
    {
        /// <summary>
        /// 收银前端
        /// </summary>
        CS,
        /// <summary>
        /// 管理后端
        /// </summary>
        BS
    }
    /// <summary>
    /// 付款方式
    /// </summary>
    public enum PayMentType
    {
        [Description("微信支付")]
        WeChat = 0,

        [Description("支付宝")]
        Alipay = 1,

        [Description("银行卡")]
        Card = 2,

        [Description("商场代收")]
        Market = 3,

        [Description("现金支付")]
        Crash = 4,

        /// <summary>
        /// 未知
        /// </summary>
        None = 5
    }
    /// <summary>
    /// 接口查询方式
    /// </summary>
    public enum MemberQueryType
    {
        /// <summary>
        /// 手机号码
        /// </summary>
        Mobile,
        /// <summary>
        /// 会员卡
        /// </summary>
        CardId
    }
    public class MemberInterface {
        public const string mobile = "query_mobile";
        public const string card = "query_card";
    }
    /// <summary>
    /// 折扣类型
    /// </summary>
    public enum DiscountType
    {
        /// <summary>
        /// 单品
        /// </summary>
        SingleDiscount,

        /// <summary>
        /// 整单
        /// </summary>
        WholeDiscount,
        /// <summary>
        /// 
        /// </summary>
        FreeGoodsDiscount,
        /// <summary>
        /// 特定
        /// </summary>
        Specific
    }
   
}
