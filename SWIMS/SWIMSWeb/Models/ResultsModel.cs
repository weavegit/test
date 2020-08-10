using System;
using System.Collections.Generic;
using SWIMSDataAccessLayer.dto;
using System.ComponentModel.DataAnnotations;
namespace SWIMSWeb.models
{
    public class ResultsModel 
    {
        public List<SearchModel> Results { get; set; }

        public string SearchTerm { get; set; }
        public string SortColumn { get; set; }
        public bool Ascending { get; set; }
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

        public bool IsChecksOff() {
            return !JobIdIsChecked && !AddressIsChecked && !ContractIsChecked && !DistrictIsChecked;
        }
        public void AllChecksOn()
        {
            JobIdIsChecked = true;
            AddressIsChecked = true; 
            ContractIsChecked = true;
            DistrictIsChecked = true;
        }
        public bool IsJobOnlySearch()
        {
            return JobIdIsChecked && !AddressIsChecked && !ContractIsChecked && !DistrictIsChecked;
        }
    }
}
