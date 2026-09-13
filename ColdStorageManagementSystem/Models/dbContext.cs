using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyFirstProj.Models
{
    public class dbContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public dbContext() : base("name=dbContext")
        {
        }

        public System.Data.Entity.DbSet<MyFirstProj.Models.Customer> Customers { get; set; }

        public System.Data.Entity.DbSet<MyFirstProj.Models.Login> Logins { get; set; }
        public System.Data.Entity.DbSet<MyFirstProj.Models.Admin> Admins { get; set; }


        public System.Data.Entity.DbSet<MyFirstProj.Models.IncomingLogistic> IncomingLogistics { get; set; }

        public System.Data.Entity.DbSet<MyFirstProj.Models.OutgoingLogistic> OutgoingLogistics { get; set; }

        public System.Data.Entity.DbSet<MyFirstProj.Models.CustomerLoan> CustomerLoans { get; set; }

        public System.Data.Entity.DbSet<MyFirstProj.Models.Payment> Payments { get; set; }

        public System.Data.Entity.DbSet<MyFirstProj.Models.Invoice> Invoices { get; set; }

       
    
    }
}
