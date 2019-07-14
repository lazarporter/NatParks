using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public class SurveySqlDAO : ISurveyDAO
    {
        private readonly string connectionString;
        public SurveySqlDAO(string connected)
        {
            this.connectionString = connected;
        }

        public bool SaveSurvey(Survey survey)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = $"INSERT INTO survey_result (parkCode, emailAddress, state, activityLevel)" +
                        $"VALUES (@code, @email, @state, @activityLevel)";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@code", survey.ParkCode);
                    cmd.Parameters.AddWithValue("@email", survey.Email);
                    cmd.Parameters.AddWithValue("@state", survey.State);
                    cmd.Parameters.AddWithValue("@activityLevel", survey.ActivityLevel);

                    cmd.ExecuteScalar();
                    return true;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error saving Survey object to DB:" + ex.Message);
                return false;
            }
        }

        public List<KeyValuePair<string, int>> SurveyRankings()
        {
            List<KeyValuePair<string, int>> results = new List<KeyValuePair<string, int>>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = $"select MAX(s.parkCode) as parkCode, COUNT(s.surveyId) as rank " +
                        $"from survey_result s join park p on p.parkCode = s.parkCode " +
                        $"group by s.parkCode " +
                        $"order by results desc, parkCode asc;";
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string key = Convert.ToString(reader["parkCode"]);
                        int value = Convert.ToInt32(reader["rank"]);

                        KeyValuePair<string, int> pair = new KeyValuePair<string, int>(key, value);
                        results.Add(pair);
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("getting survey rankings from DB:" + ex.Message);

            }
            return results;
        }

    }
}
