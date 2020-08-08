using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using SWIMSDataAccessLayer.query;
using SWIMSDataAccessLayer.dto;
using log4net;
using log4net.Config;
using System.Configuration;
using SWIMSWeb.models;
namespace SWIMSWeb.Controllers
{
    public class SearchController : Controller
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(SearchController));

     
        public ActionResult Index(FormCollection form)
        {

            string searchValue = Request.Form["searchString"];
            Dictionary<Guid, SearchModel> results = new Dictionary<Guid, SearchModel>();

            try
            {
                ISearchable seachQuery = new SearchQuery();
                IEnumerable<ResultsDTO> collection = seachQuery.List(searchValue);

                foreach(ResultsDTO dto in collection)
                {
                    if (!results.ContainsKey(dto.jobId))
                    {
                        results.Add(dto.jobId, new SearchModel(dto));
                    }
                }
            }
            catch(Exception e)
            {
                log.Error(e);
            }
            return View(results.Values.ToList());
        }

        public ActionResult Search()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Clear()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}