using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ROTM.Models
{
    public class ReportingViewModel
    {
    }

    public class QuoteAndOrderReportViewModel
    {
        [Display(Name = "Date: ")]
        [DataType(DataType.Date)]
        public DateTime? fromDate { get; set; }
    }

    public class WeeklyProgressReportViewModel
    {
        [Display(Name = "Employee Name")]
        public int Employee_ID { get; set; }
    }

    public class TrainingReportViewModel
    {
        [Display(Name = "Employee Name")]
        public int Employee_ID { get; set; }
    }

    public class ProjectedBookingsViewModel
    {
        [Display(Name = "Employee Name")]
        public int Employee_ID { get; set; }
    }
    
    public class ActualBookingsReportViewModel
    {
        [Display(Name = "Employee Name")]
        public int Employee_ID { get; set; }
    }
}