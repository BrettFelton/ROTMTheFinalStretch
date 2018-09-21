﻿﻿using System;
using System.Data.Entity;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using ROTM.Models;
using System.Net;

namespace ROTM.Controllers
{
    [Authorize]
    public class ManageController : Controller
    {
        private Entities db = new Entities();

        public ManageController()
        {
        }

        //
        // GET: /Manage/Index
        public ActionResult Index(ManageMessageId? message)
        {
            ViewBag.StatusMessage =
                message == ManageMessageId.ChangePasswordSuccess ? "Your password has been changed."
                : message == ManageMessageId.SetPasswordSuccess ? "Your password has been set."
                : message == ManageMessageId.SetTwoFactorSuccess ? "Your two-factor authentication provider has been set."
                : message == ManageMessageId.Error ? "An error has occurred."
                : message == ManageMessageId.AddPhoneSuccess ? "Your phone number was added."
                : message == ManageMessageId.RemovePhoneSuccess ? "Your phone number was removed."
                : message == ManageMessageId.UpdateProfileSuccess ? "Your profile has been updated."
                : message == ManageMessageId.UpdateAddressSuccess ? "Your address has been updated."
                : message == ManageMessageId.SetAddressSuccess ? "Your address has been added."
                : "";

            //var userId = User.Identity.GetUserId();
            var userId = System.Web.HttpContext.Current.Session["UserID"] as String;
            int IntID = Convert.ToInt32(userId);
            ViewBag.UserID = userId;

            var model = new IndexViewModel
            {
                HasPassword = HasPassword(IntID),
                //HasAddress = HasAddress(IntID)
                //PhoneNumber = await UserManager
                //.GetPhoneNumberAsync(userId),
                //TwoFactor = await UserManager.GetTwoFactorEnabledAsync(userId),
                //Logins = await UserManager.GetLoginsAsync(userId),
                //BrowserRemembered = await AuthenticationManager.TwoFactorBrowserRememberedAsync(userId)
            };
            return View(model);
            //return View("Index");
        }

