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

    public partial class client
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public client()
        {
            this.client_contact = new HashSet<client_contact>();
            this.client_mailinglist = new HashSet<client_mailinglist>();
            this.employee_client = new HashSet<employee_client>();
        }

        public int Client_ID { get; set; }
        [Required]
        [Display(Name = "Client Name")]
        [StringLength(50)]
        public string Client_Name { get; set; }

        [Required]
        [Display(Name = "Cell Phone Number")]
        [Phone]
        public string Client_Cellphone { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Client_Email { get; set; }

        [Display(Name = "Rating")]
        public Nullable<int> Client_Rating_ID { get; set; }

        [Display(Name = "Type")]
        public Nullable<int> Client_Type_ID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<client_contact> client_contact { get; set; }
        public virtual client_rating client_rating { get; set; }
        public virtual client_type client_type { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<client_mailinglist> client_mailinglist { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<employee_client> employee_client { get; set; }
    }
}
