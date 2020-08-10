using System;
using System.Collections.Generic;
using System.Text;

namespace SWIMSDataAccessLayer.dto
{
    public class SearchDTO
    {
        public string SearchValue { get; set; }
        public bool JobIdIsRequired { get; set; }
        public bool AddressIsRequired { get; set; }
        public bool ContractIsRequired { get; set; }
        public bool DistrictIsRequired { get; set; }

        public bool IsJobOnlySearch()
        {
            return JobIdIsRequired && !AddressIsRequired && !ContractIsRequired && !DistrictIsRequired;
        }

        public SearchDTO(string searchValue, bool jobIdIsRequired, bool addressIsRequired, bool contractIsRequired, bool districtIsRequired)
        {
            SearchValue = searchValue;
            JobIdIsRequired = jobIdIsRequired;
            AddressIsRequired = addressIsRequired;
            ContractIsRequired = contractIsRequired;
            DistrictIsRequired = districtIsRequired;
        }
    }
}
