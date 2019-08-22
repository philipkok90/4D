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
         


        [HttpPost]
        public ActionResult Index(Results results)
        {
            string LatestDate = results.ResultDate;
            List<Results> db_result = new List<Results>();
            Results db_result_record = new Results();
            ViewBag.Magnum = db_result_record;
            ViewBag.Damacai = db_result_record;
            ViewBag.Toto = db_result_record;
            ViewBag.Singapore = db_result_record;
            ViewBag.CashSweep = db_result_record;
            ViewBag.Sabah = db_result_record;
            ViewBag.Sandakan = db_result_record;

            if (LatestDate == "")
            {
                Response.Write("<script>alert('Please Select Result Date');</script>");
                LatestDate = HomeService.GetLatestResultDate();
            }
            else
            {
                db_result = HomeService.GetResultListing_ByDate(LatestDate);
                if(db_result == null)
                {
                    Response.Write("<script>alert('Invalid Result Date');</script>");
                    LatestDate = HomeService.GetLatestResultDate();
                    db_result = HomeService.GetResultListing_ByDate(LatestDate);
                }
                if (db_result.Where(r => r.ResultType.Equals("MAGNUM")).SingleOrDefault() != null)
                {
                    ViewBag.Magnum = db_result.Where(r => r.ResultType.Equals("MAGNUM")).SingleOrDefault();
                }

                if (db_result.Where(r => r.ResultType.Equals("DAMACAI")).SingleOrDefault() != null)
                {
                    ViewBag.Damacai = db_result.Where(r => r.ResultType.Equals("DAMACAI")).SingleOrDefault();
                }

                if (db_result.Where(r => r.ResultType.Equals("TOTO")).SingleOrDefault() != null)
                {
                    ViewBag.Toto = db_result.Where(r => r.ResultType.Equals("TOTO")).SingleOrDefault();
                }

                if (db_result.Where(r => r.ResultType.Equals("SINGAPORE 4D")).SingleOrDefault() != null)
                {
                    ViewBag.Singapore = db_result.Where(r => r.ResultType.Equals("SINGAPORE 4D")).SingleOrDefault();
                }

                if (db_result.Where(r => r.ResultType.Equals("CASH SWEEP")).SingleOrDefault() != null)
                {
                    ViewBag.CashSweep = db_result.Where(r => r.ResultType.Equals("CASH SWEEP")).SingleOrDefault();
                }

                if (db_result.Where(r => r.ResultType.Equals("SABAH LOTTO 88")).SingleOrDefault() != null)
                {
                    ViewBag.Sabah = db_result.Where(r => r.ResultType.Equals("SABAH LOTTO 88")).SingleOrDefault();
                }

                if (db_result.Where(r => r.ResultType.Equals("SANDAKAN")).SingleOrDefault() != null)
                {
                    ViewBag.Sandakan = db_result.Where(r => r.ResultType.Equals("SANDAKAN")).SingleOrDefault();
                }
            }

            ViewBag.LatestDate = LatestDate.Replace("-", "");


            Banner banner = new Banner();
            banner = HomeService.GetRandomBanner();
            ViewBag.banner = banner;
            return View();
        }

        [HttpGet]
        public ActionResult Index()
        {  
            string LatestDate = HomeService.GetLatestResultDate(); 
            List< Results> result = new List<Results>(); 
            result = HomeService.GetResultListing_ByDate(LatestDate);
            ViewBag.LatestDate = LatestDate;

            Results db_result = new Results();
            ViewBag.Magnum = db_result;
            ViewBag.Damacai = db_result;
            ViewBag.Toto = db_result;
            ViewBag.Singapore = db_result;
            ViewBag.CashSweep = db_result;
            ViewBag.Sabah = db_result;
            ViewBag.Sandakan = db_result;

            if (result.Where(r => r.ResultType.Equals("MAGNUM")).SingleOrDefault() != null)
            {
                ViewBag.Magnum = result.Where(r => r.ResultType.Equals("MAGNUM")).SingleOrDefault();
            }

            if (result.Where(r => r.ResultType.Equals("DAMACAI")).SingleOrDefault() != null)
            {
                ViewBag.Damacai = result.Where(r => r.ResultType.Equals("DAMACAI")).SingleOrDefault();
            }

            if (result.Where(r => r.ResultType.Equals("TOTO")).SingleOrDefault() != null)
            {
                ViewBag.Toto = result.Where(r => r.ResultType.Equals("TOTO")).SingleOrDefault();
            }

            if (result.Where(r => r.ResultType.Equals("SINGAPORE 4D")).SingleOrDefault() != null)
            {
                ViewBag.Singapore = result.Where(r => r.ResultType.Equals("SINGAPORE 4D")).SingleOrDefault();
            }

            if (result.Where(r => r.ResultType.Equals("CASH SWEEP")).SingleOrDefault() != null)
            {
                ViewBag.CashSweep = result.Where(r => r.ResultType.Equals("CASH SWEEP")).SingleOrDefault();
            }

            if (result.Where(r => r.ResultType.Equals("SABAH LOTTO 88")).SingleOrDefault() != null)
            {
                ViewBag.Sabah = result.Where(r => r.ResultType.Equals("SABAH LOTTO 88")).SingleOrDefault();
            }

            if (result.Where(r => r.ResultType.Equals("SANDAKAN")).SingleOrDefault() != null)
            {
                ViewBag.Sandakan = result.Where(r => r.ResultType.Equals("SANDAKAN")).SingleOrDefault();
            }


            Banner banner = new Banner();
            banner = HomeService.GetRandomBanner();
            ViewBag.banner = banner;
            return View();
        }


        [HttpGet]
        public ActionResult Index_3D()
        {
            string LatestDate = HomeService.GetLatestResultDate();
            List<Results> result = new List<Results>();
            result = HomeService.GetResultListing_ByDate(LatestDate);
            ViewBag.LatestDate = LatestDate;

            Results db_result = new Results(); 
            ViewBag.Damacai = db_result; 
            ViewBag.CashSweep = db_result;
            ViewBag.Sabah = db_result; 
             

            if (result.Where(r => r.ResultType.Equals("DAMACAI")).SingleOrDefault() != null)
            {
                ViewBag.Damacai = result.Where(r => r.ResultType.Equals("DAMACAI")).SingleOrDefault();
            } 
            if (result.Where(r => r.ResultType.Equals("CASH SWEEP")).SingleOrDefault() != null)
            {
                ViewBag.CashSweep = result.Where(r => r.ResultType.Equals("CASH SWEEP")).SingleOrDefault();
            }

            if (result.Where(r => r.ResultType.Equals("SABAH LOTTO 88")).SingleOrDefault() != null)
            {
                ViewBag.Sabah = result.Where(r => r.ResultType.Equals("SABAH LOTTO 88")).SingleOrDefault();
            }
             
            return View();
        }

        [HttpPost]
        public ActionResult Index_3D(Results results)
        {
            string LatestDate = results.ResultDate;
            List<Results> db_result = new List<Results>();
            Results db_result_record = new Results();
            ViewBag.Magnum = db_result_record;
            ViewBag.Damacai = db_result_record;
            ViewBag.Toto = db_result_record;
            ViewBag.Singapore = db_result_record;
            ViewBag.CashSweep = db_result_record;
            ViewBag.Sabah = db_result_record;
            ViewBag.Sandakan = db_result_record;

            if (LatestDate == "")
            {
                Response.Write("<script>alert('Please Select Result Date');</script>");
                LatestDate = HomeService.GetLatestResultDate();
            }
            else
            {
                db_result = HomeService.GetResultListing_ByDate(LatestDate);
                if (db_result == null)
                {
                    Response.Write("<script>alert('Invalid Result Date');</script>");
                    LatestDate = HomeService.GetLatestResultDate();
                    db_result = HomeService.GetResultListing_ByDate(LatestDate);
                } 

                if (db_result.Where(r => r.ResultType.Equals("DAMACAI")).SingleOrDefault() != null)
                {
                    ViewBag.Damacai = db_result.Where(r => r.ResultType.Equals("DAMACAI")).SingleOrDefault();
                } 

                if (db_result.Where(r => r.ResultType.Equals("CASH SWEEP")).SingleOrDefault() != null)
                {
                    ViewBag.CashSweep = db_result.Where(r => r.ResultType.Equals("CASH SWEEP")).SingleOrDefault();
                }

                if (db_result.Where(r => r.ResultType.Equals("SABAH LOTTO 88")).SingleOrDefault() != null)
                {
                    ViewBag.Sabah = db_result.Where(r => r.ResultType.Equals("SABAH LOTTO 88")).SingleOrDefault();
                } 
            }

            ViewBag.LatestDate = LatestDate.Replace("-", "");
            return View();
        }





        [HttpGet]
        public ActionResult Index_5D()
        {
            string LatestDate = HomeService.GetLatestResultDate_5D();
            List<Result_5D> result = new List<Result_5D>();
            result = HomeService.GetResult_5DListing_ByDate(LatestDate);
            ViewBag.LatestDate = LatestDate;

            Result_5D db_result = new Result_5D();
            ViewBag.Toto = db_result; 


            if (result.Where(r => r.ResultType.Equals("TOTO")).SingleOrDefault() != null)
            {
                ViewBag.Toto = result.Where(r => r.ResultType.Equals("TOTO")).SingleOrDefault();
            } 

            return View();
        }

        [HttpPost]
        public ActionResult Index_5D(Result_5D results)
        {
            string LatestDate = results.ResultDate;
            List<Result_5D> db_result = new List<Result_5D>();
            Result_5D db_result_record = new Result_5D();
            ViewBag.Toto = db_result_record; 

            if (LatestDate == "")
            {
                Response.Write("<script>alert('Please Select Result Date');</script>");
                LatestDate = HomeService.GetLatestResultDate_5D();
            }
            else
            {
                db_result = HomeService.GetResult_5DListing_ByDate(LatestDate);
                if (db_result == null)
                {
                    Response.Write("<script>alert('Invalid Result Date');</script>");
                    LatestDate = HomeService.GetLatestResultDate_5D();
                    db_result = HomeService.GetResult_5DListing_ByDate(LatestDate);
                }

                if (db_result.Where(r => r.ResultType.Equals("TOTO")).SingleOrDefault() != null)
                {
                    ViewBag.Toto = db_result.Where(r => r.ResultType.Equals("TOTO")).SingleOrDefault();
                }
                 
            }

            ViewBag.LatestDate = LatestDate.Replace("-", "");
            return View();
        }





        [HttpGet]
        public ActionResult Index_6D()
        {
            string LatestDate = HomeService.GetLatestResultDate_6D();
            List<Result_6D> result = new List<Result_6D>();
            result = HomeService.GetResult_6DListing_ByDate(LatestDate);
            ViewBag.LatestDate = LatestDate;

            Result_6D db_result = new Result_6D();
            ViewBag.SupremeToto = db_result;
            ViewBag.PowerToto = db_result;
            ViewBag.StarToto = db_result;
            ViewBag.Toto6D = db_result;
            ViewBag.SingaporeToto = db_result;
            ViewBag.SabahLotto = db_result;


            if (result.Where(r => r.ResultType.Equals("SUPREME TOTO")).SingleOrDefault() != null)
            {
                ViewBag.SupremeToto = result.Where(r => r.ResultType.Equals("SUPREME TOTO")).SingleOrDefault();
            }
            if (result.Where(r => r.ResultType.Equals("POWER TOTO")).SingleOrDefault() != null)
            {
                ViewBag.PowerToto = result.Where(r => r.ResultType.Equals("POWER TOTO")).SingleOrDefault();
            }
            if (result.Where(r => r.ResultType.Equals("STAR TOTO")).SingleOrDefault() != null)
            {
                ViewBag.StarToto = result.Where(r => r.ResultType.Equals("STAR TOTO")).SingleOrDefault();
            }
            if (result.Where(r => r.ResultType.Equals("TOTO 6D")).SingleOrDefault() != null)
            {
                ViewBag.Toto6D = result.Where(r => r.ResultType.Equals("TOTO 6D")).SingleOrDefault();
            }
            if (result.Where(r => r.ResultType.Equals("SINGAPORE TOTO")).SingleOrDefault() != null)
            {
                ViewBag.SingaporeToto = result.Where(r => r.ResultType.Equals("SINGAPORE TOTO")).SingleOrDefault();
            }
            if (result.Where(r => r.ResultType.Equals("SABAH LOTTO")).SingleOrDefault() != null)
            {
                ViewBag.SabahLotto = result.Where(r => r.ResultType.Equals("SABAH LOTTO")).SingleOrDefault();
            }

            return View();
        }

        [HttpPost]
        public ActionResult Index_6D(Result_6D results)
        {
            string LatestDate = results.ResultDate;
            List<Result_6D> db_result = new List<Result_6D>();
            Result_6D db_result_record = new Result_6D(); 
            ViewBag.SupremeToto = db_result_record;
            ViewBag.PowerToto = db_result_record;
            ViewBag.StarToto = db_result_record;
            ViewBag.Toto6D = db_result_record;
            ViewBag.SingaporeToto = db_result_record;
            ViewBag.SabahLotto = db_result_record;

            if (LatestDate == "")
            {
                Response.Write("<script>alert('Please Select Result Date');</script>");
                LatestDate = HomeService.GetLatestResultDate_6D();
            }
            else
            {
                db_result = HomeService.GetResult_6DListing_ByDate(LatestDate);
                if (db_result == null)
                {
                    Response.Write("<script>alert('Invalid Result Date');</script>");
                    LatestDate = HomeService.GetLatestResultDate_6D();
                    db_result = HomeService.GetResult_6DListing_ByDate(LatestDate);
                }

                if (db_result.Where(r => r.ResultType.Equals("SUPREME TOTO")).SingleOrDefault() != null)
                {
                    ViewBag.SupremeToto = db_result.Where(r => r.ResultType.Equals("SUPREME TOTO")).SingleOrDefault();
                }
                if (db_result.Where(r => r.ResultType.Equals("POWER TOTO")).SingleOrDefault() != null)
                {
                    ViewBag.PowerToto = db_result.Where(r => r.ResultType.Equals("POWER TOTO")).SingleOrDefault();
                }
                if (db_result.Where(r => r.ResultType.Equals("STAR TOTO")).SingleOrDefault() != null)
                {
                    ViewBag.StarToto = db_result.Where(r => r.ResultType.Equals("STAR TOTO")).SingleOrDefault();
                }
                if (db_result.Where(r => r.ResultType.Equals("TOTO 6D")).SingleOrDefault() != null)
                {
                    ViewBag.Toto6D = db_result.Where(r => r.ResultType.Equals("TOTO 6D")).SingleOrDefault();
                }
                if (db_result.Where(r => r.ResultType.Equals("SINGAPORE TOTO")).SingleOrDefault() != null)
                {
                    ViewBag.SingaporeToto = db_result.Where(r => r.ResultType.Equals("SINGAPORE TOTO")).SingleOrDefault();
                }
                if (db_result.Where(r => r.ResultType.Equals("SABAH LOTTO")).SingleOrDefault() != null)
                {
                    ViewBag.SabahLotto = db_result.Where(r => r.ResultType.Equals("SABAH LOTTO")).SingleOrDefault();
                }

            }

            ViewBag.LatestDate = LatestDate.Replace("-", "");
            return View();
        }





        [HttpGet]
        public ActionResult Index_Result()
        {
            string LatestDate = HomeService.GetLatestResultDate_6D();
            List<Result_6D> result = new List<Result_6D>();
            result = HomeService.GetResult_6DListing_ByDate(LatestDate);
            ViewBag.LatestDate = LatestDate;

            Result_6D db_result = new Result_6D();
            ViewBag.SupremeToto = db_result;
            ViewBag.PowerToto = db_result;
            ViewBag.StarToto = db_result;
            ViewBag.Toto6D = db_result;
            ViewBag.SingaporeToto = db_result;
            ViewBag.SabahLotto = db_result;

            List<Results> result_3D = new List<Results>();
            result_3D = HomeService.GetResultListing_ByDate(LatestDate);
            Results db_3D_result = new Results();
            ViewBag.Damacai = db_3D_result;
            ViewBag.CashSweep = db_3D_result;
            ViewBag.Sabah = db_3D_result;

            List<Result_5D> result_5D = new List<Result_5D>();
            result_5D = HomeService.GetResult_5DListing_ByDate(LatestDate);
            ViewBag.LatestDate = LatestDate;
            Result_5D db_result_5D = new Result_5D();
            ViewBag.Toto = db_result_5D;
            ViewBag.Toto_5D = db_result_5D;

            if (result.Where(r => r.ResultType.Equals("TOTO")).SingleOrDefault() != null)
            {
                ViewBag.Toto = result.Where(r => r.ResultType.Equals("TOTO")).SingleOrDefault();
            }



            if (result.Where(r => r.ResultType.Equals("SUPREME TOTO")).SingleOrDefault() != null)
            {
                ViewBag.SupremeToto = result.Where(r => r.ResultType.Equals("SUPREME TOTO")).SingleOrDefault();
            }
            if (result.Where(r => r.ResultType.Equals("POWER TOTO")).SingleOrDefault() != null)
            {
                ViewBag.PowerToto = result.Where(r => r.ResultType.Equals("POWER TOTO")).SingleOrDefault();
            }
            if (result.Where(r => r.ResultType.Equals("STAR TOTO")).SingleOrDefault() != null)
            {
                ViewBag.StarToto = result.Where(r => r.ResultType.Equals("STAR TOTO")).SingleOrDefault();
            }
            if (result.Where(r => r.ResultType.Equals("TOTO 6D")).SingleOrDefault() != null)
            {
                ViewBag.Toto6D = result.Where(r => r.ResultType.Equals("TOTO 6D")).SingleOrDefault();
            }
            if (result.Where(r => r.ResultType.Equals("SINGAPORE TOTO")).SingleOrDefault() != null)
            {
                ViewBag.SingaporeToto = result.Where(r => r.ResultType.Equals("SINGAPORE TOTO")).SingleOrDefault();
            }
            if (result.Where(r => r.ResultType.Equals("SABAH LOTTO")).SingleOrDefault() != null)
            {
                ViewBag.SabahLotto = result.Where(r => r.ResultType.Equals("SABAH LOTTO")).SingleOrDefault();
            }

            if (result_3D.Where(r => r.ResultType.Equals("DAMACAI")).SingleOrDefault() != null)
            {
                ViewBag.Damacai = result_3D.Where(r => r.ResultType.Equals("DAMACAI")).SingleOrDefault();
            }
            if (result_3D.Where(r => r.ResultType.Equals("CASH SWEEP")).SingleOrDefault() != null)
            {
                ViewBag.CashSweep = result_3D.Where(r => r.ResultType.Equals("CASH SWEEP")).SingleOrDefault();
            }

            if (result_3D.Where(r => r.ResultType.Equals("SABAH LOTTO 88")).SingleOrDefault() != null)
            {
                ViewBag.Sabah = result_3D.Where(r => r.ResultType.Equals("SABAH LOTTO 88")).SingleOrDefault();
            }

            if (result_5D.Where(r => r.ResultType.Equals("TOTO")).SingleOrDefault() != null)
            {
                ViewBag.Toto_5D = result_5D.Where(r => r.ResultType.Equals("TOTO")).SingleOrDefault();
            }




            string LatestDateDamacai = HomeService.GetLatestResultDamacaiDate_6D();
            List<Result_Damacai> result_damacai = new List<Result_Damacai>();
            result_damacai = HomeService.GetResultDamacai_6DListing_ByDate(LatestDateDamacai);
            ViewBag.LatestDateDamacai = LatestDateDamacai;
            ViewBag.result_damacai = result_damacai.SingleOrDefault();


            Banner banner = new Banner();
            banner = HomeService.GetRandomBanner();
            ViewBag.banner = banner;
            return View();
        }



        public static string convert_YYYY_MM_DD(string value)
        {
            string rtnValue;
            rtnValue = "";
            if(value != "")
            {
                rtnValue = value.Substring(0,4) + "-" + value.Substring(4,2) + "-" + value.Substring(6,2);
            }

            return rtnValue;
        }
         
    }
}