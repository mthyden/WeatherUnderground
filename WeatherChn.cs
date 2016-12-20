using System;
using System.Text;
using Crestron.SimplSharp;      // For Basic SIMPL# Classes
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Crestron.SimplSharp.Net.Http;

namespace WeatherUnderground
{
    public delegate ushort OutputDelegate (SimplSharpString str);
    
    public class WeatherChn
    {
        public String ZipCode;
        public String APIKey;
        public String City;
        public String Condition;
        public String Temp;
        public String TempString;
        public String Humidity;
        public String WindDirection;
        public String WindSpeed;
        public String ConditionURL;
        public String LastUpdated;
        private String url;

        public void getWeather()
        {
            url = string.Format("http://api.wunderground.com/api/{0}/conditions/q/{1}.json", APIKey, ZipCode);
            try
            {
                var httpSet = new HttpClient();
                httpSet.KeepAlive = false;
                httpSet.Accept = "text/html";
                HttpClientRequest sRequest = new HttpClientRequest();
                sRequest.Url.Parse(url);                                                        //send request URL
                HttpClientResponse sResponse = httpSet.Dispatch(sRequest);
                var jsontext = sResponse.ContentString;                                         //dump info from request response into variable
                JObject Data = JObject.Parse(jsontext);                         
                RootObject myObject = JsonConvert.DeserializeObject<RootObject>(jsontext);      //Reflection of JSON to myObject from class below

                ZipCode = myObject.current_observation.display_location.zip;                    //feed myObject data to SIMPL+ strings
                City = myObject.current_observation.display_location.city;
                Temp = myObject.current_observation.feelslike_string;
                Condition = myObject.current_observation.weather;
                ConditionURL = myObject.current_observation.icon_url;
                WindDirection = myObject.current_observation.wind_dir;
                WindSpeed = myObject.current_observation.wind_mph.ToString();

            }
            catch (Exception e)
            {
                CrestronConsole.PrintLine("couldn't execute: {0}", e);
            }
        }

        public void SendtoSIMPL()
        {
            ushort i = myDel(Condition);

        }

        public OutputDelegate myDel
        {
            get;
            set;
        }

        /// <summary>
        /// SIMPL+ can only execute the default constructor. If you have variables that require initialization, please
        /// use an Initialize method
        /// </summary>
        public WeatherChn()
        {
        }
    }


    public class Features
    {
        public int conditions { get; set; }
    }

    public class Response
    {
        public string version { get; set; }
        public string termsofService { get; set; }
        public Features features { get; set; }
    }

    public class Image
    {
        public string url { get; set; }
        public string title { get; set; }
        public string link { get; set; }
    }

