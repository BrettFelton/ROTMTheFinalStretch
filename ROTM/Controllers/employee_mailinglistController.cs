using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using ROTM;

namespace ROTM.Controllers
{
    [Authorize]
    public class employee_mailinglistController : Controller
    {
        private Entities db = new Entities();

        // GET: employee_mailinglist
        public ActionResult Index()
        {
            var employee_mailinglist = db.employee_mailinglist.Include(e => e.employee).Include(e => e.mailing_list);
            return View(employee_mailinglist.ToList());
        }

        // GET: employee_mailinglist/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employee_mailinglist employee_mailinglist = db.employee_mailinglist.Find(id);
            if (employee_mailinglist == null)
            {
                return HttpNotFound();
            }
            return View(employee_mailinglist);
        }

        // GET: employee_mailinglist/Create
        public ActionResult Create()
        {
            ViewBag.Employee_ID = new SelectList(db.employees, "Employee_ID", "Employee_Name");
            ViewBag.Mailing_List_ID = new SelectList(db.mailing_list, "Mailing_List_ID", "Mailing_List_Name");
            return View();
        }

        // POST: employee_mailinglist/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Employee_ID,Mailing_List_ID,Description")] employee_mailinglist employee_mailinglist)
        {
            if (ModelState.IsValid)
            {

               // List<employee> employeeEmail = db.employees.ToList();
               //// var fileName = @"c:\test.pdf";

               // foreach (var employeeE in employeeEmail)
               // {
               //     MailMessage mail = new MailMessage("no-reply@repsonthemove.com", employeeE.Employee_Email);
               //     SmtpClient client = new SmtpClient();
               //     client.Port = 25;
               //     client.DeliveryMethod = SmtpDeliveryMethod.Network;
               //     client.Credentials = new System.Net.NetworkCredential("no-reply@repsonthemove.com", "k1Yvi2&5");
               //     client.Host = "nl1-wss2.a2hosting.com";
               //     mail.Subject = "Internal Mailing List";
               //    // mail.Attachments.Add(new Attachment(fileName));
               //     mail.Body = "Hi " + employeeE.Employee_Name+ " " + employeeE.Employee_Surname + "\n\n" + employee_mailinglist.Description + "\n\nRegards" + "\nReps On The Move Team";
               //     client.Send(mail);
               // }

                //db.employee_mailinglist.Add(employee_mailinglist);
                //db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Employee_ID = new SelectList(db.employees, "Employee_ID", "Employee_Name", employee_mailinglist.Employee_ID);
            ViewBag.Mailing_List_ID = new SelectList(db.mailing_list, "Mailing_List_ID", "Mailing_List_Name", employee_mailinglist.Mailing_List_ID);
            return View(employee_mailinglist);
        }

        // GET: employee_mailinglist/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employee_mailinglist employee_mailinglist = db.employee_mailinglist.Find(id);
            if (employee_mailinglist == null)
            {
                return HttpNotFound();
            }
            ViewBag.Employee_ID = new SelectList(db.employees, "Employee_ID", "Employee_Name", employee_mailinglist.Employee_ID);
            ViewBag.Mailing_List_ID = new SelectList(db.mailing_list, "Mailing_List_ID", "Mailing_List_Name", employee_mailinglist.Mailing_List_ID);
            return View(employee_mailinglist);
        }

        // POST: employee_mailinglist/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Employee_ID,Mailing_List_ID,Description")] employee_mailinglist employee_mailinglist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee_mailinglist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Employee_ID = new SelectList(db.employees, "Employee_ID", "Employee_Name", employee_mailinglist.Employee_ID);
            ViewBag.Mailing_List_ID = new SelectList(db.mailing_list, "Mailing_List_ID", "Mailing_List_Name", employee_mailinglist.Mailing_List_ID);
            return View(employee_mailinglist);
        }

        // GET: employee_mailinglist/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employee_mailinglist employee_mailinglist = db.employee_mailinglist.Find(id);
            if (employee_mailinglist == null)
            {
                return HttpNotFound();
            }
            return View(employee_mailinglist);
        }

        // POST: employee_mailinglist/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            employee_mailinglist employee_mailinglist = db.employee_mailinglist.Find(id);
            db.employee_mailinglist.Remove(employee_mailinglist);
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
