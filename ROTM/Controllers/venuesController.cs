using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ROTM;
using ROTM.Models;

namespace ROTM.Controllers
{
    [Authorize]
    public class venuesController : Controller
    {
        private Entities db = new Entities();

        // GET: venues
        public ActionResult Index(string searchString)
        {
            var venues = from s in (db.venues.Include(v => v.address)) select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                venues = venues.Where(s => s.Venue_Name.Contains(searchString) || s.Venue_Description.Contains(searchString)
                /*|| s.Venue_Size == Convert.ToInt32(searchString)*/ || s.address.Street_Name.Contains(searchString) || s.address.Suburb.Contains(searchString) 
                || s.address.City.Contains(searchString) || s.address.Province.Contains(searchString) || s.address.Country.Contains(searchString));
            }

            //var venues = db.venues.Include(v => v.address);
            return View(venues.ToList());
        }

        // GET: venues/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            venue venue = db.venues.Find(id);
            if (venue == null)
            {
                return HttpNotFound();
            }
            return View(venue);
        }

        // GET: venues/Create
        public ActionResult Create()
        {
            //ViewBag.Address_ID = new SelectList(db.addresses, "Address_ID", "Street_Name");
            return View();
        }

        // POST: venues/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Venue_ID,Venue_Name,Venue_Description,Venue_Size")] venue venue, address address)
        {
            bool val = Validate(venue.Venue_Name);
            
            if (val == false)
            {
                db.addresses.Add(address);
                venue.Address_ID = address.Address_ID;
                db.venues.Add(venue);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else if (val == true)
            {
                //ViewBag.StatusMessage = "There is already a venue called: " + venue.Venue_Name + "  in the database.";

                ViewBag.Address_ID = new SelectList(db.addresses, "Address_ID", "Street_Name", venue.Address_ID);
                return View();
            }
            //ViewBag.Address_ID = new SelectList(db.addresses, "Address_ID", "Street_Name", venue.Address_ID);
            return View(venue);
        }

        // GET: venues/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            venue venue = db.venues.Find(id);
            if (venue == null)
            {
                return HttpNotFound();
            }
            //ViewBag.Address_ID = new SelectList(db.addresses, "Address_ID", "Street_Name", venue.Address_ID);
            return View(venue);
        }

        // POST: venues/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Venue_ID,Venue_Name,Venue_Description,Venue_Size,Address_ID")] venue venue, address address)
        {
            bool val = db.venues.Any(s => s.Venue_Name == venue.Venue_Name && s.Venue_ID != venue.Venue_ID);
            

            if (val == false)
            {
                //address.Address_ID = venue.Address_ID;
                db.Entry(address).State = EntityState.Modified;

                db.Entry(venue).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else if (val == true)
            {
                ViewBag.StatusMessage = "There is already a venue called: " + venue.Venue_Name + "  in the database.";

                ViewBag.Address_ID = new SelectList(db.addresses, "Address_ID", "Street_Name", venue.Address_ID);
                return View();
            }
            ViewBag.Address_ID = new SelectList(db.addresses, "Address_ID", "Street_Name", venue.Address_ID);
            return View(venue);
        }

        // GET: venues/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            venue venue = db.venues.Find(id);
            if (venue == null)
            {
                return HttpNotFound();
            }
            return View(venue);
        }

        // POST: venues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var check = db.training_course_instance.Where(s => s.Venue_ID == id).FirstOrDefault();

            if (check == null)
            {
                venue venue = db.venues.Find(id);
                address address = db.addresses.Find(venue.Address_ID);

                db.addresses.Remove(address);
                db.venues.Remove(venue);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Error = "Can't delete a venue that is in-use please add a new venue instead.";
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
            var checkV = (from s in (db.venues) where s.Venue_Name == stri select s).FirstOrDefault();
            if (checkV != null)
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