        public ActionResult UpdateAddress()
        {
            var userId = System.Web.HttpContext.Current.Session["UserID"] as String;
            int IntID = Convert.ToInt32(userId);

            employee employee = db.employees.Find(IntID);
            address address = db.addresses.Find(employee.Address_ID);
            UpdateProfileAddress model = new UpdateProfileAddress();

            model.Street_Name = address.Street_Name;
            model.Suburb = address.Suburb;
            model.City = address.City;
            model.Province = address.Province;
            model.Country = address.Country;

            if (employee == null)
            {
                return HttpNotFound();
            }
            if (address == null)
            {
                return HttpNotFound();
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateAddress(UpdateProfileAddress model)
        {
            var userId = System.Web.HttpContext.Current.Session["UserID"] as String;
            int IntID = Convert.ToInt32(userId);

            employee employee = db.employees.Find(IntID);
            address address = db.addresses.Find(employee.Address_ID);

            address.Street_Name = model.Street_Name;
            address.Suburb = model.Suburb;
            address.City = model.City;
            address.Province = model.Province;
            address.Country = model.Country;

            db.Entry(address).State = EntityState.Modified;
            db.SaveChanges();


            return RedirectToAction("Index", new { Message = ManageMessageId.UpdateAddressSuccess });
        }

        public ActionResult SetAddress()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SetAddress(UpdateProfileAddress model)
        {
            var userId = System.Web.HttpContext.Current.Session["UserID"] as String;
            int IntID = Convert.ToInt32(userId);

            employee employee = db.employees.Find(IntID);
            //address address = db.addresses.Find(employee.Address_ID);
            

            db.addresses.Add(model);
            db.SaveChanges();

            address address = db.addresses.OrderByDescending(x => x.Address_ID).Take(1).ToList().FirstOrDefault();

            employee.Address_ID = address.Address_ID;
            db.Entry(employee).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index", new { Message = ManageMessageId.UpdateAddressSuccess });
        }


        public ActionResult UpdateProfile()
        {
            var userId = System.Web.HttpContext.Current.Session["UserID"] as String;
            int IntID = Convert.ToInt32(userId);

            employee employee = db.employees.Find(IntID);
            UpdateProfileDetails model = new UpdateProfileDetails();
            model.Name = employee.Employee_Name;
            model.Surname = employee.Employee_Surname;
            model.Home_Phone = employee.Employee_Home_Phone;
            model.Cell_Phone = employee.Employee_Cellphone;
            model.RSA_ID = employee.Employee_RSA_ID;
            model.Gender_ID = employee.Gender_ID;
            model.Employee_Type_ID = employee.Employee_Type_ID;
            model.Address_ID = employee.Address_ID;
            model.Title_ID = employee.Title_ID;

            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.Address_ID = new SelectList(db.addresses, "Address_ID", "Street_Name", employee.Address_ID);
            ViewBag.Employee_Type_ID = new SelectList(db.employee_type, "Employee_Type_ID", "Type_Name", employee.Employee_Type_ID);
            ViewBag.Gender_ID = new SelectList(db.genders, "Gender_ID", "Gender1", employee.Gender_ID);
            ViewBag.Title_ID = new SelectList(db.titles, "Title_ID", "Title1", employee.Title_ID);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateProfile(UpdateProfileDetails model)
        {
            var userId = System.Web.HttpContext.Current.Session["UserID"] as String;
            int IntID = Convert.ToInt32(userId);

            employee employee = db.employees.Find(IntID);

            employee.Employee_Name = model.Name;
            employee.Employee_Surname = model.Surname;
            employee.Employee_Home_Phone = model.Home_Phone;
            employee.Employee_Cellphone = model.Cell_Phone;
            employee.Employee_RSA_ID = model.RSA_ID;
            employee.Gender_ID = model.Gender_ID;
            employee.Employee_Type_ID = model.Employee_Type_ID;
            employee.Address_ID = model.Address_ID;
            employee.Title_ID = model.Title_ID;

            db.Entry(employee).State = EntityState.Modified;
            db.SaveChanges();

            ViewBag.Address_ID = new SelectList(db.addresses, "Address_ID", "Street_Name", employee.Address_ID);
            ViewBag.Employee_Type_ID = new SelectList(db.employee_type, "Employee_Type_ID", "Type_Name", employee.Employee_Type_ID);
            ViewBag.Gender_ID = new SelectList(db.genders, "Gender_ID", "Gender1", employee.Gender_ID);
            ViewBag.Title_ID = new SelectList(db.titles, "Title_ID", "Title1", employee.Title_ID);

            return RedirectToAction("Index", new { Message = ManageMessageId.UpdateProfileSuccess });
        }

        //        //
        //        // POST: /Manage/RemoveLogin
        //        [HttpPost]
        //        [ValidateAntiForgeryToken]
        //        public async Task<ActionResult> RemoveLogin(string loginProvider, string providerKey)
        //        {
        //            ManageMessageId? message;
        //            var result = await UserManager.RemoveLoginAsync(User.Identity.GetUserId(), new UserLoginInfo(loginProvider, providerKey));
        //            if (result.Succeeded)
        //            {
        //                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
        //                if (user != null)
        //                {
        //                    await SignInUser.SignInAsync(user, isPersistent: false, rememberBrowser: false);
        //                }
        //                message = ManageMessageId.RemoveLoginSuccess;
        //            }
        //            else
        //            {
        //                message = ManageMessageId.Error;
        //            }
        //            return RedirectToAction("ManageLogins", new { Message = message });
        //        }

        //        //
        //        // GET: /Manage/AddPhoneNumber
        //        public ActionResult AddPhoneNumber()
        //        {
        //            return View();
        //        }

        //        //
        //        // POST: /Manage/AddPhoneNumber
        //        [HttpPost]
        //        [ValidateAntiForgeryToken]
        //        public async Task<ActionResult> AddPhoneNumber(AddPhoneNumberViewModel model)
        //        {
        //            if (!ModelState.IsValid)
        //            {
        //                return View(model);
        //            }
        //            // Generate the token and send it
        //            var code = await UserManager.GenerateChangePhoneNumberTokenAsync(User.Identity.GetUserId(), model.Number);
        //            if (UserManager.SmsService != null)
        //            {
        //                var message = new IdentityMessage
        //                {
        //                    Destination = model.Number,
        //                    Body = "Your security code is: " + code
        //                };
        //                await UserManager.SmsService.SendAsync(message);
        //            }
        //            return RedirectToAction("VerifyPhoneNumber", new { PhoneNumber = model.Number });
        //        }

        //        //
        //        // POST: /Manage/EnableTwoFactorAuthentication
        //        [HttpPost]
        //        [ValidateAntiForgeryToken]
        //        public async Task<ActionResult> EnableTwoFactorAuthentication()
        //        {
        //            await UserManager.SetTwoFactorEnabledAsync(User.Identity.GetUserId(), true);
        //            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
        //            if (user != null)
        //            {
        //                await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
        //            }
        //            return RedirectToAction("Index", "Manage");
        //        }

        //        //
        //        // POST: /Manage/DisableTwoFactorAuthentication
        //        [HttpPost]
        //        [ValidateAntiForgeryToken]
        //        public async Task<ActionResult> DisableTwoFactorAuthentication()
        //        {
        //            await UserManager.SetTwoFactorEnabledAsync(User.Identity.GetUserId(), false);
        //            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
        //            if (user != null)
        //            {
        //                await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
        //            }
        //            return RedirectToAction("Index", "Manage");
        //        }

        //        //
        //        // GET: /Manage/VerifyPhoneNumber
        //        public async Task<ActionResult> VerifyPhoneNumber(string phoneNumber)
        //        {
        //            var code = await UserManager.GenerateChangePhoneNumberTokenAsync(User.Identity.GetUserId(), phoneNumber);
        //            // Send an SMS through the SMS provider to verify the phone number
        //            return phoneNumber == null ? View("Error") : View(new VerifyPhoneNumberViewModel { PhoneNumber = phoneNumber });
        //        }

        //        //
        //        // POST: /Manage/VerifyPhoneNumber
        //        [HttpPost]
        //        [ValidateAntiForgeryToken]
        //        public async Task<ActionResult> VerifyPhoneNumber(VerifyPhoneNumberViewModel model)
        //        {
        //            if (!ModelState.IsValid)
        //            {
        //                return View(model);
        //            }
        //            var result = await UserManager.ChangePhoneNumberAsync(User.Identity.GetUserId(), model.PhoneNumber, model.Code);
        //            if (result.Succeeded)
        //            {
        //                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
        //                if (user != null)
        //                {
        //                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
        //                }
        //                return RedirectToAction("Index", new { Message = ManageMessageId.AddPhoneSuccess });
        //            }
        //            // If we got this far, something failed, redisplay form
        //            ModelState.AddModelError("", "Failed to verify phone");
        //            return View(model);
        //        }

        //        //
        //        // POST: /Manage/RemovePhoneNumber
        //        [HttpPost]
        //        [ValidateAntiForgeryToken]
        //        public async Task<ActionResult> RemovePhoneNumber()
        //        {
        //            var result = await UserManager.SetPhoneNumberAsync(User.Identity.GetUserId(), null);
        //            if (!result.Succeeded)
        //            {
        //                return RedirectToAction("Index", new { Message = ManageMessageId.Error });
        //            }
        //            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
        //            if (user != null)
        //            {
        //                await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
        //            }
        //            return RedirectToAction("Index", new { Message = ManageMessageId.RemovePhoneSuccess });
        //        }

        //        //
        //        // GET: /Manage/ChangePassword
        public ActionResult ChangePassword()
        {
            return View();
        }

        //
        // POST: /Manage/ChangePassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(/*[Bind(Include = "Employee_ID,Employee_Name,Employee_Surname,Employee_Email,Employee_Home_Phone,Employee_Cellphone,Employee_RSA_ID,Employee_Avatar,Employee_Type_ID,Encrypted_Password,Gender_ID,Address_ID,Title_ID")] employee employee,*/ ChangePasswordViewModel model) //employee employee)
        {
            var userId = System.Web.HttpContext.Current.Session["UserID"] as String;
            int IntID = Convert.ToInt32(userId);

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                using (db)
                {
                    SHA1 sha1 = SHA1.Create();
                    SHA1 sha2 = SHA1.Create();
                    SHA1 sha3 = SHA1.Create();

                    var hashData = sha1.ComputeHash(Encoding.UTF8.GetBytes(model.OldPassword));
                    var OLDPASS = new StringBuilder(hashData.Length * 2);
                    foreach (byte b in hashData)
                    {
                        OLDPASS.Append(b.ToString("X2"));
                    }
                    string stri = OLDPASS.ToString();

                    employee employee = (from s in db.employees where s.Employee_ID == IntID && s.Encrypted_Password == stri select s).FirstOrDefault();

                    if (employee != null && ModelState.IsValid)
                    {
                        var NewPassword = sha2.ComputeHash(Encoding.UTF8.GetBytes(model.NewPassword));
                        var NEWPASS = new StringBuilder(NewPassword.Length * 2);
                        OLDPASS = new StringBuilder(NewPassword.Length * 2);
                        foreach (byte b in NewPassword)
                        {
                            NEWPASS.Append(b.ToString("X2"));
                        }

                        var ConfirmPassword = sha3.ComputeHash(Encoding.UTF8.GetBytes(model.ConfirmPassword));
                        var CONFIRM = new StringBuilder(ConfirmPassword.Length * 2);
                        OLDPASS = new StringBuilder(ConfirmPassword.Length * 2);
                        foreach (byte b in ConfirmPassword)
                        {
                            CONFIRM.Append(b.ToString("X2"));
                        }

                        employee.Encrypted_Password = CONFIRM.ToString();
                        db.Entry(employee).State = EntityState.Modified;
                        db.SaveChanges();

                        //This is for an emal service Remeber this !
                        MailMessage mail = new MailMessage("no-reply@repsonthemove.com", employee.Employee_Email);
                        SmtpClient client = new SmtpClient();
                        client.Port = 25;
                        client.DeliveryMethod = SmtpDeliveryMethod.Network;
                        client.Credentials = new System.Net.NetworkCredential("no-reply@repsonthemove.com", "k1Yvi2&5");
                        client.Host = "nl1-wss2.a2hosting.com";
                        mail.Subject = "Password Change";
                        mail.Body = "Hi " + employee.Employee_Name + " " + employee.Employee_Surname + "\n\nYour password has been successfully changed. If this was not you please contact admin immediately " + "\n\nRegards" + "\nReps On The Move Team";
                        client.Send(mail);

                        return RedirectToAction("Index", new { Message = ManageMessageId.ChangePasswordSuccess });

                    }
                    ModelState.AddModelError(string.Empty, "Current password does not match with current password please retype your old password in correctly");
                    return View(model);
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, "Some exception occured" + e);
                return View();
            }
        }

        //
        // GET: /Manage/SetPassword
        //public ActionResult SetPassword()
        //{
        //    return View();
        //}

        ////
        //// POST: /Manage/SetPassword
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> SetPassword(SetPasswordViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var result = await UserManager.AddPasswordAsync(User.Identity.GetUserId(), model.NewPassword);
        //        if (result.Succeeded)
        //        {
        //            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
        //            if (user != null)
        //            {
        //                await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
        //            }
        //            return RedirectToAction("Index", new { Message = ManageMessageId.SetPasswordSuccess });
        //        }
        //        AddErrors(result);
        //    }

        //    // If we got this far, something failed, redisplay form
        //    return View(model);
        //}

        //        //
        //        // GET: /Manage/ManageLogins
        //        public async Task<ActionResult> ManageLogins(ManageMessageId? message)
        //        {
        //            ViewBag.StatusMessage =
        //                message == ManageMessageId.RemoveLoginSuccess ? "The external login was removed."
        //                : message == ManageMessageId.Error ? "An error has occurred."
        //                : "";
        //            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
        //            if (user == null)
        //            {
        //                return View("Error");
        //            }
        //            var userLogins = await UserManager.GetLoginsAsync(User.Identity.GetUserId());
        //            var otherLogins = AuthenticationManager.GetExternalAuthenticationTypes().Where(auth => userLogins.All(ul => auth.AuthenticationType != ul.LoginProvider)).ToList();
        //            ViewBag.ShowRemoveButton = user.PasswordHash != null || userLogins.Count > 1;
        //            return View(new ManageLoginsViewModel
        //            {
        //                CurrentLogins = userLogins,
        //                OtherLogins = otherLogins
        //            });
        //        }

        //        //
        //        // POST: /Manage/LinkLogin
        //        [HttpPost]
        //        [ValidateAntiForgeryToken]
        //        public ActionResult LinkLogin(string provider)
        //        {
        //            // Request a redirect to the external login provider to link a login for the current user
        //            return new AccountController.ChallengeResult(provider, Url.Action("LinkLoginCallback", "Manage"), User.Identity.GetUserId());
        //        }

        //        //
        //        // GET: /Manage/LinkLoginCallback
        //        public async Task<ActionResult> LinkLoginCallback()
        //        {
        //            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync(XsrfKey, User.Identity.GetUserId());
        //            if (loginInfo == null)
        //            {
        //                return RedirectToAction("ManageLogins", new { Message = ManageMessageId.Error });
        //            }
        //            var result = await UserManager.AddLoginAsync(User.Identity.GetUserId(), loginInfo.Login);
        //            return result.Succeeded ? RedirectToAction("ManageLogins") : RedirectToAction("ManageLogins", new { Message = ManageMessageId.Error });
        //        }

        //        protected override void Dispose(bool disposing)
        //        {
        //            if (disposing && _userManager != null)
        //            {
        //                _userManager.Dispose();
        //                _userManager = null;
        //            }

        //            base.Dispose(disposing);
        //        }

        #region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private bool HasPassword(int id)
        {
            //var user = UserManager.FindById(User.Identity.GetUserId());
            using (db)
            {
                var chkUser = (from s in db.employees where s.Employee_ID == id select s).FirstOrDefault();

                if (chkUser != null)
                {
                    return chkUser.Encrypted_Password != null;
                }
            }
            return false;
        }

        //private bool HasAddress(int id)
        //{
        //    using (db)
        //    {
        //        var ch = (from s in db.employees where s.Employee_ID == id select s).FirstOrDefault();

        //        if (ch != null)
        //        {
        //            return ch.Address_ID != null;
        //        }
        //    }
        //    return false;
        //}
        //private bool HasPhoneNumber()
        //{
        //    var user = UserManager.FindById(User.Identity.GetUserId());
        //    if (user != null)
        //    {
        //        return user.PhoneNumber != null;
        //    }
        //    return false;
        //}

        public enum ManageMessageId
        {
            AddPhoneSuccess,
            ChangePasswordSuccess,
            UpdateProfileSuccess,
            UpdateAddressSuccess,
            SetAddressSuccess,
            SetTwoFactorSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
            RemovePhoneSuccess,

            Error
        }

        #endregion
    }
}