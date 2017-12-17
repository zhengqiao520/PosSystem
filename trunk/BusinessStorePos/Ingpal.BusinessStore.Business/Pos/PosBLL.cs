using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ingpal.BusinessStore.DataAccess;
using Ingpal.BusinessStore.Model.Entity;
using System.Data;
using Ingpal.BusinessStore.Model;

namespace Ingpal.BusinessStore.Business
{
    public class PosBLL
    {
        private PosBLL() { }
        public static readonly PosBLL instance = new PosBLL();
        public int InsertPos(PosEntity entity)
        {
            return PosDAL.InsertPos(entity);
        }
        public int InsertPosDetail(PosDetailEntity entity)
        {
            return PosDAL.InsertPosDetail(entity);
        }
        public int InsertRestPos(RestPosEntity entity)
        {
            return PosDAL.InsertRestPos(entity);
        }
        public int InsertPosDetail(RestPosDetailEntity entity)
        {
            return PosDAL.InsertRestPosDetail(entity);
        }
        /// <summary>
        /// 根据门店导购、编号获取挂单信息
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public List<RestPosEntity> GetRestPos(string guider = "", string storeId = "")
        {
            return PosDAL.GetRestPos(guider, storeId);
        }
        /// <summary>
        /// 根据门店导购、编号获取挂单明细信息
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public List<RestPosDetailEntity> GetRestDetailPos(string posId)
        {
            return PosDAL.GetRestDetailPos(posId);
        }
        public List<PosExt> GetRestPosExt(string posId, string storeID = "")
        {
            return PosDAL.GetRestPosExt(posId, storeID);
        }
        /// <summary>
        /// 删除挂单
        /// </summary>
        /// <param name="posID"></param>
        /// <returns></returns>
        public int RemoveRestPos(string posID)
        {
            return PosDAL.RemoveRestPos(posID);
        }
        public string GetBatchNumber(string prefix = "LS", string storeID = null)
        {
            storeID = storeID ?? UserInfo.Instance.StoreID.ToString();
            return PosDAL.GetBatchNumber(prefix, storeID);
        }
        /// <summary>
        /// 根据编号更新外部订单号
        /// </summary>
        /// <param name="posID"></param>
        /// <param name="orderNo"></param>
        /// <returns></returns>
        public int UpdatePosPayNo(string posID, string orderNo)
        {
            return PosDAL.UpdatePosPayNo(posID, orderNo);
        }
        /// <summary>
        /// 根据posId获取收银结果
        /// </summary>
        /// <param name="posID"></param>
        /// <returns></returns>
        public DataSet GetPosResultByPosID(Guid posID)
        {
            return PosDAL.GetPosResultByPosID(posID);
        }

        /// <summary>
        /// 交班查询统计
        /// </summary>
        /// <param name="cashier">收银员账号</param>
        /// <param name="storeID">门店ID</param>
        /// <param name="startSaleTime">上班时间</param>
        /// <param name="endSaleTime">下班时间</param>
        /// <returns></returns>
        public DataRow QueryPosSummaryByCashier(string cashier, int? storeID, DateTime startSaleTime, DateTime endSaleTime)
        {
            return PosDAL.QueryPosSummaryByCashier(cashier, storeID, startSaleTime, endSaleTime);
        }

        /// <summary>
        /// 交班查询统计 支付金额分类统计
        /// </summary>
        /// <param name="cashier">收银员账号</param>
        /// <param name="storeID">门店ID</param>
        /// <param name="startSaleTime">上班时间</param>
        /// <param name="endSaleTime">下班时间</param>
        /// <returns></returns>
        public DataRow QueryPayTypeMoneyByCashier(string cashier, int? storeID, DateTime startSaleTime, DateTime endSaleTime)
        {
            return PosDAL.QueryPayTypeMoneyByCashier(cashier, storeID, startSaleTime, endSaleTime);
        }

        /// <summary>
        /// 提交交班记录
        /// </summary>
        /// <param name="agrs">交班记录信息</param>
        /// <returns></returns>
        public bool SubmitSettlement(SettlementAgrs agrs)
        {
            return PosDAL.SubmitSettlement(agrs);
        }

        public  List<PosSaleExtend> GetAdminPostList(SaleQueryEntity saleQueryEntity)
        {
            return PosDAL.GetAdminPostList(saleQueryEntity);
        }

        /// <summary>
        /// 提交退货信息
        /// </summary>
        /// <param name="returnGoods">退货信息</param>
        /// <returns></returns>
        public bool SubmitRetunGoods(ReturnGoods returnGoods)
        {
            return PosDAL.SubmitRetunGoods(returnGoods);
        }
    }
}
