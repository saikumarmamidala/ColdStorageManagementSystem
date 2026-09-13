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
    public class CustomerLoansController : Controller
    {
        private dbContext db = new dbContext();

        // GET: /CustomerLoans/
        public ActionResult Index()
        {
            var customerloans = db.CustomerLoans.Include(c => c.IncomingLogistic);
            return View(customerloans.ToList());
        }

        // GET: /CustomerLoans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerLoan customerloan = db.CustomerLoans.Find(id);
            if (customerloan == null)
            {
                return HttpNotFound();
            }
            return View(customerloan);
        }

        // GET: /CustomerLoans/Create
        public ActionResult Create()
        {
            ViewBag.IncomingLogisticID = new SelectList(db.IncomingLogistics, "IncomingLogisticID", "IncomingLogisticName");
            return View();
        }

        // POST: /CustomerLoans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="CustomerLoanID,CustomerLoanDate,IncomingLogisticID,CustomerLoanAmount,CustomerLoanBankName,CustomerAccountNumber,CustomerLoanBankIFSCCode")] CustomerLoan customerloan)
        {
            if (ModelState.IsValid)
            {
                db.CustomerLoans.Add(customerloan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IncomingLogisticID = new SelectList(db.IncomingLogistics, "IncomingLogisticID", "IncomingLogisticName", customerloan.IncomingLogisticID);
            return View(customerloan);
        }

        // GET: /CustomerLoans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerLoan customerloan = db.CustomerLoans.Find(id);
            if (customerloan == null)
            {
                return HttpNotFound();
            }
            ViewBag.IncomingLogisticID = new SelectList(db.IncomingLogistics, "IncomingLogisticID", "IncomingLogisticName", customerloan.IncomingLogisticID);
            return View(customerloan);
        }

        // POST: /CustomerLoans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="CustomerLoanID,CustomerLoanDate,IncomingLogisticID,CustomerLoanAmount,CustomerLoanBankName,CustomerAccountNumber,CustomerLoanBankIFSCCode")] CustomerLoan customerloan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customerloan).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IncomingLogisticID = new SelectList(db.IncomingLogistics, "IncomingLogisticID", "IncomingLogisticName", customerloan.IncomingLogisticID);
            return View(customerloan);
        }

        // GET: /CustomerLoans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerLoan customerloan = db.CustomerLoans.Find(id);
            if (customerloan == null)
            {
                return HttpNotFound();
            }
            return View(customerloan);
        }

        // POST: /CustomerLoans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CustomerLoan customerloan = db.CustomerLoans.Find(id);
            db.CustomerLoans.Remove(customerloan);
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
