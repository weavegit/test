using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SWIMSSearchEngine;
using SWIMSDataAccessLayer;
using log4net;
using log4net.Config;
using System.Configuration;

namespace SWIMSWeb.Controllers
{
    public class HomeController : Controller
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(HomeController));
        public ActionResult Index()
        {
 
            try
            {
                SearchQuery query = new SearchQuery();
                IEnumerable<JobResults>  collection = query.GetSearchResults();
                ISearchable engine = new DataBaseSearch();
            }
            catch(Exception e)
            {
                log.Error(e);
            }
            return View();
        }

        //public ActionResult Index(string searchterm)
        //{
        //    return View();
        //}

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