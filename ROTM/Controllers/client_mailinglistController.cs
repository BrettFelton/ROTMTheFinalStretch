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
    public class client_mailinglistController : Controller
    {
        private Entities db = new Entities();

        // GET: client_mailinglist
        public ActionResult Index()
        {
            var client_mailinglist = db.client_mailinglist.Include(c => c.client).Include(c => c.mailing_list);
            return View(client_mailinglist.ToList());
        }

        // GET: client_mailinglist/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            client_mailinglist client_mailinglist = db.client_mailinglist.Find(id);
            if (client_mailinglist == null)
            {
                return HttpNotFound();
            }
            return View(client_mailinglist);
        }

        // GET: client_mailinglist/Create
        public ActionResult Create()
        {
            ViewBag.Client_ID = new SelectList(db.clients, "Client_ID", "Client_Name");
            ViewBag.Mailing_List_ID = new SelectList(db.mailing_list, "Mailing_List_ID", "Mailing_List_Name");
            return View();
        }

        // POST: client_mailinglist/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Client_ID,Mailing_List_ID,Description")] client_mailinglist client_mailinglist)
        {
            if (ModelState.IsValid)
            {

               // List<client> clientEmail = db.clients.ToList();
               //// var fileName = @"c:\test.pdf";

               // foreach (var clientE in clientEmail)
               // {
               //     MailMessage mail = new MailMessage("no-reply@repsonthemove.com", clientE.Client_Email);
               //     SmtpClient client = new SmtpClient();
               //     client.Port = 25;
               //     client.DeliveryMethod = SmtpDeliveryMethod.Network;
               //     client.Credentials = new System.Net.NetworkCredential("no-reply@repsonthemove.com", "k1Yvi2&5");
               //     client.Host = "nl1-wss2.a2hosting.com";
               //     mail.Subject = "External Mailing List";
               //    // mail.Attachments.Add(new Attachment(fileName));
               //     mail.Body = "Hi " + clientE.Client_Name + "\n\n"+ client_mailinglist.Description + "\n\nRegards" + "\nReps On The Move Team";
               //     client.Send(mail);
               // }

                //db.client_mailinglist.Add(client_mailinglist);
                //db.SaveChanges();
                return RedirectToAction("Index" ,"Home");
            }

            ViewBag.Client_ID = new SelectList(db.clients, "Client_ID", "Client_Name", client_mailinglist.Client_ID);
            ViewBag.Mailing_List_ID = new SelectList(db.mailing_list, "Mailing_List_ID", "Mailing_List_Name", client_mailinglist.Mailing_List_ID);
            return View(client_mailinglist);
        }

        // GET: client_mailinglist/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            client_mailinglist client_mailinglist = db.client_mailinglist.Find(id);
            if (client_mailinglist == null)
            {
                return HttpNotFound();
            }
            ViewBag.Client_ID = new SelectList(db.clients, "Client_ID", "Client_Name", client_mailinglist.Client_ID);
            ViewBag.Mailing_List_ID = new SelectList(db.mailing_list, "Mailing_List_ID", "Mailing_List_Name", client_mailinglist.Mailing_List_ID);
            return View(client_mailinglist);
        }

        // POST: client_mailinglist/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Client_ID,Mailing_List_ID,Description")] client_mailinglist client_mailinglist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(client_mailinglist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Client_ID = new SelectList(db.clients, "Client_ID", "Client_Name", client_mailinglist.Client_ID);
            ViewBag.Mailing_List_ID = new SelectList(db.mailing_list, "Mailing_List_ID", "Mailing_List_Name", client_mailinglist.Mailing_List_ID);
            return View(client_mailinglist);
        }

        // GET: client_mailinglist/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            client_mailinglist client_mailinglist = db.client_mailinglist.Find(id);
            if (client_mailinglist == null)
            {
                return HttpNotFound();
            }
            return View(client_mailinglist);
        }

        // POST: client_mailinglist/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            client_mailinglist client_mailinglist = db.client_mailinglist.Find(id);
            db.client_mailinglist.Remove(client_mailinglist);
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
