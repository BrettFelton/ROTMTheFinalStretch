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
    public class mailing_listController : Controller
    {
        private Entities db = new Entities();

        // GET: mailing_list
        public ActionResult Index()
        {
            return View(db.mailing_list.ToList());
        }

        // GET: mailing_list/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mailing_list mailing_list = db.mailing_list.Find(id);
            if (mailing_list == null)
            {
                return HttpNotFound();
            }
            return View(mailing_list);
        }

        // GET: mailing_list/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: mailing_list/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Mailing_List_ID,Mailing_List_Name,Mailing_List_Description")] mailing_list mailing_list)
        {
            if (ModelState.IsValid)
            {
                db.mailing_list.Add(mailing_list);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mailing_list);
        }

        // GET: mailing_list/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mailing_list mailing_list = db.mailing_list.Find(id);
            if (mailing_list == null)
            {
                return HttpNotFound();
            }
            return View(mailing_list);
        }

        // POST: mailing_list/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Mailing_List_ID,Mailing_List_Name,Mailing_List_Description")] mailing_list mailing_list)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mailing_list).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mailing_list);
        }

        // GET: mailing_list/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mailing_list mailing_list = db.mailing_list.Find(id);
            if (mailing_list == null)
            {
                return HttpNotFound();
            }
            return View(mailing_list);
        }

        // POST: mailing_list/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var check = db.mailing_list.Where(s => s.Mailing_List_ID == id).FirstOrDefault();

            if (check == null)
            {
                mailing_list mailing_list = db.mailing_list.Find(id);
                db.mailing_list.Remove(mailing_list);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                mailing_list mailing_list = db.mailing_list.Find(id);
                ViewBag.Error = "Can't delete a mailing list that is in-use please add a new mailing list instead.";
                return View(mailing_list);
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
