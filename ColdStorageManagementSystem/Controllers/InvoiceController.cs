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
    public class InvoiceController : Controller
    {
        private dbContext db = new dbContext();

        // GET: /Invoice/
        public ActionResult Index()
        {
            var invoices = db.Invoices.Include(i => i.Customer).Include(i => i.OutgoingLogistic).Include(i => i.Payment);
            return View(invoices.ToList());
        }

        // GET: /Invoice/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice invoice = db.Invoices.Find(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            return View(invoice);
        }

        // GET: /Invoice/Create
        public ActionResult Create()
        {
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CustomerName");
            ViewBag.OutgoingLogisticID = new SelectList(db.OutgoingLogistics, "OutgoingLogisticID", "OutgoingLogisticName");
            ViewBag.PaymentID = new SelectList(db.Payments, "PaymentID", "PaymentType");
            return View();
        }

        // POST: /Invoice/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="BillNumber,CustomerID,OutgoingLogisticID,PaymentID,OutgoingLogisticQuantity,Date,Time")] Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                db.Invoices.Add(invoice);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CustomerName", invoice.CustomerID);
            ViewBag.OutgoingLogisticID = new SelectList(db.OutgoingLogistics, "OutgoingLogisticID", "OutgoingLogisticName", invoice.OutgoingLogisticID);
            ViewBag.PaymentID = new SelectList(db.Payments, "PaymentID", "PaymentType", invoice.PaymentID);
            return View(invoice);
        }

        // GET: /Invoice/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice invoice = db.Invoices.Find(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CustomerName", invoice.CustomerID);
            ViewBag.OutgoingLogisticID = new SelectList(db.OutgoingLogistics, "OutgoingLogisticID", "OutgoingLogisticName", invoice.OutgoingLogisticID);
            ViewBag.PaymentID = new SelectList(db.Payments, "PaymentID", "PaymentType", invoice.PaymentID);
            return View(invoice);
        }

        // POST: /Invoice/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="BillNumber,CustomerID,OutgoingLogisticID,PaymentID,OutgoingLogisticQuantity,Date,Time")] Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(invoice).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CustomerName", invoice.CustomerID);
            ViewBag.OutgoingLogisticID = new SelectList(db.OutgoingLogistics, "OutgoingLogisticID", "OutgoingLogisticName", invoice.OutgoingLogisticID);
            ViewBag.PaymentID = new SelectList(db.Payments, "PaymentID", "PaymentType", invoice.PaymentID);
            return View(invoice);
        }

        // GET: /Invoice/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice invoice = db.Invoices.Find(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            return View(invoice);
        }

        // POST: /Invoice/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Invoice invoice = db.Invoices.Find(id);
            db.Invoices.Remove(invoice);
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
