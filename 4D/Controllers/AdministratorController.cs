using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _4D.Models;
using _4D.Services;

namespace _4D.Controllers
{
    public class AdministratorController : Controller
    {


        #region Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Login1()
        {

            return View();
        }
        #endregion




        public ActionResult Dashboard()
        {
            return View();
        }
    }
}