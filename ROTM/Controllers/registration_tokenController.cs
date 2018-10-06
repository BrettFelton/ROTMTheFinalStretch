﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using ROTM;

namespace ROTM.Controllers
{
    [Authorize]
    public class registration_tokenController : Controller
    {
        private Entities db = new Entities();

        // GET: registration_token
        public ActionResult Index()
        {
            var registration_token = db.registration_token.Include(r => r.access_level).Include(r => r.employee);
            return View(registration_token.ToList());
        }

        // GET: registration_token/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            registration_token registration_token = db.registration_token.Find(id);
            if (registration_token == null)
            {
                return HttpNotFound();
            }
            return View(registration_token);
        }

        // GET: registration_token/Create
        public ActionResult Create()
        {
            ViewBag.Access_Level_ID = new SelectList(db.access_level, "Access_Level_ID", "Access_Level_Name");
            ViewBag.Employee_ID = new SelectList(db.employees, "Employee_ID", "Employee_Name");
            return View();
        }

        // POST: registration_token/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Registration_Token_ID,Registration_Token1,New_Email,Access_Level_ID,Employee_ID")] registration_token registration_token)
        {
            //New Token
            RNGCryptoServiceProvider rngCryptoServiceProvider = new RNGCryptoServiceProvider();
            byte[] randomBytes = new byte[6];
            rngCryptoServiceProvider.GetBytes(randomBytes);


            bool val = Validate(registration_token.New_Email);

            if (ModelState.IsValid && val == false)
            {
                registration_token.Registration_Token1 = Convert.ToBase64String(randomBytes);
                registration_token.Employee_ID = null;
                db.registration_token.Add(registration_token);
                db.SaveChanges();

                //info@repsonthemove.com upg$H101
                //This is for an emal service Remeber this !
                MailMessage mail = new MailMessage("no-reply@repsonthemove.com", registration_token.New_Email);
                SmtpClient client = new SmtpClient();
                client.Port = 25;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Credentials = new System.Net.NetworkCredential("no-reply@repsonthemove.com", "k1Yvi2&5");
                client.Host = "nl1-wss2.a2hosting.com";
                mail.Subject = "Registration Token";
                mail.Body = "Hi there! \n\n You have registered with email address: " + registration_token.New_Email + "\n\nHere is you registration token: " + Convert.ToBase64String(randomBytes) + "\n\nRegards" + "\nReps On The Move Team";
                client.Send(mail);


                return RedirectToAction("Index");
            }
            else if (val == true)
            {
                ViewBag.Access_Level_ID = new SelectList(db.access_level, "Access_Level_ID", "Access_Level_Name", registration_token.Access_Level_ID);
                ViewBag.Employee_ID = new SelectList(db.employees, "Employee_ID", "Employee_Name", registration_token.Employee_ID);
                ViewBag.StatusMessage = "There is already an: " + registration_token.New_Email + " email address registered for a access token.";
                return View();
            }

            ViewBag.Access_Level_ID = new SelectList(db.access_level, "Access_Level_ID", "Access_Level_Name", registration_token.Access_Level_ID);
            ViewBag.Employee_ID = new SelectList(db.employees, "Employee_ID", "Employee_Name", registration_token.Employee_ID);
            return View(registration_token);
        }

        // GET: registration_token/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            registration_token registration_token = db.registration_token.Find(id);
            if (registration_token == null)
            {
                return HttpNotFound();
            }
            ViewBag.Access_Level_ID = new SelectList(db.access_level, "Access_Level_ID", "Access_Level_Name", registration_token.Access_Level_ID);
            ViewBag.Employee_ID = new SelectList(db.employees, "Employee_ID", "Employee_Name", registration_token.Employee_ID);
            return View(registration_token);
        }

        // POST: registration_token/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Registration_Token_ID,Registration_Token1,New_Email,Access_Level_ID,Employee_ID")] registration_token registration_token)
        {
            //Validation for duplicate emails
            bool val = db.registration_token.Any(s => s.New_Email == registration_token.New_Email && s.Registration_Token_ID != registration_token.Registration_Token_ID);
            if (ModelState.IsValid && val == false)
            {
                db.Entry(registration_token).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else if (val == true)
            {
                ViewBag.Access_Level_ID = new SelectList(db.access_level, "Access_Level_ID", "Access_Level_Name", registration_token.Access_Level_ID);
                ViewBag.Employee_ID = new SelectList(db.employees, "Employee_ID", "Employee_Name", registration_token.Employee_ID);
                ViewBag.StatusMessage = "There is already an: " + registration_token.New_Email + " email address registered for a access token.";
                return View();
            }
            ViewBag.Access_Level_ID = new SelectList(db.access_level, "Access_Level_ID", "Access_Level_Name", registration_token.Access_Level_ID);
            ViewBag.Employee_ID = new SelectList(db.employees, "Employee_ID", "Employee_Name", registration_token.Employee_ID);
            return View(registration_token);
        }

        // GET: registration_token/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            registration_token registration_token = db.registration_token.Find(id);
            if (registration_token == null)
            {
                return HttpNotFound();
            }
            return View(registration_token);
        }

        // POST: registration_token/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            registration_token registration_token = db.registration_token.Find(id);
            db.registration_token.Remove(registration_token);
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

        public bool Validate(string stri)
        {
            //var employees = from s in (db.employees.Include(e => e.address).Include(e => e.employee_type).Include(e => e.gender).Include(e => e.title)) select s;
            var checkTC = (from s in (db.registration_token) where s.New_Email == stri select s).FirstOrDefault();
            if (checkTC != null)
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