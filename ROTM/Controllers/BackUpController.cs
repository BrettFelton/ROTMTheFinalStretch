using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ROTM.Controllers
{
    public class BackUpController : Controller
    {
        // GET: BackUp
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(int? id)
        {
            Entities nw = new Entities();
            string date = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            string connection = nw.Database.Connection.ConnectionString;
            string connectionstring = "~/"+ date + "MyDumpFile.sql";
            string file = Server.MapPath(connectionstring);//"C:\\backup.sql";


            using (MySqlConnection conn = new MySqlConnection(connection))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    using (MySqlBackup mb = new MySqlBackup(cmd))
                    {
                        try
                        {
                            cmd.Connection = conn;
                            conn.Open();
                            mb.ExportToFile(file);
                            conn.Close();

                            ViewBag.Success = "Database has been backed up.";

                            byte[] fileBytes = GetFile(file); 

                            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, file); 

                        }
                        catch (Exception)
                        {
                            ViewBag.Success = "Database Couldn't connect, please check your internet connection";
                            return View();
                            throw;
                        }
                       
                    }
                }
            }

            byte[] GetFile(string s)
            {
                System.IO.FileStream fs = System.IO.File.OpenRead(s);
                byte[] data = new byte[fs.Length];
                int br = fs.Read(data, 0, data.Length);
                if (br != fs.Length)
                    throw new System.IO.IOException(s);
                return data;
            }
        }
    }
}