using System;
using System.Collections.Generic;
using System.Text;

namespace SWIMSDataAccessLayer.dto
{
    public class ResultsDTO
    {
        public Guid jobId { get; set; }
        public string applicationId { get; set; }
        public int contractId { get; set; }
        public string contractCode { get; set; }
        public string contractDesc { get; set; }
        public int districtId { get; set; }
        public string districtCode { get; set; }
        public string districtDesc { get; set; }
        public int masterjobId { get; set; }
        public string jobAddress { get; set; }
        public string districtAddress { get; set; }
        public string districtPostCode { get; set; }

        public ResultsDTO()
        {
        }

        public ResultsDTO(Guid jobId, string applicationId, int contractId, string contractCode, 
            string contractDesc, int districtId, string districtCode, string districtDesc,
            int masterjobId, string jobAddress, string districtAddress, string districtPostCode)
        {
            this.jobId = jobId;
            this.applicationId = applicationId;
            this.contractId = contractId;
            this.contractCode = contractCode;
            this.contractDesc = contractDesc;
            this.districtId = districtId;
            this.districtCode = districtCode;
            this.districtDesc = districtDesc;
            this.masterjobId = masterjobId;
            this.jobAddress = jobAddress;
            this.districtAddress = districtAddress;
            this.districtPostCode = districtPostCode;
        }
    }
}
