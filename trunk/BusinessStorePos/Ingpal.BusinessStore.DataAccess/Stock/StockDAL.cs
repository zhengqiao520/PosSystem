using System.Collections.Generic;
using Ingpal.BusinessStore.Model;
using System.Data.Common;
using System;

namespace Ingpal.BusinessStore.DataAccess
{
    public class StockDAL : BaseDAL
    {
        public static int InsertGoodsIn(GoodsInEntity entity,DbTransaction trans)
        {
            var res=utity.ExecuteNonQuerySp(trans, "usp_InsertGoodsIn", new object[] {
                entity.ID,
                entity.StoreID,
                entity.GoodsInCode,
                entity.GoodsInDate,
                entity.GoodsInQuantity,
                entity.GoodsInAmount,
                entity.GoodsInHumanID,
                entity.GoodsInHumanName,
                entity.Remrks,
                entity.GoodsInType,
                entity.GoodsInTypeName
            });
            return res;
        }

        public static int InsertGoodsInDetail(GoodsInDetailEntity entity, DbTransaction trans) {
            var res = utity.ExecuteNonQuerySp(trans, "usp_InsertGoodsInDetail", new object[] {
                entity.ID,
                entity.GoodsInCode,
                entity.StoreID,
                entity.BarID,
                entity.Name,
                entity.NameAbbr,
                entity.SPEC,
                entity.ModelNumber,
                entity.CategoryID,
                entity.Category,
                entity.CodeNumber,
                entity.BatchNo,
                entity.Unit,
                entity.Supplier,
                entity.BuyingPrice,
                entity.RetailPrice,
                entity.InQuantityStock,
                entity.InstockAmount,
                entity.ProductionDate,
                entity.ProductionPlace
            });
            return res;
        }

        public static List<GoodsInEntity> GetGoodsInList(QueryEntiy entity)
        {
            return utity.ExecuteListSp<GoodsInEntity>("usp_GetGoodsInList", new object[] {
                entity.StoreID,
                entity.StartDate,
                entity.EndDate,
                entity.UserName
            });
        }


        public static int InsertGoodsOut(GoodsOutEntity entity, DbTransaction trans)
        {
            var res = utity.ExecuteNonQuerySp(trans, "usp_InsertGoodsOut", new object[] {
                entity.ID,
                entity.StoreID,
                entity.ReceiverStoreID,
                entity.GoodsOutCode,
                entity.GoodsOutDate,
                entity.GoodsOutQuantity,
                entity.GoodsOutHumanID,
                entity.GoodsOutHumanName,
                entity.GoodsOutType,
                entity.GoodsOutTypeName,
                entity.Remrks
            });
            return res;
        }

        public static int InsertGoodsOutDetail(GoodsOutDetailEntity entity, DbTransaction trans)
        {
            var res = utity.ExecuteNonQuerySp(trans, "usp_InsertGoodsOutDetail", new object[] {
                entity.ID,
                entity.GoodsId,
                entity.GoodsOutCode,
                entity.Unit,
                entity.OutQuantityStock,
                entity.ReceiverStoreId
            });
            return res;
        }

        public static int MaintainGoodsOutStatus(GoodsOutEntity entity, int status, Guid? receiverUserID)
        {
            var res = utity.ExecuteNonQuerySp("usp_MaintainGoodsOutStatus", new object[] {
               entity.ID,
               status,
               receiverUserID
            });
            return res;
        }

        public static List<GoodsOutEntity> GetGoodsOutList(int storeId)
        {
            return utity.ExecuteListSp<GoodsOutEntity>("usp_GetGoodsOutList", new object[] {
                storeId
            });
        }

        public static List<GoodsOutFullInfo> GetGoodsOutListWithArgs(GoodsOutQueryArgs args)
        {
            return utity.ExecuteListSp<GoodsOutFullInfo>("usp_GetGoodsOutListForWeb", new object[] {
                args.StoreId,
                args.ReceiverStoreId,
                args.Status,
                args.GoodsOutType,
                args.BeginDate,
                args.EndDate
            });
        }

        public static List<GoodsInFullInfo> GetGoodsInListForWeb(GoodsOutQueryArgs args)
        {
            return utity.ExecuteListSp<GoodsInFullInfo>("usp_GetGoodsInListForWeb", new object[] {
                args.StoreId,

                args.BeginDate,
                args.EndDate
            });
        }
        public static List<GoodsOutEntity> GetPendingGoodsOutListByReceiver(int receiverStoreId)
        {
            return utity.ExecuteListSp<GoodsOutEntity>("usp_GetGoodsOutListByReceiver", new object[] {
                receiverStoreId
            });
        }

        public static List<GoodsOutEntity> GetGoodsOutHistoryByReceiver(int receiverStoreId)
        {
            return utity.ExecuteListSp<GoodsOutEntity>("usp_GetGoodsInHistory", new object[] {
                receiverStoreId
            });
        }

        public static List<GoodsOutDetailEntity> GetGoodsOutDetailList(string goodsOutCode)
        {
            return utity.ExecuteListSp<GoodsOutDetailEntity>("usp_GetGoodsOutDetailList", new object[] {
                goodsOutCode
            });
        }
    }
}
