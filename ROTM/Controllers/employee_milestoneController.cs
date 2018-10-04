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
    [Authorize]
    public class employee_milestoneController : Controller
    {
        private Entities db = new Entities();

        // GET: employee_milestone
        public ActionResult Index()
        {
            var employee_milestone = db.employee_milestone.Include(e => e.employee).Include(e => e.milestone);
            return View(employee_milestone.ToList());
        }

        // GET: employee_milestone/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employee_milestone employee_milestone = db.employee_milestone.Find(id);
            if (employee_milestone == null)
            {
                return HttpNotFound();
            }
            return View(employee_milestone);
        }

        // GET: employee_milestone/Create
        public ActionResult Create()
        {
            ViewBag.Employee_ID = new SelectList(db.employees, "Employee_ID", "Employee_Name");
            ViewBag.Milestone_ID = new SelectList(db.milestones, "Milestone_ID", "Milestone_Name");
            return View();
        }

        // POST: employee_milestone/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Employee_ID,Milestone_ID,Reason_Milestone,Milestone_Progress")] employee_milestone employee_milestone)
        {
            var check = db.employee_milestone.Where(s => s.Employee_ID == employee_milestone.Employee_ID && s.Milestone_ID == employee_milestone.Milestone_ID).FirstOrDefault();
            if (check == null)
            {
                if (ModelState.IsValid)
                {
                    db.employee_milestone.Add(employee_milestone);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.Employee_ID = new SelectList(db.employees, "Employee_ID", "Employee_Name", employee_milestone.Employee_ID);
                ViewBag.Milestone_ID = new SelectList(db.milestones, "Milestone_ID", "Milestone_Name", employee_milestone.Milestone_ID);
                return View(employee_milestone);
            }
            else
            {
                ViewBag.Error = "This Employee already has that milestone assigned to them. Did you not mean to choose a different employee.";
                ViewBag.Employee_ID = new SelectList(db.employees, "Employee_ID", "Employee_Name", employee_milestone.Employee_ID);
                ViewBag.Milestone_ID = new SelectList(db.milestones, "Milestone_ID", "Milestone_Name", employee_milestone.Milestone_ID);
                return View(employee_milestone);
            }


        }

        // GET: employee_milestone/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employee_milestone employee_milestone = db.employee_milestone.Find(id);
            if (employee_milestone == null)
            {
                return HttpNotFound();
            }
            ViewBag.Employee_ID = new SelectList(db.employees, "Employee_ID", "Employee_Name", employee_milestone.Employee_ID);
            ViewBag.Milestone_ID = new SelectList(db.milestones, "Milestone_ID", "Milestone_Name", employee_milestone.Milestone_ID);
            return View(employee_milestone);
        }

        // POST: employee_milestone/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Employee_ID,Milestone_ID,Reason_Milestone,Milestone_Progress")] employee_milestone employee_milestone)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee_milestone).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Employee_ID = new SelectList(db.employees, "Employee_ID", "Employee_Name", employee_milestone.Employee_ID);
            ViewBag.Milestone_ID = new SelectList(db.milestones, "Milestone_ID", "Milestone_Name", employee_milestone.Milestone_ID);
            return View(employee_milestone);
        }

        // GET: employee_milestone/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employee_milestone employee_milestone = db.employee_milestone.Find(id);
            if (employee_milestone == null)
            {
                return HttpNotFound();
            }
            return View(employee_milestone);
        }

        // POST: employee_milestone/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            employee_milestone employee_milestone = db.employee_milestone.Find(id);
            db.employee_milestone.Remove(employee_milestone);
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
