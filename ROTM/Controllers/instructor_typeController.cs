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
    public class instructor_typeController : Controller
    {
        private Entities db = new Entities();

        // GET: instructor_type
        public ActionResult Index()
        {
            return View(db.instructor_type.ToList());
        }

        // GET: instructor_type/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            instructor_type instructor_type = db.instructor_type.Find(id);
            if (instructor_type == null)
            {
                return HttpNotFound();
            }
            return View(instructor_type);
        }

        // GET: instructor_type/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: instructor_type/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Instructor_Type_ID,Instructor_Type_Name,Instrutor_Type_Description")] instructor_type instructor_type)
        {
            bool val = Validate(instructor_type.Instructor_Type_Name);
            if (ModelState.IsValid && val == false)
            {
                db.instructor_type.Add(instructor_type);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else if (val == true)
            {
                ViewBag.StatusMessage = "There is already an: " + instructor_type.Instructor_Type_Name + " type in the database.";
                return View();
            }
            return View(instructor_type);
        }

        // GET: instructor_type/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            instructor_type instructor_type = db.instructor_type.Find(id);
            if (instructor_type == null)
            {
                return HttpNotFound();
            }
            return View(instructor_type);
        }

        // POST: instructor_type/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Instructor_Type_ID,Instructor_Type_Name,Instrutor_Type_Description")] instructor_type instructor_type)
        {
            bool val = db.instructor_type.Any(s => s.Instructor_Type_Name == instructor_type.Instructor_Type_Name && s.Instructor_Type_ID != instructor_type.Instructor_Type_ID);
            if (ModelState.IsValid && val == false)
            {
                db.Entry(instructor_type).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else if (val == true)
            {
                ViewBag.StatusMessage = "There is already an: " + instructor_type.Instructor_Type_Name + " type in the database.";
                return View();
            }
            return View(instructor_type);
        }

        // GET: instructor_type/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            instructor_type instructor_type = db.instructor_type.Find(id);
            if (instructor_type == null)
            {
                return HttpNotFound();
            }
            return View(instructor_type);
        }

        // POST: instructor_type/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var check = db.instructors.Where(s => s.Instructor_Type_ID == id).FirstOrDefault();

            if (check == null)
            {
                instructor_type instructor_type = db.instructor_type.Find(id);
                db.instructor_type.Remove(instructor_type);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Error = "Can't delete a type that is in-use please add a new type instead, or delete all instructors related to this type first.";
                return View();
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
            var checkInstruc = (from s in (db.instructor_type) where s.Instructor_Type_Name == stri select s).FirstOrDefault();
            if (checkInstruc != null)
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
