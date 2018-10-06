using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
            SqlConnection con = new SqlConnection();
            SqlCommand sqlcmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();

            con.ConnectionString = @"server = nl1 - wss2.a2hosting.com; user id = repso_Brett; persistsecurityinfo = True; database = repsont1_rotm";

            return View();
        }
    }
}