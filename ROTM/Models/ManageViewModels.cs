using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace ROTM.Models
{
    public class IndexViewModel
    {
        public bool HasPassword { get; set; }
        public bool HasAddress { get; set; }
        public IList<UserLoginInfo> Logins { get; set; }
        public string PhoneNumber { get; set; }
        public bool TwoFactor { get; set; }
        public bool BrowserRemembered { get; set; }

        public string filepath { get; set; }
    }

    public class ProfilePicture
    {
        [Required(ErrorMessage = "Please select file.")]
        [Display(Name = "Browse File")]
        public HttpPostedFileBase files { get; set; }
    }

    public class UpdateProfileAddress : address
    {
        //[Required]
        //[Display(Name = "Street Name")]
        //[StringLength(50)]
        //public string Street_Name { get; set; }

        //[Required]
        //[Display(Name = "Suburb")]
        //[StringLength(50)]
        //public string Suburb { get; set; }

        //[Required]
        //[Display(Name = "City")]
        //[StringLength(50)]
        //public string City { get; set; }

        //[Required]
        //[Display(Name = "Province")]
        //[StringLength(50)]
        //public string Province { get; set; }

        //[Required]
        //[Display(Name = "Country")]
        //[StringLength(50)]
        //public string Country { get; set; }
    }


    public class UpdateProfileDetails
    {
        [Required]
        [Display(Name = "Employee Name")]
        [StringLength(50)]
        public string Name { get; set; }

        [Display(Name = "Employee Surname")]
        [StringLength(50)]
        public string Surname { get; set; }

        [Display(Name = "Home Phone Number")]
        [Phone]
        public string Home_Phone { get; set; }

        [Display(Name = "Cell Phone Number")]
        [Phone]
        public string Cell_Phone { get; set; }

        [Display(Name = "RSA ID")]
        [StringLength(13)]
        public string RSA_ID { get; set; }

        [Display(Name = "Employee Type")]
        public Nullable<int> Employee_Type_ID { get; set; }

        [Display(Name = "Gender")]
        public Nullable<int> Gender_ID { get; set; }

        [Display(Name = "Title")]
        public Nullable<int> Title_ID { get; set; }

        public virtual employee_type employee_type { get; set; }
        public virtual gender gender { get; set; }
        public virtual title title { get; set; }
    }

    public class ManageLoginsViewModel
    {
        public IList<UserLoginInfo> CurrentLogins { get; set; }
        public IList<AuthenticationDescription> OtherLogins { get; set; }
    }

    public class FactorViewModel
    {
        public string Purpose { get; set; }
    }

    public class SetPasswordViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class AddPhoneNumberViewModel
    {
        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string Number { get; set; }
    }

    public class VerifyPhoneNumberViewModel
    {
        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
    }

    public class ConfigureTwoFactorViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
    }
}