using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ingpal.BusinessStore.Model;
using Ingpal.BusinessStore.Model.Entity;
using Ingpal.BusinessStore.Business;

namespace Ingpal.BusinessStore.Presentation
{
    public  class Marketing
    {
        private Marketing()
        {

        }

        /// <summary>
        /// 查询单品折扣
        /// </summary>
        /// <param name="enity"></param>
        /// <returns></returns>
        public  static GoodsGrantEntity DiscountGoodsItem(PosExt enity)
        {
            var sWhere = $"StoreID='{enity.StoreID}' and BarID='{enity.BarID}' and  IsAllowDiscount=1 and DiscountPrice>0";
            var grantGoodsList = SysBLL.Instance.GetALL<GoodsGrantEntity>(where: $"{sWhere}");
            if (null != grantGoodsList && grantGoodsList.Count > 0) {
                return grantGoodsList[0];
            }
            return null;
        }

        /// <summary>
        /// 满减折扣规则
        /// </summary>
        /// <returns></returns>
        public static  List<StoreEventMoneyOffRule> GetStoreEventMoneyOffRules()
        {
            var discountRule = GoodsBLL.instance.GetDiscountMoneyOffRule();
            if (discountRule == null)
            {
                return null;
            }
            int storeEvnetID = -1;
            List<StoreEventMoneyOffRule> eventMoneyOffRules = discountRule.Where(item => item.EventType == 0&& item.StoreIds.IndexOf(UserInfo.Instance.StoreID.ToString()) > -1).ToList();
            if (eventMoneyOffRules.Count > 0)
            {
                //同一门店多批次活动取最新规则
                storeEvnetID = eventMoneyOffRules.OrderByDescending(item => item.CreateTime).ToList().FirstOrDefault().ID;
            }
            return eventMoneyOffRules.Where(item => item.ID == storeEvnetID).ToList();
        }
        /// <summary>
        /// 整单打折、买赠
        /// </summary>
        /// <returns></returns>
        public static StoreEventMoneyOffRule GetWholeDiscountFreeGoodsEventRules(DiscountType discountType=DiscountType.WholeDiscount)
        {
            var discountRule = GoodsBLL.instance.GetDiscountMoneyOffRule();
            if (discountRule == null) {
                return null;
            }
            int storeEvnetID = -1;
            List<StoreEventMoneyOffRule> eventMoneyOffRules = discountRule.Where(item => item.EventType ==(int)discountType && item.StoreIds!=null&& item.StoreIds.IndexOf(UserInfo.Instance.StoreID.ToString()) > -1).ToList();
            if (eventMoneyOffRules.Count > 0)
            {
                //统一门店多批次活动取最新规则
                storeEvnetID = eventMoneyOffRules.OrderByDescending(item => item.CreateTime).ToList().FirstOrDefault().ID;
            }
            return eventMoneyOffRules.Where(item => item.ID == storeEvnetID).ToList().FirstOrDefault();
        }
    }
}
