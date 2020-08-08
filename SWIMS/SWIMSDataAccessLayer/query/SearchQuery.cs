using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SWIMSDataAccessLayer.query
{
    public class SearchQuery : ISearchable
    {
        private const int JOBID = 0;
        private const int APPLICATIONID = 1;
        private const int CONTRACTID = 2;
        private const int CONTRACTCODE = 3;
        private const int CONTRACTDESC = 4;
        private const int DISTRICTID = 5;
        private const int DISTRICTCODE = 6;
        private const int DISTRICTDESC = 7;
        private const int MASTERJOBID = 8;
        private const int JOBADDRESS = 9;
        private const int DISTRICTADDRESS = 10;
        private const int DISTRICTPOSTCODE = 11;

        private const string SEARCH_QUERY = "SELECT j.job_id, j.application_id, j.contract_id, " + "" +
                                            " c.contract_code, c.contract_desc, j.district_id, " +
                                            " d.district_code, d.district_desc, j.masterjob_id, j.job_address, d.district_address, d.district_postcode " +
                                            " FROM[SWIMS_CUSTOMER].[dbo].[job] j " +
                                            " INNER JOIN[SWIMS_CUSTOMER].[dbo].[contract] c ON c.contract_id = j.contract_id " +
                                            " INNER JOIN[SWIMS_CUSTOMER].[dbo].[district] d ON d.district_id = j.district_id " +
                                            " WHERE j.job_id = '%@param1%' " +
                                            " OR d.district_address LIKE '%@param2%'" +
                                            " OR c.contract_code LIKE '%@param3%'" +
                                            " OR d.district_code LIKE '%@param4%'";
        public IEnumerable<dto.ResultsDTO> List(string searchValue)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            List<dto.ResultsDTO> resultsCol = new List<dto.ResultsDTO>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = SEARCH_QUERY;
                SqlCommand cmd = new SqlCommand(SEARCH_QUERY, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@param1", searchValue);
                cmd.Parameters.AddWithValue("@param2", searchValue);
                cmd.Parameters.AddWithValue("@param3", searchValue);
                cmd.Parameters.AddWithValue("@param4", searchValue);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Guid jobId = rdr.GetGuid(JOBID);
                    string applicationId = rdr.IsDBNull(APPLICATIONID) ? "" : rdr.GetString(APPLICATIONID);
                    int contractId = rdr.GetInt32(CONTRACTID);
                    string contractCode = rdr.IsDBNull(CONTRACTCODE) ? "" : rdr.GetString(CONTRACTCODE);
                    string contractDesc = rdr.IsDBNull(CONTRACTDESC) ? "" : rdr.GetString(CONTRACTDESC);
                    int districtId = rdr.GetInt32(DISTRICTID);
                    string districtCode = rdr.IsDBNull(DISTRICTCODE) ? "" : rdr.GetString(DISTRICTCODE);
                    string districtDesc = rdr.IsDBNull(DISTRICTDESC) ? "" : rdr.GetString(DISTRICTDESC);
                    int masterjobId =  rdr.GetInt32(MASTERJOBID);
                    string jobAddress = rdr.IsDBNull(JOBADDRESS) ? "" : rdr.GetString(JOBADDRESS);
                    string districtAddress = rdr.IsDBNull(DISTRICTADDRESS) ? "" : rdr.GetString(DISTRICTADDRESS);
                    string districtPostCode = rdr.IsDBNull(DISTRICTPOSTCODE) ? "" : rdr.GetString(DISTRICTPOSTCODE);

                    resultsCol.Add(new dto.ResultsDTO(jobId,
                                                applicationId,
                                                contractId,
                                                contractCode,
                                                contractDesc,
                                                districtId,
                                                districtCode,
                                                districtDesc,
                                                masterjobId,
                                                jobAddress,
                                                districtAddress,
                                                districtPostCode));
                }
            }

            return resultsCol;
        }

    }
}
