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

    public partial class registration_token
    {
        public int Registration_Token_ID { get; set; }

        [Display(Name = "Registration Token")]
        [StringLength(40)]
        public string Registration_Token1 { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string New_Email { get; set; }

        [Display(Name = "Access Level")]
        public Nullable<int> Access_Level_ID { get; set; }

        [Display(Name = "Employee")]
        public Nullable<int> Employee_ID { get; set; }

        public virtual access_level access_level { get; set; }
        public virtual employee employee { get; set; }
    }
}
