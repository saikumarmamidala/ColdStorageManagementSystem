using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyFirstProj.Models;
//public partial class OutgoingLogistics : System.Web.UI.Page
//{ }
//using MyFirstProj.This.That.Foo.bar();

namespace MyFirstProj.Controllers
{
    
    public class OutgoingLogisticsController : Controller
    {
       
        public dbContext db = new dbContext();

        // GET: /OutgoingLogistics/
        public ActionResult Index()
        {
            var outgoinglogistics = db.OutgoingLogistics.Include(o => o.Customer);
            return View(outgoinglogistics.ToList());
        }

        // GET: /OutgoingLogistics/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OutgoingLogistic outgoinglogistic = db.OutgoingLogistics.Find(id);
            if (outgoinglogistic == null)
            {
                return HttpNotFound();
            }
            return View(outgoinglogistic);
        }

        // GET: /OutgoingLogistics/Create
        public ActionResult Create()
        {
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CustomerName");
            return View();
        }

        // POST: /OutgoingLogistics/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="OutgoingLogisticID,OutgoingLogisticDate,OutgoingLogisticName,OutgoingLogisticCost,OutgoingLogisticQuantity,OutgoingLogisticLocation,CustomerID")] OutgoingLogistic outgoinglogistic)
        {
            //OutgoingLogistic obj = new OutgoingLogistic();
          //  var x = obj.OutgoingLogisticCost;
            if (ModelState.IsValid)
            {
                db.OutgoingLogistics.Add(outgoinglogistic);
               // db.SaveChanges();
                
              //  String s1 = "delete from IncomingLogistics where IncomingLogisticCost='" + x +"'";
                    //"delete from IncomingLogistics where exists (select * from OutgoingLogistics where OutgoingLogistics.OutgoingLogisticID =IncomingLogistics.IncomingLogisticID)";

                    //"delete from IncomingLogistics where exists (select * from OutgoingLogistics where OutgoingLogistics.OutgoingLogisticID = IncomingLogistics.IncomingLogisticID)'";
                  //  db.IncomingLogistics.SqlQuery(s1);
                    string s = " delete from IncomingLogistics where IncomingLogisticQuantity='" + Session["OutgoingLogisticQuantity"] + "'";
                    db.Database.ExecuteSqlCommand(s);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                   // db.SaveChanges();
               // return RedirectToAction("Index");
             
            }

            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CustomerName", outgoinglogistic.CustomerID);
            return View(outgoinglogistic);
        }

        // GET: /OutgoingLogistics/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OutgoingLogistic outgoinglogistic = db.OutgoingLogistics.Find(id);
            if (outgoinglogistic == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CustomerName", outgoinglogistic.CustomerID);
            return View(outgoinglogistic);
        }

        // POST: /OutgoingLogistics/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="OutgoingLogisticID,OutgoingLogisticDate,OutgoingLogisticName,OutgoingLogisticCost,OutgoingLogisticQuantity,OutgoingLogisticLocation,CustomerID")] OutgoingLogistic outgoinglogistic)
        {
            if (ModelState.IsValid)
            {
                db.Entry(outgoinglogistic).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CustomerName", outgoinglogistic.CustomerID);
            return View(outgoinglogistic);
        }

        // GET: /OutgoingLogistics/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OutgoingLogistic outgoinglogistic = db.OutgoingLogistics.Find(id);
            if (outgoinglogistic == null)
            {
                return HttpNotFound();
            }
            return View(outgoinglogistic);
        }

        // POST: /OutgoingLogistics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OutgoingLogistic outgoinglogistic = db.OutgoingLogistics.Find(id);
            db.OutgoingLogistics.Remove(outgoinglogistic);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
