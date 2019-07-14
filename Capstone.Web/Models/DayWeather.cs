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
                        result = "National Parks Service recommends packing snowshoes today.";
                        break;
                    case "rain":
                        result = "National Parks Service recommends packing rain gear, including waterproof shoes.";
                        break;
                    case "thunderstorms":
                        result = "National Parks Services recommends you seek shelter and avoid hiking on exposed ridges.";
                        break;
                    case "sunny":
                        result = "National Parks Services recommends bringing sunscreen with SPF 50 rating.";
                        break;

                    default:
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
