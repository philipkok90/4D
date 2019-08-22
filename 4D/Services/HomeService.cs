using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _4D.DAL;
using _4D.Models;
using System.Data.SqlClient;

namespace _4D.Services
{
    public class HomeService
    {




        #region Top Banner



        public static Banner GetRandomBanner()
        {
            using (var dbContext = new Context1())
            {
                string sql = "";
                sql = sql + " Select Top 1 * ";
                sql = sql + " From Mst_4D_TopBanner With (Nolock)  ";
                sql = sql + " Where Status = 'ACTIVE' Order By NEWID() "; 
                var result = dbContext.Database.SqlQuery<Banner>(sql).FirstOrDefault();
                return result;
            }
        }


        public static List<Banner> GetTopBannersList()
        {
            using (var dbContext = new Context1())
            {
                string sql = "";
                sql = sql + " Select * ";
                sql = sql + " From Mst_4D_TopBanner With (Nolock)  ";
                var result = dbContext.Database.SqlQuery<Banner>(sql).ToList();
                return result;
            }
        }

        public static Banner GetTopBanner_BySrno(int Srno)
        {
            using (var dbContext = new Context1())
            {
                string sql = "";
                sql = sql + " Select * ";
                sql = sql + " From Mst_4D_TopBanner With (Nolock)  ";
                sql = sql + " Where Srno = @Srno  ";
                SqlParameter[] param = new SqlParameter[]
                 {
                    new SqlParameter("@Srno", Srno)
                 };
                var result = dbContext.Database.SqlQuery<Banner>(sql, param).FirstOrDefault();
                return result;
            }
        }

        public static void AddTopBanner(string UploadedPath, string Description, string UrlPath, int SequenceArrange)
        {
            using (var dbContext = new Context1())
            {
                string sql;
                sql = "";
                sql = sql + " Insert Into Mst_4D_TopBanner (UploadedPath, Description, UrlPath, SequenceArrange) Values (@UploadedPath, @Description, @UrlPath, @SequenceArrange)";
                SqlParameter[] param = new SqlParameter[]
                {
                    new SqlParameter("@UploadedPath", UploadedPath),
                    new SqlParameter("@Description", Description),
                    new SqlParameter("@UrlPath", UrlPath),
                    new SqlParameter("@SequenceArrange", SequenceArrange)
                };

                dbContext.Database.ExecuteSqlCommand(sql, param);
            }
        }


        public static void EditTopBanner(long Srno, string UploadedPath, string Description, string UrlPath, int SequenceArrange, string Status)
        {
            using (var dbContext = new Context1())
            {
                string sql;
                sql = "";
                sql = sql + " Update Mst_4D_TopBanner ";
                sql = sql + " Set UploadedPath = @UploadedPath ";
                sql = sql + " ,Description = @Description ";
                sql = sql + " ,Status = @Status ";
                sql = sql + " ,SequenceArrange = @SequenceArrange ";
                sql = sql + " ,UrlPath = @UrlPath ";
                sql = sql + " Where Srno = @Srno ";
                SqlParameter[] param = new SqlParameter[]
                {
                    new SqlParameter("@UploadedPath", UploadedPath),
                    new SqlParameter("@Description", Description),
                    new SqlParameter("@Status", Status),
                    new SqlParameter("@SequenceArrange", SequenceArrange),
                    new SqlParameter("@UrlPath", UrlPath),
                    new SqlParameter("@Srno", Srno)
                };

                dbContext.Database.ExecuteSqlCommand(sql, param);
            }
        }

        #endregion












        public static string GetLatestResultDate()
        {
            using (var dbContext = new Context1())
            {
                string sql = "";
                sql = sql + " Select Top 1 * ";
                sql = sql + " From Mst_Result Order By ResultDate Desc ";  
                var result = dbContext.Database.SqlQuery<Results>(sql).SingleOrDefault();
                return result.ResultDate;
            }
        }


