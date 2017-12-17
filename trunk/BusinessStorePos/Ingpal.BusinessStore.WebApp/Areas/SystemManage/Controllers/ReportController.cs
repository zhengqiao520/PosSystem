using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ingpal.BusinessStore.Business;
using Ingpal.BusinessStore.Model;
using Ingpal.BusinessStore.Infrastructure;

namespace Ingpal.BusinessStore.WebApp.Areas.SystemManage.Controllers
{
    public class ReportController : BaseController
    {
        public ReportController()
        {
            ViewBag.Stores = SysBLL.Instance.GetALL<StoreInfoEntity>().Select(item => new { ID = item.ID, Name = item.StoreName }).ToJson();
        }
        public ActionResult RptIndexSummary()
        {
            return JavaScript($"var RptIndexSummary = {GetChartKPI(ChartType.TopTileChart)},SaleSummary={GetChartKPI(ChartType.SaleBartChart)},PosPayTypeSummary={GetChartKPI(ChartType.PayTypeBarChart)}");
        }
        private string GetChartKPI(ChartType chartType)
        {
            var chartJsonString = string.Empty;
            switch (chartType)
            {
                case ChartType.PayTypeBarChart:
                    chartJsonString = ReportBLL.GetPosPayTypeSummary().ToJson();
                    break;
                case ChartType.TopTileChart:
                    chartJsonString = ReportBLL.Instance.RptIndexSummary(DateTime.Now.ToString("yyyyMM"))[0].ToJson();
                    break;
                case ChartType.SaleBartChart:
                    chartJsonString = ReportBLL.GetSaleGoodsDetail().ToJson();
                    break;
                default:
                    break;
            }
            return chartJsonString;
        }

        private enum ChartType
        {
            /// <summary>
            /// 顶部磁贴图
            /// </summary>
            TopTileChart,
            /// <summary>
            /// 支付方式柱状图
            /// </summary>
            PayTypeBarChart,
            /// <summary>
            /// 按周销售柱状图
            /// </summary>
            SaleBartChart
        }
        public ActionResult SummarySale()
        {
            return View();
        }
        public ActionResult SummarySaleList()
        {
            return View();
        }
        [HttpGet]
        public ActionResult SummarySaleJson(Pagination pagination, Model.SaleQueryEntity entity)
        {
            var res = ReportBLL.Instance.RptGetSummarySale(entity);
            if (res != null)
            {
                return Content(GetPagingJson(res.ToList(), pagination));
            }
            else
            {
                return Error("未找到符合条件的记录!");
            }
        }
        [HttpGet]
        public ActionResult SummarySaleListJson(Pagination pagination, SaleQueryEntity queryAgrs)
        {
            var res = ReportBLL.Instance.RptGetSummarySaleList(queryAgrs);
            if (res != null)
            {
                return Content(GetPagingJson(res.ToList(), pagination));
            }
            else
            {
                return Error("未找到符合条件的记录!");
            }
        }

        public ActionResult StoresSale()
        {
            //ViewBag.Stores = SysBLL.Instance.GetALL<StoreInfoEntity>().Select(item => new { ID = item.ID, Name = item.StoreName }).ToJson();
            return View();
        }

        public ActionResult GuiderSale()
        {
            //ViewBag.Stores = SysBLL.Instance.GetALL<StoreInfoEntity>().Select(item => new { ID = item.ID, Name = item.StoreName }).ToJson();
            return View();
        }

        public ActionResult GetGuiderPerformance(Pagination pagination, GuiderPerformanceRptModel model)
        {
            var data = ReportBLL.GetGuiderPerformanceSummary(model);
            return Content(GetPagingJson(data, pagination));
        }

        public ActionResult GetStoresSale(Pagination pagination, GuiderPerformanceRptModel model)
        {
            var data = ReportBLL.GetStoreSaleSummary(model);
            return Content(GetPagingJson(data, pagination));
        }

