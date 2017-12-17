using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ingpal.BusinessStore.Model;
using Ingpal.BusinessStore.Business;
using Ingpal.BusinessStore.Infrastructure;
namespace Ingpal.BusinessStore.WebApp.Areas.SystemManage.Controllers
{
    public class LogController : BaseController
    {
        [HttpGet]
        public ActionResult RemoveLog()
        {
            return View();
        }
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetGridJson(Pagination pagination, string queryJson)
        {
            PagingParams paging = new PagingParams {
                  PageIndex=pagination.page,
                  PageSize=pagination.rows
            };
            var queryParam = queryJson.ToJObject();
            var sWhere = string.Empty;
            if (!string.IsNullOrEmpty(queryParam["keyword"]==null?"": queryParam["keyword"].ToString()))
            {
                string keyword = queryParam["keyword"].ToString();
                sWhere = $"ModuleName like '%{keyword}%'";
            }
            if (!string.IsNullOrEmpty(queryParam["timeType"]==null?"": queryParam["timeType"].ToString()))
            {
                string timeType = queryParam["timeType"].ToString();
                DateTime? startTime = DateTime.Now.ToString("yyyy-MM-dd").ToDateTime();
                DateTime? endTime = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd").ToDateTime();
                switch (timeType)
                {
                    case "1":
                        break;
                    case "2":
                        startTime = DateTime.Now.AddDays(-7);
                        break;
                    case "3":
                        startTime = DateTime.Now.AddMonths(-1);
                        break;
                    case "4":
                        startTime = DateTime.Now.AddMonths(-3);
                        break;
                    default:
                        break;
                }
                sWhere += $" LogDate>='{startTime}' and LogDate<='{endTime}'";
            }
            paging.Filter = sWhere;
            paging.TableName = "SysLog";
            paging.PrimaryKey = "Id";
            paging.Sort = "LogDate desc";
            var pageRows = SysBLL.Instance.GetPagingSP<SysLog>(paging);
            pagination.records = pageRows != null ? pageRows[0].TotalCount.ToInt32() : 0;
            var data = new
            {
                rows = pageRows,
                total = pagination.total,
                page = pagination.page,
                records = pageRows!=null?pageRows.Count():0
            };
            return Content(data.ToJson());
        }
        [HttpPost]
        [HandlerAjaxOnly]
        public ActionResult SubmitRemoveLog(string keepTime)
        {
            DateTime operateTime = DateTime.Now;
            if (keepTime == "7")            //保留近一周
            {
                operateTime = DateTime.Now.AddDays(-7);
            }
            else if (keepTime == "1")       //保留近一个月
            {
                operateTime = DateTime.Now.AddMonths(-1);
            }
            else if (keepTime == "3")       //保留近三个月
            {
                operateTime = DateTime.Now.AddMonths(-3);
            }
            SysBLL.Instance.DeleteByWhere<SysLog>($" LogDate<='{operateTime}'");
            return Success("清空成功。");
        }
    }
}