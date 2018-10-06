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

    public partial class audit_trail
    {
        public int Audit_Trail_ID { get; set; }

        [Display(Name = "Employee Name")]
        public Nullable<int> Employee_ID { get; set; }

        [Required]
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> Trail_DateTime { get; set; }

        [Required]
        [Display(Name = "Trail Description")]
        [StringLength(255)]
        public string Trail_Description { get; set; }

        [Required]
        [Display(Name = "Deleted Record")]
        [StringLength(255)]
        public string Deleted_Record { get; set; }
    
        public virtual employee employee { get; set; }
    }
}