    public class DisplayLocation
    {
        public string full { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string state_name { get; set; }
        public string country { get; set; }
        public string country_iso3166 { get; set; }
        public string zip { get; set; }
        public string magic { get; set; }
        public string wmo { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string elevation { get; set; }
    }

    public class ObservationLocation
    {
        public string full { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string country_iso3166 { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string elevation { get; set; }
    }

    public class Estimated
    {
    }

    public class CurrentObservation
    {
        public Image image { get; set; }
        public DisplayLocation display_location { get; set; }
        public ObservationLocation observation_location { get; set; }
        public Estimated estimated { get; set; }
        public string station_id { get; set; }
        public string observation_time { get; set; }
        public string observation_time_rfc822 { get; set; }
        public string observation_epoch { get; set; }
        public string local_time_rfc822 { get; set; }
        public string local_epoch { get; set; }
        public string local_tz_short { get; set; }
        public string local_tz_long { get; set; }
        public string local_tz_offset { get; set; }
        public string weather { get; set; }
        public string temperature_string { get; set; }
        public double temp_f { get; set; }
        public double temp_c { get; set; }
        public string relative_humidity { get; set; }
        public string wind_string { get; set; }
        public string wind_dir { get; set; }
        public int wind_degrees { get; set; }
        public double wind_mph { get; set; }
        public int wind_gust_mph { get; set; }
        public double wind_kph { get; set; }
        public int wind_gust_kph { get; set; }
        public string pressure_mb { get; set; }
        public string pressure_in { get; set; }
        public string pressure_trend { get; set; }
        public string dewpoint_string { get; set; }
        public int dewpoint_f { get; set; }
        public int dewpoint_c { get; set; }
        public string heat_index_string { get; set; }
        public string heat_index_f { get; set; }
        public string heat_index_c { get; set; }
        public string windchill_string { get; set; }
        public string windchill_f { get; set; }
        public string windchill_c { get; set; }
        public string feelslike_string { get; set; }
        public string feelslike_f { get; set; }
        public string feelslike_c { get; set; }
        public string visibility_mi { get; set; }
        public string visibility_km { get; set; }
        public string solarradiation { get; set; }
        public string UV { get; set; }
        public string precip_1hr_string { get; set; }
        public string precip_1hr_in { get; set; }
        public string precip_1hr_metric { get; set; }
        public string precip_today_string { get; set; }
        public string precip_today_in { get; set; }
        public string precip_today_metric { get; set; }
        public string icon { get; set; }
        public string icon_url { get; set; }
        public string forecast_url { get; set; }
        public string history_url { get; set; }
        public string ob_url { get; set; }
        public string nowcast { get; set; }
    }

    public class RootObject
    {
        public Response response { get; set; }
        public CurrentObservation current_observation { get; set; }
    }

}

/*

{
  "response": {
  "version":"0.1",
  "termsofService":"http://www.wunderground.com/weather/api/d/terms.html",
  "features": {
  "conditions": 1
  }
	}
  ,	"current_observation": {
		"image": {
		"url":"http://icons.wxug.com/graphics/wu2/logo_130x80.png",
		"title":"Weather Underground",
		"link":"http://www.wunderground.com"
		},
		"display_location": {
		"full":"Los Angeles, CA",
		"city":"Los Angeles",
		"state":"CA",
		"state_name":"California",
		"country":"US",
		"country_iso3166":"US",
		"zip":"90043",
		"magic":"1",
		"wmo":"99999",
		"latitude":"33.99000168",
		"longitude":"-118.33000183",
		"elevation":"29.9"
		},
		"observation_location": {
		"full":"Park Mesa Heights, Los Angeles, California",
		"city":"Park Mesa Heights, Los Angeles",
		"state":"California",
		"country":"US",
		"country_iso3166":"US",
		"latitude":"33.984119",
		"longitude":"-118.336716",
		"elevation":"191 ft"
		},
		"estimated": {
		},
		"station_id":"KCALOSAN621",
		"observation_time":"Last Updated on December 20, 7:44 AM PST",
		"observation_time_rfc822":"Tue, 20 Dec 2016 07:44:28 -0800",
		"observation_epoch":"1482248668",
		"local_time_rfc822":"Tue, 20 Dec 2016 07:44:49 -0800",
		"local_epoch":"1482248689",
		"local_tz_short":"PST",
		"local_tz_long":"America/Los_Angeles",
		"local_tz_offset":"-0800",
		"weather":"Clear",
		"temperature_string":"48.6 F (9.2 C)",
		"temp_f":48.6,
		"temp_c":9.2,
		"relative_humidity":"27%",
		"wind_string":"From the NNW at 2.0 MPH",
		"wind_dir":"NNW",
		"wind_degrees":338,
		"wind_mph":2.0,
		"wind_gust_mph":0,
		"wind_kph":3.2,
		"wind_gust_kph":0,
		"pressure_mb":"1023",
		"pressure_in":"30.21",
		"pressure_trend":"0",
		"dewpoint_string":"16 F (-9 C)",
		"dewpoint_f":16,
		"dewpoint_c":-9,
		"heat_index_string":"NA",
		"heat_index_f":"NA",
		"heat_index_c":"NA",
		"windchill_string":"49 F (9 C)",
		"windchill_f":"49",
		"windchill_c":"9",
		"feelslike_string":"49 F (9 C)",
		"feelslike_f":"49",
		"feelslike_c":"9",
		"visibility_mi":"10.0",
		"visibility_km":"16.1",
		"solarradiation":"--",
		"UV":"0","precip_1hr_string":"0.00 in ( 0 mm)",
		"precip_1hr_in":"0.00",
		"precip_1hr_metric":" 0",
		"precip_today_string":"0.00 in (0 mm)",
		"precip_today_in":"0.00",
		"precip_today_metric":"0",
		"icon":"clear",
		"icon_url":"http://icons.wxug.com/i/c/k/clear.gif",
		"forecast_url":"http://www.wunderground.com/US/CA/Los_Angeles.html",
		"history_url":"http://www.wunderground.com/weatherstation/WXDailyHistory.asp?ID=KCALOSAN621",
		"ob_url":"http://www.wunderground.com/cgi-bin/findweather/getForecast?query=33.984119,-118.336716",
		"nowcast":""
	}
}
*/