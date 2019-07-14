using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public class WeatherSqlDAO : IWeatherDAO
    {
        private readonly string connectionString;
        public WeatherSqlDAO(string connectionStringParam)
        {
            this.connectionString = connectionStringParam;
        }

        public IList<DayWeather> GetWeatherByParkCode(string parkCode)
        {
            List<DayWeather> result = new List<DayWeather>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "select * from weather WHERE parkCode = @code " +
                        "ORDER BY fiveDayForecastValue ASC";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@code", parkCode);         //add user input safely

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        DayWeather weather = new DayWeather();

                        weather.ParkCode = Convert.ToString(reader["parkCode"]);
                        weather.FiveDayForecastValue = Convert.ToInt32(reader["fiveDayForecastValue"]);
                        weather.Low = Convert.ToInt32(reader["low"]);
                        weather.High = Convert.ToInt32(reader["high"]);
                        weather.Forecast = Convert.ToString(reader["forecast"]);

                        result.Add(weather);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return result;
        }
    }
}
