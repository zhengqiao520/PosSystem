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
    /// 销售管理
    /// </summary>
    public class SaleBusiness
    {
        DbHelper db = new DbHelper(Encodetool.ConnctionString, DevLib.Data.DbProvider.SqlServer);

        /// <summary>
        /// 销售记录查询
        /// </summary>
        /// <param name="queryAgrs">销售记录查询</param>
        /// <returns></returns>
        public DataTable SaleListQuery(SaleQueryAgrs queryAgrs)
        {
           var ds=db.ExecuteDataSetSp("usp_GetPosSaleList", new object[] { queryAgrs.StoreID,queryAgrs.SaleStartTime,queryAgrs.SaleEndTime,queryAgrs.RecordStatus,queryAgrs.TicketCode });
            if (ds != null && ds.Tables[0].Rows.Count > 0) {
                return ds.Tables[0];
            }
            return new DataTable();
            //string select_content = "SELECT * , [dbo].[fn_GetPayTypeNameByCode](PayType) PayTypeName FROM POS";
            //string select_where = " WHERE ";

            //IList<DbParameter> parms = new List<DbParameter>();

            //if (queryAgrs != null)
            //{
            //    if (queryAgrs.StoreID.HasValue)
            //    {
            //        select_where += " StoreID=@StoreID AND ";
            //        parms.Add(new SqlParameter("@StoreID", queryAgrs.StoreID));
            //    }

            //    if (!string.IsNullOrEmpty(queryAgrs.TicketCode))
            //    {
            //        select_where += " TicketCode LIKE '%'+@TicketCode+'%' AND ";
            //        parms.Add(new SqlParameter("@TicketCode", queryAgrs.TicketCode));
            //    }
            //    if (queryAgrs.SaleStartTime.HasValue) {
            //        select_where += " SaleDate>=@SaleStartTime  AND ";
            //        parms.Add(new SqlParameter("@SaleStartTime", queryAgrs.SaleStartTime));
            //    }
            //    if (queryAgrs.SaleEndTime.HasValue)
            //    {
            //        select_where += " SaleDate<=@SaleEndTime  AND ";
            //        parms.Add(new SqlParameter("@SaleEndTime", queryAgrs.SaleEndTime));
            //    }
            //    if (queryAgrs.SaleStartTime.HasValue && queryAgrs.SaleEndTime.HasValue)
            //    {
            //        select_where += " SaleDate<@SaleEndTime AND SaleDate>@SaleStartTime AND ";
            //        parms.Add(new SqlParameter("@SaleStartTime", queryAgrs.SaleStartTime));
            //        parms.Add(new SqlParameter("@SaleEndTime", queryAgrs.SaleEndTime));
            //    }

            //    if (queryAgrs.RecordStatus.HasValue)
            //    {
            //        select_where += " RecordStatus=@RecordStatus AND ";
            //        parms.Add(new SqlParameter("@RecordStatus", queryAgrs.RecordStatus));                   
            //    }
            //}

            //DataSet result;

            //try
            //{
            //    if (parms.Count > 0)
            //    {
            //        select_where = select_where.Remove(select_where.LastIndexOf("AND"));
            //        select_content += select_where;
            //        select_content += "  Order By SaleDate DESC ";
            //        result = db.ExecuteDataSet(CommandType.Text, select_content, parms.ToArray());
            //    }
            //    else
            //    {
            //        result = db.ExecuteDataSet(CommandType.Text, select_content);
            //    }

            //    if (result != null)
            //    {
            //        return result.Tables[0];
            //    }
            //    else
            //    {
            //        return null;
            //    }
            //}
            //catch (Exception exc)
            //{
            //    throw exc;
            //}

            
        }


        /// <summary>
        /// 销售记录明细查询
        /// </summary>
        /// <param name="queryAgrs">销售明细查询</param>
        /// <returns></returns>
        public DataTable SaleDetailQuery(SaleQueryAgrs queryAgrs)
        {
            string select_content = "SELECT *  FROM [PosDetail] WHERE PosID=@PosID";
          

            IList<DbParameter> parms = new List<DbParameter>();

            if (queryAgrs != null)
            {
                if (Guid.Empty != queryAgrs.PosID)
                {
                    parms.Add(new SqlParameter("@PosID", queryAgrs.PosID));
                }

                if (!string.IsNullOrEmpty(queryAgrs.BarID))
                {
                    select_content += "  AND  BarID  Like @BarID+'%' ";
                    parms.Add(new SqlParameter("@BarID", queryAgrs.BarID));
                }
            }

            DataSet result;

            try
            {
                if (parms.Count > 0)
                {
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

    }
}