        /// <summary>
        /// 导购销售报表导出
        /// </summary>
        /// <returns></returns>
        public FileResult ExportGuiderSaleExcel()
        {
            var data = ReportBLL.GetGuiderPerformanceSummary(new GuiderPerformanceRptModel
            {
                GuiderID = Request["GuiderID"],
                QueryStartDate = Request["QueryStartDate"],
                QueryEndDate = Request["QueryEndDate"],
                StoreID = Request["StoreID"]
            });
            List<string> exportFields = new List<string> { "GuiderName", "StoreName", "GoodsAmount", "GoodsNum", "RefundAmount", "ReturnGoodsNum" };
            if (data == null || !data.Any())
            {
                data = new List<GuiderPerformanceRptList>() {
                    new GuiderPerformanceRptList {
                        GuiderName="合计",GoodsAmount=0m,GoodsNum=0,RefundAmount=0m,ReturnGoodsNum=0
                    }
                };
            }
            System.IO.MemoryStream memory = ExcelExport.ExportMemory(data, exportFields);
            return File(memory, "application/vnd.ms-excel", $"导购业绩报表{DateTime.Now.ToString("yyyyMMddHH")}.xls");
        }

        /// <summary>
        /// 门店销售报表导出
        /// </summary>
        /// <returns></returns>
        public FileResult ExportStoresSaleExcel()
        {
            var data = ReportBLL.GetStoreSaleSummary(new GuiderPerformanceRptModel
            {
                GuiderID = Request["GuiderID"],
                QueryStartDate = Request["QueryStartDate"],
                QueryEndDate = Request["QueryEndDate"],
                StoreID = Request["StoreID"]
            });
            List<string> exportFields = new List<string> { "StoreID", "StoreName", "GoodsAmount", "GoodsNum", "RefundAmount", "ReturnGoodsNum", "CardMode", "WeChatMode", "AlipayMode", "CashMode", "MarketMode" };
            if (data == null || !data.Any())
            {
                data = new List<StoreSaleRptList>() {
                    new StoreSaleRptList { StoreID="合计",GoodsAmount=0m,GoodsNum=0,RefundAmount=0m,ReturnGoodsNum=0 }
                };
            }
            System.IO.MemoryStream memory = ExcelExport.ExportMemory(data, exportFields);
            return File(memory, "application/vnd.ms-excel", $"门店销售统计报表{DateTime.Now.ToString("yyyyMMddHH")}.xls");
        }

        /// <summary>
        /// 销售汇总导出
        /// </summary>
        /// <returns></returns>
        public FileResult ExportSummarySale()
        {
            var data = ReportBLL.Instance.RptGetSummarySale(new SaleQueryEntity
            {
                StoreID = (Request["StoreID"] == null) ? null : Request["StoreID"].ToString().ToNullableInt32(),
                SaleStartTime = Request["SaleStartTime"].ToDateTime(),
                SaleEndTime = Request["SaleEndTime"].ToDateTime(),
                Guider = Request["Guider"],
                PayType = Request["PayType"],
            });
            List<string> exportFields = new List<string> { "TicketCode", "SaleDate", "StoreName", "TotalCount", "GoodsAmount", "DiscountAmount", "ActualAmount", "PayType", "Cashier", "Guider", "ReturnGoodsCount", "RefundAmount" };
            System.IO.MemoryStream memory = ExcelExport.ExportMemory(data, exportFields);
            return File(memory, "application/vnd.ms-excel", $"销售汇总统计报表{DateTime.Now.ToString("yyyyMMddHH")}.xls");
        }
        /// <summary>
        /// 销售明细导出
        /// </summary>
        /// <returns></returns>
        public FileResult ExportSummarySaleList()
        {
            var data = ReportBLL.Instance.RptGetSummarySaleList(new SaleQueryEntity
            {
                StoreID = (Request["StoreID"] == null) ? null : Request["StoreID"].ToString().ToNullableInt32(),
                SaleStartTime = Request["SaleStartTime"].ToDateTime(),
                SaleEndTime = Request["SaleEndTime"].ToDateTime(),
                Guider = Request["Guider"],
                Category = Request["GoodsType"],
                GoodsName = Request["GoodsName"]

            });
            List<string> exportFields = new List<string> { "TicketCode", "StoreName", "GoodsName", "GoodsCategory", "RetailPrice", "GoodsCount", "GoodsAmount", "Guider", "SaleDate", "ReturnCount", "ReturnAmount" };
            System.IO.MemoryStream memory = ExcelExport.ExportMemory(data, exportFields);
            return File(memory, "application/vnd.ms-excel", $"销售明细统计报表{DateTime.Now.ToString("yyyyMMddHH")}.xls");
        }
    }
}