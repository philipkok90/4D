using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Globalization;
using System.Threading;
using _4D.Services;
using _4D.Models;
using System.IO;

namespace _4D.Controllers
{
    public class AdminBaseController : Controller
    {
        // GET: AdminBase

        #region Access Validation

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        { 
            if (Session["Msg"] != null)
            {
                if(Session["Msg"].ToString() != "")
                { 
                    Response.Write("<script>alert('" + Session["Msg"].ToString()  + "');</script>"); 
                }
            } 
            Session["Msg"] = ""; 

            string AdminID = "";
            if (Session["AdminID"] != null)
                AdminID = Session["AdminID"].ToString();
            else
                AdminID = ""; 
            // get controller and action name
            string actionName = filterContext.ActionDescriptor.ActionName;
            string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            string httpMethod = filterContext.HttpContext.Request.HttpMethod;

            if (AdminID != "")
            {

            }
            else
            {
                if (actionName != "Login" && actionName != "ResetPassword")
                {
                    filterContext.Result = RedirectToAction("Login", "Administrator");
                }
            }


        }

        #endregion



         


    }
}