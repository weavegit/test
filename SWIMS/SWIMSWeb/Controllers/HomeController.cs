using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SWIMSSearchEngine; 

namespace SWIMSWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ISearchable engine = new DataBaseSearch();
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