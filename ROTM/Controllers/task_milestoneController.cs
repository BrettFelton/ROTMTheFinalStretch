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
    public class task_milestoneController : Controller
    {
        private Entities db = new Entities();

        // GET: task_milestone
        public ActionResult Index(string searchString)
        {
            var task_milestone = from s in (db.task_milestone.Include(t => t.milestone).Include(t => t.task)) select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                task_milestone = task_milestone.Where(s => s.task.Task_Name.Contains(searchString) || s.milestone.Milestone_Name.Contains(searchString))
                /*|| s.Venue_Size == Convert.ToInt32(searchString)*/;
            }
            //var task_milestone = db.task_milestone.Include(t => t.milestone).Include(t => t.task);
            return View(task_milestone.ToList());
        }

        // GET: task_milestone/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            task_milestone task_milestone = db.task_milestone.Find(id);
            if (task_milestone == null)
            {
                return HttpNotFound();
            }
            return View(task_milestone);
        }

        // GET: task_milestone/Create
        public ActionResult Create()
        {
            ViewBag.Milestone_ID = new SelectList(db.milestones, "Milestone_ID", "Milestone_Name");
            ViewBag.Task_ID = new SelectList(db.tasks, "Task_ID", "Task_Name");
            return View();
        }

        // POST: task_milestone/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Task_ID,Milestone_ID,Task_Repetion")] task_milestone task_milestone)
        {
            var check = db.task_milestone.Where(s => s.Task_ID == task_milestone.Task_ID && s.Milestone_ID == task_milestone.Milestone_ID).FirstOrDefault();
            if (check == null)
            {
                if (ModelState.IsValid)
                {
                    db.task_milestone.Add(task_milestone);
                    db.SaveChanges();
                    return RedirectToAction("Create", "employee_milestone");
                }
                ViewBag.Milestone_ID = new SelectList(db.milestones, "Milestone_ID", "Milestone_Name", task_milestone.Milestone_ID);
                ViewBag.Task_ID = new SelectList(db.tasks, "Task_ID", "Task_Name", task_milestone.Task_ID);
                return View(task_milestone);
            }
            else
            {
                ViewBag.Error = "This Task already has that Milestone assigned to them. Did you not mean to choose a different Task.";
                ViewBag.Milestone_ID = new SelectList(db.milestones, "Milestone_ID", "Milestone_Name", task_milestone.Milestone_ID);
                ViewBag.Task_ID = new SelectList(db.tasks, "Task_ID", "Task_Name", task_milestone.Task_ID);
                return View(task_milestone);
            }

           
        }

        // GET: task_milestone/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            task_milestone task_milestone = db.task_milestone.Find(id);
            if (task_milestone == null)
            {
                return HttpNotFound();
            }
            ViewBag.Milestone_ID = new SelectList(db.milestones, "Milestone_ID", "Milestone_Name", task_milestone.Milestone_ID);
            ViewBag.Task_ID = new SelectList(db.tasks, "Task_ID", "Task_Name", task_milestone.Task_ID);
            return View(task_milestone);
        }

        // POST: task_milestone/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Task_ID,Milestone_ID,Task_Repetion")] task_milestone task_milestone)
        {
            if (ModelState.IsValid)
            {
                db.Entry(task_milestone).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Milestone_ID = new SelectList(db.milestones, "Milestone_ID", "Milestone_Name", task_milestone.Milestone_ID);
            ViewBag.Task_ID = new SelectList(db.tasks, "Task_ID", "Task_Name", task_milestone.Task_ID);
            return View(task_milestone);
        }

        // GET: task_milestone/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            task_milestone task_milestone = db.task_milestone.Find(id);
            if (task_milestone == null)
            {
                return HttpNotFound();
            }
            return View(task_milestone);
        }

        // POST: task_milestone/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, audit_trail audit)
        {
            task_milestone task_milestone = db.task_milestone.Find(id);

            var userId = System.Web.HttpContext.Current.Session["UserID"] as String;
            int IntID = Convert.ToInt32(userId);

            audit.Employee_ID = IntID;
            audit.Trail_DateTime = DateTime.Now.Date;
            audit.Deleted_Record = "Mileston ID: " + task_milestone.Milestone_ID.ToString() + " Task ID: " + task_milestone.Task_ID.ToString() + " Task Repetion: " + task_milestone.Task_Repetion.ToString();
            audit.Trail_Description = "Deleted a Task Milestone";

            db.audit_trail.Add(audit);

            db.task_milestone.Remove(task_milestone);
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
