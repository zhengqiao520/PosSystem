using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingpal.BusinessStore.Model
{
    public class GoodsOutQueryArgs
    {

        /// <summary>
        /// 出库门店
        /// </summary>
        public int StoreId { get; set; }

        /// <summary>
        /// 接收门店
        /// </summary>
        public int ReceiverStoreId { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        ///开始日期
        /// </summary>
        public DateTime? BeginDate { get; set; }

        /// <summary>
        ///结束日期
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// 出库类型
        /// </summary>
        public int GoodsOutType { get; set; }
    }
}
