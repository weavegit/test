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
                                            " INNER JOIN[SWIMS_CUSTOMER].[dbo].[district] d ON d.district_id = j.district_id " ;
                                            
        public IEnumerable<dto.ResultsDTO> List(dto.SearchDTO dto)
        {
            string query = SEARCH_QUERY;
            string connectionString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            List<dto.ResultsDTO> resultsCol = new List<dto.ResultsDTO>();
            Guid validGuid;
            bool isFormatValid = Guid.TryParse(dto.SearchValue, out validGuid);

            if (dto.JobIdIsRequired && !isFormatValid)
            {
                return resultsCol;
            }

            query = CompleteQueryString(query, dto, isFormatValid);

            using (SqlConnection con = new SqlConnection(connectionString))
            {

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.Text;

                LoadParameters(cmd, dto, isFormatValid);

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

        private void LoadParameters(SqlCommand cmd, dto.SearchDTO dto, bool isFormatValid)
        {
            if (isFormatValid && dto.JobIdIsRequired)
            {
                cmd.Parameters.AddWithValue("@job_id", dto.SearchValue);
            }
            if (dto.AddressIsRequired)
            {
                cmd.Parameters.AddWithValue("@district_address", "%" + dto.SearchValue + "%");
            }
            if (dto.ContractIsRequired)
            {
                cmd.Parameters.AddWithValue("@contract_code", "%" + dto.SearchValue + "%");
            }
            if (dto.DistrictIsRequired)
            {
                cmd.Parameters.AddWithValue("@district_code", "%" + dto.SearchValue + "%");
            }
        }

        private string CompleteQueryString(String querySoFar, dto.SearchDTO dto, bool isFormatValid)
        {
            string clausePrefix = " WHERE ";

            if (isFormatValid && dto.JobIdIsRequired)
            {
                querySoFar += clausePrefix + " j.job_id = @job_id ";
                clausePrefix = " OR ";
            }
            if (dto.AddressIsRequired)
            {
                querySoFar += clausePrefix + " d.district_address LIKE @district_address OR j.job_address LIKE @district_address ";
                clausePrefix = " OR ";
            }
            if (dto.ContractIsRequired)
            {
                querySoFar += clausePrefix + " c.contract_code LIKE @contract_code OR c.contract_desc LIKE @contract_code";
                clausePrefix = " OR ";
            }
            if (dto.DistrictIsRequired)
            {
                querySoFar += clausePrefix + " d.district_code LIKE @district_code OR d.district_desc LIKE @district_code ";
            }

            return querySoFar;
        }
    }
}
