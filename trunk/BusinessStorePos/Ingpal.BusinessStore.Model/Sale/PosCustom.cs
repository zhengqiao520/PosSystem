using Ingpal.BusinessStore.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingpal.BusinessStore.Model
{
    /// <summary>
    /// Pos客显
    /// </summary>
    public class PosCustom:PosEntity
    {

        /// <summary>
        /// 产品详情
        /// </summary>
        public IList<PosDetailEntity> PosDetail { get; set; }
    }
}