        public static string GetLatestResultDate_5D()
        {
            using (var dbContext = new Context1())
            {
                string sql = "";
                sql = sql + " Select Top 1 * ";
                sql = sql + " From Mst_Result_5D Order By ResultDate Desc ";
                var result = dbContext.Database.SqlQuery<Results>(sql).SingleOrDefault();
                return result.ResultDate;
            }
        }


        public static string GetLatestResultDate_6D()
        {
            using (var dbContext = new Context1())
            {
                string sql = "";
                sql = sql + " Select Top 1 * ";
                sql = sql + " From Mst_Result_6D Order By ResultDate Desc ";
                var result = dbContext.Database.SqlQuery<Results>(sql).SingleOrDefault();
                return result.ResultDate;
            }
        }


        public static string GetLatestResultDamacaiDate_6D()
        {
            using (var dbContext = new Context1())
            {
                string sql = "";
                sql = sql + " Select Top 1 * ";
                sql = sql + " From Mst_Result_Damacai_6D Order By ResultDate Desc ";
                var result = dbContext.Database.SqlQuery<Results>(sql).SingleOrDefault();
                return result.ResultDate;
            }
        }

        public static List<Results> GetResultListing_ByDate(string ResultDate)
        {
            using (var dbContext = new Context1())
            {
                string sql = "";
                sql = sql + " Select * ";
                sql = sql + " From Mst_Result ";
                sql = sql + " Where ResultDate = @ResultDate ";
                SqlParameter[] param = new SqlParameter[]
                 {
                    new SqlParameter("@ResultDate", ResultDate.Replace("-", "")) 
                 };
                var result = dbContext.Database.SqlQuery<Results>(sql, param).ToList();
                return result;
            }
        }

        public static Results GetResult_ByDateAndType(string ResultDate, string ResultType)
        {
            using (var dbContext = new Context1())
            {
                string sql = "";
                sql = sql + " Select * ";
                sql = sql + " From Mst_Result ";
                sql = sql + " Where ResultDate = @ResultDate ";
                sql = sql + " And ResultType = @ResultType ";
                SqlParameter[] param = new SqlParameter[]
                 {
                    new SqlParameter("@ResultDate", ResultDate.Replace("-", "")),
                    new SqlParameter("@ResultType", ResultType)
                 };
                var result = dbContext.Database.SqlQuery<Results>(sql, param).SingleOrDefault();
                return result;
            }
        }



        public static Result_Damacai GetResultDamacai_ByDateAndType(string ResultDate)
        {
            using (var dbContext = new Context1())
            {
                string sql = "";
                sql = sql + " Select * ";
                sql = sql + " From Mst_Result_Damacai_6D ";
                sql = sql + " Where ResultDate = @ResultDate "; 
                SqlParameter[] param = new SqlParameter[]
                 {
                    new SqlParameter("@ResultDate", ResultDate.Replace("-", "")) 
                 };
                var result = dbContext.Database.SqlQuery<Result_Damacai>(sql, param).SingleOrDefault();
                return result;
            }
        }


