using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.DAL;
using Capstone.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Web.Controllers
{
    public class ParksController : Controller
    {
        //Data Access properties
        private IParkDAO parkDao = null;
        private IWeatherDAO weatherDao = null;

        /// <summary>
        /// Constructory
        /// </summary>
        /// <param name="parkDAOParam">An object </param>
        public ParksController(IParkDAO parkDAOParam, IWeatherDAO weatherDAOParam)
        {
            this.parkDao = parkDAOParam;
            this.weatherDao = weatherDAOParam;
        }

        public IActionResult Index()
        {            
            return View(this.parkDao.GetAllParks());
        }

        public IActionResult Detail(string Park)
        {
            IList<DayWeather> vm = this.weatherDao.GetWeatherByParkCode(Park);
            return View(vm);
        }
    }
}