using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.DAL;
using Capstone.Web.Models;
using Microsoft.AspNetCore.Http;
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

        [HttpGet]
        public IActionResult Detail(string Park)
        {
            ParkDetailVM vm = new ParkDetailVM();
            vm.tempUnits = GetTemperaturePreference();                      //get the selected units from session (or null)
            vm._Park = this.parkDao.GetParkBy_Code(Park);                   //retreive PARK from database
            vm.Weather = this.weatherDao.GetWeatherByParkCode(Park);        //retreive corresponding weather 
                                                                            //pass the vm to our Detail View.
            return View(vm);
        }

        [HttpPost]
        public IActionResult Detail(ParkDetailVM vm)
        {
            SetTemperaturePreference(vm.tempUnits);

            var obj = new { Park = vm.ParkCode };                       //pass the parkCode to the next request
            return RedirectToAction("Detail", obj);                         //redirect the user back to the same park detail page (units should change now!)
        }


        private string GetTemperaturePreference()
        {
            return HttpContext.Session.GetString("TempUnits") ?? "f";       //if no pref in session, default to "f" for fahrenheit
        }

        private void SetTemperaturePreference(string pref)
        {
            HttpContext.Session.SetString("TempUnits", pref);               //store the selected units in session
        }
    }
}