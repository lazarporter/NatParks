using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.DAL;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Web.Controllers
{
    public class SurveyController : Controller
    {
        private ISurveyDAO SurveyDAO = null;

        /// <summary>
        /// Constructory
        /// </summary>
        /// <param name="parkDAOParam">An object </param>
        public SurveyController(ISurveyDAO daoParam)
        {
            this.SurveyDAO = daoParam;
        }


        public IActionResult Index()
        {

            return View();
        }
    }
}