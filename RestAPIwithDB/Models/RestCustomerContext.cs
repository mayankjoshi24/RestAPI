using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RestAPIwithDB.Models
{
    public class RestCustomerContext:DbContext
    {
        public RestCustomerContext():base("MyConn")
        {

        }

        public DbSet<RestCustomer> RestCustomers { get; set; }    
      }
}