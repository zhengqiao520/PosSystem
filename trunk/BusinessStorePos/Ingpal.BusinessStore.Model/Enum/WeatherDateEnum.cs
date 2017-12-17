using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingpal.BusinessStore.Model
{
    /// <summary>
    /// 日期天气枚举
    /// </summary>
    public enum WeatherDateEnum
    {
        /// <summary>
        /// 昨天
        /// </summary>
        Yesterday,
        /// <summary>
        /// 今天
        /// </summary>
        NowDate,
        /// <summary>
        /// 一天后
        /// </summary>
        AfterOneday,
        AfterTwoday,
        AfterThreeday,
        AfterFourday,
        AfterFiveday
    }
}
