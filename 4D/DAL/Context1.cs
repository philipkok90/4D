using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace _4D.DAL
{
    public class Context1 : DbContext
    {
        public Context1() : base("name=Context1")
        {

        }
    }
}