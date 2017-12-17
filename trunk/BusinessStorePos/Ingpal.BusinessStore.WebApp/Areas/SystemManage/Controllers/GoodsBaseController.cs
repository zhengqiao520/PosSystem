using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ingpal.BusinessStore.Business;
using Ingpal.BusinessStore.Model;
using Ingpal.BusinessStore.Infrastructure;
using Ingpal.BusinessStore.Infrastructure.DB;
namespace Ingpal.BusinessStore.WebApp.Areas.SystemManage.Controllers
{
    public class GoodsBaseController : BaseController
    {
        private DBUtility utity = new DBUtility();
        public ActionResult GetGoodsBaseFormJson(Pagination pagination)
        {
            try
            {
                var result = GetGoodsBaseList();
                if (!string.IsNullOrEmpty(pagination.keyword))
                {
                    var keyword = pagination.keyword;
                    result = result.Where(item => item.Category.Contains(keyword) ||
                                         item.BarID.Contains(keyword) ||
                                         item.Name.Contains(keyword)).ToList();
                }
                var paginationJson = GetPagingJson(result, pagination);
                return Content(paginationJson);
            }
            catch (Exception e)
            {
                return Error(e.Message);
            }
        }
        private List<GoodsBaseEntity> GetGoodsBaseList()
        {
            return SysBLL.Instance.GetALL<GoodsBaseEntity>().OrderBy(s => s.Category).ToList();
        }
        /// <summary>
        /// 更新商品列表
        /// </summary>
        /// <param name="pagination"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SubmitGoodsBaseForm(GoodsBaseUpdateModel entity)
        {
            Guid guid;
            int categoryID;
            decimal retailPrice;
            if (string.IsNullOrWhiteSpace(entity.BarID) || !Guid.TryParse(entity.GoodsBaseGuid, out guid) || !int.TryParse(entity.CategoryID, out categoryID) || !decimal.TryParse(entity.RetailPrice, out retailPrice))
                return Error("参数不能为空");
            var goodsBaseQuery = SysBLL.Instance.GetALL<GoodsBaseEntity>();
            if (goodsBaseQuery.Any(s => s.BarID == entity.BarID && s.ID != guid))
                return Error("条码已存在！");
            var query = SysBLL.Instance.GetALL<CategoryEntity>().FirstOrDefault(item => item.ID == categoryID);
            if (query == null)
                return Error("不存在的商品分类！");

            using (System.Data.Common.DbTransaction trans = utity.Transation)
            {
                var res = GoodsBLL.instance.UpdateGoodsBase(new GoodsBaseUpdateEntity
                {
                    GoodsBaseGuid = guid,
                    BarID = entity.BarID,
                    CategoryID = categoryID,
                    Category = query.Category,
                    RetailPrice = retailPrice
                }, trans);
                if (res > 0)
                {
                    trans.Commit();
                }
                else
                {
                    trans.Rollback();
                }
                return res > 0 ? Success("更新成功！") : Error("更新失败！");
            }
        }

        public ActionResult SyncGoodsInfoFromERP() {
            int res=SysBLL.Instance.SyncGoodsInfoFromERP();
            return  Success("商品列表同步完成！");
        }
        [HttpGet]
        public FileResult ExportExcel()
        {
            List<string> exportFields = new List<string> { "BarID", "OuterBarID", "Name", "Category", "CategoryID", "RetailPrice" };
            System.IO.MemoryStream memory = ExcelExport.ExportMemory(GetGoodsBaseList(), exportFields);
            return File(memory, "application/vnd.ms-excel", $"商品列表{DateTime.Now.ToString("yyyyMMddHH")}.xls");
        }

        public ActionResult PriceChangeLogIndex() {
            ViewBag.Stores = SysBLL.Instance.GetALL<StoreInfoEntity>().Select(item => new { ID = item.ID, Name = item.StoreName }).ToJson();
            return View();
        }

        public ActionResult PriceChangeLogList(Pagination pagination,string storeID = "")
        {
            List<PriceChangeLog> priceChangeLogList = SysBLL.Instance.GetALL<PriceChangeLog>().Where(item => item.StoreID == (string.IsNullOrEmpty(storeID) ? item.StoreID : storeID)).ToList();
            if (null != priceChangeLogList && priceChangeLogList.Count() > 0) {
                priceChangeLogList = priceChangeLogList.OrderByDescending(item => item.LogDate).ToList();
            }
            return Content(GetPagingJson(priceChangeLogList, pagination));
        }
    }
}