using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using SWIMSDataAccessLayer.query;
using SWIMSDataAccessLayer.dto;
using log4net;
using SWIMSWeb.models;

namespace SWIMSWeb.Controllers
{
    public class SearchController : Controller
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(SearchController));

        public ActionResult Index(ResultsModel model)
        {
            var re = Request;
            Guid validGuid;
            bool isFormatValid = Guid.TryParse(model.SearchTerm, out validGuid);
            ISearchable seachQuery = new SearchQuery();
            IEnumerable<ResultsDTO> collection = null;
            List<SearchModel> results = results = new List<SearchModel>();

            if (string.IsNullOrWhiteSpace(model.SearchTerm) || model.IsChecksOff() ) {
                model.AllChecksOn();
                ViewBag.UserMessage = "Please enter your search";
            } 
            else if ((model.IsJobOnlySearch() && !isFormatValid)) {
                ViewBag.UserMessage = "Please enter a valid GUID";
            } 
            else
            {
                try
                {
                    collection = seachQuery.List(new SearchDTO(model.SearchTerm.Trim(), model.JobIdIsChecked, model.AddressIsChecked, model.ContractIsChecked, model.DistrictIsChecked));
                    foreach(ResultsDTO dto in collection)
                    {
                        results.Add(new SearchModel(dto));
                    }
                }
                catch(Exception e)
                {
                    log.Error(e);
                }

                if(model.SortColumn !=null)
                {
                    model.Results = OrderResults(results, model);
                } 
                else
                {
                    model.Results = results;
                }
              
                ViewBag.UserMessage = "Your search gave " + model.Results.Count + " results.";
            }
            return View(model);
        }

        private List<SearchModel> OrderResults(List<SearchModel> results, ResultsModel model)
        {
            model.Ascending = !model.Ascending;
            var propertyInfo = typeof(SearchModel).GetProperty(model.SortColumn);
            if (model.Ascending)
            {
                results = results.OrderBy(x => propertyInfo.GetValue(x, null)).ToList();
            } 
            else
            {

                results = results.OrderByDescending(x => propertyInfo.GetValue(x, null)).ToList();
            }
 
            return results;
        }
    }
}