        public static void AddResultRecord(Results result)
        {
            using (var dbContext = new Context1())
            {
                string sql = "";
                sql = sql + " Insert Into Mst_Result ";
                sql = sql + " (ResultDate, ResultType, F1, F2, F3, S1, S2, S3, S4, S5, S6, S7, S8, S9, S10, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10) ";
                sql = sql + " Values ";
                sql = sql + " (@ResultDate, @ResultType, @F1, @F2, @F3, @S1, @S2, @S3, @S4, @S5, @S6, @S7, @S8, @S9, @S10, @T1, @T2, @T3, @T4, @T5, @T6, @T7, @T8, @T9, @T10) "; 
                SqlParameter[] param = new SqlParameter[]
                 {
                    new SqlParameter("@ResultDate", result.ResultDate.Replace("-", "")),
                    new SqlParameter("@ResultType", result.ResultType),
                    new SqlParameter("@F1", result.F1 + ""),
                    new SqlParameter("@F2", result.F2 + ""),
                    new SqlParameter("@F3", result.F3 + ""),
                    new SqlParameter("@S1", result.S1 + ""),
                    new SqlParameter("@S2", result.S2 + ""),
                    new SqlParameter("@S3", result.S3 + ""),
                    new SqlParameter("@S4", result.S4 + ""),
                    new SqlParameter("@S5", result.S5 + ""),
                    new SqlParameter("@S6", result.S6 + ""),
                    new SqlParameter("@S7", result.S7 + ""),
                    new SqlParameter("@S8", result.S8 + ""),
                    new SqlParameter("@S9", result.S9 + ""),
                    new SqlParameter("@S10", result.S10 + ""),
                    new SqlParameter("@T1", result.T1 + ""),
                    new SqlParameter("@T2", result.T2 + ""),
                    new SqlParameter("@T3", result.T3 + ""),
                    new SqlParameter("@T4", result.T4 + ""),
                    new SqlParameter("@T5", result.T5 + ""),
                    new SqlParameter("@T6", result.T6 + ""),
                    new SqlParameter("@T7", result.T7 + ""),
                    new SqlParameter("@T8", result.T8 + ""),
                    new SqlParameter("@T9", result.T9 + ""),
                    new SqlParameter("@T10", result.T10 + "")
                 };
                dbContext.Database.ExecuteSqlCommand(sql, param); ;
            }
        }

        public static void UpdateResultRecord(Results result)
        {
            using (var dbContext = new Context1())
            {
                string sql = "";
                sql = sql + " Update Mst_Result ";
                sql = sql + " Set F1 = @F1, F2=@F2, F3 = @F3 ";
                sql = sql + " , S1 = @S1, S2 = @S2, S3 = @S3, S4 = @S4, S5 = @S5, S6 = @S6, S7 = @S7, S8 = @S8, S9 = @S9, S10 = @S10 ";
                sql = sql + " , T1 = @T1, T2 = @T2, T3 = @T3, T4 = @T4, T5 = @T5, T6 = @T6, T7 = @T7, T8 = @T8, T9 = @T9, T10 = @T10 ";
                sql = sql + " Where ResultDate = @ResultDate and ResultType = @ResultType "; 
                SqlParameter[] param = new SqlParameter[]
                 {
                    new SqlParameter("@ResultDate", result.ResultDate.Replace("-", "")),
                    new SqlParameter("@ResultType", result.ResultType),
                    new SqlParameter("@F1", result.F1 + ""),
                    new SqlParameter("@F2", result.F2 + ""),
                    new SqlParameter("@F3", result.F3 + ""),
                    new SqlParameter("@S1", result.S1 + ""),
                    new SqlParameter("@S2", result.S2 + ""),
                    new SqlParameter("@S3", result.S3 + ""),
                    new SqlParameter("@S4", result.S4 + ""),
                    new SqlParameter("@S5", result.S5 + ""),
                    new SqlParameter("@S6", result.S6 + ""),
                    new SqlParameter("@S7", result.S7 + ""),
                    new SqlParameter("@S8", result.S8 + ""),
                    new SqlParameter("@S9", result.S9 + ""),
                    new SqlParameter("@S10", result.S10 + ""),
                    new SqlParameter("@T1", result.T1 + ""),
                    new SqlParameter("@T2", result.T2 + ""),
                    new SqlParameter("@T3", result.T3 + ""),
                    new SqlParameter("@T4", result.T4 + ""),
                    new SqlParameter("@T5", result.T5 + ""),
                    new SqlParameter("@T6", result.T6 + ""),
                    new SqlParameter("@T7", result.T7 + ""),
                    new SqlParameter("@T8", result.T8 + ""),
                    new SqlParameter("@T9", result.T9 + ""),
                    new SqlParameter("@T10", result.T10 + "")
                 };
                dbContext.Database.ExecuteSqlCommand(sql, param); ;
            }
        }




