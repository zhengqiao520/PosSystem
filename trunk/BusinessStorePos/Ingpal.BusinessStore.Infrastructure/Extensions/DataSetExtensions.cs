using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Reflection;

namespace Ingpal.BusinessStore.Infrastructure.Extensions
{
    public  static class DataSetExtensions
    {
        public static DataTable ToDataTable(this DataSet ds) {
            if (ds != null && ds.Tables[0].Rows.Count > 0) {
                return ds.Tables[0];
            }
            return new DataTable();
        }
    }
}
