using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingpal.BusinessStore.Model
{
    public class ExtraCrashEntity
    {
        /// <summary>
        /// 收银员名称
        /// </summary>
        public string CrashID {
            get;set;
        }
        public string CrashName {
            get;set;
        }
        /// <summary>
        /// 会员名称
        /// </summary>
        public string MemberName {
            get;set;
        }
        public string MemberID { get; set;}
    }
}
