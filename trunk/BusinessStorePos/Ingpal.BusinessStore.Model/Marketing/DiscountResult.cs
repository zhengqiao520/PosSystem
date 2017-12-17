using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingpal.BusinessStore.Model
{
    /// <summary>
    /// 优惠结果
    /// </summary>
   public class DiscountResult
    {
        /// <summary>
        /// 满减结果
        /// </summary>
        public StoreEventMoneyOffRule MoneyOfResult {
            get;
            set;
        }
        /// <summary>
        /// 整单折扣
        /// </summary>
        public StoreEventMoneyOffRule WholeDiscountResult
        {
            get;
            set;
        }
        /// <summary>
        /// 折扣总金额
        /// </summary>
        public decimal SubtractAmount { get; set; }

        /// <summary>
        /// 优惠前总金额
        /// </summary>
        public decimal TotalAmount { get; set; }
    }
}
