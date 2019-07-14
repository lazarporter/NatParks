using Capstone.Web.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public interface IParkDAO
    {
        /// <summary>
        /// Retrieves all parks from the database
        /// </summary>
        /// <returns>IList of Park objects</returns>
        IList<Park> GetAllParks();

        /// <summary>
        /// Retrieves a single park based on the parkCode
        /// </summary>
        /// <param name="Park_Code">parkCode corresponding the park to be returned</param>
        /// <returns>Single Park object</returns>
        Park GetParkBy_Code(string Park_Code);

        /// <summary>
        /// Returns a List of SelectListItems for display as a dropdown
        /// </summary>
        /// <returns></returns>
        List<SelectListItem> GetParkSelections();
    }
}
