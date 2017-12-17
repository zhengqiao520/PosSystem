using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingpal.BusinessStore.Model
{
    [Serializable]
    [Table(TableName = "StoreInfo")]
    //机构单位表
    public class StoreInfoEntity
    {
        [Table(PrimaryKey = true)]
        /// <summary>
        /// 门店编号
        /// </summary>
        public int ID
        {
            get;
            set;
        }
        /// <summary>
        /// 父级编号
        /// </summary>
        public string ParentID
        {
            get;
            set;
        }
        /// <summary>
        /// 机构简称
        /// </summary>
        public string StoreName
        {
            get;
            set;
        }
        /// <summary>
        /// 外线电话
        /// </summary>
        public string StorePhone
        {
            get;
            set;
        }
        /// <summary>
        /// 详细地址
        /// </summary>
        public string Address
        {
            get;
            set;
        }
        /// <summary>
        /// 传真
        /// </summary>
        public string Fax
        {
            get;
            set;
        }
        /// <summary>
        /// 电子邮箱
        /// </summary>
        public string Email
        {
            get;
            set;
        }
        /// <summary>
        /// 负责人主键
        /// </summary>
        public string ManagerId
        {
            get;
            set;
        }
        /// <summary>
        /// 负责人
        /// </summary>
        public string Manager
        {
            get;
            set;
        }
        /// <summary>
        /// EmployCount
        /// </summary>
        public int EmployCount
        {
            get;
            set;
        }
        /// <summary>
        /// 区域
        /// </summary>
        public string Area
        {
            get;
            set;
        }
        /// <summary>
        /// 省主键
        /// </summary>
        public string ProvinceId
        {
            get;
            set;
        }
        /// <summary>
        /// 市主键
        /// </summary>
        public string CityId
        {
            get;
            set;
        }
        /// <summary>
        /// 成立时间
        /// </summary>
        public DateTime? FoundedTime
        {
            get;
            set;
        }
        /// <summary>
        /// 排序码
        /// </summary>
        public int SortCode
        {
            get;
            set;
        }
        /// <summary>
        /// 有效标志 0正常，-1：作废
        /// </summary>
        public int RecordStatus
        {
            get;
            set;
        }
        /// <summary>
        /// 城市号
        /// </summary>
        public string CityNo
        {
            get;
            set;
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string Description
        {
            get;
            set;
        }
        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime CreateDate
        {
            get;
            set;
        }

        /// <summary>
        /// 业绩指标
        /// </summary>
        public int? ExpectedAchievement
        {
            get;
            set;
        }

        /// <summary>
        /// 结算日期
        /// </summary>
        public DateTime? SettlementDate
        {
            get;
            set;
        }
    }
}
