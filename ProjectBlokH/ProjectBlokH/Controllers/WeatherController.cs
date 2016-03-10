using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ProjectBlokH.Controllers
{
    [EnableCors(origins: "http://localhost:8000", headers: "*", methods: "*")]
    public class WeatherController : ApiController
    {
        [HttpGet]
        [Route("api/Login")]
        public string getWeather()
        {
            weather.ndfdXML myweather = new weather.ndfdXML();

            decimal lat = 52.068102M;
            decimal lon = 4.322507M;

            weather.weatherParametersType wtp = new weather.weatherParametersType();
            wtp.temp = true;

            string xml = myweather.NDFDgen(lat, lon, weather.productType.timeseries, DateTime.Now, DateTime.Now, weather.unitType.e, wtp);

            xml = xml.Substring(xml.IndexOf("Temperature"));

            return xml;

        }
       

    }
}
