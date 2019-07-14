using Capstone.Web.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public class ParkSqlDAO : IParkDAO
    {
        private readonly string connectionString;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="connectionStringParam">SQL Connection string</param>
        public ParkSqlDAO(string connectionStringParam)
        {
            this.connectionString = connectionStringParam;
        }

        public IList<Park> GetAllParks()
        {
            List<Park> parksList = new List<Park>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "select * from park ORDER BY parkname";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Park park = new Park();
                        park.Acreage = Convert.ToDouble(reader["acreage"]);
                        park.Animals = Convert.ToInt32(reader["numberOfAnimalSpecies"]);
                        park.AnVisitors = Convert.ToInt32(reader["annualVisitorCount"]);
                        park.CampsiteCount = Convert.ToInt32(reader["numberOfCampsites"]);
                        park.Climate = Convert.ToString(reader["climate"]);
                        park.Description = Convert.ToString(reader["parkDescription"]);
                        park.TrailMiles = Convert.ToDouble(reader["milesOfTrail"]);
                        park.Elevation = Convert.ToDouble(reader["elevationInFeet"]);
                        park.Fee = Convert.ToDecimal(reader["entryFee"]);
                        park.ParkCode = Convert.ToString(reader["parkCode"]);
                        park.ParkName = Convert.ToString(reader["parkName"]);
                        park.Quote = Convert.ToString(reader["inspirationalQuote"]);
                        park.QuoteSource = Convert.ToString(reader["inspirationalQuoteSource"]);
                        park.State = Convert.ToString(reader["state"]);
                        park.YearFounded = Convert.ToInt32(reader["yearFounded"]);

                        parksList.Add(park);
                    }

                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return parksList;
        }

        public Park GetParkBy_Code(string parkCode)
        {
            Park result = new Park();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "select * from park WHERE parkCode = @code";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@code", parkCode);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        result.ParkCode = Convert.ToString(reader["parkCode"]);
                        result.ParkName = Convert.ToString(reader["parkName"]);
                        result.State = Convert.ToString(reader["state"]);
                        result.Climate = Convert.ToString(reader["climate"]);
                        result.Quote = Convert.ToString(reader["inspirationalQuote"]);
                        result.QuoteSource = Convert.ToString(reader["inspirationalQuoteSource"]);
                        result.Description = Convert.ToString(reader["parkDescription"]);
                        result.Acreage = Convert.ToDouble(reader["acreage"]);
                        result.AnVisitors = Convert.ToInt32(reader["annualVisitorCount"]);
                        result.CampsiteCount = Convert.ToInt32(reader["numberOfCampsites"]);
                        result.TrailMiles = Convert.ToDouble(reader["milesOfTrail"]);
                        result.Elevation = Convert.ToDouble(reader["elevationInFeet"]);
                        result.Fee = Convert.ToDecimal(reader["entryFee"]);
                        result.YearFounded = Convert.ToInt32(reader["yearFounded"]);
                        result.Animals = Convert.ToInt32(reader["numberOfAnimalSpecies"]);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return result;
        }

        public List<SelectListItem> GetParkSelections()
        {
            List<SelectListItem> results = new List<SelectListItem>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT parkName, parkCode FROM park";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string parkName = Convert.ToString(reader["parkName"]);
                        string parkCode = Convert.ToString(reader["parkCode"]);
                        results.Add(new SelectListItem() { Text = parkName, Value = parkCode });
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return results;
        }
    }
}
