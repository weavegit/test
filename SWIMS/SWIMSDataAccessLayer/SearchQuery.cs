using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SWIMSDataAccessLayer
{
    public class SearchQuery
    {
        private const string SEARCH_QUERY = "SELECT j.job_id jobId, j.application_id applicationId, j.contract_id contractId, " + "" +
                                            " c.contract_code contractCode, c.contract_desc contract_desc, j.district_id districtId, " +
                                            " d.district_code districtCode, d.district_desc districtDesc, j.masterjob_id masterjobId " +
                                            " FROM[SWIMS_CUSTOMER].[dbo].[job] j " +
                                            " INNER JOIN[SWIMS_CUSTOMER].[dbo].[contract] c ON c.contract_id = j.job_id " +
                                            " INNER JOIN[SWIMS_CUSTOMER].[dbo].[district] d ON d.contract_id = j.job_id";
        public IEnumerable<JobResults> GetSearchResults()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            List<JobResults> resultsCol = new List<JobResults>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(SEARCH_QUERY, con);
                cmd.CommandType = CommandType.Text;

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    resultsCol.Add(new JobResults());
                }
            }

            return resultsCol;
        }
        
    }
}
