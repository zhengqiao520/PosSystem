using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingpal.BusinessStore.Model
{
    [Table(TableName ="PriceChangeLog")]
   public class PriceChangeLog
    {
        [Table(PrimaryKey = true,AutoIncrement =true)]
        public string Id { get; set; }
        public string StoreID { get; set; }
        public string StoreName { get; set; }
        public string IPAddress { get; set; }
        public string Account { get; set; }
        public string OutBarID { get; set; }
        public string TicketCode { get; set; }
        public string BarID { get; set; }
        public string GoodsName { get; set; }
        public decimal OrginalPrice { get; set; }
        public decimal RealPrice { get; set; }
        public string Description { get; set; }
        [Table(Ignor =true)]
        public DateTime LogDate { get; set; }
        public string Remark { get; set; }

    }
}
