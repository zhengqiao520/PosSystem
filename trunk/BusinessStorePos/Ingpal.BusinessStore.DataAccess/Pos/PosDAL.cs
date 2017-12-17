using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Ingpal.BusinessStore.Infrastructure.DB;
using Ingpal.BusinessStore.Infrastructure.Extensions;
using Ingpal.BusinessStore.Model.Entity;
using System.Data.Common;
using Ingpal.BusinessStore.Model;
using Ingpal.BusinessStore.Infrastructure;

namespace Ingpal.BusinessStore.DataAccess
{
    public class PosDAL : BaseDAL
    {
        public PosDAL()
        {

        }
        /// <summary>
        /// 写入pos
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static int InsertPos(PosEntity entity)
        {
            return utity.Insert(entity);
        }
        /// <summary>
        /// 写入RestPos
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static int InsertRestPos(RestPosEntity entity)
        {
            return utity.Insert(entity);
        }
        /// <summary>
        /// 写入挂单明细
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static int InsertRestPosDetail(RestPosDetailEntity entity)
        {
            return utity.Insert(entity);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static List<RestPosEntity> GetRestPos(string guider = null, string storeId = null)
        {
            return utity.ExecuteListSp<RestPosEntity>("usp_GetRestPos", new object[] { string.IsNullOrEmpty(guider) ? null : guider, storeId });
        }
        /// <summary>
        /// 根据门店编号、收银流水号获取挂单列表
        /// </summary>
        /// <param name="posId"></param>
        /// <param name="storeID"></param>
        /// <returns></returns>
        public static List<PosExt> GetRestPosExt(string posId, string storeID)
        {
            return utity.ExecuteListSp<PosExt>("usp_GetRestPosDetail", new object[] { posId, storeID });
        }
        public static List<RestPosDetailEntity> GetRestDetailPos(string posId)
        {
            return utity.ExecuteListText<RestPosDetailEntity>("select * from RestPosDetail where posid=@PosID", new SqlParameter[] {
                new SqlParameter("@PosID",posId)
            });
        }
        /// <summary>
        /// 删除挂单
        /// </summary>
        /// <param name="posID"></param>
        /// <returns></returns>
        public static int RemoveRestPos(string posID)
        {
            return utity.ExecuteNonQuerySp("usp_deleteRestPos", new object[] { posID });
        }
        /// <summary>
        /// 写入pos明细
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static int InsertPosDetail(PosDetailEntity entity)
        {
            return utity.Insert(entity);
        }
        /// <summary>
        /// 获取唯一编码
        /// </summary>
        /// <param name="prefix"></param>
        /// <returns></returns>
        public static string GetBatchNumber(string prefix = "LS", string storeID = null)
        {
            return utity.ExecuteScalarSp("GetSerialNo", new object[] { prefix, storeID }).ToString();
        }
        /// <summary>
        /// 根据pos主键获取pos信息
        /// </summary>
        /// <param name="posID"></param>
        /// <returns></returns>
        public static DataSet GetPosResultByPosID(Guid posID)
        {
            return utity.ExecuteDataSetSp("usp_getPosResultByPosId", new object[] { posID });
        }

        public static DataRow QueryPosSummaryByCashier(string cashier, int? storeID, DateTime startSaleTime, DateTime endSaleTime)
        {
            IList<DbParameter> lstparam = new List<DbParameter>();
            lstparam.Add(new SqlParameter("@Cashier", cashier));
            lstparam.Add(new SqlParameter("@StoreID", storeID));
            lstparam.Add(new SqlParameter("@StartSaleTime", startSaleTime));
            lstparam.Add(new SqlParameter("@EndSaleTime", endSaleTime));

            var result = utity.ExecuteDataSet(CommandType.StoredProcedure, "usp_QueryPosSummaryByCashier", lstparam.ToArray());
            if (result != null && result.Tables[0].Rows.Count > 0)
            {
                return result.Tables[0].Rows[0];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 退货
        /// </summary>
        /// <param name="returnGoods">退货信息</param>
        /// <returns></returns>
        public static bool SubmitRetunGoods(ReturnGoods returnGoods)
        {
            if (null == returnGoods)
            {
                return false;
            }

            if (null == returnGoods.Details || returnGoods.Details.Count == 0)
            {
                return false;
            }

            string returnDetailInsertCommand = "INSERT INTO [ReturnPosDetail]([ID],[PosID],[BarID],[StoreID],[RetailPrice],[GoodsCount],[GoodsAmount],[DiscountRate],[DiscountPrice],[DiscountAmount],[BuyingPrice],[GoodsProfit],[GoodsName],[GoodsID],[GoodsCategoryID],[GoodsCategory],[CashierID],[SaleDate]) SELECT [ID],[PosID],[BarID],[StoreID],[RetailPrice],@GoodsCount,@GoodsAmount,[DiscountRate],[DiscountPrice],[DiscountAmount],[BuyingPrice],[GoodsProfit],[GoodsName],[GoodsID],[GoodsCategoryID],[GoodsCategory],[CashierID],[SaleDate] FROM [PosDetail] WHERE ID=@ID";
            string returnGoodsInsertCommand = "INSERT INTO [ReturnGoods]([ID],[RecordSerial],[TicketCode],[PayType],[RefundAmount],[ReturnGoodsCount],[RefundTime],[CashierID],[Cashier],[GuiderID],[Guider],[Description]) VALUES(@ID,@RecordSerial,@TicketCode,@PayType,@RefundAmount,@ReturnGoodsCount,@RefundTime,@CashierID,@Cashier,@GuiderID,@Guider,@Description)";

            string posDetailUpdateCommand = "UPDATE [PosDetail] SET [ReturnCount]=@GoodsCount WHERE  [ID]=@ID";
            string posUpdateCommand = "UPDATE [Pos] SET [RecordStatus]=-1 WHERE  [ID]=@ID";

            string goodsCommand = "UPDATE dbo.Goods SET SaleQuantity=SaleQuantity-@ReturnCount,SaleAmount=SaleAmount-@ReturnAmount,StockQuantity=StockQuantity+ @ReturnCount WHERE BarID IN (SELECT [BarID] FROM [PosDetail] WHERE ID=@ID) AND [StoreID] IN (SELECT [StoreID] FROM [PosDetail] WHERE ID=@ID)";

            var trans = utity.BeginTransaction();

            try
            {

                foreach (var item in returnGoods.Details)
                {
                    List<DbParameter> parms = new List<DbParameter>();
                    parms.Add(new SqlParameter("@GoodsCount", item.ReturnCount));
                    parms.Add(new SqlParameter("@ID", item.ID));
                    utity.ExecuteNonQuery(trans, CommandType.Text, posDetailUpdateCommand, parms.ToArray()); //更新销售明细表
                    parms.Add(new SqlParameter("@GoodsAmount", item.ReturnAmount));
                    utity.ExecuteNonQuery(trans, CommandType.Text, returnDetailInsertCommand, parms.ToArray()); //增加退货记录

                    var goodsPara = new List<DbParameter>();
                    goodsPara.Add(new SqlParameter("@ReturnCount", item.ReturnCount));
                    goodsPara.Add(new SqlParameter("@ReturnAmount", item.ReturnAmount));
                    goodsPara.Add(new SqlParameter("@ID", item.ID));
                    utity.ExecuteNonQuery(trans, CommandType.Text, goodsCommand, goodsPara.ToArray());
                }

                List<DbParameter> return_parms = new List<DbParameter>();
                return_parms.Add(new SqlParameter("@ID", returnGoods.ID));

                utity.ExecuteNonQuery(trans, CommandType.Text, posUpdateCommand, return_parms.ToArray()); //修改销售记录状态
                return_parms.Add(new SqlParameter("@RecordSerial", returnGoods.RecordSerial));
                return_parms.Add(new SqlParameter("@TicketCode", returnGoods.TicketCode));
                return_parms.Add(new SqlParameter("@PayType", returnGoods.PayType));
                return_parms.Add(new SqlParameter("@RefundAmount", returnGoods.RefundAmount));
                return_parms.Add(new SqlParameter("@ReturnGoodsCount", returnGoods.ReturnGoodsCount));
                return_parms.Add(new SqlParameter("@RefundTime", returnGoods.RefundTime));
                return_parms.Add(new SqlParameter("@CashierID", returnGoods.CashierID));
                return_parms.Add(new SqlParameter("@Cashier", returnGoods.Cashier));
                return_parms.Add(new SqlParameter("@GuiderID", returnGoods.GuiderID));
                return_parms.Add(new SqlParameter("@Guider", returnGoods.Guider));
                return_parms.Add(new SqlParameter("@Description", returnGoods.Description));
                utity.ExecuteNonQuery(trans, CommandType.Text, returnGoodsInsertCommand, return_parms.ToArray()); //增加退货记录

                trans.Commit();

                return true;

            }
            catch (Exception exc)
            {
                string error = exc.Message;
                trans.Rollback();
                return false;
            }
        }

        /// <summary>
        /// 根据编号更新外部订单号
        /// </summary>
        /// <param name="posID"></param>
        /// <param name="orderNo"></param>
        /// <returns></returns>
        public static int UpdatePosPayNo(string posID, string orderNo)
        {
            return utity.ExecuteNonQuerySp("usp_UpdatePosPayNo", new object[] { posID.ToString(), orderNo });
        }
        public static DataRow QueryPayTypeMoneyByCashier(string cashier, int? storeID, DateTime startSaleTime, DateTime endSaleTime)
        {
            IList<DbParameter> lstparam = new List<DbParameter>();
            lstparam.Add(new SqlParameter("@Cashier", cashier));
            lstparam.Add(new SqlParameter("@StoreID", storeID));
            lstparam.Add(new SqlParameter("@StartSaleTime", startSaleTime));
            lstparam.Add(new SqlParameter("@EndSaleTime", endSaleTime));

            var result = utity.ExecuteDataSet(CommandType.StoredProcedure, "usp_QueryPayTypeMoneyByCashier", lstparam.ToArray());
            if (result != null && result.Tables[0].Rows.Count > 0)
            {
                return result.Tables[0].Rows[0];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 提交交班记录
        /// </summary>
        /// <param name="agrs">交班记录信息</param>
        /// <returns></returns>
        public static bool SubmitSettlement(SettlementAgrs agrs)
        {
            IList<DbParameter> lstparam = new List<DbParameter>();
            lstparam.Add(new SqlParameter("@StoreID", agrs.StoreID));
            lstparam.Add(new SqlParameter("@CashierID", agrs.CashierID));
            lstparam.Add(new SqlParameter("@CashierName", agrs.CashierName));

            lstparam.Add(new SqlParameter("@OffDutyDateTime", agrs.OffDutyDateTime));
            lstparam.Add(new SqlParameter("@StartDutyDateTime", agrs.StartDutyDateTime));
            lstparam.Add(new SqlParameter("@SalesDiscountAmount", agrs.SalesDiscountAmount));

            lstparam.Add(new SqlParameter("@SalesAmount", agrs.SalesAmount));
            lstparam.Add(new SqlParameter("@SalesCount", agrs.SalesCount));
            lstparam.Add(new SqlParameter("@SalesTicketsCount", agrs.SalesTicketsCount));

            lstparam.Add(new SqlParameter("@SalesReturnCount", agrs.SalesReturnCount));
            lstparam.Add(new SqlParameter("@SalesReturnAmount", agrs.SalesReturnAmount));
            lstparam.Add(new SqlParameter("@SalesReturnTickets", agrs.SalesReturnTickets));

            lstparam.Add(new SqlParameter("@StockInCount", agrs.StockInCount));
            lstparam.Add(new SqlParameter("@StockInAmount", agrs.StockInAmount));
            lstparam.Add(new SqlParameter("@StockOutCount", agrs.StockOutCount));

            lstparam.Add(new SqlParameter("@StockOutAmount", agrs.StockOutAmount));
            lstparam.Add(new SqlParameter("@Remarks", agrs.Remarks));
            lstparam.Add(new SqlParameter("@OperationDate", agrs.OperationDate));

            lstparam.Add(new SqlParameter("@PettyCash", agrs.PettyCash));
            lstparam.Add(new SqlParameter("@WeixinPayAmount", agrs.WeixinPayAmount));
            lstparam.Add(new SqlParameter("@AliPayAmount", agrs.AliPayAmount));

            lstparam.Add(new SqlParameter("@BankCardAmount", agrs.BankCardAmount));
            lstparam.Add(new SqlParameter("@MarketAmount", agrs.MarketAmount));
            lstparam.Add(new SqlParameter("@CrashAmount", agrs.CrashAmount));

            try
            {
                utity.ExecuteNonQuery(CommandType.StoredProcedure, "usp_InsertSettlement", lstparam.ToArray());
                return true;
            }
            catch (Exception exc)
            {
                string error = exc.Message;
                return false;
            }
        }

        public static List<PosSaleExtend> GetAdminPostList(SaleQueryEntity saleQueryEntity)
        {
            return utity.ExecuteListSp<PosSaleExtend>("usp_GetPosList", new object[] { saleQueryEntity.StoreID, ConvertHelper.ToNullableDt(saleQueryEntity.SaleStartTime), ConvertHelper.ToNullableDt(saleQueryEntity.SaleEndTime, true), saleQueryEntity.PayType, saleQueryEntity.Guider, saleQueryEntity.TicketCode });
        }
    }
}
