using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingpal.BusinessStore.Model
{
    /// <summary>
    /// 首页指标
    /// </summary>
    public class IndexSummary
    {
        /// <summary>
        /// 日客均单价
        /// </summary>
        public decimal DayAveSaleAmount { get; set; }
        /// <summary>
        /// 当日销售金额
        /// </summary>
        public decimal DaySaleAmount { get; set; }
        public decimal MonthSaleAmount { get; set; }

        public decimal MemberAmountPCT { get; set; }

        public decimal MemberOrderCountPCT { get; set; }

        public object this[int index]
        {
            get
            {
                return this[index];
            }
            //set
            //{
            //     this[index] = value;
            //}
        }

    }

    /// <summary>
    /// 首页销售明细数据
    /// </summary>
    public class SaleGoodsList
    {
        public decimal GoodsAmount { get; set; }
        public string SaleDate { get; set; }
    }

    /// <summary>
    /// 首页支付方式汇总
    /// </summary>
    public class PosPayTypeList
    {
        public decimal GoodsAmount { get; set; }
        public string PayType { get; set; }
    }

    /// <summary>
    /// 首页销售汇总数据
    /// </summary>
    public class SaleGoodsSummary
    {
        public List<decimal> PreSaleSummary { get; set; }
        public List<decimal> LastSaleSummary { get; set; }
    }

    /// <summary>
    /// 导购业绩报表查询参数
    /// </summary>
    public class GuiderPerformanceRptModel
    {
        public string QueryStartDate { get; set; }
        public string QueryEndDate { get; set; }
        public string StoreID { get; set; }
        public string GuiderID { get; set; }
    }

    public class RptTotalModel
    {
        public string Tag { get; set; }
        public decimal GoodsAmount { get; set; }
        public int GoodsNum { get; set; }
        public decimal RefundAmount { get; set; }
        public int ReturnGoodsNum { get; set; }
    }

    public class GuiderPerformanceRptEntity
    {
        public string QueryStartDate { get; set; }
        public string QueryEndDate { get; set; }
        public int StoreID { get; set; }
        public string GuiderID { get; set; }
    }

    /// <summary>
    /// 导购业绩报表
    /// </summary>
    public class GuiderPerformanceRptList
    {
        [Table(ColumnName = "导购员名称")]
        public string GuiderName { get; set; }
        public Guid GuiderID { get; set; }
        [Table(ColumnName = "所属门店")]
        public string StoreName { get; set; }
        [Table(ColumnName = "销售金额")]
        public decimal GoodsAmount { get; set; }
        [Table(ColumnName = "销售数量")]
        public int GoodsNum { get; set; }
        [Table(ColumnName = "退货金额")]
        public decimal RefundAmount { get; set; }
        [Table(ColumnName = "退货数量")]
        public int ReturnGoodsNum { get; set; }
    }

    /// <summary>
    /// 门店销售统计报表
    /// </summary>
    public class StoreSaleRptList
    {
        [Table(ColumnName = "门店编号")]
        public string StoreID { get; set; }
        [Table(ColumnName = "门店名称")]
        public string StoreName { get; set; }
        [Table(ColumnName = "销售金额")]
        public decimal GoodsAmount { get; set; }
        [Table(ColumnName = "销售数量")]
        public int GoodsNum { get; set; }
        [Table(ColumnName = "退货数量")]
        public decimal RefundAmount { get; set; }
        [Table(ColumnName = "退货金额")]
        public int ReturnGoodsNum { get; set; }
        [Table(ColumnName = "POS刷卡金额/频次")]
        public string CardMode { get; set; }
        [Table(ColumnName = "POS微信金额/频次")]
        public string WeChatMode { get; set; }
        [Table(ColumnName = "POS支付宝金额/频次")]
        public string AlipayMode { get; set; }
        [Table(ColumnName = "现金金额/频次")]
        public string CashMode { get; set; }
        [Table(ColumnName = "商场代收金额/频次")]
        public string MarketMode { get; set; }
    }

    public class DailyCategorySummary
    {
        public string GoodsAmount { get; set; }
        public string GoodsCategory { get; set; }
    }
    /// <summary>
    /// 首页饼图模型
    /// </summary>
    public class CategoryPieChartModel
    {
        public string Tile { get; set; }
        public List<string> LegendData { get; set; }
        public List<NameValue> Data { get; set; }

    }
    public class NameValue
    {
        public string name { get; set; }
        public string value { get; set; }
    }


    /// <summary>
    ///
    /// </summary>
    public class DailyStoreBarModel
    {
        public string GoodsAmount { get; set; }
        public string StoreID { get; set; }
        public string StoreName { get; set; }
    }
    public class SimpleDailyChartModel
    {
        public string Title { get; set; }
        public List<string> xAxis { get; set; }
        public List<List<string>> seriesDataList { get; set; }
        public List<string> seriesData { get; set; }
    }

}