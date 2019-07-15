using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public interface ISurveyDAO
    {
        /// <summary>
        /// Saves a single Survey object to the data base
        /// </summary>
        /// <param name="survey">The Survey to save</param>
        /// <returns>Success of failuer</returns>
        bool SaveSurvey(Survey survey);

        /// <summary>
        /// 
        /// </summary>
        /// <returns>An ordered list, highest to lowest, of parks by the number of surveys received</returns>
        List<KeyValuePair<string, int>> GetSurveyRankings();
    }
}
