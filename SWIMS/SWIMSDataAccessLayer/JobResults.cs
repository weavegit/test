using System;
using System.Collections.Generic;
using System.Text;

namespace SWIMSDataAccessLayer
{
    public class JobResults
    {
        private int jobId;
        private string applicationId;
        private int contractId;
        private string contractCode;
        private string contractDesc;
        private int districtId;
        private string districtCode;
        private string districtDesc;
        private string masterjobId;
        private string jobAddress;

        public JobResults()
        {
        }

        public JobResults(int jobId, string applicationId, int contractId, string contractCode, 
            string contract_desc, int districtId, string districtCode, string district_desc, 
            string masterjobId, string jobAddress)
        {
            this.jobId = jobId;
            this.applicationId = applicationId;
            this.contractId = contractId;
            this.contractCode = contractCode;
            this.contractDesc = contract_desc;
            this.districtId = districtId;
            this.districtCode = districtCode;
            this.districtDesc = district_desc;
            this.masterjobId = masterjobId;
            this.jobAddress = jobAddress;
        }
    }
}
