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

    public partial class marketing_type
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public marketing_type()
        {
            this.marketings = new HashSet<marketing>();
        }
    
        public int Marketing_Type_ID { get; set; }

        [Required]
        [Display(Name = "Marketing Name")]
        [StringLength(50)]
        public string Marketing_Name { get; set; }

        [Required]
        [Display(Name = "Marketing Description")]
        [StringLength(255)]
        public string Marketing_Description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<marketing> marketings { get; set; }
    }
}
