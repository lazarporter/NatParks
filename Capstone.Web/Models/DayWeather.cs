using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class DayWeather
    {
        public string ParkCode { get; set; }
        public int FiveDayForecastValue { get; set; }       //1 = today, 2 = tomorrow, 3= next day etc
        public int Low { get; set; }                        //in fahrenheit
        public int High { get; set; }                       //in fahrenheit
        public string Forecast { get; set; }                //"sunny", "rainy" etc
        public string Advisory
        {
            get
            {
                string result = "";
                switch (this.Forecast)
                {
                    case "snow":
                        result = "Snowshoes recommended.";
                        break;
                    case "rain":
                        result = "Rain gear recommended, including waterproof shoes.";
                        break;
                    case "thunderstorms":
                        result = "Seek shelter and avoid hiking on exposed ridges.";
                        break;
                    case "sunny":
                        result = "Sunscreen with SPF 50 rating recommended.";
                        break;

                    default:
                        result = "Looks like a beautiful day!";
                        break;
                }
                if (High > 75)
                {
                    result += " Make sure to bring an extra gallon of water.";
                }
                if (High - Low > 20)
                {
                    result += " Wear breathable layers!";
                }
                if (Low < 20)
                {
                    result += " Exposure to frigid tempuratures can lead to death, or even frost bite!";
                }
                return result;
            }

        }
    }
}
