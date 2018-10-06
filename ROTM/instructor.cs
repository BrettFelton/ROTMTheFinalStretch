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

    public partial class instructor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public instructor()
        {
            this.training_course_instance = new HashSet<training_course_instance>();
        }
    
        public int Instructor_ID { get; set; }

        [Required]
        [Display(Name = "Instructor Name")]
        [StringLength(50)]
        public string Instructor_Name { get; set; }

        [Required]
        [Display(Name = "Instructor Surname")]
        [StringLength(50)]
        public string Instructor_Surname { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Instructor Email")]
        public string Instructor_Email { get; set; }

        [Required]
        [Display(Name = "Instructor Cellphone")]
        [Phone]
        public string Instructor_Cellphone { get; set; }

        [Required]
        [Display(Name = "Employee Name")]
        public Nullable<int> Employee_ID { get; set; }

        [Required]
        [Display(Name = "Instructor Type Name")]
        public Nullable<int> Instructor_Type_ID { get; set; }

        [Required]
        [Display(Name = "Title")]
        public Nullable<int> Title_ID { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public int Gender_ID { get; set; }

        public virtual employee employee { get; set; }
        public virtual gender gender { get; set; }
        public virtual title title { get; set; }
        public virtual instructor_type instructor_type { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<training_course_instance> training_course_instance { get; set; }
    }
}