using System;
using SWIMSDataAccessLayer.dto;

namespace SWIMSWeb.models
{
    public class SearchModel
    {
        public Guid jobId { get; set; }
        public string applicationId { get; set; }
        public string contractCode { get; set; }
        public string contractDesc { get; set; }
        public string districtCode { get; set; }
        public string districtDesc { get; set; }
        public string jobAddress { get; set; }
        public string districtAddress { get; set; }
        public string districtPostCode { get; set; }
        
        public SearchModel()
        {
        }

        public SearchModel(ResultsDTO dto)
        {
            this.jobId = dto.jobId;
            this.applicationId = dto.applicationId;
            this.contractCode = dto.contractCode;
            this.contractDesc = dto.contractDesc;
            this.districtCode = dto.districtCode;
            this.districtDesc = dto.districtDesc;
            this.jobAddress = dto.jobAddress;
            this.districtAddress = dto.districtAddress;
            this.districtPostCode = dto.districtPostCode;
        }

        public SearchModel(
            Guid jobId, 
            string applicationId, 
            string contractCode, 
            string contract_desc, 
            string districtCode, 
            string district_desc,
            string jobAddress, 
            string districtAddress, 
            string districtPostCode)
        {
            this.jobId = jobId;
            this.applicationId = applicationId;
            this.contractCode = contractCode;
            this.contractDesc = contract_desc;
            this.districtCode = districtCode;
            this.districtDesc = district_desc;
            this.jobAddress = jobAddress;
            this.districtAddress = districtAddress;
            this.districtPostCode = districtPostCode;
        }
    }
}
