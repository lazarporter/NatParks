using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class Park
    {
        public string ParkCode { get; set; }
        public string ParkName { get; set; }
        public string State { get; set; }
        public double Acreage { get; set; }
        public double Elevation { get; set; }
        public double TrailMiles { get; set; }
        public int CampsiteCount { get; set; }
        public string Climate { get; set; }
        public int YearFounded { get; set; }
        public int AnVisitors { get; set; }
        public string Quote { get; set; }
        public string QuoteSource { get; set; }
        public string Description { get; set; }
        public decimal Fee { get; set; }
        public int Animals { get; set; }
    }
}
