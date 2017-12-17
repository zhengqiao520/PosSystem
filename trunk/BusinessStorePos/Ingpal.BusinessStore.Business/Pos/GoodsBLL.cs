using Ingpal.BusinessStore.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ingpal.BusinessStore.DataAccess;
using System.Data;
using Ingpal.BusinessStore.Model;

namespace Ingpal.BusinessStore.Business
{
    public class GoodsBLL
    {
        private GoodsBLL() { }
        public static readonly GoodsBLL instance = new GoodsBLL();

        public List<CategoryEntity> GetGoodsCategoryByStoreID(string storeID = "")
        {
            return GoodsDAL.GetGoodsCategoryByStoreID(storeID);
        }

        public List<GoodsEntity> GetGoodsListByCodeOrName(string barIDOrName, string storeID = "")
        {
            return GoodsDAL.GetGoodsListByCodeOrName(barIDOrName, storeID);
        }
        public List<GoodsBaseEntity> GetGoodsBaseListByCodeOrName(string barIDOrName, string storeID = "-1")
        {
            return GoodsDAL.GetGoodsBaseListByCodeOrName(barIDOrName, storeID);
        }
        public DataTable GetGoodsTableByCodeOrName(string barIDOrName, string storeID = "")
        {
            return GoodsDAL.GetGoodsTableByCodeOrName(barIDOrName, storeID);
        }
        public List<GoodsEntity> GetGoodsList(string storeID = "")
        {
            return GoodsDAL.GetGoodsList(storeID);
        }
        public int UpdateGoodsStock(GoodsEntity entity)
        {
            return GoodsDAL.UpdateGoodsStock(entity);
        }

        /// <summary>
        /// 根据商品分类获取商品列表
        /// </summary>
        /// <param name="storeID">店铺编号</param>
        /// <param name="categoryID">商品分类ID</param>
        /// <returns></returns>
        public List<GoodsEntity> GetGoodsListByCategoryID(int? storeID, int categoryID)
        {
            var list = GoodsDAL.GetGoodsListByCategoryID(storeID, categoryID);
            if (list != null && list.Any())
            {
                list = list.OrderBy(s => s.RetailPrice).ThenBy(s => s.Name).ToList();
            }
            return list;
        }
        public bool InsertOrUpdateGoods(GoodsEntity entity, OperationType type = OperationType.Insert)
        {
            return GoodsDAL.InsertOrUpdateGoods(entity);
        }
        public List<GoodsGrantExt> GetGoodsGrantListExt(int storeID, string grantType)
        {
            return GoodsDAL.GetGoodsGrantListExt(storeID, grantType);
        }
        /// <summary>
        /// 获取有效换购商品
        /// </summary>
        /// <param name="storeID"></param>
        /// <returns></returns>
        public List<GoodsGrantExt> GetValidExchangePrice(int storeID)
        {
            return GoodsDAL.GetValidExchangePrice(storeID);
        }

        public DataRow SetGrantGoods(int storeID, string selectIds, string unselectIds)
        {
            return GoodsDAL.SetGrantGoods(storeID, selectIds, unselectIds);
        }
        public int SetDiscountPricePermission(GoodsGrantExt entity)
        {
            return GoodsDAL.SetDiscountPricePermission(entity);
        }
        public int SetExchangePricePermission(GoodsGrantExt entity)
        {
            return GoodsDAL.SetExchangePricePermission(entity);
        }
        public int UpdateGoodsCategory(CategoryEntity entity)
        {
            return GoodsDAL.UpdateGoodsCategory(entity);
        }

        public int DelGoodsCategory(int categoryID)
        {
            return GoodsDAL.DelGoodsCategory(categoryID);
        }

        public int UpdateGoodsBase(GoodsBaseUpdateEntity entity, System.Data.Common.DbTransaction trans)
        {
            return GoodsDAL.UpdateGoodsBase(entity, trans);
        }
        public int AddStoreEvent(StoreEvent entity)
        {
            return GoodsDAL.AddStoreEvent(entity);
        }
        public List<StoreEventMoneyOffRule> GetDiscountMoneyOffRule()
        {
            return GoodsDAL.GetDiscountMoneyOffRule();
        }

    }
}