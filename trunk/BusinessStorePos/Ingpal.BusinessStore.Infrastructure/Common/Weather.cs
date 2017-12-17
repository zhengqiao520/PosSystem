using Ingpal.BusinessStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
namespace Ingpal.BusinessStore.Infrastructure
{
    public class Weather
    {
        /// <summary>
        /// 天气接口
        /// </summary>
        /// <param name="cityName"></param>
        /// <returns></returns>
        public static WeatherAPIEntity GetCityWeather(string cityName = "上海")
        {
            WeatherAPIEntity entity = new WeatherAPIEntity(); 
            try
            {
                System.Net.HttpWebResponse response = HttpWebResponseUtility.CreateGetHttpResponse("http://wthrcdn.etouch.cn/weather_mini?city=" + $"{HttpUtility.UrlEncode(cityName)}", null, null, null);
                string jsonString = HttpWebResponseUtility.getResponseString(response);
                entity = JsonConvert.DeserializeObject<WeatherAPIEntity>(jsonString);
            }
            catch{ }
            return entity; 
        }

    }
}
