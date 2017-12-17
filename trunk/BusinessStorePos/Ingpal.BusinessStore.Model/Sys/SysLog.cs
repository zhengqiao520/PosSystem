using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Ingpal.BusinessStore.Model
{
    /// <summary>
    /// 日志部分类
    /// </summary>
    public class PartialLog
    {
        public PartialLog()
        {

        }
        public PartialLog(string _Result, string _Description,string _ModuleName,string _ModuleId,string _Type,string _StoreID="")
        {
            Result = _Result;
            Description = _Description;
            ModuleName = _ModuleName;
            ModuleId = _ModuleId;
            Type = _Type;
            StoreID = _StoreID;
        }
        public string Result { get; set; }
        public string Description { get; set; }
        public string ModuleName { get; set; }
        public string ModuleId { get; set; }
        public string Type {
            get;set;
        }
        [Table(ColumnName = "所属门店")]
        public string StoreID { get; set; }
    }

    /// <summary>
    /// 日志类
    /// </summary>
    /// 
    [Table(TableName = "SysLog")]
    public class SysLog:PartialLog
    {
        public string GetTableName()
        {
            return "";
        }
        [Table(ColumnName ="主键",PrimaryKey =true,AutoIncrement =true)]
        public string Id { get; set; }

        public DateTime? LogDate { get; set; }
        public string Account { get; set; }
        public string RealName { get; set; }
        public string IPAddress { get; set; }
        public string IPAddressName { get; set; }

        [Table(Ignor =true)]
        public string TotalCount { get; set; }

    }
}
