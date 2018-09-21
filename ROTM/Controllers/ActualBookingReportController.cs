using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ROTM.Controllers
{
    [Authorize]
    public class ActualBookingReportController : Controller
    {
        private Entities db = new Entities();
        // GET: ActualBookingReport
        public ActionResult Index()
        {
            var employee = db.employees.ToList();
            return View(employee);
        }

        public ActionResult ExportActualBookings()
        {
            List<employee> allEmployees = new List<employee>();
            allEmployees = db.employees.ToList();

            PropertyDescriptorCollection properties =
            TypeDescriptor.GetProperties(typeof(employee));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
            table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (employee item in allEmployees)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }



            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Reporting"), "ActualBookingsReport.rpt"));
            
            rd.SetDataSource(table);
            rd.ReadRecords();
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();


            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/pdf", "ActualBookingsReport.pdf");
        }

    }
}