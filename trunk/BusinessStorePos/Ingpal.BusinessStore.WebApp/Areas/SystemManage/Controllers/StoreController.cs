using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ingpal.BusinessStore.Business;
using Ingpal.BusinessStore.Model;
using System.Web.Http;

namespace Ingpal.BusinessStore.WebApp.Areas.SystemManage.Controllers
{
    public class StoreController : BaseController
    {
        /// <summary>
        /// 获取所有门店信息
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        // GET: SystemManage/Store
        public ActionResult GetStores(Pagination pagination)
        {
            //数据比较少在内存分页
            var storeList = StoreBLL.Instance.GetStoreList();
            if (pagination != null && !string.IsNullOrEmpty(pagination.keyword))
            {
                var keyword = pagination.keyword;
                storeList = storeList.Where(item => item.Address.Contains(keyword) || item.ID.ToString().Contains(keyword) || item.StoreName.Contains(keyword)
                || (item.Area!=null && item.Area.Contains(keyword)) || (item.CityNo != null && item.CityNo.Contains(keyword))).ToList();
            }
            return Content(GetPagingJson(storeList, pagination));
        }
        /// <summary>
        /// 获取门店信息
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        ///
        [System.Web.Mvc.HttpGet]
        public ActionResult GetStoreFormJson(string keyValue)
        {
            var list = StoreBLL.Instance.GetStoreList();
            var res = list.Where(item => item.ID == int.Parse(keyValue));

            if (res != null && res.Count() > 0)
            {
                return Content(res.FirstOrDefault().ToJson());
            }
            return null;
        }
        [System.Web.Mvc.HttpPost]
        public ActionResult SubmitForm(Model.StoreInfoEntity entity, string keyValue)
        {
            PartialLog log = new PartialLog();
            if (!string.IsNullOrEmpty(keyValue))
            {
                entity.ID = int.Parse(keyValue);
                entity.CreateDate = DateTime.Now;
                entity.FoundedTime = entity.FoundedTime > DateTime.MinValue ? entity.FoundedTime : null;
                entity.SettlementDate = entity.SettlementDate > DateTime.MinValue ? entity.SettlementDate : null;
                entity.ExpectedAchievement = entity.ExpectedAchievement == 0 ? null : entity.ExpectedAchievement;
                var res = StoreBLL.Instance.UpdateStore(entity) > 0;
                var description = res ? "更新成功" : "更新失败";
                log.Description = $"修改：{entity.StoreName}门店信息{description}";
                log.ModuleName = "门店管理";
                log.Result = res ? ResultType.success.ToString() : ResultType.error.ToString();
                WriteLog(log);
                return res ? Success(description) : Error(description);
            }
            else
            {
                var existStore = StoreBLL.Instance.GetAllStore().ToList().Where(item => item.ID == entity.ID || item.StoreName == entity.StoreName);
                if (existStore.Count() > 0)
                {
                    return Error("门店编号或名称已存在请修改！");
                }
                entity.CreateDate = DateTime.Now;
                var res = StoreBLL.Instance.InsertStore(entity) > 0;
                var description = res ? "新建门店成功" : "新建门店失败";
                log.Description = $"新建：{entity.StoreName}{description}";
                log.ModuleName = "门店管理";
                log.Result = res ? ResultType.success.ToString() : ResultType.error.ToString();
                log.StoreID = entity.ID.ToString();
                WriteLog(log);
                return res ? Success(description) : Error(description);
            }
        }

        public override ActionResult Form()
        {
            var storeUsers = UserBLL.Instance.GetStoreUsers();
            ViewBag.StoreUsers = storeUsers == null || !storeUsers.Any() ? null : storeUsers.Select(s => new { ID = s, Name = s }).ToJson();
            return base.Form();
        }

        public ActionResult DeleteForm(string keyValue)
        {
            var res = StoreBLL.Instance.DeleteStoreInfoRelative(keyValue);
            var description = res ? $"删除门店{keyValue}成功" : $"删除门店{keyValue}失败";
            PartialLog log = new PartialLog();
            log.Description = $"删除：{description}";
            log.ModuleName = "门店管理";
            log.Result = res ? ResultType.success.ToString() : ResultType.error.ToString();
            WriteLog(log);
            return res ? Success("删除成功！") : Error("删除失败！");
        }

        public override ActionResult Index()
        {
            ViewBag.Stores = StoreBLL.Instance.GetStoreList().Select(item => new { ID = item.ID, Name = item.StoreName }).ToJson();
            return base.Index();
        }
    }
}