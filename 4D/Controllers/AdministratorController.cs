using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _4D.Models;
using _4D.Services;


namespace _4D.Controllers
{
    public class AdministratorController : AdminBaseController
    {


        #region Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost] 
        public ActionResult Login(Administrator admin)
        {
            string LoginID = admin.LoginID;
            string Password = admin.Password;

            if(LoginID == "Admin" && Password == "123456")
            {
                Session["AdminID"] = LoginID;
                return RedirectToAction("Dashboard", "Administrator");
            }
            else
            {
                Response.Write("<script>alert('Wrong ID and Password');</script>");
            }
            return View();
        }
        #endregion


        #region Top Banner
        public ActionResult Banner()
        {
            string msg;
            msg = Session["Msg"] == null ? "" : Session["Msg"].ToString();
            if (msg != "")
            {
                Response.Write("<script>alert('" + msg + "');</script>");
            }
            Session["Msg"] = "";

            Banner topbanner = new Banner();
            topbanner.TopBanners_List = new List<Banner>();
            topbanner.TopBanners_List = HomeService.GetTopBannersList();

            return View(topbanner.TopBanners_List);
        }


        [HttpGet]
        public ActionResult AddTopBanner()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddTopBanner(Banner topbanner, HttpPostedFileBase file)
        {
            if (file.ContentLength > 0)
            {
                string fileName = System.IO.Path.GetFileName(file.FileName);

                string filepath = Path.Combine(Server.MapPath("~/Content/Upload/Banner/"), fileName);
                //string filepath = Path.Combine("http://4dhit.com/Content/upload/Banner/", fileName);

                string UploadedPath = "../Content/Upload/Banner/" + fileName;
                int SequenceArrange = topbanner.SequenceArrange;
                string Description = topbanner.Description;
                string UrlPath = topbanner.UrlPath;
                if (SequenceArrange <= 0)
                {
                    Response.Write("<script>alert('Sequence Arrange Cannot Less Than 0');</script>");
                }
                else
                {
                    HomeService.AddTopBanner(UploadedPath, Description, UrlPath, SequenceArrange);
                    file.SaveAs(filepath);
                    Session["Msg"] = "Add Banner Successful";
                    return RedirectToAction("Banner", "Administrator");
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult EditTopBanner(int? Srno)
        {
            int intSrno = 0;
            intSrno = Srno.HasValue ? Convert.ToInt32(Srno) : 0;
            if (Srno <= 0)
            {
                return RedirectToAction("Banner", "Administrator");
            }

            Banner topBanner = new Banner();
            topBanner = HomeService.GetTopBanner_BySrno(intSrno);

            if (topBanner.Status == "ACTIVE")
            {
                ViewBag.StatusActive = true;
                ViewBag.StatusInActive = false;
            }
            else
            {
                ViewBag.StatusActive = false;
                ViewBag.StatusInActive = true;
            }

            ViewBag.uploadPath = topBanner.UploadedPath;
            return View(topBanner);
        }



        [HttpPost]
        public ActionResult EditTopBanner(Banner topbanner, HttpPostedFileBase file)
        {
            if (file == null)
            {
                string UploadedPath = topbanner.UploadedPath;
                int SequenceArrange = topbanner.SequenceArrange;
                long Srno = topbanner.Srno;
                string Description = topbanner.Description;
                string UrlPath = topbanner.UrlPath;
                string Status = topbanner.Status;

                if (SequenceArrange <= 0)
                {
                    Response.Write("<script>alert('Sequence Arrange Cannot Less Than 0');</script>");
                }
                else
                {
                    HomeService.EditTopBanner(Srno, UploadedPath, Description, UrlPath, SequenceArrange, Status);
                    Session["Msg"] = "Edit Banner Successful";
                    return RedirectToAction("Banner", "Administrator");
                }
            }
            else if (file.ContentLength > 0)
            {
                string fileName = Path.GetFileName(file.FileName);
                string filepath = Path.Combine(Server.MapPath("~/Content/Upload/Banner/"), fileName);
                //string filepath = Path.Combine("http://4dhit.com/Content/upload/Banner/", fileName);

                string UploadedPath = "../Content/Upload/Banner/" + fileName;
                int SequenceArrange = topbanner.SequenceArrange;
                long Srno = topbanner.Srno;
                string Description = topbanner.Description;
                string UrlPath = topbanner.UrlPath;
                string Status = topbanner.Status;

                if (SequenceArrange <= 0)
                {
                    Response.Write("<script>alert('Sequence Arrange Cannot Less Than 0');</script>");
                }
                else
                {
                    HomeService.EditTopBanner(Srno, UploadedPath, Description, UrlPath, SequenceArrange, Status);
                    file.SaveAs(filepath);
                    Session["Msg"] = "Edit Banner Successful";
                    return RedirectToAction("Banner", "Administrator");
                }
            }
            else
            {
                string UploadedPath = topbanner.UploadedPath;
                int SequenceArrange = topbanner.SequenceArrange;
                long Srno = topbanner.Srno;
                string Description = topbanner.Description;
                string UrlPath = topbanner.UrlPath;
                string Status = topbanner.Status;

                if (SequenceArrange <= 0)
                {
                    Response.Write("<script>alert('Sequence Arrange Cannot Less Than 0');</script>");
                }
                else
                {
                    HomeService.EditTopBanner(Srno, UploadedPath, Description, UrlPath, SequenceArrange, Status);
                    Session["Msg"] = "Edit Banner Successful";
                    return RedirectToAction("Banner", "Administrator");
                }
            }
            return View();


        }
        #endregion



        public ActionResult Dashboard()
        {
            return View();
        }




        [HttpGet]
        public ActionResult AddResult( )
        { 
            return View();
        }

        [HttpPost]
        public ActionResult AddResult(Results result)
        {
            string ResultDate = result.ResultDate + "";
            string ResultType = result.ResultType + ""; 
            Results result_data = new Results();
            if (ResultDate == "")
            {
                Response.Write("<script>alert('Please select Result Date');</script>");
            }
            else if (ResultType == "")
            {
                Response.Write("<script>alert('Please select Result Type');</script>");
            }
            else
            { 
                result_data = HomeService.GetResult_ByDateAndType(ResultDate, ResultType);
                if (result_data == null)
                    ViewBag.Valid = "False";
                else
                    ViewBag.Valid = "True"; 
            }
            return View(result_data);
        }

        [HttpPost]
        public ActionResult AddResultRecord(Results result)
        {
            string ResultDate = result.ResultDate + "";
            string ResultType = result.ResultType + "";
            Results result_data = new Results();
            if (ResultDate == "")
            {
                Response.Write("<script>alert('Please select Result Date');</script>");
            }
            else if (ResultType == "")
            {
                Response.Write("<script>alert('Please select Result Type');</script>");
            }
            else
            {
                result_data = HomeService.GetResult_ByDateAndType(ResultDate, ResultType);
                if (result_data == null)
                {
                    HomeService.AddResultRecord(result);
                    Session["Msg"] = "Insert Result Successful";
                }
                else
                {
                    HomeService.UpdateResultRecord(result);
                    Session["Msg"] = "Update Result Successful";
                }

            }
            return RedirectToAction("AddResult", "Administrator");


        }



        [HttpGet]
        public ActionResult AddResult_3D()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddResult_3D(Results result)
        {
            string ResultDate = result.ResultDate + "";
            string ResultType = result.ResultType + "";
            Results result_data = new Results();
            if (ResultDate == "")
            {
                Response.Write("<script>alert('Please select Result Date');</script>");
            }
            else if (ResultType == "")
            {
                Response.Write("<script>alert('Please select Result Type');</script>");
            }
            else
            {
                result_data = HomeService.GetResult_ByDateAndType(ResultDate, ResultType);
                if (result_data == null)
                    ViewBag.Valid = "False";
                else
                    ViewBag.Valid = "True";
            }
            return View(result_data);
        }

        [HttpPost]
        public ActionResult AddResultRecord_3D(Results result)
        {
            string ResultDate = result.ResultDate + "";
            string ResultType = result.ResultType + "";
            Results result_data = new Results();
            if (ResultDate == "")
            {
                Response.Write("<script>alert('Please select Result Date');</script>");
            }
            else if (ResultType == "")
            {
                Response.Write("<script>alert('Please select Result Type');</script>");
            }
            else
            {
                result_data = HomeService.GetResult_ByDateAndType(ResultDate, ResultType);
                if (result_data == null)
                {
                    HomeService.AddResultRecord_3D(result);
                    Session["Msg"] = "Insert Result Successful";
                }
                else
                {
                    HomeService.UpdateResultRecord_3D(result);
                    Session["Msg"] = "Update Result Successful";
                }

            }
            return RedirectToAction("AddResult_3D", "Administrator");


        }



        [HttpGet]
        public ActionResult AddResult_5D()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddResult_5D(Result_5D result)
        {
            string ResultDate = result.ResultDate + "";
            string ResultType = result.ResultType + "";
            Result_5D result_data = new Result_5D();
            if (ResultDate == "")
            {
                Response.Write("<script>alert('Please select Result Date');</script>");
            }
            else if (ResultType == "")
            {
                Response.Write("<script>alert('Please select Result Type');</script>");
            }
            else
            {
                result_data = HomeService.GetResult_5D_ByDateAndType(ResultDate, ResultType);
                if (result_data == null)
                    ViewBag.Valid = "False";
                else
                    ViewBag.Valid = "True";
            }
            return View(result_data);
        }

        [HttpPost]
        public ActionResult AddResultRecord_5D(Result_5D result)
        {
            string ResultDate = result.ResultDate + "";
            string ResultType = result.ResultType + "";
            Result_5D result_data = new Result_5D();
            if (ResultDate == "")
            {
                Response.Write("<script>alert('Please select Result Date');</script>");
            }
            else if (ResultType == "")
            {
                Response.Write("<script>alert('Please select Result Type');</script>");
            }
            else
            {
                result_data = HomeService.GetResult_5D_ByDateAndType(ResultDate, ResultType);
                if (result_data == null)
                {
                    HomeService.AddResultRecord_5D(result);
                    Session["Msg"] = "Insert Result Successful";
                }
                else
                {
                    HomeService.UpdateResultRecord_5D(result);
                    Session["Msg"] = "Update Result Successful";
                }

            }
            return RedirectToAction("AddResult_5D", "Administrator");


        }





        [HttpGet]
        public ActionResult AddResult_6D()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddResult_6D(Result_6D result)
        {
            string ResultDate = result.ResultDate + "";
            string ResultType = result.ResultType + "";
            Result_6D result_data = new Result_6D();
            if (ResultDate == "")
            {
                Response.Write("<script>alert('Please select Result Date');</script>");
            }
            else if (ResultType == "")
            {
                Response.Write("<script>alert('Please select Result Type');</script>");
            }
            else
            {
                result_data = HomeService.GetResult_6D_ByDateAndType(ResultDate, ResultType);
                if (result_data == null)
                    ViewBag.Valid = "False";
                else
                    ViewBag.Valid = "True";
            }
            return View(result_data);
        }

        [HttpPost]
        public ActionResult AddResultRecord_6D(Result_6D result)
        {
            string ResultDate = result.ResultDate + "";
            string ResultType = result.ResultType + "";
            Result_6D result_data = new Result_6D();
            if (ResultDate == "")
            {
                Response.Write("<script>alert('Please select Result Date');</script>");
            }
            else if (ResultType == "")
            {
                Response.Write("<script>alert('Please select Result Type');</script>");
            }
            else
            {
                result_data = HomeService.GetResult_6D_ByDateAndType(ResultDate, ResultType);
                if (result_data == null)
                {
                    HomeService.AddResultRecord_6D(result);
                    Session["Msg"] = "Insert Result Successful";
                }
                else
                {
                    HomeService.UpdateResultRecord_6D(result);
                    Session["Msg"] = "Update Result Successful";
                }

            }
            return RedirectToAction("AddResult_6D", "Administrator");


        }



        [HttpGet]
        public ActionResult AddResult_Damacai()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddResult_Damacai(Result_Damacai result)
        {
            string ResultDate = result.ResultDate + "";
            string ResultType = result.ResultType + "";
            Result_Damacai result_data = new Result_Damacai();
            if (ResultDate == "")
            {
                Response.Write("<script>alert('Please select Result Date');</script>");
            } 
            else
            {
                result_data = HomeService.GetResultDamacai_ByDateAndType(ResultDate);
                if (result_data == null)
                    ViewBag.Valid = "False";
                else
                    ViewBag.Valid = "True";
            }
            return View(result_data);
        }

        [HttpPost]
        public ActionResult AddResultDamacaiRecord(Result_Damacai result)
        {
            string ResultDate = result.ResultDate + "";
            string ResultType = result.ResultType + "";
            Result_Damacai result_data = new Result_Damacai();
            if (ResultDate == "")
            {
                Response.Write("<script>alert('Please select Result Date');</script>");
            } 
            else
            {
                result_data = HomeService.GetResultDamacai_ByDateAndType(ResultDate);
                if (result_data == null)
                {
                    HomeService.AddResultDamacaiRecord(result);
                    Session["Msg"] = "Insert Result Successful";
                }
                else
                {
                    HomeService.UpdateResultDamacaiRecord(result);
                    Session["Msg"] = "Update Result Successful";
                }

            }
            return RedirectToAction("AddResult", "Administrator");


        }




    }
}