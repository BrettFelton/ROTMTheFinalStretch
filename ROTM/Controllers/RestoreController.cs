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

            string p = Path.GetExtension(fileUploader.FileName).ToLower();

            //return View();
            string file = fileUploader.FileName;
            if (p == ".sql")
            {
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
                                try
                                {
                                    mb.ImportFromFile(sourcepath);
                                }
                                catch (Exception e)
                                {
                                    ViewBag.Error = "Restore failed because of: " + e;
                                    return View();
                                }

                                conn.Close();

                                ViewBag.Success = "Database has been successfully restored.";

                                return View();
                            }
                            catch (Exception)
                            {
                                ViewBag.Error = "Couldn't Connect to the database.";
                                return View();
                            }

                        }
                    }
                }
            }
            else
            {
                ViewBag.Error = "Not a supported file format. Please Upload a .sql file that you have downloaded from Backup.";
                return View();
            }
        }
    }
}