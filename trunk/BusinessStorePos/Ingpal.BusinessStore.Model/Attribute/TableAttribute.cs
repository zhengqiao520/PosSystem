using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingpal.BusinessStore.Model
{
    [AttributeUsage(AttributeTargets.Class|AttributeTargets.Property,AllowMultiple =true,Inherited =true)]
    public class TableAttribute:System.Attribute
    {
        public bool PrimaryKey { get; set; }
        public bool AutoIncrement { get; set; }
        public string TableName { get; set; }
        public string ColumnName { get; set; }
        public bool Ignor { get; set; }
    }
}
