using Ingpal.BusinessStore.DataAccess;
using Ingpal.BusinessStore.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingpal.BusinessStore.Business
{
    public class StockBLL
    {
        public static readonly StockBLL Instance = new StockBLL();
        private StockBLL()
        {

        }
        public  int InsertGoodsIn(GoodsInEntity entity, DbTransaction trans)
        {
            return StockDAL.InsertGoodsIn(entity, trans);
        }
        public  int InsertGoodsInDetail(GoodsInDetailEntity entity, DbTransaction trans)
        {
            return StockDAL.InsertGoodsInDetail(entity, trans);
        }
        public List<GoodsInEntity> GetGoodsInList(QueryEntiy entity)
        {
            return StockDAL.GetGoodsInList(entity);
        }

        public List<GoodsInFullInfo> GetGoodsInListForWeb(GoodsOutQueryArgs args)
        {
            return StockDAL.GetGoodsInListForWeb(args);
        }

        public List<GoodsOutEntity> GetGoodsOutList(int storeId)
        {
            return StockDAL.GetGoodsOutList(storeId);
        }

        public List<GoodsOutFullInfo> GetGoodsOutListWithArgs(GoodsOutQueryArgs args)
        {
            return StockDAL.GetGoodsOutListWithArgs(args);
        }

        public List<GoodsOutEntity> GetPendingGoodsOutListByReceiver(int receiverStoreId)
        {
            return StockDAL.GetPendingGoodsOutListByReceiver(receiverStoreId);
        }

        public List<GoodsOutEntity> GetGoodsOutHistoryByReceiver(int receiverStoreId)
        {
            return StockDAL.GetGoodsOutHistoryByReceiver(receiverStoreId);
        }

        public List<GoodsOutDetailEntity> GetGoodsOutDetailList(string goodsOutCode)
        {
            return StockDAL.GetGoodsOutDetailList(goodsOutCode);
        }
        public int InsertGoodsOut(GoodsOutEntity entity, DbTransaction trans)
        {
            return StockDAL.InsertGoodsOut(entity, trans);
        }
        public int InsertGoodsOutDetail(GoodsOutDetailEntity entity, DbTransaction trans)
        {
            return StockDAL.InsertGoodsOutDetail(entity, trans);
        }

        public int MaintainGoodsOutStatus(GoodsOutEntity entity, int status, Guid? receiverUserId = null)
        {
            return StockDAL.MaintainGoodsOutStatus(entity, status, receiverUserId);
        }
    }
}
