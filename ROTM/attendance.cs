//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ROTM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class attendance
    {
        [Display(Name = "Traning Course ID")]
        public int Training_Course_Instance_ID { get; set; }

        [Display(Name = "Employee Name")]
        public int Employee_ID { get; set; }

        [Display(Name = "Replied Going")]
        public bool Replied_Going { get; set; }

        [Display(Name = "Actual Attendance")]
        public bool Actual_Attendance { get; set; }

        public virtual employee employee { get; set; }
        public virtual training_course_instance training_course_instance { get; set; }
    }
}
