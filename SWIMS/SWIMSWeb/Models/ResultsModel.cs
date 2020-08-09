using System;
using System.Collections.Generic;
using SWIMSDataAccessLayer.dto;

namespace SWIMSWeb.models
{
    public class ResultsModel 
    {
        public List<SearchModel> Results { get; set; }
        public string SearchTerm { get; set; }
        public string UserMessage { get; set; }
        public bool JobIdIsChecked { get; set; }
        public bool AddressIsChecked { get; set; }
        public bool ContractIsChecked { get; set; }
        public bool DistrictIsChecked { get; set; }

        public ResultsModel()
        {
        }

        public ResultsModel(List<SearchModel> resultsLcl)
        {
            Results = resultsLcl;
        }

        public bool AllOffChecksOff() {
            return !(JobIdIsChecked || AddressIsChecked || ContractIsChecked || DistrictIsChecked);
        }

    }
}
