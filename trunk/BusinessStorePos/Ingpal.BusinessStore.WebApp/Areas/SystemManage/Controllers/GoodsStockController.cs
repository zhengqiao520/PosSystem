using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ingpal.BusinessStore.Business;
using Ingpal.BusinessStore.Model;
using System.Collections.Specialized;
using Ingpal.BusinessStore.Infrastructure;
namespace Ingpal.BusinessStore.WebApp.Areas.SystemManage.Controllers
{
    public class GoodsStockController : BaseController
    {
        private StockBusiness stockBLL = new StockBusiness();
        UserInfo user = UserInfo.Instance;
        /// <summary>
        /// 获取库存列表
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetGoodsStockListJson(Pagination pagination,Model.StockQueryAgrs entity)
        {

            //if (user.IsAdmin&&string.IsNullOrEmpty(entity.StoreID.ToString()))
            //{
            //    entity.StoreID = null;
            //}
            //if(!user.IsAdmin) {
            //    entity.StoreID = user.StoreID;
            //}
            var stockList = QueryGoods(entity);
            if (stockList == null) {
                return Error("未找到符合条件的记录！");
            }
            return Content(GetPagingJson(stockList, pagination));
        }

        [HttpGet]
        public ActionResult GoodsOutListJson(Pagination pagination, Model.GoodsOutQueryArgs entity)
        {
            if (entity.BeginDate == DateTime.MinValue)
            {
                entity.BeginDate = null;
            }
            if (entity.EndDate == DateTime.MinValue)
            {
                entity.EndDate = null;
            }
            if (entity.EndDate != null && entity.EndDate != DateTime.MinValue)
            {
                entity.EndDate = entity.EndDate?.AddDays(1);
            }
            if (entity.BeginDate != null && entity.EndDate !=null && entity.BeginDate > entity.EndDate)
            {
                return Error("开始日期必须小于结束日期！");
            }
            if (entity.StoreId > 0 && entity.StoreId == entity.ReceiverStoreId)
            {
                return Error("出库方和接收方不能为同一个门店！");
            }

            if (!user.IsAdmin && entity.StoreId != user.StoreID && entity.ReceiverStoreId != user.StoreID)
            {
                return Error("请查询当前门店相关记录！");
            }

            entity.GoodsOutType = 1;

            var goodsOutList = QueryGoodsOut(entity);
            return Content(GetPagingJson(goodsOutList, pagination));
        }
        private List<GoodsStockExtend> QueryGoods(Model.StockQueryAgrs entity)
        {
            if (user.IsAdmin && string.IsNullOrEmpty(entity.StoreID.ToString()))
            {
                entity.StoreID = null;
            }
            if (!user.IsAdmin)
            {
                entity.StoreID = user.StoreID;
            }
            return stockBLL.GetGoodsStockInfo(entity);
        }

        private List<GoodsOutFullInfo> QueryGoodsOut(Model.GoodsOutQueryArgs args)
        {
            return StockBLL.Instance.GetGoodsOutListWithArgs(args);

        }
        public ActionResult GoodsInListJson(GoodsOutQueryArgs args)
        {
            if (args.BeginDate == DateTime.MinValue)
            {
                args.BeginDate = null;
            }
            if (args.BeginDate == DateTime.MinValue)
            {
                args.EndDate = null;
            }
            if (args.EndDate != null && args.EndDate != DateTime.MinValue)
            {
                args.EndDate = args.EndDate?.AddDays(1);
            }
            if (args.BeginDate != null && args.EndDate != null && args.BeginDate > args.EndDate)
            {
                return Error("开始日期必须小于结束日期！");
            }
            if (user.IsAdmin && string.IsNullOrEmpty(args.StoreId.ToString()))
            {
                args.StoreId = -1;
            }
            if (!user.IsAdmin)
            {
                args.StoreId = user.StoreID??-1;
            }
            var res=StockBLL.Instance.GetGoodsInListForWeb(args);
            return Content(res!=null ? res.ToJson() : "未找到符合条件的记录");
        }
        /// <summary>
        /// 更新预警库存数量
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SubmitGoodsStockForm()
        {
            var nameVlues = Request.Params;
            var entity = new GoodsEntity
            {
                AlarmAmount= nameVlues["AlarmAmount"].ToInt32(),
                StoreID=nameVlues["StoreID"].ToInt32(),
                BarID=nameVlues["BarID"].ToString()
            };
            //if (!(entity.AlarmAmount > 0)) {
            //    return Error("库存预警数量必须大于0！");
            //}
            if (string.IsNullOrEmpty(entity.BarID)) {
                return Error("商品条码异常无法更新库存预警数！");
            }
            var res = stockBLL.UpdateGoogsAlarmCount(entity) > 0;
            var success = new { AlarmAmount = entity.AlarmAmount, state = ResultType.success.ToString(), message = "更新库存预警成功！" }.ToJson();
            return res ? Success(success) : Error("更新预警库存失败！");
        }
        public override ActionResult Index()
        {
            ViewBag.Stores = SysBLL.Instance.GetALL<StoreInfoEntity>().Select(item => new { ID = item.ID, Name = item.StoreName }).ToJson();
            return base.Index();
        }

        public ActionResult GoodsOutList()
        {
            var stores = SysBLL.Instance.GetALL<StoreInfoEntity>().Select(item => new { ID = item.ID, Name = item.StoreName }).ToList();

            stores.Add(new { ID = -1, Name = "全部" });
            stores.Sort((a1, a2) => { return a1.ID.CompareTo(a2.ID); });
            ViewBag.Stores = stores.ToJson();
            return View();



        }

        public ActionResult GoodsInList()
        {
            var stores = SysBLL.Instance.GetALL<StoreInfoEntity>().Select(item => new { ID = item.ID, Name = item.StoreName }).ToList();

            stores.Add(new { ID = -1, Name = "全部" });
            stores.Sort((a1, a2) => { return a1.ID.CompareTo(a2.ID); });
            ViewBag.Stores = stores.ToJson();
            return View();
        }
        public override ActionResult Success(string message)
        {
            return Content(message);
        }
        [HttpGet]
        public FileResult ExportExcel()
        {
            Model.StockQueryAgrs entity = new StockQueryAgrs();
            entity.StoreID = (Request["StoreID"] == null) ? null : Request["StoreID"].ToString().ToNullableInt32();
            entity.Category = Request["Catetory"];
            entity.ProductName = Request["ProductName"];
            List<string> exportFields = new List<string> { "StoreName", "BarID", "Name", "Category", "RetailPrice", "SaleQuantity", "StockQuantity", "AlarmAmount" };
            System.IO.MemoryStream memory = ExcelExport.ExportMemory(QueryGoods(entity), exportFields);
            return File(memory, "application/vnd.ms-excel", $"库存列表{DateTime.Now.ToString("yyyyMMddHH")}.xls");
        }
    }
}