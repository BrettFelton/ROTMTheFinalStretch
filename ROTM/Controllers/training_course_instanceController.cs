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
    public class training_course_instanceController : Controller
    {
        private Entities db = new Entities();

        // GET: training_course_instance
        public ActionResult Index(string searchString, DateTime? fromDate, DateTime? toDate)
        {
            var training_course_instance = from s in (db.training_course_instance.Include(t => t.instructor).Include(t => t.training_course).Include(t => t.venue)) select s;

            if (!fromDate.HasValue) fromDate = DateTime.Now.Date;
            if (!toDate.HasValue) toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
            if (toDate < fromDate) toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);

            ViewBag.fromDate = String.Format("{0:yyyy/MM/dd}", fromDate);
            ViewBag.toDate = String.Format("{0:yyyy/MM/dd}", toDate); ;

            //Returns Name Search
            if (!String.IsNullOrEmpty(searchString))
            {
                training_course_instance = training_course_instance.Where(s => s.instructor.Instructor_Name.Contains(searchString) || s.training_course.Training_Course_Name.Contains(searchString) || s.venue.Venue_Name.Contains(searchString));

                return View(training_course_instance.ToList());
            }
            //Returns both Name and day search
            else if (!String.IsNullOrEmpty(searchString) && fromDate != null && toDate != null)
            {
                training_course_instance = training_course_instance.Where(s => s.instructor.Instructor_Name.Contains(searchString) || s.training_course.Training_Course_Name.Contains(searchString) || s.venue.Venue_Name.Contains(searchString) && (s.Instance_Date >= fromDate && s.Instance_Date <= toDate));

                return View(training_course_instance.ToList());
            }
            //Returns Day Search
            else if (fromDate != null && toDate != null)
            {
                var Meeting = db.training_course_instance.Where(c => c.Instance_Date >= fromDate && c.Instance_Date <= toDate).ToList();
                return View(Meeting);
            }


            //var training_course_instance = db.training_course_instance.Include(t => t.instructor).Include(t => t.training_course).Include(t => t.venue);
            return View();
        }

        // GET: training_course_instance/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            training_course_instance training_course_instance = db.training_course_instance.Find(id);
            if (training_course_instance == null)
            {
                return HttpNotFound();
            }
            return View(training_course_instance);
        }

        // GET: training_course_instance/Create
        public ActionResult Create()
        {
            ViewBag.Instructor_ID = new SelectList(db.instructors, "Instructor_ID", "Instructor_Name");
            ViewBag.Training_Course_ID = new SelectList(db.training_course, "Training_Course_ID", "Training_Course_Name");
            ViewBag.Venue_ID = new SelectList(db.venues, "Venue_ID", "Venue_Name");
            return View();
        }

        // POST: training_course_instance/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Training_Course_Instance_ID,Instance_Date,Instance_Start_Time,Instance_End_Time,Venue_ID,Instructor_ID,Training_Course_ID")] training_course_instance training_course_instance)
        {
            if (ModelState.IsValid)
            {
                TimeSpan end = new TimeSpan(22, 0, 0);
                TimeSpan start = new TimeSpan(02, 59, 0);
                bool val = db.training_course_instance.Any(s => s.Instance_Date == training_course_instance.Instance_Date
                && (s.Instructor_ID == training_course_instance.Instructor_ID || s.Venue_ID == training_course_instance.Venue_ID)
                &&
                //inside
                ((s.Instance_Start_Time <= training_course_instance.Instance_Start_Time && s.Instance_End_Time >= training_course_instance.Instance_End_Time)
                //outside
                || (s.Instance_Start_Time >= training_course_instance.Instance_Start_Time && s.Instance_End_Time <= training_course_instance.Instance_End_Time)
                //before start and after start
                || (s.Instance_Start_Time <= training_course_instance.Instance_Start_Time && training_course_instance.Instance_Start_Time <= s.Instance_End_Time)
                //befor end and after end
                || (s.Instance_Start_Time <= training_course_instance.Instance_End_Time && training_course_instance.Instance_End_Time <= s.Instance_End_Time)));

                bool time = training_course_instance.Instance_Start_Time <= start || training_course_instance.Instance_End_Time >= end;


                if (val == false && training_course_instance.Instance_Start_Time <= training_course_instance.Instance_End_Time && time == false)
                {
                    db.training_course_instance.Add(training_course_instance);
                    db.SaveChanges();
                    ViewBag.Instructor_ID = new SelectList(db.instructors, "Instructor_ID", "Instructor_Name", training_course_instance.Instructor_ID);
                    ViewBag.Training_Course_ID = new SelectList(db.training_course, "Training_Course_ID", "Training_Course_Name", training_course_instance.Training_Course_ID);
                    ViewBag.Venue_ID = new SelectList(db.venues, "Venue_ID", "Venue_Name", training_course_instance.Venue_ID);
                    return RedirectToAction("Index");
                }
                else if (training_course_instance.Instance_Start_Time >= training_course_instance.Instance_End_Time)
                {
                    ViewBag.Error = "The End time cannot be at the same time or an earlier time then the start time.";
                }
                else if (val == true)
                {
                    ViewBag.Error = "The training course cannot be booked because there is another training course at the same time, please try a different time, or the venue is already booked, or the instructor is already giving a lecture at that time.";
                }
                else if (time == true)
                {
                    ViewBag.Error = "The start time of a training course cannot start at any time between 00:00 and 02:59 and the end time of a training course cannot end at any time between 22:00 and 23:59.";
                }

                //db.training_course_instance.Add(training_course_instance);
                //db.SaveChanges();
                ViewBag.Instructor_ID = new SelectList(db.instructors, "Instructor_ID", "Instructor_Name", training_course_instance.Instructor_ID);
                ViewBag.Training_Course_ID = new SelectList(db.training_course, "Training_Course_ID", "Training_Course_Name", training_course_instance.Training_Course_ID);
                ViewBag.Venue_ID = new SelectList(db.venues, "Venue_ID", "Venue_Name", training_course_instance.Venue_ID);
                return View();
            }

            ViewBag.Instructor_ID = new SelectList(db.instructors, "Instructor_ID", "Instructor_Name", training_course_instance.Instructor_ID);
            ViewBag.Training_Course_ID = new SelectList(db.training_course, "Training_Course_ID", "Training_Course_Name", training_course_instance.Training_Course_ID);
            ViewBag.Venue_ID = new SelectList(db.venues, "Venue_ID", "Venue_Name", training_course_instance.Venue_ID);
            return View(training_course_instance);
        }

        // GET: training_course_instance/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            training_course_instance training_course_instance = db.training_course_instance.Find(id);
            if (training_course_instance == null)
            {
                return HttpNotFound();
            }
            ViewBag.Instructor_ID = new SelectList(db.instructors, "Instructor_ID", "Instructor_Name", training_course_instance.Instructor_ID);
            ViewBag.Training_Course_ID = new SelectList(db.training_course, "Training_Course_ID", "Training_Course_Name", training_course_instance.Training_Course_ID);
            ViewBag.Venue_ID = new SelectList(db.venues, "Venue_ID", "Venue_Name", training_course_instance.Venue_ID);
            return View(training_course_instance);
        }

        // POST: training_course_instance/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Training_Course_Instance_ID,Instance_Date,Instance_Start_Time,Instance_End_Time,Venue_ID,Instructor_ID,Training_Course_ID")] training_course_instance training_course_instance)
        {
            if (ModelState.IsValid)
            {
                TimeSpan end = new TimeSpan(22, 0, 0);
                TimeSpan start = new TimeSpan(02, 59, 0);
                bool val = db.training_course_instance.Any(s => s.Instance_Date == training_course_instance.Instance_Date
                && (s.Instructor_ID == training_course_instance.Instructor_ID || s.Venue_ID == training_course_instance.Venue_ID)
                &&
                //inside
                ((s.Instance_Start_Time <= training_course_instance.Instance_Start_Time && s.Instance_End_Time >= training_course_instance.Instance_End_Time)
                //outside
                || (s.Instance_Start_Time >= training_course_instance.Instance_Start_Time && s.Instance_End_Time <= training_course_instance.Instance_End_Time)
                //before start and after start
                || (s.Instance_Start_Time <= training_course_instance.Instance_Start_Time && training_course_instance.Instance_Start_Time <= s.Instance_End_Time)
                //befor end and after end
                || (s.Instance_Start_Time <= training_course_instance.Instance_End_Time && training_course_instance.Instance_End_Time <= s.Instance_End_Time))
                && s.Training_Course_Instance_ID != training_course_instance.Training_Course_Instance_ID);

                bool time = training_course_instance.Instance_Start_Time <= start || training_course_instance.Instance_End_Time >= end;


                if (val == false && training_course_instance.Instance_Start_Time <= training_course_instance.Instance_End_Time && time == false)
                {
                    db.Entry(training_course_instance).State = EntityState.Modified;
                    db.SaveChanges();
                    ViewBag.Instructor_ID = new SelectList(db.instructors, "Instructor_ID", "Instructor_Name", training_course_instance.Instructor_ID);
                    ViewBag.Training_Course_ID = new SelectList(db.training_course, "Training_Course_ID", "Training_Course_Name", training_course_instance.Training_Course_ID);
                    ViewBag.Venue_ID = new SelectList(db.venues, "Venue_ID", "Venue_Name", training_course_instance.Venue_ID);
                    return RedirectToAction("Index");
                }
                else if (training_course_instance.Instance_Start_Time >= training_course_instance.Instance_End_Time)
                {
                    ViewBag.Error = "The End time cannot be at the same time or an earlier time then the start time.";
                }
                else if (val == true)
                {
                    ViewBag.Error = "The training course cannot be booked because there is another training course at the same time, please try a different time, or the venue is already booked, or the instructor is already giving a lecture at that time.";
                }
                else if (time == true)
                {
                    ViewBag.Error = "The start time of a training course cannot start at any time between 00:00 and 02:59 and the end time of a training course cannot end at any time between 22:00 and 23:59.";
                }

                //db.training_course_instance.Add(training_course_instance);
                //db.SaveChanges();
                ViewBag.Instructor_ID = new SelectList(db.instructors, "Instructor_ID", "Instructor_Name", training_course_instance.Instructor_ID);
                ViewBag.Training_Course_ID = new SelectList(db.training_course, "Training_Course_ID", "Training_Course_Name", training_course_instance.Training_Course_ID);
                ViewBag.Venue_ID = new SelectList(db.venues, "Venue_ID", "Venue_Name", training_course_instance.Venue_ID);
                return View();            
            }
            ViewBag.Instructor_ID = new SelectList(db.instructors, "Instructor_ID", "Instructor_Name", training_course_instance.Instructor_ID);
            ViewBag.Training_Course_ID = new SelectList(db.training_course, "Training_Course_ID", "Training_Course_Name", training_course_instance.Training_Course_ID);
            ViewBag.Venue_ID = new SelectList(db.venues, "Venue_ID", "Venue_Name", training_course_instance.Venue_ID);
            return View(training_course_instance);
        }

        // GET: training_course_instance/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            training_course_instance training_course_instance = db.training_course_instance.Find(id);
            if (training_course_instance == null)
            {
                return HttpNotFound();
            }
            return View(training_course_instance);
        }

        // POST: training_course_instance/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, audit_trail audit)
        {
            

            var check = db.attendances.Where(s => s.Training_Course_Instance_ID == id).FirstOrDefault();

            if (check == null)
            {
                training_course_instance training_course_instance = db.training_course_instance.Find(id);
                var userId = System.Web.HttpContext.Current.Session["UserID"] as String;
                int IntID = Convert.ToInt32(userId);

                audit.Employee_ID = IntID;
                audit.Trail_DateTime = DateTime.Now.Date;
                audit.Deleted_Record = "Training Course ID: " + training_course_instance.Training_Course_ID.ToString() + " Instructor Course ID: " + training_course_instance.Instructor_ID.ToString() + " Venue ID: "
                    + training_course_instance.Venue_ID.ToString() + " Date:" + Convert.ToString(training_course_instance.Instance_Date) + " Start Time:" + Convert.ToString(training_course_instance.Instance_Start_Time)
                    + " End Time:" + Convert.ToString(training_course_instance.Instance_End_Time);
                audit.Trail_Description = "Deleted a Training Course Instance.";

                db.audit_trail.Add(audit);

                db.training_course_instance.Remove(training_course_instance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Error = "Cannot delete a training course instance that has sales rep attendance.";
                training_course_instance training_course_instance = db.training_course_instance.Find(id);
                return View(training_course_instance);
            }
           
        }

        // GET: training_course_instance/Delete/5
        public ActionResult CaptureSaleRepAttendance(int? id)
        {
            var attendances = db.attendances.Include(a => a.employee).Include(a => a.training_course_instance).Where(a => a.Training_Course_Instance_ID == id);
            return View(attendances.ToList());
        }

        // POST: training_course_instance/Delete/5
        //[HttpPost, ActionName("CaptureSaleRepAttendance")]
        //[ValidateAntiForgeryToken]
        //public ActionResult CaptureSaleRepAttendance([Bind(Include = "Training_Course_Instance_ID,Employee_ID,Replied_Going,Actual_Attendance")] attendance[] attendance)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        //attendance = db.attendances.Include(a => a.employee).Include(a => a.training_course_instance).Where(a => a.Training_Course_Instance_ID == id);
        //        //attendance.Actual_Attendance = attendance.Actual_Attendance;
        //        //db.Entry(attendance).State = EntityState.Modified;
        //        //db.SaveChanges();
        //        return RedirectToAction("EditSalesRepAttendance");
        //    }
        //    //ViewBag.Employee_ID = new SelectList(db.employees, "Employee_ID", "Employee_Name", attendance.Employee_ID);
        //    //ViewBag.Training_Course_Instance_ID = new SelectList(db.training_course_instance, "Training_Course_Instance_ID", "Training_Course_Instance_ID", attendance.Training_Course_Instance_ID);
        //    return View(attendance);
        //}

        // GET: attendances/Edit/5
        public ActionResult EditSalesRepAttendance(int? id, int? id2)
        {
            if (id == null && id2 == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var chkUser = (from s in db.attendances where s.Employee_ID == id && s.Training_Course_Instance_ID == id2 select s).FirstOrDefault();
            //attendance attendance = db.attendances.Where(s=> s.Employee_ID == id && s.Training_Course_Instance_ID == id2);
            if (chkUser == null)
            {
                return HttpNotFound();
            }
            ViewBag.Employee_ID = new SelectList(db.employees, "Employee_ID", "Employee_Name", chkUser.Employee_ID);
            ViewBag.Training_Course_Instance_ID = new SelectList(db.training_course_instance, "Training_Course_Instance_ID", "Training_Course_Instance_ID", chkUser.Training_Course_Instance_ID);
            return View(chkUser);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditSalesRepAttendance([Bind(Include = "Training_Course_Instance_ID,Employee_ID,Replied_Going,Actual_Attendance")] attendance attendance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(attendance).State = EntityState.Modified;
                db.SaveChanges();

                ViewBag.Success = "Sales rep attendance updated, Please click back to list.";

                return View(attendance);
                //return RedirectToAction("CaptureSaleRepAttendance",attendance.Training_Course_Instance_ID);
            }
            ViewBag.Employee_ID = new SelectList(db.employees, "Employee_ID", "Employee_Name", attendance.Employee_ID);
            ViewBag.Training_Course_Instance_ID = new SelectList(db.training_course_instance, "Training_Course_Instance_ID", "Training_Course_Instance_ID", attendance.Training_Course_Instance_ID);
            return View(attendance);
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
