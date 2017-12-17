using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ingpal.BusinessStore.Business;
using Ingpal.BusinessStore.Model;
using Ingpal.BusinessStore.WebApp.Extension;
using Ingpal.BusinessStore.Infrastructure;
namespace Ingpal.BusinessStore.WebApp.Areas.SystemManage.Controllers
{
    public class GoodsGrantController : BaseController
    {
        [HttpGet]
        public ActionResult GetGoodsGrantListExt(Pagination pagination, string grantType,string storeID="1001")
        {
            var goodsList= GoodsBLL.instance.GetGoodsGrantListExt(int.Parse(storeID), grantType);
            return Content(GetPagingJson(goodsList, pagination));
        }
        [HttpPost]
        public ActionResult SubmitGoodsGrant()
        {
            PartialLog log = new PartialLog();
            System.Data.DataRow dataRow = null;
            var selectIds = Request.Params["selectIds"].ToString();
            var unselectIds = Request.Params["unselectIds"].ToString();
            var storeID = int.Parse(Request.Params["storeID"]);
            log.Description = $"商品授权：{storeID}门店授权商品";
            log.ModuleName = "商品管理";
            try
            {
                dataRow = GoodsBLL.instance.SetGrantGoods(storeID, selectIds, unselectIds);
                log.Result = (dataRow!=null)? ResultType.success.ToString() : ResultType.error.ToString();
                WriteLog(log);
            }
            catch(Exception ee)
            {
                log.Result = ResultType.error.ToString();
                WriteLog(log);
                return Error("授权失败!" + ee.Message);
            }
            return dataRow==null?Error("授权失败！"):Success("操作成功！");
        }
        public ActionResult GetTreeJson()
        {
            var data = SysBLL.Instance.GetALL<MDMTypeEntity>();
            var treeList = new List<TreeViewModel>();
            foreach (var item in data)
            {
                TreeViewModel tree = new TreeViewModel();
                bool hasChildren = data.Count(t => t.ParentID == item.ID) == 0 ? false : true;
                tree.id = item.ID.ToString();
                tree.text = item.TypeName;
                tree.value = item.TypeValue;
                tree.parentId = item.ParentID.ToString();
                tree.isexpand = true;
                tree.complete = true;
                tree.hasChildren = hasChildren;
                treeList.Add(tree);
            }
            return Content(treeList.TreeViewJson());
        }
        public override ActionResult Index()
        {
            ViewBag.Stores = SysBLL.Instance.GetALL<StoreInfoEntity>().Select(item => new { ID = item.ID, Name = item.StoreName }).ToJson();
            return base.Index();
        }
        [HttpGet]
        public FileResult ExportExcel()
        {
            string storeID = Request["StoreID"] == null ? "1001" : Request["StoreID"].ToString();
            string grantType = Request["grantTyp"] == null ? "1" : Request["grantTyp"].ToString();
            var goodsList = GoodsBLL.instance.GetGoodsGrantListExt(int.Parse(storeID), grantType);
            List<string> exportFields = new List<string> { "IsGrantText", "BarID", "OuterBarID","Name", "Category", "RetailPrice"};
            System.IO.MemoryStream memory = ExcelExport.ExportMemory(goodsList, exportFields);
            return File(memory, "application/vnd.ms-excel", $"商品授权{DateTime.Now.ToString("yyyyMMddHH")}.xls");

        }
    }
}