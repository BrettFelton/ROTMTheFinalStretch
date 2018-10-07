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
    public class tasksController : Controller
    {
        private Entities db = new Entities();

        // GET: tasks
        public ActionResult Index(string searchString)
        {
            var tasks = from s in (db.tasks) select s;


            if (!String.IsNullOrEmpty(searchString))
            {
                tasks = tasks.Where(s => s.Task_Name.Contains(searchString) || s.Task_Description.Contains(searchString));
            }

            return View(tasks.ToList());
        }

        // GET: tasks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            task task = db.tasks.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        // GET: tasks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tasks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Task_ID,Task_Name,Task_Description")] task task)
        {
            bool val = Validate(task.Task_Name);
            if (ModelState.IsValid && val == false)
            {
                db.tasks.Add(task);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else if (val == true)
            {
                ViewBag.StatusMessage = "There is already a task called: " + task.Task_Name + "  in the database.";
                return View();
            }

            return View(task);
        }

        // GET: tasks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            task task = db.tasks.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        // POST: tasks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Task_ID,Task_Name,Task_Description")] task task)
        {
            bool val = db.tasks.Any(s => s.Task_Name == task.Task_Name && s.Task_ID != task.Task_ID);
            if (ModelState.IsValid && val == false)
            {
                db.Entry(task).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else if (val == true)
            {
                ViewBag.StatusMessage = "There is already a task called: " + task.Task_Name + "  in the database.";
                return View();
            }
            return View(task);
        }

        // GET: tasks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            task task = db.tasks.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        // POST: tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, audit_trail audit)
        {
            var check = db.tasks.Where(s => s.Task_ID == id).FirstOrDefault();
            if (check == null)
            {
                task task = db.tasks.Find(id);

                var userId = System.Web.HttpContext.Current.Session["UserID"] as String;
                int IntID = Convert.ToInt32(userId);

                audit.Employee_ID = IntID;
                audit.Trail_DateTime = DateTime.Now.Date;
                audit.Deleted_Record = task.Task_ID.ToString() + " " + task.Task_Name + " " + task.Task_Description;
                audit.Trail_Description = "Deleted a Task.";

                db.audit_trail.Add(audit);

                db.tasks.Remove(task);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                task task = db.tasks.Find(id);
                ViewBag.Error = "Can't delete a type that is in-use please add a new type instead, or delete all employees related to this type first.";
                return View(task);
            }

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public bool Validate(string stri)
        {
            //var employees = from s in (db.employees.Include(e => e.address).Include(e => e.employee_type).Include(e => e.gender).Include(e => e.title)) select s;
            var checkT = (from s in (db.tasks) where s.Task_Name == stri select s).FirstOrDefault();
            if (checkT != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
