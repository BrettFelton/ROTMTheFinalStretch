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

    public partial class employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public employee()
        {
            this.attendances = new HashSet<attendance>();
            this.audit_trail = new HashSet<audit_trail>();
            this.bookings = new HashSet<booking>();
            this.employee_client = new HashSet<employee_client>();
            this.employee_mailinglist = new HashSet<employee_mailinglist>();
            this.employee_milestone = new HashSet<employee_milestone>();
            this.instructors = new HashSet<instructor>();
            this.registration_token = new HashSet<registration_token>();
            this.training_course = new HashSet<training_course>();
        }
    
        public int Employee_ID { get; set; }

        [Required]
        [Display(Name = "Employee Name")]
        [StringLength(50)]
        public string Employee_Name { get; set; }

        [Display(Name = "Employee Surname")]
        [StringLength(50)]
        public string Employee_Surname { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Employee_Email { get; set; }

        [Display(Name = "Home Phone Number")]
        [Phone]
        public string Employee_Home_Phone { get; set; }

        [Display(Name = "Cell Phone Number")]
        [Phone]
        public string Employee_Cellphone { get; set; }

        [Display(Name = "RSA ID")]
        [StringLength(13)]
        public string Employee_RSA_ID { get; set; }

        [Display(Name = "Avatar")]
        [DataType(DataType.Upload)]
        public string Employee_Avatar { get; set; }
        public Nullable<int> Employee_Type_ID { get; set; }

        [Required]
        [StringLength(40, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Encrypted_Password { get; set; }

        [Display(Name = "Gender")]
        public Nullable<int> Gender_ID { get; set; }

        [Display(Name = "Address")]
        public Nullable<int> Address_ID { get; set; }

        [Display(Name = "Title")]
        public Nullable<int> Title_ID { get; set; }

        public virtual address address { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<attendance> attendances { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<audit_trail> audit_trail { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<booking> bookings { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<employee_client> employee_client { get; set; }
        public virtual employee_type employee_type { get; set; }
        public virtual gender gender { get; set; }
        public virtual title title { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<employee_mailinglist> employee_mailinglist { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<employee_milestone> employee_milestone { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<instructor> instructors { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<registration_token> registration_token { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<training_course> training_course { get; set; }
    }
}
