using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingpal.BusinessStore.Model
{
    /// <summary>
    /// 天气接口类
    /// </summary>
    public class WeatherAPIEntity
    {
        public string desc { get; set; }
        public string status { get; set; }
        public Weatherdata data { get; set; }

        public class Weatherdata
        {
            public string wendu { get; set; }
            public string ganmao { get; set; }
            public List<tianqi> forecast { get; set; }
            public yesterdaywather yesterday { get; set; }
            public string aqi { get; set; }
            public string city { get; set;}
        }
        public class tianqi
        {
            public string fengxiang { get; set; }
            public string fengli { get; set; }
            public string high { get; set; }
            public string type { get; set; }
            public string low { get; set; }
            public string date { get; set; }
        }
        public class yesterdaywather {
            public string fl { get; set; }
            public string fx { get; set; }
            public string high { get; set; }
            public string type { get; set; }
        }
    }

}
