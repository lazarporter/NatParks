using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.DAL;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Web.Controllers
{
    public class ParksController : Controller
    {
        //Data Access properties
        private IParkDAO parkDao = null;

        /// <summary>
        /// Constructory
        /// </summary>
        /// <param name="parkDAOParam">An object </param>
        public ParksController(IParkDAO parkDAOParam)
        {
            this.parkDao = parkDAOParam;
        }

        public IActionResult Index()
        {
            
            return View(this.parkDao.GetAllParks());
        }
    }
}