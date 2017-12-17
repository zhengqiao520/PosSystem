using Ingpal.BusinessStore.Business;
using Ingpal.BusinessStore.Model;
using Ingpal.BusinessStore.WebApp.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace Ingpal.BusinessStore.WebApp.Controllers
{
    [HandlerLogin]
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Default()
        {
            ChartViewData();
            return View();
        }
        [HttpGet]
        public ActionResult About()
        {
            return View();
        }
        private void ChartViewData()
        {
            //饼图
            ViewData["IndexSummary"] = ReportBLL.Instance.RptIndexSummary(DateTime.Now.ToString("yyyyMM"))[0];
            var date = DateTime.Now.ToString("yyyyMM");
            var dailyCategorySummary = ReportBLL.Instance.RptDailyCategoryPieData<DailyCategorySummary>(date, date);
            ViewData["DailyCategoryPieData"]= new CategoryPieChartModel
            {
                LegendData = dailyCategorySummary==null?new List<string>():dailyCategorySummary.Select(item => item.GoodsCategory).ToList(),
                Data = dailyCategorySummary==null?new List<NameValue>():dailyCategorySummary.Select(item => new NameValue { value = item.GoodsAmount, name = item.GoodsCategory }).ToList()
            };
            var dailyRankStoreBarSummary = ReportBLL.Instance.RptDailyRankStoreBarData<DailyStoreBarModel>(date, date);
            //门店销售top 10 排行
            ViewData["DailyRankStoreBarData"] = new SimpleDailyChartModel {
                xAxis = dailyRankStoreBarSummary == null ?new List<string>():dailyRankStoreBarSummary.Select(item => item.StoreName).ToList(),
                seriesData = dailyRankStoreBarSummary == null ? new List<string>() : dailyRankStoreBarSummary.Select(item => item.GoodsAmount).ToList(),
            };
        }

    }
}
