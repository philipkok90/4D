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
        public static List<Results> GetResultListing_ByDate()
        {
            using (var dbContext = new Context1())
            {
                string sql = "";
                sql = sql + " Select * ";
                sql = sql + " From Mst_Result ";
                var result = dbContext.Database.SqlQuery<Results>(sql).ToList();
                return result;
            }
        }
    }
}