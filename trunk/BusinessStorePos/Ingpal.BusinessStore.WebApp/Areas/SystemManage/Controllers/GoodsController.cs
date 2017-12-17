using Ingpal.BusinessStore.Model;
using Ingpal.BusinessStore.WebApp.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using Ingpal.BusinessStore.Infrastructure;
using System.Data.Common;
using Ingpal.BusinessStore.Infrastructure.DB;
using Ingpal.BusinessStore.Business;
using AutoMapper;

namespace Ingpal.BusinessStore.WebApp.Areas.SystemManage.Controllers
{
    public class GoodsController : BaseController
    {
        internal static DBUtility utity = new DBUtility();
        /// <summary>
        /// 商品分类树
        /// </summary>
        /// <returns></returns>
        public ActionResult GetGoodsTreeJson()
        {
            var category = Business.SysBLL.Instance.GetALL<Model.CategoryEntity>();
            var treeList = new List<TreeSelectModel>();
            foreach (var item in category)
            {
                TreeSelectModel treeModel = new TreeSelectModel();
                treeModel.id = item.ID.ToString();
                treeModel.text = item.Category;
                treeModel.parentId = item.ParentCategoryID.ToString();
                treeModel.data = item;
                treeList.Add(treeModel);
            }
            return Content(treeList.TreeSelectJson());
        }

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetTreeJson()
        {
            var category = Business.SysBLL.Instance.GetALL<Model.CategoryEntity>();
            var treeList = new List<TreeViewModel>();
            foreach (var item in category)
            {
                TreeViewModel tree = new TreeViewModel();
                bool hasChildren = category.Count(t => t.ParentCategoryID == item.ID) == 0 ? false : true;
                tree.id = item.ID.ToString();
                tree.text = item.Category;
                tree.value = item.ID.ToString();
                tree.parentId = item.ParentCategoryID.ToString();
                tree.isexpand = true;
                tree.complete = true;
                tree.hasChildren = hasChildren;
                treeList.Add(tree);
            }
            return Content(treeList.TreeViewJson());
        }


        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetTreeGridJson(string keyword)
        {
            var data = Business.SysBLL.Instance.GetALL<Model.CategoryEntity>();
            if (!string.IsNullOrEmpty(keyword))
            {
                data = data.TreeWhere(t => t.Category.Contains(keyword));
            }
            var treeList = new List<TreeGridModel>();
            foreach (var item in data)
            {
                TreeGridModel treeModel = new TreeGridModel();
                bool hasChildren = data.Count(t => t.ParentCategoryID == item.ID) == 0 ? false : true;
                treeModel.id = item.ID.ToString();
                treeModel.isLeaf = hasChildren;
                treeModel.parentId = item.ParentCategoryID.ToString();
                treeModel.expanded = hasChildren;
                treeModel.entityJson = item.ToJson();
                treeList.Add(treeModel);
            }
            return Content(treeList.TreeGridJson());
        }

        /// <summary>
        /// 查询商品分类详情
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetGoodsCategoryDetails(string keyValue)
        {
            if (string.IsNullOrWhiteSpace(keyValue))
                return Content("");
            var category = SysBLL.Instance.GetALL<CategoryEntity>().FirstOrDefault(s => s.ID.ToString() == keyValue);
            return Content(category.ToJson());
        }

        /// <summary>
        /// 编辑商品分类详情
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SubmitGoodsCategoryForm(CategoryEntity entity, string keyValue)
        {
            if (string.IsNullOrWhiteSpace(entity.Category))
                return Error("商品分类名称不能为空！");
            var existGoodsCategory = SysBLL.Instance.GetALL<CategoryEntity>().Where(item => item.Category == entity.Category);
            var isEdit = !string.IsNullOrWhiteSpace(keyValue);
            if (existGoodsCategory.Any(s => (isEdit && s.ID != entity.ID) || !isEdit))
                return Error("商品分类名称已存在请修改！");
            var res = GoodsBLL.instance.UpdateGoodsCategory(entity);
            return res > 0 ? Success("更新成功！") : Error("更新失败！");
        }

        /// <summary>
        /// 删除商品分类详情
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DeleteGoodsCategoryForm(string keyValue)
        {
            var categoryID = 0;
            if (!int.TryParse(keyValue, out categoryID))
                return Error("不存在的商品分类！");
            var query = SysBLL.Instance.GetALL<CategoryEntity>().Where(item => item.ParentCategoryID == categoryID);
            if (query.Any())
                return Error("请先删除该商品分类下的小类！");
            var existCategory = SysBLL.Instance.GetALL<GoodsBaseEntity>().Any(item => item.CategoryID == categoryID);
            if (existCategory)
                return Error("该商品分类下存在商品，不允许被删除！");
            var res = GoodsBLL.instance.DelGoodsCategory(categoryID);
            return res > 0 ? Success("删除成功！") : Error("删除失败！");
        }

        /// <summary>
        /// 新增或修改门店商品
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public ActionResult SubmitGoodsStoreForm(GoodsEntity entity, string keyValue)
        {
            if (string.IsNullOrEmpty(keyValue))
            {
                entity.ID = Guid.NewGuid();
                var res = Business.GoodsBLL.instance.InsertOrUpdateGoods(entity, OperationType.Insert);
                return res ? Success("添加商品入库成功！") : Error("添加商品入库失败！");
            }
            else
            {
                var res = Business.GoodsBLL.instance.InsertOrUpdateGoods(entity, OperationType.Update);
                return res ? Success("更新成功！") : Error("更新失败！");
            }
        }