        public static void AddResultRecord_3D(Results result)
        {
            using (var dbContext = new Context1())
            {
                string sql = "";
                sql = sql + " Insert Into Mst_Result ";
                sql = sql + " (ResultDate, ResultType, F_3D_1, F_3D_2, F_3D_3) ";
                sql = sql + " Values ";
                sql = sql + " (@ResultDate, @ResultType, @F_3D_1, @F_3D_2, @F_3D_3) ";
                SqlParameter[] param = new SqlParameter[]
                 {
                    new SqlParameter("@ResultDate", result.ResultDate.Replace("-", "")),
                    new SqlParameter("@ResultType", result.ResultType),
                    new SqlParameter("@F_3D_1", result.F_3D_1 + ""),
                    new SqlParameter("@F_3D_2", result.F_3D_2 + ""),
                    new SqlParameter("@F_3D_3", result.F_3D_3 + "")
                 };
                dbContext.Database.ExecuteSqlCommand(sql, param); ;
            }
        }

        public static void UpdateResultRecord_3D(Results result)
        {
            using (var dbContext = new Context1())
            {
                string sql = "";
                sql = sql + " Update Mst_Result ";
                sql = sql + " Set F_3D_1 = @F_3D_1, F_3D_2=@F_3D_2, F_3D_3 = @F_3D_3 ";
                sql = sql + " Where ResultDate = @ResultDate and ResultType = @ResultType ";
                SqlParameter[] param = new SqlParameter[]
                 {
                    new SqlParameter("@ResultDate", result.ResultDate.Replace("-", "")),
                    new SqlParameter("@ResultType", result.ResultType),
                    new SqlParameter("@F_3D_1", result.F_3D_1 + ""),
                    new SqlParameter("@F_3D_2", result.F_3D_2 + ""),
                    new SqlParameter("@F_3D_3", result.F_3D_3 + "")
                 };
                dbContext.Database.ExecuteSqlCommand(sql, param); ;
            }
        }





        public static List<Result_5D> GetResult_5DListing_ByDate(string ResultDate)
        {
            using (var dbContext = new Context1())
            {
                string sql = "";
                sql = sql + " Select * ";
                sql = sql + " From Mst_Result_5D ";
                sql = sql + " Where ResultDate = @ResultDate ";
                SqlParameter[] param = new SqlParameter[]
                 {
                    new SqlParameter("@ResultDate", ResultDate.Replace("-", ""))
                 };
                var result = dbContext.Database.SqlQuery<Result_5D>(sql, param).ToList();
                return result;
            }
        }


        public static Result_5D GetResult_5D_ByDateAndType(string ResultDate, string ResultType)
        {
            using (var dbContext = new Context1())
            {
                string sql = "";
                sql = sql + " Select * ";
                sql = sql + " From Mst_Result_5D ";
                sql = sql + " Where ResultDate = @ResultDate ";
                sql = sql + " And ResultType = @ResultType ";
                SqlParameter[] param = new SqlParameter[]
                 {
                    new SqlParameter("@ResultDate", ResultDate.Replace("-", "")),
                    new SqlParameter("@ResultType", ResultType)
                 };
                var result = dbContext.Database.SqlQuery<Result_5D>(sql, param).SingleOrDefault();
                return result;
            }
        }


        public static void AddResultRecord_5D(Result_5D result)
        {
            using (var dbContext = new Context1())
            {
                string sql = "";
                sql = sql + " Insert Into Mst_Result_5D ";
                sql = sql + " (ResultDate, ResultType, F1, F2, F3, F4, F5, F6) ";
                sql = sql + " Values ";
                sql = sql + " (@ResultDate, @ResultType, @F1, @F2, @F3, @F4, @F5, @F6) ";
                SqlParameter[] param = new SqlParameter[]
                 {
                    new SqlParameter("@ResultDate", result.ResultDate.Replace("-", "")),
                    new SqlParameter("@ResultType", result.ResultType),
                    new SqlParameter("@F1", result.F1 + ""),
                    new SqlParameter("@F2", result.F2 + ""),
                    new SqlParameter("@F3", result.F3 + ""),
                    new SqlParameter("@F4", result.F4 + ""),
                    new SqlParameter("@F5", result.F5 + ""),
                    new SqlParameter("@F6", result.F6 + "")
                 };
                dbContext.Database.ExecuteSqlCommand(sql, param); ;
            }
        }

