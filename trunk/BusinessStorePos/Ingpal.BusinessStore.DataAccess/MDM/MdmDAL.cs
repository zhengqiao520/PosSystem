using Ingpal.BusinessStore.Infrastructure.DB;
using Ingpal.BusinessStore.Model;
using Ingpal.BusinessStore.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingpal.BusinessStore.DataAccess
{
    public class MdmDAL: BaseDAL
    {
        public static List<MDMEntity> GetMDMByNameOrCode(MDMEntity mdm=null)
        {
            return utity.ExecuteListSp<MDMEntity>("usp_GetMDMByNameOrCode", new object[] { mdm?.MDMName??"", mdm?.MDMCode??"" });
        }
    }
}
