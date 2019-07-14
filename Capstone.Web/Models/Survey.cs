using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class Survey
    {
        public int SurveyID { get; set; }

        [Required(ErrorMessage = "Invalid email")]
        [EmailAddress]
        [Display(Name = "Email", Prompt = "enter email")]
        public string Email { get; set; }

        public string ParkCode { get; set; }
        public string State { get; set; }

        [Required(ErrorMessage = "*")]
        public string ActivityLevel { get; set; }
    }
}