        public static void UpdateResultRecord_5D(Result_5D result)
        {
            using (var dbContext = new Context1())
            {
                string sql = "";
                sql = sql + " Update Mst_Result_5D ";
                sql = sql + " Set F1=@F1, F2=@F2, F3=@F3, F4=@F4, F5=@F5, F6=@F6 ";
                sql = sql + " Where ResultDate = @ResultDate and ResultType = @ResultType ";
                SqlParameter[] param = new SqlParameter[]
                 {
                    new SqlParameter("@ResultDate", result.ResultDate.Replace("-", "")),
                    new SqlParameter("@ResultType", result.ResultType),
                    new SqlParameter("@F1", result.F1 + ""),
                    new SqlParameter("@F2", result.F2 + ""),
                    new SqlParameter("@F3", result.F3 + ""),
                    new SqlParameter("@F4", result.F4 + ""),
                    new SqlParameter("@F5", result.F5 + ""),
                    new SqlParameter("@F6", result.F6 + "")
                 };
                dbContext.Database.ExecuteSqlCommand(sql, param); ;
            }
        }

        public static List<Result_6D> GetResult_6DListing_ByDate(string ResultDate)
        {
            using (var dbContext = new Context1())
            {
                string sql = "";
                sql = sql + " Select * ";
                sql = sql + " From Mst_Result_6D ";
                sql = sql + " Where ResultDate = @ResultDate ";
                SqlParameter[] param = new SqlParameter[]
                 {
                    new SqlParameter("@ResultDate", ResultDate.Replace("-", ""))
                 };
                var result = dbContext.Database.SqlQuery<Result_6D>(sql, param).ToList();
                return result;
            }
        }
        public static List<Result_Damacai> GetResultDamacai_6DListing_ByDate(string ResultDate)
        {
            using (var dbContext = new Context1())
            {
                string sql = "";
                sql = sql + " Select * ";
                sql = sql + " From Mst_Result_Damacai_6D ";
                sql = sql + " Where ResultDate = @ResultDate ";
                SqlParameter[] param = new SqlParameter[]
                 {
                    new SqlParameter("@ResultDate", ResultDate.Replace("-", ""))
                 };
                var result = dbContext.Database.SqlQuery<Result_Damacai>(sql, param).ToList();
                return result;
            }
        }


        public static Result_6D GetResult_6D_ByDateAndType(string ResultDate, string ResultType)
        {
            using (var dbContext = new Context1())
            {
                string sql = "";
                sql = sql + " Select * ";
                sql = sql + " From Mst_Result_6D ";
                sql = sql + " Where ResultDate = @ResultDate ";
                sql = sql + " And ResultType = @ResultType ";
                SqlParameter[] param = new SqlParameter[]
                 {
                    new SqlParameter("@ResultDate", ResultDate.Replace("-", "")),
                    new SqlParameter("@ResultType", ResultType)
                 };
                var result = dbContext.Database.SqlQuery<Result_6D>(sql, param).SingleOrDefault();
                return result;
            }
        }


