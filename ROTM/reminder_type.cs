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

    public partial class reminder_type
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public reminder_type()
        {
            this.reminders = new HashSet<reminder>();
        }
    
        public int Reminder_Type_ID { get; set; }

        [Required]
        [Display(Name = "Reminder Type Name")]
        [StringLength(50)]
        public string Reminder_Type_Name { get; set; }

        [Required]
        [Display(Name = "Reminder Type Description")]
        [StringLength(255)]
        public string Reminder_Type_Description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<reminder> reminders { get; set; }
    }
}
