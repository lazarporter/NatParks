using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class SurveyVM
    {
        public Survey survey { get; set; }
        public List<SelectListItem> parkNames { get; set; }
        public List<SelectListItem> stateNames { get; set; }
        public List<string> activityLevels { get; set; }
    }
}
