using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingpal.BusinessStore.Model
{
    [Table(TableName = "StoreEvent")]
    public class StoreEvent
    {
        [Table(PrimaryKey = true, AutoIncrement = true)]
        /// <summary>
        /// ID
        /// </summary>		
        public int ID
        {
            get;
            set;
        }
        /// <summary>
        /// 活动名称
        /// </summary>		
        public string Name
        {
            get;
            set;
        }
        /// <summary>
        /// 活动标签
        /// </summary>		
        public string EventTag
        {
            get;
            set;
        }
        /// <summary>
        /// 活动范围
        /// </summary>		
        public int? RangeFlag
        {
            get;
            set;
        }
        /// <summary>
        /// 活动范围门店编号
        /// </summary>		
        public string StoreIds
        {
            get;
            set;
        }
        /// <summary>
        /// 活动范围门店名称
        /// </summary>		
        public string StoreName
        {
            get;
            set;
        }
        /// <summary>
        /// 活动开始
        /// </summary>		
        public DateTime StartTime
        {
            get;
            set;
        }
        /// <summary>
        /// 活动结束
        /// </summary>		
        public DateTime EndTime
        {
            get;
            set;
        }
        /// <summary>
        /// 活动类型
        /// </summary>		
        public int EventType
        {
            get;
            set;
        }
        /// <summary>
        /// 备注
        /// </summary>		
        public string Remark
        {
            get;
            set;
        }
        /// <summary>
        /// 记录状态
        /// </summary>		
        public int RecordStatus
        {
            get;
            set;
        }
        public string EventConfigString { get; set; }

        public StoreEventConfig StoreEventConfig
        {
            get;
            set;
        }
    }
    [Table(TableName = "StoreEventConfig")]
    public class StoreEventConfig  {
        public string ConditionName { get; set; }
        public string ConditionValue { get; set; }
        public string StoreEventID{ get; set; }

        [Table(PrimaryKey =true, AutoIncrement =true)]
        public string ID { get; set; }

        public string Description { get; set; }
    }


    /// <summary>
    /// 满减及折扣规则
    /// </summary>
    public class StoreEventMoneyOffRule {
        public int ID { get; set; }
        public string StoreIds { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int EventType { get; set; }
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 1、满减:满足金额 2:
        /// </summary>
        public string ConditionName { get; set; }
        /// <summary>
        ///  1、满减:减掉金额 2：
        /// </summary>
        public string ConditionValue { get; set; }

    }
}
