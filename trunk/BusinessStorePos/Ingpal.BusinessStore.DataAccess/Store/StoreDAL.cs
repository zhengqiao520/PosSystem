using System;
using System.Collections.Generic;
using System.Linq;
using Ingpal.BusinessStore.Infrastructure;
using Ingpal.BusinessStore.Model;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;

namespace Ingpal.BusinessStore.DataAccess
{
    public class StoreDAL:BaseDAL
    {
        /// <summary>
        /// 获取所有门店
        /// </summary>
        /// <returns></returns>
        public static List<StoreInfoEntity> GetAllStore()
        {
          return utity.GetAll<StoreInfoEntity>();
        }
        /// <summary>
        /// 根据主键更新门店信息
        /// </summary>
        /// <typeparam name="StoreInfoEntity"></typeparam>
        /// <param name="store"></param>
        /// <returns></returns>
        public static int UpdateStore<StoreInfoEntity>(StoreInfoEntity store)
        {
            return utity.UpdateByKey(store);
        }
        public static int InsertStore<StoreInfoEntity>(StoreInfoEntity store)
        {
            try
            {
                return utity.ExecuteNonQuerySp("usp_InsertStore", store.ToObjectArray());
            }
            catch (Exception ex)
            {

                throw;
            }
           
        }

        public static List<StoreInfoEntity> GetStoreList()
        {
            return utity.ExecuteListSp<StoreInfoEntity>("usp_GetStoreList", new object[] {
                
            });
        }


        /// <summary>
        /// 获取本门店的所有导购员
        /// </summary>
        /// <param name="storeID">店铺编号</param>
        /// <returns></returns>
        public static List<GuiderInfo> QueryGuiderInfoListByStoreID(int? storeID)
        {
            IList<DbParameter> lstparam = new List<DbParameter>();
            lstparam.Add(new SqlParameter("@StoreID", storeID));

            var result = utity.ExecuteDataSet(CommandType.StoredProcedure, "usp_GetGuiderInfoByStoreID", lstparam.ToArray());
            if (result != null && result.Tables[0].Rows.Count > 0)
            {
                List<GuiderInfo> list = new List<GuiderInfo>();
                for (int i = 0; i < result.Tables[0].DefaultView.Count; i++)
                {
                    var row = result.Tables[0].DefaultView[i].Row;
                    GuiderInfo guider = new GuiderInfo();
                    guider.GuiderID = new Guid(row["ID"].ToString());
                    guider.GuderName = row["RealName"].ToString();
                    list.Add(guider);
                }
                return list;
            }
            else
            {
                return null;
            }
        }

        public static bool DeleteStoreInfoRelative(string storeID)
        {
            using (DbTransaction tran = utity.BeginTransaction()) {
              int res=utity.ExecuteNonQuerySp(tran, "usp_DeleteStoreInfoRelative", new object[] { storeID });
                if (res > 0)
                {
                    tran.Commit();
                    return true;
                }
                tran.Rollback();
                return false;
            }
        }
    }
}
