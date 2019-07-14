using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class ParkDetailVM
    {
        public Park _Park { get; set; }
        public IList<DayWeather> Weather { get; set; }
        public string tempUnits { get; set; }       //"f" or "c" indicated which temperature units is relevant for the VM instance
        public string ParkCode { get; set; }        //The parcode for the _Park of the instance
    }
}
