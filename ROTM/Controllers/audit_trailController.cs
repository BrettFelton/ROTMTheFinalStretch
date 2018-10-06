using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ROTM;

namespace ROTM.Controllers
{
    public class audit_trailController : Controller
    {
        private Entities db = new Entities();

        // GET: audit_trail
        public ActionResult Index(string searchString, DateTime? fromDate, DateTime? toDate)
        {
            var audit_trail = from s in (db.audit_trail.Include(a => a.employee)) select s;

            if (!fromDate.HasValue) fromDate = DateTime.Now.Date;
            if (!toDate.HasValue) toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
            if (toDate < fromDate) toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);

            ViewBag.fromDate = String.Format("{0:yyyy/MM/dd}", fromDate);
            ViewBag.toDate = String.Format("{0:yyyy/MM/dd}", toDate); ;

            if (!String.IsNullOrEmpty(searchString))
            {
                audit_trail = audit_trail.Where(s => s.Deleted_Record.Contains(searchString) || s.Trail_Description.Contains(searchString) || s.employee.Employee_Name.Contains(searchString));

                return View(audit_trail.ToList());
            }
            //Returns both Name and day search
            else if (!String.IsNullOrEmpty(searchString) && fromDate != null && toDate != null)
            {
                audit_trail = audit_trail.Where(s => s.Deleted_Record.Contains(searchString) || s.Trail_Description.Contains(searchString) || s.employee.Employee_Name.Contains(searchString) && (s.Trail_DateTime >= fromDate && s.Trail_DateTime <= toDate));

                return View(audit_trail.ToList());
            }
            //Returns Day Search
            else if (fromDate != null && toDate != null)
            {
                var Meeting = db.audit_trail.Where(s => s.Trail_DateTime >= fromDate && s.Trail_DateTime <= toDate).ToList();
                return View(Meeting);
            }


            return View(audit_trail.ToList());
        }

        // GET: audit_trail/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            audit_trail audit_trail = db.audit_trail.Find(id);
            if (audit_trail == null)
            {
                return HttpNotFound();
            }
            return View(audit_trail);
        }

        // GET: audit_trail/Create
        public ActionResult Create()
        {
            ViewBag.Employee_ID = new SelectList(db.employees, "Employee_ID", "Employee_Name");
            return View();
        }

        // POST: audit_trail/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Audit_Trail_ID,Employee_ID,Trail_DateTime,Trail_Description,Deleted_Record")] audit_trail audit_trail)
        {
            if (ModelState.IsValid)
            {
                db.audit_trail.Add(audit_trail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Employee_ID = new SelectList(db.employees, "Employee_ID", "Employee_Name", audit_trail.Employee_ID);
            return View(audit_trail);
        }

        // GET: audit_trail/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            audit_trail audit_trail = db.audit_trail.Find(id);
            if (audit_trail == null)
            {
                return HttpNotFound();
            }
            ViewBag.Employee_ID = new SelectList(db.employees, "Employee_ID", "Employee_Name", audit_trail.Employee_ID);
            return View(audit_trail);
        }

        // POST: audit_trail/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Audit_Trail_ID,Employee_ID,Trail_DateTime,Trail_Description,Deleted_Record")] audit_trail audit_trail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(audit_trail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Employee_ID = new SelectList(db.employees, "Employee_ID", "Employee_Name", audit_trail.Employee_ID);
            return View(audit_trail);
        }

        // GET: audit_trail/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            audit_trail audit_trail = db.audit_trail.Find(id);
            if (audit_trail == null)
            {
                return HttpNotFound();
            }
            return View(audit_trail);
        }

        // POST: audit_trail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            audit_trail audit_trail = db.audit_trail.Find(id);
            db.audit_trail.Remove(audit_trail);
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
