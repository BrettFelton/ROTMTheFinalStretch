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
    public class access_levelController : Controller
    {
        private Entities db = new Entities();

        // GET: access_level
        public ActionResult Index()
        {
            return View(db.access_level.ToList());
        }

        // GET: access_level/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            access_level access_level = db.access_level.Find(id);
            if (access_level == null)
            {
                return HttpNotFound();
            }
            return View(access_level);
        }

        // GET: access_level/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: access_level/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Access_Level_ID,Access_Level_Name,Access_Level_Description")] access_level access_level)
        {
            if (ModelState.IsValid)
            {
                db.access_level.Add(access_level);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(access_level);
        }

        // GET: access_level/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            access_level access_level = db.access_level.Find(id);
            if (access_level == null)
            {
                return HttpNotFound();
            }
            return View(access_level);
        }

        // POST: access_level/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Access_Level_ID,Access_Level_Name,Access_Level_Description")] access_level access_level)
        {
            if (ModelState.IsValid)
            {
                db.Entry(access_level).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(access_level);
        }

        // GET: access_level/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            access_level access_level = db.access_level.Find(id);
            if (access_level == null)
            {
                return HttpNotFound();
            }
            return View(access_level);
        }

        // POST: access_level/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, audit_trail audit)
        {
            var check = db.employees.Where(s => s.Address_ID == id).FirstOrDefault();

            if (check == null)
            {
                access_level access_level = db.access_level.Find(id);

                var userId = System.Web.HttpContext.Current.Session["UserID"] as String;
                int IntID = Convert.ToInt32(userId);

                audit.Employee_ID = IntID;
                audit.Trail_DateTime = DateTime.Now.Date;
                audit.Deleted_Record = access_level.Access_Level_ID.ToString() + " " + access_level.Access_Level_Name + " " + access_level.Access_Level_Description ;
                audit.Trail_Description = "Deleted a Access Level";

                db.audit_trail.Add(audit);

                db.access_level.Remove(access_level);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                access_level access_level = db.access_level.Find(id);
                ViewBag.Error = "Can't delete a access level that is in-use please add a new access level instead.";
                return View(access_level);
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
    }
}
