namespace Ingpal.BusinessStore.DataAccess
{
    using System.Collections.Generic;
    using System.Data;
    using Ingpal.BusinessStore.Model;
    using Infrastructure;
    using System.Data.SqlClient;
    public class GoodsDAL : BaseDAL
    {
        public GoodsDAL()
        {

        }

        /// <summary>
        /// 根据门店查询存在商品的分类
        /// </summary>
        /// <param name="storeID"></param>
        /// <returns></returns>
        public static List<CategoryEntity> GetGoodsCategoryByStoreID(string storeID = "")
        {
            return utity.ExecuteListSp<CategoryEntity>("usp_GetExistGoodsCategory", new object[] { storeID });
        }

        /// <summary>
        /// 根据条码或门店编号获取商品信息
        /// </summary>
        /// <param name="barID"></param>
        /// <returns></returns>
        public static List<GoodsEntity> GetGoodsListByCodeOrName(string barIDOrName, string storeID = "")
        {
            return utity.ExecuteListSp<GoodsEntity>("usp_GetGoodsByBarIdOrName", new object[] { barIDOrName, storeID });
        }
        /// <summary>
        /// 获取商品列表
        /// </summary>
        /// <param name="barIDOrName"></param>
        /// <returns></returns>
        public static List<GoodsBaseEntity> GetGoodsBaseListByCodeOrName(string barIDOrName, string storeID = "-1")
        {
            return utity.ExecuteListSp<GoodsBaseEntity>("usp_GetGoodsBaseByBarIdOrName", new object[] { barIDOrName, storeID });
        }
        /// <summary>
        /// 根据条码或门店编号获取商品信息
        /// </summary>
        /// <param name="barID"></param>
        /// <param name="storeID"></param>
        /// <returns></returns>
        public static DataTable GetGoodsTableByCodeOrName(string barIDOrName, string storeID = "")
        {
            return utity.ExecuteDataSetSp("usp_GetGoodsByBarIdOrName", new object[] { barIDOrName, storeID }).Tables[0];
        }
        /// <summary>
        /// 根据门店编号获取商品信息
        /// </summary>
        /// <param name="storeID"></param>
        /// <returns></returns>
        public static List<GoodsEntity> GetGoodsList(string storeID = "")
        {
            return utity.ExecuteListSp<GoodsEntity>("usp_GetGoodsByStoreID", new object[] { storeID });
        }
        /// <summary>
        /// 根据商品分类获取商品列表
        /// </summary>
        /// <param name="storeID">店铺编号</param>
        /// <param name="categoryID">商品分类ID</param>
        /// <returns></returns>
        public static List<GoodsEntity> GetGoodsListByCategoryID(int? storeID, int categoryID)
        {
            if (categoryID <= 0)
            {
                return GetGoodsList(storeID.ToString());
            }
            else
            {
                return utity.ExecuteListSp<GoodsEntity>("usp_GetGoodsByCategoryID", new object[] { storeID, categoryID });
            }
        }

        /// <summary>
        /// 编辑商品分类
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static int UpdateGoodsCategory(CategoryEntity entity)
        {
            var categoryID = entity.ID;
            var category = entity.Category;
            var parentCategoryID = entity.ParentCategoryID;
            var parentCategoryName = entity.ParentCategoryName == "&nbsp;" ? null : entity.ParentCategoryName;
            var remark = entity.Remark == "&nbsp;" ? null : entity.Remark;
            var st = utity.ExecuteListSp<List<int>>("usp_UpdateGoodsCategory", new object[] { categoryID, category, parentCategoryID, parentCategoryName, remark });
            return st == null || st.Count == 0 ? 0 : 1;
        }

        /// <summary>
        /// 更新商品列表
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static int UpdateGoodsBase(GoodsBaseUpdateEntity entity,System.Data.Common.DbTransaction trans)
        {

            var st = utity.ExecuteListSp<List<int>>(trans, "usp_UpdateGoodsBase", new object[] { entity.GoodsBaseGuid, entity.BarID, entity.CategoryID, entity.Category, entity.RetailPrice });
            return st == null || st.Count == 0 ? 0 : 1;
            //    var st = utity.ExecuteListSp<List<int>>("usp_UpdateGoodsBase", new object[] { entity.GoodsBaseGuid, entity.BarID, entity.CategoryID, entity.Category, entity.RetailPrice });
            //return st == null || st.Count == 0 ? 0 : 1;
        }

        /// <summary>
        /// 删除商品分类
        /// </summary>
        /// <param name="categoryID"></param>
        /// <returns></returns>
        public static int DelGoodsCategory(int categoryID)
        {
            var st = utity.ExecuteListSp<List<int>>("usp_DeleteGoodsCategory", new object[] { categoryID });
            return st == null || st.Count == 0 ? 0 : 1;
        }

