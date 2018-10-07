using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ROTM.Controllers
{
    public class RestoreController : Controller
    {
        // GET: Restore
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(HttpPostedFileBase fileUploader)
        {
            Entities nw = new Entities();

            string connection = nw.Database.Connection.ConnectionString;

            string fileName = Path.GetFileName(fileUploader.FileName);
            var sourcepath = Path.Combine(Server.MapPath("~/Restore/") + fileName);

            //return View();
            string file = fileUploader.FileName;

            using (MySqlConnection conn = new MySqlConnection(connection))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    using (MySqlBackup mb = new MySqlBackup(cmd))
                    {
                        try
                        {

                            fileUploader.SaveAs(sourcepath);
                            cmd.Connection = conn;
                            conn.Open();
                            mb.ImportFromFile(sourcepath);
                            conn.Close();

                            ViewBag.Success = "Database has been successfully restored.";

                            return View();
                        }
                        catch (Exception)
                        {
                            ViewBag.Error = "Couldn't Connect to the database.";
                            throw;
                        }
                       
                    }
                }
            }
        }
    }
}