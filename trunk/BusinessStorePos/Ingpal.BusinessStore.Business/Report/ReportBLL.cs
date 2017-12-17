namespace Ingpal.BusinessStore.Business
{
    using System;
    using System.Collections.Generic;
    using Ingpal.BusinessStore.DataAccess;
    using Model;
    using System.Linq;
    using Infrastructure;

    public class ReportBLL
    {
        public static ReportBLL Instance = new ReportBLL();
        private ReportBLL() { }
        public List<IndexSummary> RptIndexSummary(string yearMonth = "")
        {
            return ReportDAL.RptIndexSummary(yearMonth);

        }
        public List<T> RptDailyCategoryPieData<T>(string startData = "", string endData = "")
        {
            return ReportDAL.RptDailyCategoryPieData<T>(startData, endData);
        }

        public List<T> RptDailyRankStoreBarData<T>(string startData = "", string endData = "")
        {
            return ReportDAL.RptDailyRankStoreBarData<T>(startData, endData);
        }
        /// <summary>
        /// 销售汇总报表
        /// </summary>
        /// <param name="queryAgrs"></param>
        /// <returns></returns>
        public List<SummarySale> RptGetSummarySale(SaleQueryEntity queryAgrs)
        {
            var data = ReportDAL.RptGetSummarySale(queryAgrs);
            if (data != null && data.Any())
            {
                var cnt = data.Count;
                var tag = "合计";
                if (data[cnt - 1].TicketCode == tag)
                {
                    var castData = new List<SummarySale>();
                    castData.Add(data[cnt - 1]);
                    castData.AddRange(data.Where(s => s.TicketCode != tag).ToList());
                    return castData;
                }
                return data;
            }
            return data;
        }
        /// <summary>
        /// 查询指定日期的销售数据
        /// </summary>
        /// <returns></returns>
        public static SaleGoodsSummary GetSaleGoodsDetail()
        {
            var dt = DateTime.Now;
            var dayCnt = 7;
            var preDt0 = dt.AddDays(Convert.ToInt32(1 - Convert.ToInt32(dt.DayOfWeek)) - dayCnt);
            var preDt1 = preDt0.AddDays(dayCnt - 1);
            var lastDt0 = dt.AddDays(1 - Convert.ToInt32(dt.DayOfWeek.ToString("d")));
            var qData = ReportDAL.GetSaleGoodsDetail(ConvertHelper.FormatDate(preDt0), ConvertHelper.FormatDate(dt));
            var defaultSummary = Enumerable.Repeat(0m, dayCnt).ToList();
            var preSaleSummary = defaultSummary;
            var lastSaleSummary = defaultSummary;
            var func = new Func<DateTime, DateTime, List<decimal>>((s, t) =>
            {
                var list = new List<decimal>();
                DateTime q0 = s < t ? s : t;
                DateTime q1 = q0 == s ? t : s;
                for (var s0 = 0; s0 < dayCnt; s0++)
                {
                    var p = ConvertHelper.FormatDate(q0.AddDays(s0));
                    var data = qData.FirstOrDefault(k => k.SaleDate == p);
                    list.Add(data == null ? 0m : data.GoodsAmount);
                }
                return list;
            });
            if (qData != null && qData.Any())
            {
                preSaleSummary = func(preDt0, preDt1);
                lastSaleSummary = func(lastDt0, dt);
            }
            return new SaleGoodsSummary { PreSaleSummary = preSaleSummary, LastSaleSummary = lastSaleSummary };
        }

        /// <summary>
        /// 查询支付方式与支付金额的汇总数据
        /// </summary>
        /// <returns></returns>
        public static List<PosPayTypeList> GetPosPayTypeSummary()
        {
            var dt = DateTime.Now;
            var tDt = ConvertHelper.FormatDate(dt.AddDays(1));
            var data = ReportDAL.GetPosPayTypeSummary(ConvertHelper.FormatDate(dt), tDt);
            return data;
        }

        /// <summary>
        /// 查询导购业绩报表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static List<GuiderPerformanceRptList> GetGuiderPerformanceSummary(GuiderPerformanceRptModel model)
        {
            var entity = new GuiderPerformanceRptEntity();
            if (!string.IsNullOrWhiteSpace(model.QueryStartDate))
            {
                DateTime dt0;
                if (DateTime.TryParse(model.QueryStartDate, out dt0)) { entity.QueryStartDate = ConvertHelper.FormatDate(dt0); }
            }
            if (!string.IsNullOrWhiteSpace(model.QueryEndDate))
            {
                DateTime dt1;
                if (DateTime.TryParse(model.QueryEndDate, out dt1)) { entity.QueryEndDate = ConvertHelper.FormatDate(dt1.AddDays(1).Date); }
            }
            var storeID = 0;
            Guid guid;
            int.TryParse(model.StoreID, out storeID);
            entity.StoreID = storeID;
            entity.GuiderID = !Guid.TryParse(model.GuiderID, out guid) ? null : model.GuiderID;
            return ReportDAL.GetGuiderPerformanceSummary(entity);
        }

        /// <summary>
        /// 查询门店销售统计报表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static List<StoreSaleRptList> GetStoreSaleSummary(GuiderPerformanceRptModel model)
        {
            var entity = new GuiderPerformanceRptEntity();
            if (!string.IsNullOrWhiteSpace(model.QueryStartDate))
            {
                DateTime dt0;
                if (DateTime.TryParse(model.QueryStartDate, out dt0)) { entity.QueryStartDate = ConvertHelper.FormatDate(dt0); }
            }
            if (!string.IsNullOrWhiteSpace(model.QueryEndDate))
            {
                DateTime dt1;
                if (DateTime.TryParse(model.QueryEndDate, out dt1)) { entity.QueryEndDate = ConvertHelper.FormatDate(dt1.AddDays(1).Date); }
            }
            var storeID = 0;
            Guid guid;
            int.TryParse(model.StoreID, out storeID);
            entity.StoreID = storeID;
            entity.GuiderID = !Guid.TryParse(model.GuiderID, out guid) ? null : model.GuiderID;
            return ReportDAL.GetStoreSaleSummary(entity);
        }
        /// <summary>
        /// 销售明细报表
        /// </summary>
        /// <param name="queryAgrs"></param>
        /// <returns></returns>
        public List<SummerSaleList> RptGetSummarySaleList(SaleQueryEntity queryAgrs)
        {
            return ReportDAL.RptGetSummarySaleList(queryAgrs);
        }
    }
}