        /// <summary>
        /// 根据条码和门店编号更新库存
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static int UpdateGoodsStock(GoodsEntity entity)
        {
            return utity.ExecuteNonQuerySp("usp_UpdateGoodsStock", new object[] { entity.StoreID, entity.BarID, entity.SaleQuantity });
        }
        public static bool InsertOrUpdateGoods(GoodsEntity entity, OperationType type = OperationType.Insert)
        {
            return utity.ExecuteNonQuerySp("usp_InsertGoods", entity.ToObjectArray()) > 0;
        }
        public static List<GoodsStockExtend> GetGoodsStockInfo(StockQueryAgrs stockQueryEntity)
        {
            return utity.ExecuteListSp<GoodsStockExtend>("usp_GetGoodsStockInfo", new object[] {
                stockQueryEntity.StoreID?.ToString(),
                stockQueryEntity.Category,
                stockQueryEntity.ProductName
            });
        }
        /// <summary>
        /// 更新门店商品库存预警数量
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static int UpdateGoogsAlarmCount(GoodsEntity entity)
        {
            return utity.ExecuteNonQuery(CommandType.Text, "update Goods set AlarmAmount=@AlarmAmount where StoreID=@StoreID and BarID=@BarID",
                                        new System.Data.Common.DbParameter[]
                                        {
                                            new SqlParameter("@AlarmAmount",entity.AlarmAmount),
                                            new SqlParameter("@StoreID",entity.StoreID),
                                            new SqlParameter("@BarID",entity.BarID)
                                        });
        }
        public static List<GoodsGrantExt> GetGoodsGrantListExt(int storeID,string grantType)
        {
            return utity.ExecuteListSp<GoodsGrantExt>("usp_GetGrantGoods", new object[] { storeID, grantType });
        }
        /// <summary>
        /// 获取有效的换购商品
        /// </summary>
        /// <param name="storeID"></param>
        /// <param name="grantType"></param>
        /// <returns></returns>
        public static List<GoodsGrantExt> GetValidExchangePrice(int storeID)
        {
            return utity.ExecuteListSp<GoodsGrantExt>("usp_GetValidExchangePrice", new object[] { storeID });
        }
        public static DataRow SetGrantGoods(int storeID, string selectIds, string unselectIds)
        {
            var trans = utity.BeginTransaction();
            var dataset = utity.ExecuteDataSetSp(trans, "usp_SetGrantGoods", new object[] { storeID, selectIds, unselectIds });
            var table = dataset.Tables[0];
            if (table.Rows.Count > 0)
            {
                trans.Commit();
                return table.Rows[0];
            }
            return null;
        }
        public static int SetExchangePricePermission(GoodsGrantExt entity)
        {
            var res = 0;
            using (var trans = utity.BeginTransaction())
            {
                try
                {
                    string sql = "update GoodsGrant set ExchangePrice=@ExchangePrice,IsAllowExchange=@IsAllowExchange where BarId = @BarID and StoreID = @StoreID";
                    res = utity.ExecuteNonQuery(trans, CommandType.Text, sql,
                                    new System.Data.Common.DbParameter[]
                                    {
                                        new SqlParameter("@ExchangePrice",entity.ExchangePrice),
                                        new SqlParameter("@IsAllowExchange",entity.IsAllowExchange),
                                        new SqlParameter("@StoreID",entity.StoreID),
                                        new SqlParameter("@BarID",entity.BarID)
                                    }
                        );
                    trans.Commit();
                }
                catch(System.Exception ee)
                {
                    trans.Rollback();
                }
            }
            return res;

        }
        public static int SetDiscountPricePermission(GoodsGrantExt entity)
        {
            return utity.ExecuteNonQuerySp("usp_SetDiscountPricePermission", new object[] {
                entity.DiscountPrice.ToString(),
                entity.GroupPrice.ToString(),
                entity.IsAllowDiscount?1:0,
                entity.BarID, entity.StoreID });
        }
        public static int AddStoreEvent(StoreEvent entity)
        {
            var trans = utity.BeginTransaction();
            var res= utity.ExecuteScalarSp(trans, "usp_MoneyOffAdd", new object[] {
                 entity.Name,
                 entity.EventTag,
                 entity.RangeFlag,
                 entity.StoreIds,
                 entity.StoreName,
                 entity.StartTime,
                 entity.EndTime,
                 entity.EventType,
                 entity.Remark,
                 entity.RecordStatus
            });
            trans.Commit();
            return int.Parse(res.ToString());
        }
        /// <summary>
        /// 获取满减及折扣规则
        /// </summary>
        /// <returns></returns>
        public static List<StoreEventMoneyOffRule> GetDiscountMoneyOffRule()
        {
            return utity.ExecuteListSp<StoreEventMoneyOffRule>("usp_GetDiscountMoneyOffRule", new object[] { });
        }
    }
}
