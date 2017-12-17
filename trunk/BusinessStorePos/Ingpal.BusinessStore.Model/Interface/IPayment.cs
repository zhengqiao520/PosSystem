using Com.Alipay.Business;
using Com.Alipay.Model;
using Ingpal.BusinessStore.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Alipay.Domain;

namespace Ingpal.BusinessStore.Model.Interface
{
    /// <summary>
    /// 支付接口
    /// </summary>
    public interface IPayment
    {
        /// <summary>
        /// 构建支付对象
        /// </summary>
        /// <param name="posEntity">订单汇总</param>
        /// <param name="posDetailEntity">订单明细</param>
        /// <returns></returns>
        object CreatePaymentArgs();
        /// <summary>
        /// 支付
        /// </summary>
        /// <param name="fun">回调函数</param>
        /// <returns></returns>
        void Pay();
        void Pay(Func<object, bool> funCallBack);
    }
}
