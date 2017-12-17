using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingpal.BusinessStore.Model
{
    [Serializable]
    [Table(TableName = "RestPos")]
    public class RestPosEntity
    {
        /// <summary>
        /// 
        /// </summary>		
        public Guid Id
        {
            get;
            set;
        }
        /// <summary>
        /// 流水号
        /// </summary>		
        public string RecordSerial
        {
            get;
            set;
        }
        /// <summary>
        /// 小票号
        /// </summary>		
        public string TicketCode
        {
            get;
            set;
        }
        /// <summary>
        /// 门店编号
        /// </summary>		
        public int StoreID
        {
            get;
            set;
        }
        /// <summary>
        /// 合计数量
        /// </summary>		
        public int TotalCount
        {
            get;
            set;
        }
        /// <summary>
        /// 合计金额
        /// </summary>		
        public decimal TotalAmount
        {
            get;
            set;
        }
        /// <summary>
        /// 折扣金额
        /// </summary>		
        public decimal DiscountAmount
        {
            get;
            set;
        }
        /// <summary>
        /// 商品金额
        /// </summary>		
        public decimal GoodsAmount
        {
            get;
            set;
        }
        /// <summary>
        /// 实收金额
        /// </summary>		
        public decimal ActualAmount
        {
            get;
            set;
        }
        /// <summary>
        /// 利润
        /// </summary>		
        public decimal TotalProfit
        {
            get;
            set;
        }
        /// <summary>
        /// 抹零
        /// </summary>		
        public decimal ChangeClear
        {
            get;
            set;
        }
        /// <summary>
        /// 找零金额
        /// </summary>		
        public decimal ChangeAmount
        {
            get;
            set;
        }
        /// <summary>
        /// 销售日期
        /// </summary>		
        public DateTime SaleDate
        {
            get;
            set;
        }
        /// <summary>
        /// 会员guid
        /// </summary>		
        public Guid MemberGuid
        {
            get;
            set;
        }
        /// <summary>
        /// 消费积分
        /// </summary>		
        public int BonusPoints
        {
            get;
            set;
        }
        /// <summary>
        /// 支付方式
        /// </summary>		
        public int PayType
        {
            get;
            set;
        }
        /// <summary>
        /// 收银员
        /// </summary>		
        public string Cashier
        {
            get;
            set;
        }
        /// <summary>
        /// 收银员id
        /// </summary>		
        public Guid CashierID
        {
            get;
            set;
        }
        /// <summary>
        /// 导购员ID
        /// </summary>		
        public Guid GuiderID
        {
            get;
            set;
        }

        /// <summary>
        /// 导购员姓名
        /// </summary>		
        public string Guider
        {
            get;
            set;
        }

        /// <summary>
        /// 记录状态 0：正常订单，1：挂单，-1退货
        /// </summary>		
        public int RecordStatus
        {
            get;
            set;
        }
        /// <summary>
        /// 备注
        /// </summary>		
        public string Remark
        {
            get;
            set;
        }
    }


}