        [HttpGet]
        public ActionResult GetGoodsInGridJson()
        {
            return Content("");
        }
        [HttpPost]
        public ActionResult GetGoodsInFormJson(string keyValue)
        {
            return Content("");
        }

        [HttpGet]
        public ActionResult GoodsIn()
        {
            return View();
        }
        [HttpGet]
        public ActionResult GoodsInForm()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SubmitGoodsInList(List<GoodsEntity> listGoodsEntity)
        {

            if (listGoodsEntity == null) return Error("没有可入库商品信息！请确认存在待入库商品！");
            using (DbTransaction trans = utity.Transation)
            {
                try
                {
                    bool result = false;
                    int success = 0;
                    var goodsInCode = PosBLL.instance.GetBatchNumber("IN");
                    var goodsInEntiy = new GoodsInEntity();
                    listGoodsEntity.ForEach(item =>
                    {
                        Mapper.Initialize(m => m.CreateMap<GoodsEntity, GoodsInDetailEntity>());
                        var mapGoodsInDetail = Mapper.Map<GoodsInDetailEntity>(item);
                        mapGoodsInDetail.ID = Guid.NewGuid();
                        mapGoodsInDetail.GoodsInCode = goodsInCode;
                        if (!UserInfo.Instance.IsAdmin)
                        {
                            mapGoodsInDetail.StoreID = UserInfo.Instance.StoreID;
                        }
                        if (mapGoodsInDetail.ProductionDate <= DateTime.MinValue)
                        {
                            mapGoodsInDetail.ProductionDate = null;
                        }
                        success += StockBLL.Instance.InsertGoodsInDetail(mapGoodsInDetail, trans);
                    });
                    if (success > 0)
                    {
                        goodsInEntiy.GoodsInCode = goodsInCode;
                        goodsInEntiy.GoodsInDate = DateTime.Now;
                        goodsInEntiy.GoodsInHumanID = UserInfo.Instance.ID;
                        goodsInEntiy.GoodsInHumanName = UserInfo.Instance.RealName;
                        goodsInEntiy.GoodsInQuantity = listGoodsEntity.Sum(item => item.InQuantityStock);
                        goodsInEntiy.GoodsInAmount = listGoodsEntity.Sum(item => item.InstockAmount);
                        goodsInEntiy.StoreID = UserInfo.Instance.StoreID;
                        int res = StockBLL.Instance.InsertGoodsIn(goodsInEntiy, trans);
                        result = res > 0;
                    }
                    if (result)
                    {
                        trans.Commit();
                        return Success($"商品入库成功！共入库{listGoodsEntity.Count()}类商品,{listGoodsEntity.Sum(item => item.InQuantityStock)}件。");
                    }
                    else
                    {
                        trans.Rollback();
                        return Error("商品入库失败!");
                    }
                }
                catch (Exception e)
                {
                    trans.Rollback();
                    return Error($"商品入库失败。失败原因：{e.Message}");
                }
            }
        }

        public ActionResult GetGoodsTree()
        {
            return Content(GoodsCategoryTree("").ToJson());
        }

        /// <summary>
        /// 根据条码或商品名称获取商品属性
        /// </summary>
        /// <param name="barID"></param>
        /// <returns></returns>
        public ActionResult GetGoodsListByCodeOrName(string barID = "-1")
        {
            var res = GoodsBLL.instance.GetGoodsListByCodeOrName(barID);
            if (res != null)
            {
                if (res.Count() > 0)
                {
                    return Content(res[0].ToJson());
                }
            }
            return null;
        }
        /// <summary>
        /// 递归获取商品列表下拉树
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private List<EasyComboTreeModel> GoodsCategoryTree(string parentId)
        {
            var prtValue = parentId == "" ? 0 : parentId.ToInt32();
            List<CategoryEntity> classlist = Business.SysBLL.Instance.GetALL<CategoryEntity>().Where(item => item.ParentCategoryID == prtValue).ToList();
            List<EasyComboTreeModel> jsonData = new List<EasyComboTreeModel>();
            classlist.ForEach(item =>
            {
                jsonData.Add(new EasyComboTreeModel
                {
                    id = item.ID,
                    children = GoodsCategoryTree(item.ID.ToString()),
                    ParentId = item.ParentCategoryID == null ? 0 : (int)item.ParentCategoryID,
                    text = item.Category,

                });
            });
            return jsonData;
        }
    }



    public static class TreeQuery
    {
        public static List<T> TreeWhere<T>(this List<T> entityList, Predicate<T> condition, string keyValue = "ID", string parentId = "ParentCategoryID") where T : class
        {
            List<T> locateList = entityList.FindAll(condition);
            var parameter = Expression.Parameter(typeof(T), "t");
            List<T> treeList = new List<T>();
            foreach (T entity in locateList)
            {
                treeList.Add(entity);
                string pId = entity.GetType().GetProperty(parentId).GetValue(entity, null).ToString();
                while (true)
                {
                    if (string.IsNullOrEmpty(pId) && pId == "0")
                    {
                        break;
                    }
                    Predicate<T> upLambda = (Expression.Equal(parameter.Property(keyValue), Expression.Constant(pId))).ToLambda<Predicate<T>>(parameter).Compile();
                    T upRecord = entityList.Find(upLambda);
                    if (upRecord != null)
                    {
                        treeList.Add(upRecord);
                        pId = upRecord.GetType().GetProperty(parentId).GetValue(upRecord, null).ToString();
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return treeList.Distinct().ToList();
        }
    }
}