using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingpal.BusinessStore.Model
{
    /// <summary>
    /// 系统设置
    /// </summary>
    public class SystemSettings
    {
        /// <summary>
        /// 打印机名称
        /// </summary>
        public string PrintName { get; set; }

        /// <summary>
        /// 纸张规格
        /// </summary>
        public string PageSpec { get; set; }

        /// <summary>
        /// 纸张张数
        /// </summary>
        public int PageCount { get; set; }

        /// <summary>
        /// 小票标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 小票脚注
        /// </summary>
        public string Footer { get; set; }

        /// <summary>
        /// 小票Logo路径
        /// </summary>
        public string Logo { get; set; }

        /// <summary>
        /// 是否打印二维码
        /// </summary>
        public bool IsPrintQRCode { get; set; }
    }
}
