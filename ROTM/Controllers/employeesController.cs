﻿using System;
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
    public class employeesController : Controller
    {
        private Entities db = new Entities();

        // GET: employees
        public ActionResult Index(string searchString)
        {
            ViewData["CurrentFilter"] = searchString;

            var employees = from s in (db.employees.Include(e => e.address).Include(e => e.employee_type).Include(e => e.gender).Include(e => e.title)) select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                employees = employees.Where(s => s.Employee_Name.Contains(searchString) || s.Employee_Surname.Contains(searchString) 
                || s.Employee_Email.Contains(searchString) || s.Employee_Home_Phone.Contains(searchString) || s.Employee_Cellphone.Contains(searchString) 
                || s.Employee_RSA_ID.Contains(searchString) || s.title.Title1.Contains(searchString) || s.gender.Gender1.Contains(searchString) || s.employee_type.Type_Name.Contains(searchString)
                || s.address.Street_Name.Contains(searchString) || s.address.Suburb.Contains(searchString) || s.address.City.Contains(searchString) || s.address.Province.Contains(searchString) || s.address.Country.Contains(searchString));
            }
            //var employees = db.employees.Include(e => e.address).Include(e => e.employee_type).Include(e => e.gender).Include(e => e.title);
            return View(employees.ToList());
        }

        // GET: employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employee employee = db.employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: employees/Create
        public ActionResult Create()
        {
            ViewBag.Address_ID = new SelectList(db.addresses, "Address_ID", "Street_Name");
            ViewBag.Employee_Type_ID = new SelectList(db.employee_type, "Employee_Type_ID", "Type_Name");
            ViewBag.Gender_ID = new SelectList(db.genders, "Gender_ID", "Gender1");
            ViewBag.Title_ID = new SelectList(db.titles, "Title_ID", "Title1");
            return View();
        }

        // POST: employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Employee_ID,Employee_Name,Employee_Surname,Employee_Email,Employee_Home_Phone,Employee_Cellphone,Employee_RSA_ID,Employee_Avatar,Employee_Type_ID,Encrypted_Password,Gender_ID,Address_ID,Title_ID")] employee employee)
        {
            if (ModelState.IsValid)
            {
                db.employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Address_ID = new SelectList(db.addresses, "Address_ID", "Street_Name", employee.Address_ID);
            ViewBag.Employee_Type_ID = new SelectList(db.employee_type, "Employee_Type_ID", "Type_Name", employee.Employee_Type_ID);
            ViewBag.Gender_ID = new SelectList(db.genders, "Gender_ID", "Gender1", employee.Gender_ID);
            ViewBag.Title_ID = new SelectList(db.titles, "Title_ID", "Title1", employee.Title_ID);
            return View(employee);
        }

        // GET: employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employee employee = db.employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.Address_ID = new SelectList(db.addresses, "Address_ID", "Street_Name", employee.Address_ID);
            ViewBag.Employee_Type_ID = new SelectList(db.employee_type, "Employee_Type_ID", "Type_Name", employee.Employee_Type_ID);
            ViewBag.Gender_ID = new SelectList(db.genders, "Gender_ID", "Gender1", employee.Gender_ID);
            ViewBag.Title_ID = new SelectList(db.titles, "Title_ID", "Title1", employee.Title_ID);
            return View(employee);
        }

        // POST: employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Employee_ID,Employee_Name,Employee_Surname,Employee_Email,Employee_Home_Phone,Employee_Cellphone,Employee_RSA_ID,Employee_Avatar,Employee_Type_ID,Encrypted_Password,Gender_ID,Address_ID,Title_ID")] employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Address_ID = new SelectList(db.addresses, "Address_ID", "Street_Name", employee.Address_ID);
            ViewBag.Employee_Type_ID = new SelectList(db.employee_type, "Employee_Type_ID", "Type_Name", employee.Employee_Type_ID);
            ViewBag.Gender_ID = new SelectList(db.genders, "Gender_ID", "Gender1", employee.Gender_ID);
            ViewBag.Title_ID = new SelectList(db.titles, "Title_ID", "Title1", employee.Title_ID);
            return View(employee);
        }

        // GET: employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employee employee = db.employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            employee employee = db.employees.Find(id);
            db.employees.Remove(employee);
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
