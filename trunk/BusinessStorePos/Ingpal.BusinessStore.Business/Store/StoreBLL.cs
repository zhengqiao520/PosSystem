using Ingpal.BusinessStore.DataAccess;
using Ingpal.BusinessStore.Model;
using System.Collections.Generic;

namespace Ingpal.BusinessStore.Business
{
    public  class StoreBLL: BaseBLL
    {
        public static readonly StoreBLL Instance = new StoreBLL();
        private StoreBLL(){}
        /// <summary>
        /// 获取所有门店信息
        /// </summary>
        /// <returns></returns>
        public  List<StoreInfoEntity> GetAllStore()
        {
            return StoreDAL.GetAllStore();
        }

        /// <summary>
        /// 根据主键更新门店信息
        /// </summary>
        /// <typeparam name="StoreInfoEntity"></typeparam>
        /// <param name="store"></param>
        /// <returns></returns>
        public int UpdateStore<StoreInfoEntity>(StoreInfoEntity store)
        {
            return StoreDAL.UpdateStore(store);
        }
        public int InsertStore<StoreInfoEntity>(StoreInfoEntity store) {
            return StoreDAL.InsertStore(store);
        }
        /// <summary>
        /// 获取本门店的所有导购员
        /// </summary>
        /// <param name="storeID">店铺编号</param>
        /// <returns></returns>
        public List<GuiderInfo> QueryGuiderInfoListByStoreID(int? storeID)
        {
            return StoreDAL.QueryGuiderInfoListByStoreID(storeID);
        }
        /// <summary>
        /// 删除门店及关联信息
        /// </summary>
        /// <param name="storeID"></param>
        /// <returns></returns>
        public bool DeleteStoreInfoRelative(string storeID)
        {
            return StoreDAL.DeleteStoreInfoRelative(storeID);
        }

        public List<StoreInfoEntity> GetStoreList()
        {
            return StoreDAL.GetStoreList();
        }
    }
}
