using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingpal.BusinessStore.Model
{
    /// <summary>
    /// 导购员信息
    /// </summary>
    public class GuiderInfo
    {
        public GuiderInfo()
        {

        }

        public GuiderInfo(Guid guiderid, string guidName)
        {
            GuiderID = guiderid;
            GuderName = guidName;
        }

        /// <summary>
        /// 导购ID
        /// </summary>
        public Guid GuiderID { get; set; }

        /// <summary>
        /// 导购员姓名
        /// </summary>
        public string GuderName { get; set; }
    }
}
