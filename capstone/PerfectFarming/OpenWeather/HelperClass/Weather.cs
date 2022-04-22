using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenWeather.Model;
using System.Net.Http;
using System.Xml.Linq;

namespace OpenWeather.HelperClass
{
    static class Weather
    {
        private static string AppID = "faf9220f0fa4d834e94abd75ccafddb4";

        public static async Task<List<WeatherDetails>> GetWeather(string location)
        {
            string url = string.Format
                ("http://api.openweathermap.org/data/2.5/forecast?q={0}&mode=xml&units=metric&appid={1}", 
                location, AppID);
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string response = await client.GetStringAsync(url);
                    if (!(response.Contains("message") && response.Contains("cod")))
                    {
                        XElement xEl = XElement.Load(new System.IO.StringReader(response));
                        return GetWeatherInfo(xEl);
                    }
                    else
                    {
                        return new List<WeatherDetails>();
                    }
                }
                catch (HttpRequestException)
                {
                    return new List<WeatherDetails>();
                }
            }
        }
        public static async Task<List<WeatherDetails>> GetWeather(float lat,float lon)
        {
            string url = string.Format
                ("https://api.openweathermap.org/data/2.5/weather?lat={0}&lon={1}&mode=xml&units=metric&appid={2}",
                lat,lon, AppID);
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string response = await client.GetStringAsync(url);
                    if (!(response.Contains("message") && response.Contains("cod")))
                    {
                        XElement xEl = XElement.Load(new System.IO.StringReader(response));
                        return GetWeatherInfoCurret(xEl);
                    }
                    else
                    {
                        return new List<WeatherDetails>();
                    }
                }
                catch (HttpRequestException)
                {
                    return new List<WeatherDetails>();
                }
            }
        }

        private static List<WeatherDetails> GetWeatherInfo(XElement xEl)
        {
            IEnumerable<WeatherDetails> w = xEl.Descendants("time").Select((el) =>
                new WeatherDetails
                {
                    Humidity = el.Element("humidity").Attribute("value").Value.ToString() + "%",
                    MaxTemperature = el.Element("temperature").Attribute("max").Value.ToString() + "°",
                    MinTemperature = el.Element("temperature").Attribute("min").Value.ToString() + "°",
                    Temperature = el.Element("temperature").Attribute("value").Value.ToString() + "°",
                    Weather = el.Element("symbol").Attribute("name").Value,
                    WeatherDay = DayOfTheWeek(el),
                    WeatherIcon = WeatherIconPath(el),
                    WindDirection = el.Element("windDirection").Attribute("name").Value,
                    WindSpeed = el.Element("windSpeed").Attribute("mps").Value + "mps",
                    Time = el.Attribute("from").Value
                }) ;

            return w.ToList();
        }
        private static List<WeatherDetails> GetWeatherInfoCurret(XElement el)
        {
            WeatherDetails w = 
                new WeatherDetails
                {
                    Humidity = el.Element("humidity").Attribute("value").Value.ToString() + "%",
                    MaxTemperature = el.Element("temperature").Attribute("max").Value.ToString() + "°",
                    MinTemperature = el.Element("temperature").Attribute("min").Value.ToString() + "°",
                    Temperature = el.Element("temperature").Attribute("value").Value.ToString() + "°",
                    Weather = el.Element("weather").Attribute("value").Value.ToString(),
                    WeatherDay = Convert.ToDateTime(el.Element("lastupdate").Attribute("value").Value).DayOfWeek.ToString(),
                    WeatherIcon = WeatherIconPathCurrent(el),
                    WindDirection = el.Element("wind").Element("direction").Attribute("value").Value,
                    WindSpeed = el.Element("wind").Element("speed").Attribute("value").Value + "mps",
                    Time = el.Element("lastupdate").Attribute("value").Value
                };
            List<WeatherDetails> details = new List<WeatherDetails>();
            details.Add(w);
            return details;
        }

        private static string DayOfTheWeek(XElement el)
        {
            DayOfWeek dW = Convert.ToDateTime(el.Attribute("from").Value).DayOfWeek;
            return dW.ToString();
        }
        private static string WeatherIconPathCurrent(XElement el)
        {
            string symbolVar = el.Element("weather").Attribute("icon").Value;
            string symbolNumber = el.Element("weather").Attribute("number").Value;
            string dayOrNight = symbolVar.Substring(symbolVar.Length-1).ToString(); // d or n
            return String.Format("WeatherIcons/{0}{1}.png", symbolNumber, dayOrNight);
        }
        private static string WeatherIconPath(XElement el)
        {
            string symbolVar = el.Element("symbol").Attribute("var").Value;
            string symbolNumber = el.Element("symbol").Attribute("number").Value;
            string dayOrNight = symbolVar.ElementAt(2).ToString(); // d or n
            return String.Format("WeatherIcons/{0}{1}.png", symbolNumber, dayOrNight);
        }
    }
}
