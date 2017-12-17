using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingpal.BusinessStore.Model
{
    /// <summary>
    /// 门店基础角色
    /// </summary>
    public enum BaseRoleType
    {
        /// <summary>
        /// 店长
        /// </summary>
        ShopManager=1,
        /// <summary>
        /// 收银员
        /// </summary>
        Crasher=2,
        /// <summary>
        /// 导购
        /// </summary>
        Guider=3
    }
    public class BaseRoleConst
    {
        public const string ShopManager = "e65afece-7f7f-42e5-bfa9-57fb0c28d3d5";
        public const string Crasher = "650673e5-7e1b-45fe-880f-098eb60cf6d6";
        public const string Guider = "17d7e1ae-8c64-4f8b-9bbc-05e139dd0b67";
    }
}
