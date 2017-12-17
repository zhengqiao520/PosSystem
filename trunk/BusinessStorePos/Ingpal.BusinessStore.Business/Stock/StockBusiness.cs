using DevLib.Data;
using Ingpal.BusinessStore.Infrastructure;
using Ingpal.BusinessStore.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingpal.BusinessStore.Business
{
    /// <summary>
    /// 库存管理
    /// </summary>
    public class StockBusiness
    {
        DbHelper db = new DbHelper(Encodetool.ConnctionString,DbProvider.SqlServer);

        /// <summary>
        /// 库存查询
        /// </summary>
        /// <param name="queryAgrs">查询参数</param>
        /// <returns></returns>
        public DataTable StockQuery(StockQueryAgrs queryAgrs)
        {
            string select_content = "SELECT * FROM Goods ";
            string select_where = " WHERE ";

            IList<DbParameter> parms = new List<DbParameter>();

            if (queryAgrs != null)
            {
                if (queryAgrs.StoreID.HasValue)
                {
                    select_where += " StoreID=@StoreID AND ";
                    parms.Add(new SqlParameter("@StoreID", queryAgrs.StoreID.Value));
                }

                if (!string.IsNullOrEmpty(queryAgrs.Barcode))
                {
                    select_where += " BarID LIKE '%'+ @BarID +'%' AND ";
                    parms.Add(new SqlParameter("@BarID", queryAgrs.Barcode));
                }

                if (!string.IsNullOrEmpty(queryAgrs.ProductName))
                {
                    select_where += " Name LIKE '%'+ @Name +'%' AND ";

                    parms.Add(new SqlParameter("@Name", queryAgrs.ProductName));
                }

                if (!string.IsNullOrEmpty(queryAgrs.ProductNameAbbr))
                {
                    select_where += " NameAbbr LIKE '%'+ @NameAbbr +'%' AND ";
                    parms.Add(new SqlParameter("@NameAbbr", queryAgrs.ProductNameAbbr));
                }
                //CategoryID IN (select ID from GoodsCategory WHERE ParentCategoryID = @CategoryID)
                if (!string.IsNullOrEmpty(queryAgrs.Category))
                {
                    select_where += " CategoryID IN (select ID from GoodsCategory WHERE CategoryID = @CategoryID) AND ";
                    parms.Add(new SqlParameter("@CategoryID", queryAgrs.Category));
                }
            }

            DataSet result;

            try
            {
                if (parms.Count > 0)
                {
                    select_where = select_where.Remove(select_where.LastIndexOf("AND"));
                    select_content += select_where;
                    result = db.ExecuteDataSet(CommandType.Text, select_content, parms.ToArray());
                }
                else
                {
                    result = db.ExecuteDataSet(CommandType.Text, select_content);
                }

                if (result != null)
                {
                    return result.Tables[0];
                }
                else
                {
                    return null;
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        /// <summary>
        /// 库存盘点
        /// </summary>
        /// <param name="queryAgrs">盘点查询参数</param>
        /// <returns></returns>
        public DataTable StockTakingQuery(StockTakingQueryAgrs queryAgrs)
        {
            string select_content = "SELECT * FROM Stocktaking ";
            string select_where = " WHERE ";

            IList<DbParameter> parms = new List<DbParameter>();

            if (queryAgrs != null)
            {
                if (queryAgrs.MasterID != null && queryAgrs.MasterID != Guid.Empty)
                {
                    select_where += " MasterID=@MasterID AND ";
                    parms.Add(new SqlParameter("@MasterID", queryAgrs.MasterID));
                }

                if (!string.IsNullOrEmpty(queryAgrs.Barcode))
                {
                    select_where += " BarID LIKE '%'+ @BarID +'%' AND ";
                    parms.Add(new SqlParameter("@BarID", queryAgrs.Barcode));
                }

                if (!string.IsNullOrEmpty(queryAgrs.ProductName))
                {
                    select_where += " Name LIKE '%'+ @Name +'%' AND ";

                    parms.Add(new SqlParameter("@Name", queryAgrs.ProductName));
                }

                if (!string.IsNullOrEmpty(queryAgrs.ProductNameAbbr))
                {
                    select_where += " NameAbbr LIKE '%'+ @NameAbbr +'%' AND ";
                    parms.Add(new SqlParameter("@NameAbbr", queryAgrs.ProductNameAbbr));
                }
            }

            DataSet result;

            try
            {
                if (parms.Count > 0)
                {
                    select_where = select_where.Remove(select_where.LastIndexOf("AND"));
                    select_content += select_where;
                    result = db.ExecuteDataSet(CommandType.Text, select_content, parms.ToArray());
                }
                else
                {
                    result = db.ExecuteDataSet(CommandType.Text, select_content);
                }

                if (result != null)
                {
                    return result.Tables[0];
                }
                else
                {
                    return null;
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        /// <summary>
        /// 查询盘点记录
        /// </summary>
        /// <param name="queryAgrs">盘点记录参数</param>
        /// <returns></returns>
        public DataTable StockTakingMasterQuery(StockTakingMasterQueryAgrs queryAgrs)
        {
            string select_content = "SELECT * FROM StocktakingMaster ";
            string select_where = " WHERE ";

            IList<DbParameter> parms = new List<DbParameter>();

            if (queryAgrs != null)
            {
                if (queryAgrs.StartTime.HasValue)
                {
                    select_where += " StartTime>@StartTime AND ";
                    parms.Add(new SqlParameter("@StartTime", queryAgrs.StartTime));
                }

                if (queryAgrs.EndTime.HasValue)
                {
                    select_where += " StartTime < @EndTime AND ";
                    parms.Add(new SqlParameter("@EndTime", queryAgrs.EndTime));
                }

                if (!string.IsNullOrEmpty(queryAgrs.UserName))
                {
                    select_where += " UserName = @UserName AND ";

                    parms.Add(new SqlParameter("@UserName", queryAgrs.UserName));
                }

                if (!string.IsNullOrEmpty(queryAgrs.Number))
                {
                    select_where += " Number Like '%'+ @Number +'%' AND ";

                    parms.Add(new SqlParameter("@Number", queryAgrs.Number));
                }

             
                if (queryAgrs.Status.HasValue)
                {
                    select_where += " Status=@Status AND ";
                    parms.Add(new SqlParameter("@Status", queryAgrs.Status));
                }

                if (queryAgrs.StoreID.HasValue)
                {
                    select_where += " StoreID=@StoreID AND ";
                    parms.Add(new SqlParameter("@StoreID", queryAgrs.StoreID));
                }
            }

            DataSet result;

            try
            {
                if (parms.Count > 0)
                {
                    select_where = select_where.Remove(select_where.LastIndexOf("AND"));
                    select_content += select_where + " ORDER BY Number DESC ";
                    result = db.ExecuteDataSet(CommandType.Text, select_content, parms.ToArray());
                }
                else
                {
                    result = db.ExecuteDataSet(CommandType.Text, select_content);
                }

                if (result != null)
                {
                    return result.Tables[0];
                }
                else
                {
                    return null;
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        /// <summary>
        /// 初始化盘点数据
        /// </summary>
        /// <returns></returns>
        public Guid? InitStockTaking(StockTakingAgrs initAgrs)
        {
            var masterID = this.GetStockTakingMasterByStatus();

            if (!masterID.HasValue)
            {
                masterID = this.InsertStockTaking(initAgrs);
                if (!masterID.HasValue)
                {
                    this.InitStockTaking(initAgrs);
                }
            }

            var result = this.InsertStockTaking(masterID.Value, initAgrs.StoreID);

            if (result)
            {
                return masterID;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获取未完成盘点状态
        /// </summary>      
        /// <returns></returns>
        public Guid? GetStockTakingMasterByStatus()
        {
            string select_content = "SELECT TOP 1 [ID] FROM [StocktakingMaster] WHERE Status in (0,1)";

            try
            {
                var result = db.ExecuteScalar(CommandType.Text, select_content);

                if (result != null)
                {
                    return new Guid(result.ToString());
                }
                else
                {
                    return null;
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }

        }

        /// <summary>
        /// 插入盘点数据
        /// </summary>
        /// <param name="masterID">盘点记录ID</param>
        /// <returns></returns>
        public bool InsertStockTaking(Guid masterID, int storeID)
        {
            string InsertCommand = "INSERT INTO [Stocktaking]([ID],[MasterID],[StockID],[BarID],[GoodsName],[NameAbbr],[StockQuantity],[RetailPrice]) SELECT newid() ID,@MasterID,ID ,BarID ,[Name],ISNULL(NameAbbr,''),[StockQuantity],[RetailPrice] FROM Goods WHERE StoreID=@StoreID AND ID NOT IN (SELECT StockID FROM Stocktaking WHERE MasterID=@MasterID) ";
            IList<DbParameter> parms = new List<DbParameter>();
            parms.Add(new SqlParameter("@MasterID", masterID));
            parms.Add(new SqlParameter("@StoreID", storeID));

            try
            {
                var result = db.ExecuteNonQuery(CommandType.Text, InsertCommand, parms.ToArray());
                return true;
            }
            catch (Exception exc)
            {
                throw exc;
                return false;
            }


        }

        /// <summary>
        /// 初始化盘点记录
        /// </summary>
        /// <param name="startAgrs">盘点参数</param>
        /// <returns>创建成功返回盘点记录ID,否则返回NULL</returns>
        public Guid? InsertStockTaking(StockTakingAgrs startAgrs)
        {
            var number = PosBLL.instance.GetBatchNumber("ST");
            Guid masterID = Guid.NewGuid();
            string InsertCommand = "INSERT INTO [StocktakingMaster]([ID],[Number],[StartTime],[EndTime],[ModifyTime],[UserName],[UserID],[StoreID],[StoreName]) VALUES(@ID,@Number,@StartTime,@EndTime,@ModifyTime,@UserName,@UserID,@StoreID,@StoreName)";
            IList<DbParameter> parms = new List<DbParameter>();
            parms.Add(new SqlParameter("@ID", masterID));
            parms.Add(new SqlParameter("@Number", number));
            parms.Add(new SqlParameter("@StartTime", DateTime.Now));
            parms.Add(new SqlParameter("@EndTime", DateTime.Now));
            parms.Add(new SqlParameter("@ModifyTime", DateTime.Now));
            parms.Add(new SqlParameter("@UserName", startAgrs.UserName));
            parms.Add(new SqlParameter("@UserID", startAgrs.UserID));
            parms.Add(new SqlParameter("@StoreID", startAgrs.StoreID));
            parms.Add(new SqlParameter("@StoreName", startAgrs.StoreName));

            try
            {
                var result = db.ExecuteNonQuery(CommandType.Text, InsertCommand, parms.ToArray());
                if (result > 0)
                {
                    return masterID;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception exc)
            {
                throw exc;
                return null;
            }
        }

        /// <summary>
        /// 更新盘点库存
        /// </summary>
        /// <param name="updateAgrs">盘点参数</param>
        /// <returns></returns>
        public bool UpdateStockTaking(UpdateStockTakingAgrs updateAgrs)
        {
            string UpdateCommand = "UPDATE [Stocktaking] SET [InventoryQty]=@InventoryQty,[ActualQty]=@ActualQty ,[DifferenceQty]=@DifferenceQty,[DiffAmount]=@DiffAmount,[StockDate]=@StockDate WHERE [ID]=@ID";
            IList<DbParameter> parms = new List<DbParameter>();
            parms.Add(new SqlParameter("@ID", updateAgrs.StockTakingID));
            parms.Add(new SqlParameter("@InventoryQty", updateAgrs.InventoryQty));
            parms.Add(new SqlParameter("@ActualQty", updateAgrs.InventoryQty));
            parms.Add(new SqlParameter("@DifferenceQty", updateAgrs.DifferenceQty));
            parms.Add(new SqlParameter("@DiffAmount", updateAgrs.DiffAmount));
            parms.Add(new SqlParameter("@StockDate", DateTime.Now));

            try
            {
                var result = db.ExecuteNonQuery(CommandType.Text, UpdateCommand, parms.ToArray());
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception exc)
            {
                throw exc;
                return false;
            }
        }

        /// <summary>
        /// 结束盘点
        /// </summary>    
        /// <param name="endAgrs">开始盘点参数</param>
        /// <returns></returns>
        public bool EndStockTaking(StockTakingAgrs endAgrs)
        {
            string UpdateCommand = "UPDATE [StocktakingMaster] SET [EndTime]=@EndTime,[ModifyTime]=@ModifyTime,[Status]=@Status,[Count]=(SELECT SUM(ABS(DifferenceQty)) difCount FROM Stocktaking WHERE MasterID=@ID),[Money]=(SELECT SUM(ABS(DiffAmount)) DiffMoney  FROM Stocktaking WHERE MasterID=@ID) WHERE [ID]=@ID";
            IList<DbParameter> parms = new List<DbParameter>();
            parms.Add(new SqlParameter("@ID", endAgrs.ID));
            parms.Add(new SqlParameter("@EndTime", DateTime.Now));
            parms.Add(new SqlParameter("@ModifyTime", DateTime.Now));
            parms.Add(new SqlParameter("@Status", 2));

            try
            {
                var result = db.ExecuteNonQuery(CommandType.Text, UpdateCommand, parms.ToArray());
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception exc)
            {
                throw exc;
                return false;
            }
        }

        /// <summary>
        /// 开始盘点
        /// </summary>    
        /// <param name="startAgrs">开始盘点参数</param>
        /// <returns></returns>
        public bool StartStockTaking(StockTakingAgrs endAgrs)
        {
            string UpdateCommand = "UPDATE [StocktakingMaster] SET [StartTime]=@StartTime,[ModifyTime]=@ModifyTime,[Status]=@Status WHERE [ID]=@ID AND Status=0";
            IList<DbParameter> parms = new List<DbParameter>();
            parms.Add(new SqlParameter("@ID", endAgrs.ID));
            parms.Add(new SqlParameter("@StartTime", DateTime.Now));
            parms.Add(new SqlParameter("@ModifyTime", DateTime.Now));
            parms.Add(new SqlParameter("@Status", 1));

            try
            {
                var result = db.ExecuteNonQuery(CommandType.Text, UpdateCommand, parms.ToArray());              
                return true;
              
            }
            catch (Exception exc)
            {
                throw exc;               
            }
        }

        /// <summary>
        /// 调整库存
        /// </summary>
        /// <param name="masterID">盘点记录ID</param>
        /// <returns></returns>
        public bool UpdateStockByStockTakingMasterID(Guid masterID)
        {
            string SelectCommand = "SELECT StockID,InventoryQty  FROM Stocktaking WHERE MasterID = @MasterID";
            IList<DbParameter> select_parms = new List<DbParameter>();
            select_parms.Add(new SqlParameter("@MasterID", masterID));
            var result = db.ExecuteDataSet(CommandType.Text, SelectCommand, select_parms.ToArray());

            if (result != null && result.Tables[0].Rows.Count > 0)
            {
                string UpdateCommand = "UPDATE Goods SET StockQuantity = @StockCount WHERE ID = @StockID";
                for (int i = 0; i < result.Tables[0].Rows.Count; i++)
                {
                    var stockID = new Guid(result.Tables[0].Rows[i]["StockID"].ToString());
                    var stockCount = int.Parse(result.Tables[0].Rows[i]["InventoryQty"].ToString());
                    IList<DbParameter> update_parms = new List<DbParameter>();
                    update_parms.Add(new SqlParameter("@StockCount", stockCount));
                    update_parms.Add(new SqlParameter("@StockID", stockID));
                    db.ExecuteNonQuery(CommandType.Text, UpdateCommand, update_parms.ToArray());
                }

                UpdateCommand = "UPDATE [dbo].[StocktakingMaster] SET [StockRevise]=1,[ReviseTime]=GETDATE() WHERE [ID]=@ID AND [Status]=2";
                IList<DbParameter> master_update_parms = new List<DbParameter>();
                master_update_parms.Add(new SqlParameter("@ID", masterID));
                db.ExecuteNonQuery(CommandType.Text, UpdateCommand, master_update_parms.ToArray());
                return true;
            }
            return false;
        }
        /// <summary>
        /// 获取库存商品信息
        /// </summary>
        /// <param name="stockQueryEntity"></param>
        /// <returns></returns>
        public List<GoodsStockExtend> GetGoodsStockInfo(StockQueryAgrs stockQueryEntity)
        {
            return DataAccess.GoodsDAL.GetGoodsStockInfo(stockQueryEntity);
        }
        /// <summary>
        /// 更新库存预警
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int UpdateGoogsAlarmCount(GoodsEntity entity)
        {
            return DataAccess.GoodsDAL.UpdateGoogsAlarmCount(entity);
        }
    }

   
}
