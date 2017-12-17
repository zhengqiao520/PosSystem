using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ingpal.BusinessStore.Business;
using Ingpal.BusinessStore.Model;
namespace Ingpal.BusinessStore.WebApp.Areas.SaleManage.Controllers
{
    public class SaleController : BaseController
    {
        private SaleBusiness saleBLL = new SaleBusiness();
        [HttpGet]
        public ActionResult GetSaleListJson(Pagination pagination, Model.SaleQueryEntity entity)
        {
            var res = PosBLL.instance.GetAdminPostList(entity);
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
        public ActionResult GetSalieDetailJson(Guid keyValue)
        {

            var data = saleBLL.SaleDetailQuery(new Model.SaleQueryAgrs { PosID = keyValue });
            if (data != null && data.Rows.Count > 0)
            {
                var listDetailEntity = Ingpal.BusinessStore.Infrastructure.ConvertHelper.ConvertToModel<Model.Entity.PosDetailEntity>(data);
                return Content(listDetailEntity.ToJson());
            }
            return Error("数据加载失败！");
        }

        [HttpGet]
        public ActionResult GetGuiderInfoListByStoreID(int storeID)
        {
            var list = StoreBLL.Instance.QueryGuiderInfoListByStoreID(storeID);
            return Content(list.ToJson());
        }
    }
}