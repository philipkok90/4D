using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _4D.Models;
using _4D.Services; 
namespace _4D.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List< Results> result = new List<Results>(); 
            result = HomeService.GetResultListing_ByDate();

            ViewBag.Magnum = result.Where(r => r.ResultType.Equals("MAGNUM")).SingleOrDefault();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}