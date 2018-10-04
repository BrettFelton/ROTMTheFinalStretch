﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using ROTM.Models;
using System.Net.Mail;
using System.Data.Entity;
using System.Security.Cryptography;
using System.Text;

namespace ROTM.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private Entities db = new Entities();

        public AccountController()
        {
        }
        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            try
            {
                // Verification.    
                if (this.Request.IsAuthenticated)
                {
                    // Info.    
                    return this.RedirectToLocal(returnUrl);
                }
            }
            catch (Exception ex)
            {
                // Info    
                Console.Write(ex);
            }
            // Info.    
            return this.View();
        }
        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    SHA1 sha1 = SHA1.Create();
                    var hashData = sha1.ComputeHash(Encoding.UTF8.GetBytes(model.Encrypted_Password));
                    var chkpass = new StringBuilder(hashData.Length * 2);
                    foreach (byte b in hashData)
                    {
                        chkpass.Append(b.ToString("X2"));
                    }
                    string stri = chkpass.ToString();

                    var details = (from userlist in db.employees
                                   join reg in db.registration_token
                                   on userlist.Employee_Email equals reg.New_Email
                                   where userlist.Employee_Email == model.Employee_Email && userlist.Encrypted_Password == stri && reg.New_Email == userlist.Employee_Email && (reg.Access_Level_ID == 2 || reg.Access_Level_ID == 1)
                                   select new
                                   {
                                       userlist.Employee_ID,
                                       userlist.Employee_Name
                                   }).ToList();


                    var salesRepInvalid = (from userlist in db.employees
                                           join reg in db.registration_token
                                           on userlist.Employee_Email equals reg.New_Email
                                           where userlist.Employee_Email == model.Employee_Email && userlist.Encrypted_Password == stri && reg.New_Email == userlist.Employee_Email && (reg.Access_Level_ID == 3)
                                           select new
                                           {
                                               userlist.Employee_ID,
                                               userlist.Employee_Name
                                           }).ToList();


                    if (details != null && details.Count() > 0 && salesRepInvalid.Count() == 0)
                    {
                        var logindetails = details.First();
                        // Login In.    
                        this.SignInUser(logindetails.Employee_Name, false);
                        // Info.  
                        System.Web.HttpContext.Current.Session["UserID"] = logindetails.Employee_ID.ToString();
                        //Session["UserID"] = logindetails.Employee_ID;
                        return this.RedirectToLocal(returnUrl);
                    }
                    else if (salesRepInvalid != null && salesRepInvalid.Count() > 0)
                    {
                        ModelState.AddModelError(string.Empty, "Sales reps cannot log in to this system.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Invalid email address or password");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
            return View(model);
        }

        [AllowAnonymous]
        public ActionResult TokenRegister()
        {
            return View();
        }
        //POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult TokenRegister(AccessTokenRegister accessTokenRegister)
        {
            bool val = db.registration_token.Any(s => s.Registration_Token1 == accessTokenRegister.Registration_Token && (s.Access_Level_ID == 1 || s.Access_Level_ID == 2));

            if (ModelState.IsValid && val == true)
            {

                return RedirectToAction("Register", "Account");
            }
            else if (val == false)
            {
                ViewBag.StatusMessage = "The Registration token that you have entered is invalid or does not exist, please try again.";
                return View();
            }

            return View();
        }

        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }


        //POST: /Account/Register
       [HttpPost]
       [AllowAnonymous]
       [ValidateAntiForgeryToken]
        public ActionResult Register(employee model, address addresses)
        {
            var Reg = new RegisterViewModel();
            if (ModelState.IsValid)
            {
                SHA1 sha1 = SHA1.Create();
                var hashData = sha1.ComputeHash(Encoding.UTF8.GetBytes(model.Encrypted_Password));
                var chkpass = new StringBuilder(hashData.Length * 2);
                foreach (byte b in hashData)
                {
                    chkpass.Append(b.ToString("X2"));
                }
                string stri = chkpass.ToString();

                model.Encrypted_Password = stri;
                addresses.City = "";
                addresses.Country = "";
                addresses.Street_Name = "";
                addresses.Suburb = "";
                addresses.Province = "";


                db.addresses.Add(addresses);
                model.Address_ID = addresses.Address_ID;
                db.employees.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            //return View();
            //if (ModelState.IsValid)
            //{
            //    var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
            //    var result = await UserManager.CreateAsync(user, model.Password);
            //    if (result.Succeeded)
            //    {
            //        await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

            //        // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
            //        // Send an email with this link
            //        // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
            //        // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
            //        // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

            //        return RedirectToAction("Index", "Home");
            //    }
            //    AddErrors(result);
            //}
            
            //// If we got this far, something failed, redisplay form
            return View(Reg);
        }

        //
        // GET: /Account/ConfirmEmail
        //[AllowAnonymous]
        //public async Task<ActionResult> ConfirmEmail(string userId, string code)
        //{
        //    if (userId == null || code == null)
        //    {
        //        return View("Error");
        //    }
        //    var result = await UserManager.ConfirmEmailAsync(userId, code);
        //    return View(result.Succeeded ? "ConfirmEmail" : "Error");
        //}

        //
        // GET: /Account/ForgotPassword
        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        //POST: /Account/ForgotPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ForgotPassword(ForgotPasswordViewModel model)
        {
            using (db)
            {
                var chkUser = (from s in db.employees where s.Employee_Email == model.Email select s).FirstOrDefault();
                if (ModelState.IsValid && chkUser != null)
                {
                    SHA1 sha1 = SHA1.Create();
                    //Create A token
                    RNGCryptoServiceProvider rngCryptoServiceProvider = new RNGCryptoServiceProvider();
                    byte[] randomBytes = new byte[6];
                    rngCryptoServiceProvider.GetBytes(randomBytes);

                    //Hash the token
                    var hashData = sha1.ComputeHash(Encoding.UTF8.GetBytes(Convert.ToBase64String(randomBytes)));
                    var Newtoken = new StringBuilder(hashData.Length * 2);
                    foreach (byte b in hashData)
                    {
                        Newtoken.Append(b.ToString("X2"));
                    }



                    chkUser.Encrypted_Password = Newtoken.ToString();
                    //This is for an emal service Remeber this !
                    MailMessage mail = new MailMessage("no-reply@repsonthemove.com", model.Email);
                    SmtpClient client = new SmtpClient();
                    client.Port = 25;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.Credentials = new System.Net.NetworkCredential("no-reply@repsonthemove.com", "k1Yvi2&5");
                    client.Host = "nl1-wss2.a2hosting.com";
                    mail.Subject = "Password Change";
                    mail.Body = "Dear " + chkUser.Employee_Name + " " + chkUser.Employee_Surname + "\n\nIt seems like you have forgotten your login password. Here is a temporary one: " + Convert.ToBase64String(randomBytes) + " , please use this password on your next login. If you would like navigate to your profile and change your password. Otherwise keep this one safe. If this was not you please contact admin immediately " + "\n\nKind Regards" + "\nThe ArdorTech Team";
                    client.Send(mail);

                    db.Entry(chkUser).State = EntityState.Modified;
                    db.SaveChanges();
                    //var user = await UserManager.FindByNameAsync(model.Email);
                    //if (user == null || !(await UserManager.IsEmailConfirmedAsync(user.Id)))
                    //{
                    //    // Don't reveal that the user does not exist or is not confirmed
                    //    return View("ForgotPasswordConfirmation");
                    //}

                    // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                    // Send an email with this link
                    // string code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
                    // var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);		
                    // await UserManager.SendEmailAsync(user.Id, "Reset Password", "Please reset your password by clicking <a href=\"" + callbackUrl + "\">here</a>");
                    //return RedirectToAction("ForgotPasswordConfirmation", "Account");
                    return RedirectToAction("Login");
                }
                else
                {
                    ViewBag.Error = "Email address does not exist.";
                }
            }
            // If we got this far, something failed, redisplay form
            return View(model);
        }
        //
        // GET: /Account/ForgotPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        //
        // GET: /Account/ResetPassword
        [AllowAnonymous]
        public ActionResult ResetPassword(string code)
        {
            return code == null ? View("Error") : View();
        }

        //
        // POST: /Account/ResetPassword
        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(model);
        //    }
        //    var user = await db.FindByNameAsync(model.Email);
        //    if (user == null)
        //    {
        //        // Don't reveal that the user does not exist
        //        return RedirectToAction("ResetPasswordConfirmation", "Account");
        //    }
        //    var result = await db.ResetPasswordAsync(user.Id, model.Code, model.Password);
        //    if (result.Succeeded)
        //    {
        //        return RedirectToAction("ResetPasswordConfirmation", "Account");
        //    }
        //    AddErrors(result);
        //    return View();
        //}

        //
        // GET: /Account/ResetPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ResetPasswordConfirmation()
        {
            return View();
        }
        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            try
            {
                // Setting.    
                var ctx = Request.GetOwinContext();
                var authenticationManager = ctx.Authentication;
                // Sign Out.    
                authenticationManager.SignOut();
            }
            catch (Exception ex)
            {
                // Info    
                throw ex;
            }
            // Info.    
            return this.RedirectToAction("Login", "Account");
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult LogOff()
        //{
        //    AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        //    return RedirectToAction("Index", "Home");
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (db != null)
                {
                    db.Dispose();
                    db = null;
                }
                base.Dispose(disposing);
            }
        }

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

        private ActionResult RedirectToLocal(string returnUrl)
        {
            try
            {
                // Verification.    
                if (Url.IsLocalUrl(returnUrl))
                {
                    // Info.    
                    return this.Redirect(returnUrl);
                }
            }
            catch (Exception ex)
            {
                // Info    
                throw ex;
            }
            // Info.    
            return this.RedirectToAction("Index", "Home");
        }

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }
        private void SignInUser(string username, bool isPersistent)
        {
            // Initialization.    
            var claims = new List<Claim>();
            try
            {
                // Setting    
                claims.Add(new Claim(ClaimTypes.Name, username));
                var claimIdenties = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);
                var ctx = Request.GetOwinContext();
                var authenticationManager = ctx.Authentication;
                // Sign In.    
                authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, claimIdenties);
            }
            catch (Exception ex)
            {
                // Info    
                throw ex;
            }
        }

        #endregion
    }
}