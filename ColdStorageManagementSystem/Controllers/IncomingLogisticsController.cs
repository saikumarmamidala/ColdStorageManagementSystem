using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyFirstProj.Models;

namespace MyFirstProj.Controllers
{
    public class IncomingLogisticsController : Controller
    {
        private dbContext db = new dbContext();

        // GET: /IncomingLogistics/
        public ActionResult Index()
        {
            var incominglogistics = db.IncomingLogistics.Include(i => i.Customer);
            return View(incominglogistics.ToList());
        }

        // GET: /IncomingLogistics/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IncomingLogistic incominglogistic = db.IncomingLogistics.Find(id);
            if (incominglogistic == null)
            {
                return HttpNotFound();
            }
            return View(incominglogistic);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Details()
        {
            string s4 = "update IncomingLogistics set IncomingLogisticQuantity=IncomingLogisticQuantity-OutgoingLogisticQuantity where IncomingLogisticQuantity='" + Session["OutgoingLogisticQuantity"] + "'";
            db.Database.ExecuteSqlCommand(s4);
           // return RedirectToAction("Index");
            /*if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IncomingLogistic incominglogistic = db.IncomingLogistics.Find(id);
            if (incominglogistic == null)
            {
                return HttpNotFound();
            }*/
            return View();
        }
        // GET: /IncomingLogistics/Create
        public ActionResult Create()
        {
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CustomerName");
            return View();
        }

        // POST: /IncomingLogistics/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="IncomingLogisticID,IncomingLogisticDate,IncomingLogisticName,IncomingLogisticCost,IncomingLogisticQuantity,IncomingLogisticLocation,IncomingLogisticInsurance,IncomingLogisticRent,CustomerID")] IncomingLogistic incominglogistic)
        {
            if (ModelState.IsValid)
            {
                db.IncomingLogistics.Add(incominglogistic);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CustomerName", incominglogistic.CustomerID);
            return View(incominglogistic);
        }

        // GET: /IncomingLogistics/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IncomingLogistic incominglogistic = db.IncomingLogistics.Find(id);
            if (incominglogistic == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CustomerName", incominglogistic.CustomerID);
            return View(incominglogistic);
        }

        // POST: /IncomingLogistics/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="IncomingLogisticID,IncomingLogisticDate,IncomingLogisticName,IncomingLogisticCost,IncomingLogisticQuantity,IncomingLogisticLocation,IncomingLogisticInsurance,IncomingLogisticRent,CustomerID")] IncomingLogistic incominglogistic)
        {
            if (ModelState.IsValid)
            {
                db.Entry(incominglogistic).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CustomerName", incominglogistic.CustomerID);
            return View(incominglogistic);
        }

        // GET: /IncomingLogistics/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IncomingLogistic incominglogistic = db.IncomingLogistics.Find(id);
            if (incominglogistic == null)
            {
                return HttpNotFound();
            }
            return View(incominglogistic);
        }

        // POST: /IncomingLogistics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //IncomingLogistic incominglogistic = db.IncomingLogistics.Find(id);
            //db.IncomingLogistics.Remove(incominglogistic);
            //db.SaveChanges();
            db.IncomingLogistics.Remove(db.IncomingLogistics.Find(id));
            string s = " delete from IncomingLogistics where IncomingLogisticQuantity='" + Session["OutgoingLogisticQuantity"] + "'";
            db.Database.ExecuteSqlCommand(s);
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