        public static void AddResultRecord_6D(Result_6D result)
        {
            using (var dbContext = new Context1())
            {
                string sql = "";
                sql = sql + " Insert Into Mst_Result_6D ";
                sql = sql + " (ResultDate, ResultType, F1, F2, F3, F4, F5, F6, F7, Jackpot, Jackpot2 ) ";
                sql = sql + " Values ";
                sql = sql + " (@ResultDate, @ResultType, @F1, @F2, @F3, @F4, @F5, @F6, @F7, @Jackpot, @Jackpot2) ";
                SqlParameter[] param = new SqlParameter[]
                 {
                    new SqlParameter("@ResultDate", result.ResultDate.Replace("-", "")),
                    new SqlParameter("@ResultType", result.ResultType),
                    new SqlParameter("@F1", result.F1 + ""),
                    new SqlParameter("@F2", result.F2 + ""),
                    new SqlParameter("@F3", result.F3 + ""),
                    new SqlParameter("@F4", result.F4 + ""),
                    new SqlParameter("@F5", result.F5 + ""),
                    new SqlParameter("@F6", result.F6 + ""),
                    new SqlParameter("@F7", result.F7 + ""),
                    new SqlParameter("@Jackpot", result.Jackpot + ""),
                    new SqlParameter("@Jackpot2", result.Jackpot2 + "")
                 };
                dbContext.Database.ExecuteSqlCommand(sql, param); ;
            }
        }

        public static void UpdateResultRecord_6D(Result_6D result)
        {
            using (var dbContext = new Context1())
            {
                string sql = "";
                sql = sql + " Update Mst_Result_6D ";
                sql = sql + " Set F1=@F1, F2=@F2, F3=@F3, F4=@F4, F5=@F5, F6=@F6, F7=@F7, Jackpot=@Jackpot, Jackpot2=@Jackpot2";
                sql = sql + " Where ResultDate = @ResultDate and ResultType = @ResultType ";
                SqlParameter[] param = new SqlParameter[]
                 {
                    new SqlParameter("@ResultDate", result.ResultDate.Replace("-", "")),
                    new SqlParameter("@ResultType", result.ResultType),
                    new SqlParameter("@F1", result.F1 + ""),
                    new SqlParameter("@F2", result.F2 + ""),
                    new SqlParameter("@F3", result.F3 + ""),
                    new SqlParameter("@F4", result.F4 + ""),
                    new SqlParameter("@F5", result.F5 + ""),
                    new SqlParameter("@F6", result.F6 + ""),
                    new SqlParameter("@F7", result.F7 + ""),
                    new SqlParameter("@Jackpot", result.Jackpot + ""),
                    new SqlParameter("@Jackpot2", result.Jackpot2 + "")
                 };
                dbContext.Database.ExecuteSqlCommand(sql, param); ;
            }
        }




        public static void AddResultDamacaiRecord(Result_Damacai result)
        {
            using (var dbContext = new Context1())
            {
                string sql = "";
                sql = sql + " Insert Into Mst_Result_Damacai_6D ";
                sql = sql + " (ResultDate, ResultType, F1, F2, F3, S1, S2, S3, S4, S5, S6, S7, S8, S9, S10, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, F_3D_1, F_3D_2, F_3D_3) ";
                sql = sql + " Values ";
                sql = sql + " (@ResultDate, @ResultType, @F1, @F2, @F3, @S1, @S2, @S3, @S4, @S5, @S6, @S7, @S8, @S9, @S10, @T1, @T2, @T3, @T4, @T5, @T6, @T7, @T8, @T9, @T10, @F_3D_1, @F_3D_2, @F_3D_3) ";
                SqlParameter[] param = new SqlParameter[]
                 {
                    new SqlParameter("@ResultDate", result.ResultDate.Replace("-", "")),
                    new SqlParameter("@ResultType", ""),
                    new SqlParameter("@F1", result.F1 + ""),
                    new SqlParameter("@F2", result.F2 + ""),
                    new SqlParameter("@F3", result.F3 + ""),
                    new SqlParameter("@S1", result.S1 + ""),
                    new SqlParameter("@S2", result.S2 + ""),
                    new SqlParameter("@S3", result.S3 + ""),
                    new SqlParameter("@S4", result.S4 + ""),
                    new SqlParameter("@S5", result.S5 + ""),
                    new SqlParameter("@S6", result.S6 + ""),
                    new SqlParameter("@S7", result.S7 + ""),
                    new SqlParameter("@S8", result.S8 + ""),
                    new SqlParameter("@S9", result.S9 + ""),
                    new SqlParameter("@S10", result.S10 + ""),
                    new SqlParameter("@T1", result.T1 + ""),
                    new SqlParameter("@T2", result.T2 + ""),
                    new SqlParameter("@T3", result.T3 + ""),
                    new SqlParameter("@T4", result.T4 + ""),
                    new SqlParameter("@T5", result.T5 + ""),
                    new SqlParameter("@T6", result.T6 + ""),
                    new SqlParameter("@T7", result.T7 + ""),
                    new SqlParameter("@T8", result.T8 + ""),
                    new SqlParameter("@T9", result.T9 + ""),
                    new SqlParameter("@T10", result.T10 + ""),
                    new SqlParameter("@F_3D_1", result.F_3D_1 + ""),
                    new SqlParameter("@F_3D_2", result.F_3D_2 + ""),
                    new SqlParameter("@F_3D_3", result.F_3D_3 + "")
                 };
                dbContext.Database.ExecuteSqlCommand(sql, param); ;
            }
        }

