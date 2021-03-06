﻿using CrystalDecisions.CrystalReports.Engine;
using ROTM.Models;
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
    public class QuoteAndOrderReportController : Controller
    {
        // GET: QuoteAndOrderReport
        private Entities db = new Entities();
        // GET: ActualBookingReport
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(QuoteAndOrderReportViewModel model)
        {
            //if (!model.fromDate.HasValue) model.fromDate = DateTime.Now.Date;

            List<quote> allqu = new List<quote>();
            allqu = db.quotes.Where(s => s.Quote_Date == model.fromDate).ToList();

            PropertyDescriptorCollection properties =
            TypeDescriptor.GetProperties(typeof(quote));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (quote item in allqu)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }


            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Reporting"), "QuoteAndOrderReport.rpt"));

            rd.SetDataSource(table);
            rd.ReadRecords();
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();


            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/pdf", "QuoteAndOrderReport.pdf");
        }
    }
}