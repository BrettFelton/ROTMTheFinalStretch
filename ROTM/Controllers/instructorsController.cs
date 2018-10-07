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
    public class instructorsController : Controller
    {
        private Entities db = new Entities();

        // GET: instructors
        public ActionResult Index(string searchString)
        {
            var instructors = from s in (db.instructors.Include(i => i.employee).Include(i => i.gender).Include(i => i.title).Include(i => i.instructor_type)) select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                instructors = instructors.Where(s => s.Instructor_Name.Contains(searchString) || s.employee.Employee_Name.Contains(searchString) || s.gender.Gender1.Contains(searchString) || s.title.Title1.Contains(searchString)
                || s.instructor_type.Instructor_Type_Name.Contains(searchString) || s.Instructor_Surname.Contains(searchString) || s.Instructor_Email.Contains(searchString));
            }
            //var instructors = db.instructors.Include(i => i.employee).Include(i => i.gender).Include(i => i.title).Include(i => i.instructor_type);
            return View(instructors.ToList());
        }

        // GET: instructors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            instructor instructor = db.instructors.Find(id);
            if (instructor == null)
            {
                return HttpNotFound();
            }
            return View(instructor);
        }

        // GET: instructors/Create
        public ActionResult Create()
        {
            ViewBag.Employee_ID = new SelectList(db.employees, "Employee_ID", "Employee_Name");
            ViewBag.Gender_ID = new SelectList(db.genders, "Gender_ID", "Gender1");
            ViewBag.Title_ID = new SelectList(db.titles, "Title_ID", "Title1");
            ViewBag.Instructor_Type_ID = new SelectList(db.instructor_type, "Instructor_Type_ID", "Instructor_Type_Name");
            return View();
        }

        // POST: instructors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Instructor_ID,Instructor_Name,Instructor_Surname,Instructor_Email,Instructor_Cellphone,Employee_ID,Instructor_Type_ID,Title_ID,Gender_ID")] instructor instructor)
        {
            bool val = Validate(instructor.Instructor_Email);
            if (ModelState.IsValid && val == false)
            {
                db.instructors.Add(instructor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else if (val == true)
            {
                ViewBag.StatusMessage = "There is already an instructor with email: " + instructor.Instructor_Email + "  in the database.";

                ViewBag.Employee_ID = new SelectList(db.employees, "Employee_ID", "Employee_Name", instructor.Employee_ID);
                ViewBag.Gender_ID = new SelectList(db.genders, "Gender_ID", "Gender1", instructor.Gender_ID);
                ViewBag.Title_ID = new SelectList(db.titles, "Title_ID", "Title1", instructor.Title_ID);
                ViewBag.Instructor_Type_ID = new SelectList(db.instructor_type, "Instructor_Type_ID", "Instructor_Type_Name", instructor.Instructor_Type_ID);
                return View();
            }

            ViewBag.Employee_ID = new SelectList(db.employees, "Employee_ID", "Employee_Name", instructor.Employee_ID);
            ViewBag.Gender_ID = new SelectList(db.genders, "Gender_ID", "Gender1", instructor.Gender_ID);
            ViewBag.Title_ID = new SelectList(db.titles, "Title_ID", "Title1", instructor.Title_ID);
            ViewBag.Instructor_Type_ID = new SelectList(db.instructor_type, "Instructor_Type_ID", "Instructor_Type_Name", instructor.Instructor_Type_ID);
            return View(instructor);
        }

        // GET: instructors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            instructor instructor = db.instructors.Find(id);
            if (instructor == null)
            {
                return HttpNotFound();
            }
            ViewBag.Employee_ID = new SelectList(db.employees, "Employee_ID", "Employee_Name", instructor.Employee_ID);
            ViewBag.Gender_ID = new SelectList(db.genders, "Gender_ID", "Gender1", instructor.Gender_ID);
            ViewBag.Title_ID = new SelectList(db.titles, "Title_ID", "Title1", instructor.Title_ID);
            ViewBag.Instructor_Type_ID = new SelectList(db.instructor_type, "Instructor_Type_ID", "Instructor_Type_Name", instructor.Instructor_Type_ID);
            return View(instructor);
        }

        // POST: instructors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Instructor_ID,Instructor_Name,Instructor_Surname,Instructor_Email,Instructor_Cellphone,Employee_ID,Instructor_Type_ID,Title_ID,Gender_ID")] instructor instructor)
        {
            bool val = db.instructors.Any(s => s.Instructor_Email == instructor.Instructor_Email && s.Instructor_ID != instructor.Instructor_ID);
            if (ModelState.IsValid && val == false)
            {
                db.Entry(instructor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else if (val == true)
            {
                ViewBag.StatusMessage = "There is already an instructor with email: " + instructor.Instructor_Email + "  in the database.";

                ViewBag.Employee_ID = new SelectList(db.employees, "Employee_ID", "Employee_Name", instructor.Employee_ID);
                ViewBag.Gender_ID = new SelectList(db.genders, "Gender_ID", "Gender1", instructor.Gender_ID);
                ViewBag.Title_ID = new SelectList(db.titles, "Title_ID", "Title1", instructor.Title_ID);
                ViewBag.Instructor_Type_ID = new SelectList(db.instructor_type, "Instructor_Type_ID", "Instructor_Type_Name", instructor.Instructor_Type_ID);
                return View();
            }
            ViewBag.Employee_ID = new SelectList(db.employees, "Employee_ID", "Employee_Name", instructor.Employee_ID);
            ViewBag.Gender_ID = new SelectList(db.genders, "Gender_ID", "Gender1", instructor.Gender_ID);
            ViewBag.Title_ID = new SelectList(db.titles, "Title_ID", "Title1", instructor.Title_ID);
            ViewBag.Instructor_Type_ID = new SelectList(db.instructor_type, "Instructor_Type_ID", "Instructor_Type_Name", instructor.Instructor_Type_ID);
            return View(instructor);
        }

        // GET: instructors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            instructor instructor = db.instructors.Find(id);
            if (instructor == null)
            {
                return HttpNotFound();
            }
            return View(instructor);
        }

        // POST: instructors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, audit_trail audit)
        {
            var check = db.training_course_instance.Where(s => s.Instructor_ID == id).FirstOrDefault();

            if (check == null)
            {
                instructor instructor = db.instructors.Find(id);

                var userId = System.Web.HttpContext.Current.Session["UserID"] as String;
                int IntID = Convert.ToInt32(userId);

                audit.Employee_ID = IntID;
                audit.Trail_DateTime = DateTime.Now.Date;
                audit.Deleted_Record = "Instructor ID" + instructor.Instructor_ID.ToString() + " " + instructor.Instructor_Name + " " + instructor.Instructor_Surname + " " + instructor.Instructor_Cellphone + " " + instructor.Instructor_Email + " Type ID: " + instructor.Instructor_Type_ID.ToString();
                audit.Trail_Description = "Deleted a Instructor";

                db.audit_trail.Add(audit);

                db.instructors.Remove(instructor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                instructor instructor = db.instructors.Find(id);
                ViewBag.Error = "Can't delete a instructor that has given a training course, keep it as a record for historic purposes.";
                return View(instructor);
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
            var checkI = (from s in (db.instructors) where s.Instructor_Email == stri select s).FirstOrDefault();
            if (checkI != null)
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