        public static void UpdateResultDamacaiRecord(Result_Damacai result)
        {
            using (var dbContext = new Context1())
            {
                string sql = "";
                sql = sql + " Update Mst_Result_Damacai_6D ";
                sql = sql + " Set F1 = @F1, F2=@F2, F3 = @F3 ";
                sql = sql + " , S1 = @S1, S2 = @S2, S3 = @S3, S4 = @S4, S5 = @S5, S6 = @S6, S7 = @S7, S8 = @S8, S9 = @S9, S10 = @S10 ";
                sql = sql + " , T1 = @T1, T2 = @T2, T3 = @T3, T4 = @T4, T5 = @T5, T6 = @T6, T7 = @T7, T8 = @T8, T9 = @T9, T10 = @T10 ";
                sql = sql + " , F_3D_1 = @F_3D_1, F_3D_2 = @F_3D_2, F_3D_3 = @F_3D_3  ";
                sql = sql + " Where ResultDate = @ResultDate ";
                SqlParameter[] param = new SqlParameter[]
                 {
                    new SqlParameter("@ResultDate", result.ResultDate.Replace("-", "")), 
                    new SqlParameter("@F1", result.F1 + ""),
                    new SqlParameter("@F2", result.F2 + ""),
                    new SqlParameter("@F3", result.F3 + ""),
                    new SqlParameter("@S1", result.S1 + ""),
                    new SqlParameter("@S2", result.S2 + ""),
                    new SqlParameter("@S3", result.S3 + ""),
                    new SqlParameter("@S4", result.S4 + ""),
                    new SqlParameter("@S5", result.S5 + ""),
                    new SqlParameter("@S6", result.S6 + ""),
                    new SqlParameter("@S7", result.S7 + ""),
                    new SqlParameter("@S8", result.S8 + ""),
                    new SqlParameter("@S9", result.S9 + ""),
                    new SqlParameter("@S10", result.S10 + ""),
                    new SqlParameter("@T1", result.T1 + ""),
                    new SqlParameter("@T2", result.T2 + ""),
                    new SqlParameter("@T3", result.T3 + ""),
                    new SqlParameter("@T4", result.T4 + ""),
                    new SqlParameter("@T5", result.T5 + ""),
                    new SqlParameter("@T6", result.T6 + ""),
                    new SqlParameter("@T7", result.T7 + ""),
                    new SqlParameter("@T8", result.T8 + ""),
                    new SqlParameter("@T9", result.T9 + ""),
                    new SqlParameter("@T10", result.T10 + ""),
                    new SqlParameter("@F_3D_1", result.F_3D_1 + ""),
                    new SqlParameter("@F_3D_2", result.F_3D_2 + ""),
                    new SqlParameter("@F_3D_3", result.F_3D_3 + "")
                 };
                dbContext.Database.ExecuteSqlCommand(sql, param); ;
            }
        }




    }

}