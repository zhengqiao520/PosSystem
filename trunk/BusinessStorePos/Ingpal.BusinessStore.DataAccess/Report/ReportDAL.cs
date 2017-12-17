using Ingpal.BusinessStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingpal.BusinessStore.DataAccess
{
    public class ReportDAL : BaseDAL
    {
        /// <summary>
        /// 首页指标报表
        /// </summary>
        /// <param name="yearMonth"></param>
        /// <returns></returns>
        public static List<IndexSummary> RptIndexSummary(string yearMonth = "")
        {
            var rptData = utity.ExecuteListSp<IndexSummary>("rpt_IndexSummary", new object[] { yearMonth });
            if (rptData != null)
            {
                return rptData.ToList();
            }
            return null;
        }
        public static List<T> RptDailyCategoryPieData<T>(string startData = "", string endData = "")
        {
            return utity.ExecuteListSp<T>("rpt_DailyCategoryPieData", new object[] { startData, endData });
        }
        public static List<T> RptDailyRankStoreBarData<T>(string startData = "", string endData = "")
        {

            return utity.ExecuteListSp<T>("RptDailyStoreBarData", new object[] { startData, endData });
        }


        /// <summary>
        /// 查询指定日期的销售数据
        /// </summary>
        /// <param name="preDtStart"></param>
        /// <param name="lastDtEnd"></param>
        /// <returns></returns>
        public static List<SaleGoodsList> GetSaleGoodsDetail(string preDtStart, string lastDtEnd)
        {
            var qData = utity.ExecuteListSp<SaleGoodsList>("usp_GetSaleGoodsDetail", new object[] { preDtStart, lastDtEnd });
            if (qData != null)
            {
                return qData;
            }
            return null;
        }

        /// <summary>
        /// 查询支付方式与支付金额的汇总数据
        /// </summary>
        /// <param name="dtStart"></param>
        /// <param name="dtEnd"></param>
        /// <returns></returns>
        public static List<PosPayTypeList> GetPosPayTypeSummary(string dtStart, string dtEnd)
        {
            var qData = utity.ExecuteListSp<PosPayTypeList>("usp_GetPosPayTypeDetail", new object[] { dtStart, dtEnd });
            if (qData != null)
            {
                return qData;
            }
            return null;
        }

        /// <summary>
        /// 查询导购业绩报表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static List<GuiderPerformanceRptList> GetGuiderPerformanceSummary(GuiderPerformanceRptEntity model)
        {
            var qData = utity.ExecuteListSp<GuiderPerformanceRptList>("usp_GuiderPerformanceReport", new object[] { model.StoreID, model.QueryStartDate, model.QueryEndDate, model.GuiderID });
            return qData;
        }

        /// <summary>
        /// 查询门店销售统计报表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static List<StoreSaleRptList> GetStoreSaleSummary(GuiderPerformanceRptEntity model)
        {
            var qData = utity.ExecuteListSp<StoreSaleRptList>("usp_StoreSaleReport", new object[] { model.StoreID, model.QueryStartDate, model.QueryEndDate, model.GuiderID });
            return qData;
        }
        /// <summary>
        /// 销售汇总报表
        /// </summary>
        /// <param name="queryAgrs"></param>
        /// <returns></returns>

        public static List<SummarySale> RptGetSummarySale(SaleQueryEntity queryAgrs)
        {
            return utity.ExecuteListSp<SummarySale>("rpt_SummarySale", new object[] {queryAgrs.StoreID,queryAgrs.SaleStartTime,queryAgrs.SaleEndTime,queryAgrs.PayType,queryAgrs.Guider });
        }
        /// <summary>
        /// 销售明细报表
        /// </summary>
        /// <param name="queryAgrs"></param>
        /// <returns></returns>
        public static List<SummerSaleList> RptGetSummarySaleList(SaleQueryEntity queryAgrs) {
            return utity.ExecuteListSp<SummerSaleList>("rpt_SaleList", new object[] {
                 queryAgrs.StoreID,
                 queryAgrs.SaleStartTime,
                 queryAgrs.SaleEndTime,
                 queryAgrs.Guider,
                 queryAgrs.Category,
                 queryAgrs.GoodsName,
                 queryAgrs.TicketCode,
                 queryAgrs.RecordStatus
            });
        }

    }
}
