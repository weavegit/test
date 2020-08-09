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
            Guid validGuid;
            bool isFormatValid = Guid.TryParse(model.SearchTerm, out validGuid);

            if (string.IsNullOrWhiteSpace(model.SearchTerm) || model.AllOffChecksOff() ) {
                ViewBag.UserMessage = "Please enter your search";
            } 
            else if ((model.JobIdIsChecked && !isFormatValid)) {
                ViewBag.UserMessage = "Please enter a valid GUID";
            } 
            else
            {
                Dictionary<Object, SearchModel> results = new Dictionary<Object, SearchModel>();

                try
                {
                    ISearchable seachQuery = new SearchQuery();
                
                    IEnumerable<ResultsDTO> collection = seachQuery.List(new SearchDTO(model.SearchTerm.Trim(), model.JobIdIsChecked, model.AddressIsChecked, model.ContractIsChecked, model.DistrictIsChecked));

                    foreach(ResultsDTO dto in collection)
                    {
                        if (!results.ContainsKey(dto.Identifier()))
                        {
                            results.Add(dto.jobId, new SearchModel(dto));
                        }
                    }
                }
                catch(Exception e)
                {
                    log.Error(e);
                }

                model.Results = results.Values.ToList();
                ViewBag.UserMessage = "Your search gave " + model.Results.Count + " results.";
            }
            return View(model);
        }

        public ActionResult Clear()
        {
            ViewBag.Message = "Please enter your search";
            return View(new ResultsModel());
        }
    }
}