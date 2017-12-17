using Ingpal.BusinessStore.Business;
using Ingpal.BusinessStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace Ingpal.BusinessStore.WebApp.Areas.SystemManage.Controllers
{
    public class GoodsDiscountController : BaseController
    {
        public GoodsDiscountController()
        {
            ViewBag.Stores = SysBLL.Instance.GetALL<StoreInfoEntity>().Select(item => new { ID = item.ID, Name = item.StoreName }).ToJson();
        }
        [HttpGet]
        public ActionResult GetGoodsGrantListExt(Pagination pagination, string grantType, string storeID = "1001", string discountType = "")
        {
            var goodsList = GoodsBLL.instance.GetGoodsGrantListExt(int.Parse(storeID), grantType).Where(item => item.IsGrant == true && item.StoreID == storeID).ToList();
            if (!string.IsNullOrEmpty(discountType))
            {
                goodsList = goodsList.Where(item => item.IsAllowDiscount == (discountType == "1")).ToList();
            }
            return Content(GetPagingJson(goodsList, pagination));
        }

        public ActionResult SingleDiscount()
        {
            return View();
        }
        [HttpGet]
        public ActionResult GetExchangePriceListExt(Pagination pagination, string grantType, string storeID = "1001", string discountType = "")
        {
            var goodsList = GoodsBLL.instance.GetGoodsGrantListExt(int.Parse(storeID), grantType).Where(item => item.IsGrant == true && item.StoreID == storeID).ToList();
            if (!string.IsNullOrEmpty(discountType))
            {
                goodsList = goodsList.Where(item => item.IsAllowExchange == (discountType == "1")).ToList();
            }
            return Content(GetPagingJson(goodsList, pagination));
        }
        /// <summary>
        /// 换购
        /// </summary>
        /// <returns></returns>
        public ActionResult ExchangePrice()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SubmitExchangePrice(GoodsGrantExt entity)
        {
            PartialLog log = new PartialLog();
            log.Description = $"商品换购：{entity.StoreID}门店，设置{entity.Name}换购价：{entity.ExchangePrice}";
            log.ModuleName = "商品管理";
            try
            {
                var res = GoodsBLL.instance.SetExchangePricePermission(entity);
                log.Result = res > 0 ? ResultType.success.ToString() : ResultType.error.ToString();
                WriteLog(log);
            }
            catch (Exception ee)
            {
                log.Result = ResultType.error.ToString();
                WriteLog(log);
                return Error("商品换购!" + ee.Message);
            }
            return Success($"操作成功！");
        }
        public ActionResult MoneyOffList()
        {
            return View();
        }
        public ActionResult MoneyOffForm()
        {
            return View();
        }
        public ActionResult WholeDiscount()
        {
            return View();
        }
        public ActionResult WholeDiscountForm()
        {
            return View();
        }
        /// <summary>
        /// 删除折扣优惠信息
        /// </summary>
        /// <returns></returns>
        public ActionResult DeleteDiscount(string keyValue)
        {

            var result = SysBLL.Instance.DeteleByKey<StoreEvent>(keyValue);
            if (result)
            {
                SysBLL.Instance.DeleteByWhere<StoreEventConfig>($"StoreEventID={keyValue}");
                return Success("操作成功！");
            }
            return Error("操作失败！");
        }
        public ActionResult FreeGoodsForm()
        {
            return View();
        }
        public ActionResult FreeGoodsList()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SubmitGoodsGrant(GoodsGrantExt entity)
        {
            PartialLog log = new PartialLog();
            log.Description = $"单品折扣：{entity.StoreID}门店，设置{entity.Name}折扣价：{entity.DiscountPrice}";
            log.ModuleName = "商品管理";
            try
            {
                var res = GoodsBLL.instance.SetDiscountPricePermission(entity);

                log.Result = res > 0 ? ResultType.success.ToString() : ResultType.error.ToString();
                WriteLog(log);
            }
            catch (Exception ee)
            {
                log.Result = ResultType.error.ToString();
                WriteLog(log);
                return Error("单品折扣!" + ee.Message);
            }
            return Success($"操作成功！");
        }



        /// <summary>
        /// 满减
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SubmitStoreEvent(StoreEvent entity, string keyValue = "")
        {
            if (entity.EventConfigString.Equals("[[]]"))
            {
                return Error("满减条件不可为空！");
            }
            if (string.IsNullOrEmpty(keyValue))
            {
                entity.EventType = 0;
                int res = GoodsBLL.instance.AddStoreEvent(entity);
                if (!string.IsNullOrEmpty(entity.EventConfigString))
                {
                    var json = Newtonsoft.Json.JsonConvert.DeserializeObject(entity.EventConfigString);
                    Newtonsoft.Json.Linq.JArray arr = json as Newtonsoft.Json.Linq.JArray;
                    if (res > 0 && arr.Count > 0)
                    {
                        arr.ToList().ForEach(item =>
                        {
                            StoreEventConfig cfg = new StoreEventConfig
                            {
                                ConditionName = item["ConditionName"].ToString(),
                                ConditionValue = item["ConditionValue"].ToString(),
                                StoreEventID = res.ToString()
                            };
                            cfg.Description = $"满{cfg.ConditionName},减{cfg.ConditionValue}";
                            SysBLL.Instance.Insert(cfg);
                        });
                    }
                }
            }
            else {

                StoreEvent evt = SysBLL.Instance.GetALL<StoreEvent>(where: $"ID='{keyValue}'").FirstOrDefault();
                evt.StartTime = entity.StartTime;
                evt.EndTime = entity.EndTime;
                evt.Name = entity.Name;
                evt.Remark = entity.Remark;
                evt.StoreIds = entity.StoreIds;
                var res = SysBLL.Instance.UpdateByKey(evt);
                if (res)
                {
                    if (!string.IsNullOrEmpty(entity.EventConfigString))
                    {
                        var effectRow = 0;
                        var json = Newtonsoft.Json.JsonConvert.DeserializeObject(entity.EventConfigString);
                        Newtonsoft.Json.Linq.JArray arr = json as Newtonsoft.Json.Linq.JArray;
                        if (arr.Count > 0)
                        {
                            SysBLL.Instance.DeleteByWhere<StoreEventConfig>($"StoreEventID='{keyValue}'");
                            arr.ToList().ForEach(item =>
                            {
                                StoreEventConfig cfg = new StoreEventConfig
                                {
                                    ConditionName = item["ConditionName"].ToString(),
                                    ConditionValue = item["ConditionValue"].ToString(),
                                    StoreEventID = evt.ID.ToString()
                                };
                                cfg.Description = $"满{cfg.ConditionName},减{cfg.ConditionValue}";
                                bool result = SysBLL.Instance.Insert(cfg);
                                effectRow += (result ? 1 : 0);
                            });
                        }
                        return effectRow > 0 ? Success("更新成功！") : Error("更新失败！");
                    }

                }

            }
            return Success("操作成功！");
        }
        /// <summary>
        ///整单折扣
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="entity"></param>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SubmitWholeDiscountEvent(Pagination pagination, StoreEvent entity, string keyValue = "")
        {
            var result = false;
            if (string.IsNullOrEmpty(keyValue))
            {
                entity.EventType = 1;
                int res = GoodsBLL.instance.AddStoreEvent(entity);
                if (!string.IsNullOrEmpty(entity.EventConfigString))
                {

                    StoreEventConfig cfg = new StoreEventConfig
                    {
                        ConditionName = "",
                        ConditionValue = entity.EventConfigString,
                        Description = "整单折扣",
                        StoreEventID = res.ToString()
                    };
                    result = SysBLL.Instance.Insert(cfg);
                }
            }
            else
            {
                StoreEvent evt = SysBLL.Instance.GetALL<StoreEvent>(where: $"ID='{keyValue}'").FirstOrDefault();
                evt.StartTime = entity.StartTime;
                evt.EndTime = entity.EndTime;
                evt.Name = entity.Name;
                evt.Remark = entity.Remark;
                evt.StoreIds = entity.StoreIds;
                var res = SysBLL.Instance.UpdateByKey(evt);
                if (res)
                {
                    StoreEventConfig evtConfig = SysBLL.Instance.GetALL<StoreEventConfig>(where: $"StoreEventID='{keyValue}'").FirstOrDefault();
                    evtConfig.ConditionValue = entity.EventConfigString;
                    result = SysBLL.Instance.UpdateByKey(evtConfig);
                }
                return result ? Success("更新成功！") : Error("更新失败！");
            }
            return result ? Success("操作成功！") : Error("操作失败！");
        }
        /// <summary>
        ///买赠设置
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="entity"></param>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SubmitFreeGoodsEvent(Pagination pagination, StoreEvent entity, string keyValue = "")
        {
            var result = false;
            var func = new Func<string, string>(s =>
            {
                var tag = '|';
                if (s.IndexOf(tag) == -1)
                    return s;
                var str = s.Replace(" ", "");
                var list = str.Split(tag).ToList();
                var qData = list.GroupBy(q => q).Select(q => new { item = q.Key, cnt = q.Count() });
                var dict = new Dictionary<string, int>();
                foreach (var t in qData)
                {
                    if (t.item.Contains("*"))
                    {
                        var p0 = t.item.Split(new[] { "*" }, StringSplitOptions.RemoveEmptyEntries);
                        var p0Num = 0;
                        if (int.TryParse(p0[1], out p0Num))
                        {
                            var p0Str = p0[0].Trim();
                            if (dict.ContainsKey(p0Str))
                            {
                                dict[p0Str] += p0Num * t.cnt;
                            }
                            else
                            {
                                dict.Add(p0Str, p0Num * t.cnt);
                            }
                        }
                    }
                    else
                    {
                        dict.Add(t.item, t.cnt);
                    }
                }
                if (dict.Any())
                {
                    return string.Join(tag.ToString(), dict.Select(k => k.Key + (k.Value > 1 ? ("*" + k.Value) : "")).ToList());
                }
                return s;
            });
            var dt = DateTime.Now;
            var msg0 = "当前购买的商品已存在买赠设置，请修改或删除原买赠设置";
            var msg1 = "当前赠品已绑定到一条已存在的买赠设置";
            var storeEventQuery = SysBLL.Instance.GetALL<StoreEvent>().Where(s => (s.StoreIds.Contains(entity.StoreIds) || entity.StoreIds.Contains(s.StoreIds))
            && s.EventType == 2 && s.StartTime <= dt && s.EndTime >= dt);
            var storeEventTags = new List<int>();
            if (string.IsNullOrEmpty(keyValue))
            {
                entity.EventType = 2;
                if (!string.IsNullOrEmpty(entity.StoreEventConfig.ConditionName) && !string.IsNullOrEmpty(entity.StoreEventConfig.ConditionValue))
                {
                    StoreEventConfig cfg = new StoreEventConfig
                    {
                        ConditionName = func(entity.StoreEventConfig.ConditionName.Trim().Replace("\n", "").Replace("\r", "")),
                        ConditionValue = entity.StoreEventConfig.ConditionValue.Trim().Replace("\n", "").Replace("\r", ""),
                        Description = "买赠设置"
                    };
                    if (storeEventQuery.Any())
                    {
                        storeEventTags = storeEventQuery.Select(p => p.ID).ToList();
                        var storeEventConfig = SysBLL.Instance.GetALL<StoreEventConfig>().Where(q => storeEventTags.Any(k => k.ToString() == q.StoreEventID));
                        if (storeEventConfig.Any(p => p.ConditionName.Contains(cfg.ConditionName) || cfg.ConditionName.Contains(p.ConditionName)))
                            return Error(msg0);
                        if (storeEventConfig.Any(p => p.ConditionValue.Contains(cfg.ConditionValue) || cfg.ConditionValue.Contains(p.ConditionValue)))
                            return Error(msg1);
                    }
                    int res = GoodsBLL.instance.AddStoreEvent(entity);
                    cfg.StoreEventID = res.ToString();
                    result = SysBLL.Instance.Insert(cfg);
                }
            }
            else
            {
                StoreEvent evt = SysBLL.Instance.GetALL<StoreEvent>(where: $"ID='{keyValue}'").FirstOrDefault();
                evt.StartTime = entity.StartTime.Date;
                evt.EndTime = entity.EndTime.Date;
                evt.Name = entity.Name;
                evt.Remark = entity.Remark;
                evt.StoreIds = entity.StoreIds;

                StoreEventConfig evtConfig = SysBLL.Instance.GetALL<StoreEventConfig>(where: $"StoreEventID='{keyValue}'").FirstOrDefault();
                evtConfig.ConditionValue = entity.StoreEventConfig.ConditionValue.Trim().Replace("\n", "").Replace("\r", "");
                evtConfig.ConditionName = func(entity.StoreEventConfig.ConditionName.Trim().Replace("\n", "").Replace("\r", ""));

                var t_storeEventQuery = storeEventQuery.Where(y => y.ID != evt.ID);
                if (t_storeEventQuery.Any())
                {
                    storeEventTags = t_storeEventQuery.Select(p => p.ID).ToList();
                    var t_storeEventConfig = SysBLL.Instance.GetALL<StoreEventConfig>().Where(q => storeEventTags.Any(k => k.ToString() == q.StoreEventID));
                    if (t_storeEventConfig.Any(p => p.ConditionName.Contains(evtConfig.ConditionName) || evtConfig.ConditionName.Contains(p.ConditionName)))
                        return Error(msg0);
                    if (t_storeEventConfig.Any(p => p.ConditionValue.Contains(evtConfig.ConditionValue) || evtConfig.ConditionValue.Contains(p.ConditionValue)))
                        return Error(msg1);
                }

                var res = SysBLL.Instance.UpdateByKey(evt);
                if (res)
                {
                    result = SysBLL.Instance.UpdateByKey(evtConfig);
                }
                return result ? Success("更新成功！") : Error("更新失败！");
            }
            return result ? Success("操作成功！") : Error("操作失败！");
        }
        public ActionResult GetWholeDiscountEventFormJson(string keyValue = "")
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                var storeEvent = SysBLL.Instance.GetALL<StoreEvent>(where: $"ID='{keyValue}'").FirstOrDefault();
                if (null != storeEvent)
                {
                    var storeEventConfigs = SysBLL.Instance.GetALL<StoreEventConfig>(where: $"StoreEventID='{storeEvent.ID}'");
                    if (storeEventConfigs != null && storeEventConfigs.Count > 0)
                    {
                        storeEvent.EventConfigString = storeEventConfigs.FirstOrDefault().ConditionValue;
                        return Content(storeEvent.ToJson());
                    }

                }
            }
            return Error("未找到记录！");
        }

        public ActionResult GetEventStoreFormJson(string keyValue = "")
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                var storeEvent = SysBLL.Instance.GetALL<StoreEvent>(where: $"ID='{keyValue}'").FirstOrDefault();
                if (null != storeEvent)
                {
                    List<StoreEventConfig> storeEventConfigs = SysBLL.Instance.GetALL<StoreEventConfig>(where: $"StoreEventID='{storeEvent.ID}'");
                    storeEvent.EventConfigString = storeEventConfigs.ToJson();
                    storeEvent.StoreEventConfig = new StoreEventConfig
                    {
                        ConditionName = storeEventConfigs[0].ConditionName,
                        ConditionValue = storeEventConfigs[0].ConditionValue
                    };
                    return Content(storeEvent.ToJson());
                }
            }
            return Content(null);
        }
        public ActionResult GetEvenStoreConfigList(string keyValue = "")
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                var storeEventJson = SysBLL.Instance.GetALL<StoreEventConfig>(where: $"StoreEventID='{keyValue}'").ToJson();
                return Content(storeEventJson);
            }
            return Content(null);
        }

        [HttpGet]
        public ActionResult StoreEventList(string eventType = "1")
        {
            var jsonString = SysBLL.Instance.GetALL<StoreEvent>(where: $" EventType='{eventType}'").ToJson();
            return Content(jsonString);
        }
    }
}