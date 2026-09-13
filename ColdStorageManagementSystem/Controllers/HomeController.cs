using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyFirstProj.Models;
using System.Data.SqlClient;

namespace MyFirstProj.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Sai Kumar Mamidala";

            return View();
        }
        public ActionResult Login()
        {
            ViewBag.Message = "";

            return View();
        
       }
        [HttpPost]
        public ActionResult Login(Models.Login ObjLogin)
        {
            using(Models.dbContext context=new Models.dbContext())
            {
                var obj=context.Logins.Where(a=> a.LoginID == ObjLogin.LoginID && a.LoginPwd==ObjLogin.LoginPwd).FirstOrDefault();
                var x = context.Logins.Where(b => b.LoginID == ObjLogin.LoginID && b.LoginPwd != ObjLogin.LoginPwd).FirstOrDefault();
                var y = context.Logins.Where(a => a.LoginID != ObjLogin.LoginID&& a.LoginPwd == ObjLogin.LoginPwd).FirstOrDefault();
            if(obj!= null)
            {
               // String sq = "select * from Customers where CustomerID ='"+Session["LoginID"]+"'";
                String sql1 = "select * from Customers where CustomerID ='" + Session["LoginID"] + "'";
                context.Database.ExecuteSqlCommand(sql1);
                ViewBag.bio = sql1;
                Session["LoginID"] = ObjLogin.LoginID;
                return RedirectToAction("Invoice","Home");
            }
            else
            {
                if (x != null)
                {
                    ModelState.AddModelError("", "CUSTOMER PASSWORD provided is INVALID");
                }
                else if (y != null)
                {
                    ModelState.AddModelError("", "CUSTOMER ID provided is INVALID");
                }
                else if (obj == null)
                {
                    ModelState.AddModelError("", "Provide Customer ID and Customer PASSWORD");
                }
                else
                {
                    ModelState.AddModelError("", " CUSTOMER USER ID/PASSWORD provided is INVALID");

                }

                return View();
            }
            }
        }
        public ActionResult Admin()
        {
            ViewBag.Message = "";

            return View();

        }
        [HttpPost]
        public ActionResult Admin(Models.Admin ObjAdmin)
        {
            using (Models.dbContext con = new Models.dbContext())
            {
                var obj = con.Admins.Where(a => a.AdminID == ObjAdmin.AdminID && a.AdminPwd == ObjAdmin.AdminPwd).FirstOrDefault();
                var x = con.Admins.Where(b => b.AdminID == ObjAdmin.AdminID && b.AdminPwd != ObjAdmin.AdminPwd).FirstOrDefault();
               var y = con.Admins.Where(a => a.AdminID != ObjAdmin.AdminID && a.AdminPwd == ObjAdmin.AdminPwd).FirstOrDefault();
                if (obj != null)
                {
                    Session["AdminID"] = ObjAdmin.AdminID;
                    return RedirectToAction("Empty", "Home");
                }
                
                else
                {
                    if (x != null)
                    {
                        ModelState.AddModelError("", "PASSWORD provided is INVALID");
                    }
                    else if (y != null)
                    {
                        ModelState.AddModelError("", "ADMIN ID provided is INVALID");
                    }
                    else if (obj == null)
                    {
                        ModelState.AddModelError("", "Provide Admin ID and Admin PASSWORD");
                    }
                    else
                    {
                        ModelState.AddModelError("", " ADMIN USER ID/PASSWORD provided is INVALID");
                      
                    }
                  
                    return View();
                }
            }
        }

        public ActionResult logsuccess()
        {
            ViewBag.Message = "";

            return View();

        }
        public ActionResult Empty()
        {
            ViewBag.Message = "";

            return View();

        }
        public ActionResult Summary()
        {
            ViewBag.CustomerDetails = getcustomer();
            ViewBag.OutgoingLogisticDetails = getOutgoingLogistic();
            ViewBag.PaymentDetails = getPayment();

            return View();

        }
        dbContext cd = new dbContext();
        public List<Customer> getcustomer()
        {
            List<Customer> Cust = cd.Customers.ToList();
            return Cust;
        }
        public List<OutgoingLogistic> getOutgoingLogistic()
        {
            List<OutgoingLogistic> OutLog = cd.OutgoingLogistics.ToList();
            return OutLog;
        }
        public List<Payment> getPayment()
        {
            List<Payment> Pay = cd.Payments.ToList();
            return Pay;
        }
        public ActionResult CreatedSuccesfully()
        {
            ViewBag.Message = "";

            return View();

        }
        public ActionResult Invoice()
        {
            dbContext db = new dbContext();
            ViewBag.Message = "";
            string sq1 = "select * from Invoices where CustomerID='" + Session["LoginID"] + "'";
            db.Database.ExecuteSqlCommand(sq1);
            db.SaveChanges();
        
           
            return View();
            }

        private object List()
        {
            throw new NotImplementedException();
        }
         

        }
        
    }
