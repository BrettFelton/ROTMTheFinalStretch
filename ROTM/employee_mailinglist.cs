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

    public partial class employee_mailinglist
    {
        [Display(Name = "Employee Name")]
        public int Employee_ID { get; set; }

        [Display(Name = "Mailing List Name")]
        public int Mailing_List_ID { get; set; }

        [Required]
        [Display(Name = "Employee Mailing List Description")]
        [StringLength(255)]
        public string Description { get; set; }
    
        public virtual employee employee { get; set; }
        public virtual mailing_list mailing_list { get; set; }
    }
}
