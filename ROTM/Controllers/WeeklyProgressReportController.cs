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
    public class WeeklyProgressReportController : Controller
    {
        private Entities db = new Entities();
        // GET: ActualBookingReport
        public ActionResult Index()
        {
            ViewBag.Employee_ID = new SelectList(db.employees, "Employee_ID", "Employee_Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(WeeklyProgressReportViewModel model)
        {
            List<employee> allEmployees = new List<employee>();
            allEmployees = db.employees.Where(s => s.Employee_ID == model.Employee_ID).ToList();

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
            rd.Load(Path.Combine(Server.MapPath("~/Reporting"), "WeeklyProgressReport.rpt"));

            rd.SetDataSource(table);
            rd.ReadRecords();
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();

            ViewBag.Employee_ID = new SelectList(db.employees, "Employee_ID", "Employee_Name");

            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/pdf", "WeeklyProgressReport.pdf");



        }

    }
}