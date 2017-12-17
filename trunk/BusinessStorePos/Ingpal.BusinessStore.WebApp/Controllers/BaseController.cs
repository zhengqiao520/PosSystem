using Ingpal.BusinessStore.Model;
using Ingpal.BusinessStore.WebApp.App_Start;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ingpal.BusinessStore.Infrastructure;
using Ingpal.BusinessStore.Business;
namespace Ingpal.BusinessStore.WebApp
{
    [HandlerLogin]
    public abstract class BaseController : Controller
    {

        [HttpGet]
        public virtual ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public virtual ActionResult Form()
        {
            return View();
        }
        [HttpGet]
        public virtual ActionResult Details()
        {
            return View();
        }
        public virtual ActionResult Success(string message)
        {
            return Content(new AjaxResult { state = ResultType.success.ToString(), message = message }.ToJson());
        }
        public virtual ActionResult Success(string message, object data)
        {
            return Content(new AjaxResult { state = ResultType.success.ToString(), message = message, data = data }.ToJson());
        }
        public virtual ActionResult Error(string message)
        {
            return Content(new AjaxResult { state = ResultType.error.ToString(), message = message }.ToJson());
        }
        public string GetPagingJson<T>(List<T> list, Pagination pagination) where T : new()
        {
            if (null != list)
            {
                pagination.records = list.Count();
                list = list.Skip(pagination.rows * (pagination.page - 1)).Take(pagination.rows).ToList();
            }
            var data = new
            {
                rows = list,
                total = pagination.total,
                page = pagination.page,
                records = pagination.records
            };
            return data.ToJson();
        }
        public string GetPagingJson<T, U>(List<T> list, Pagination pagination, U userdata) where T : new()
        {
            if (null != list)
            {
                pagination.records = list.Count();
                list = list.Skip(pagination.rows * (pagination.page - 1)).Take(pagination.rows).ToList();
            }
            var data = new
            {
                rows = list,
                total = pagination.total,
                page = pagination.page,
                records = pagination.records,
                userdata = userdata
            };
            return data.ToJson();
        }
        public int? StoreID { get; set; }
        private static SysBLL SysInstance = SysBLL.Instance;
        public bool WriteLog(PartialLog partialLog)
        {
            var logEntity = new PartialLog { ModuleName = "后台登录", Type = LogType.BS.ToString() };
            logEntity.ModuleName = partialLog.ModuleName;
            logEntity.Result = partialLog.Result;
            logEntity.Description = partialLog.Description;
            return SysInstance.WriteLog(logEntity);
        }
    }
}