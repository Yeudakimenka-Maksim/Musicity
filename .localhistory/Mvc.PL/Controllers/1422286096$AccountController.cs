using System;
using System.Drawing.Imaging;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;
using BLL.Interface.Services;
using Mvc.PL.Infrastructure;
using Mvc.PL.Providers;
using Mvc.PL.ViewModels.LogOnPage;
using Mvc.PL.ViewModels.RegisterPage;

namespace Mvc.PL.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly IUserService userService;

        public AccountController(IUserService userService)
        {
            this.userService = userService;
        }

        [ChildActionOnly]
        public ActionResult Menu()
        {
            return PartialView();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LogOnPageViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(model.Name, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.Name, model.RememberMe);
                    if (Url.IsLocalUrl(returnUrl))
                        return Redirect(returnUrl);
                    return RedirectToAction("Categories", "Musicity");
                }
                ModelState.AddModelError("", "Incorrect Login or Password");
            }
            return View(model);
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterPageRegisterViewModel model)
        {
            if (model.Captcha != (string) Session[CaptchaImage.CaptchaValueKey])
            {
                ModelState.AddModelError("Captcha", "Captcha text is incorrect");
                return View(model);
            }

            if (userService.GetUserByName(model.Name) != null)
            {
                ModelState.AddModelError("Username", "This user name is already registered");
                return View(model);
            }

            if (ModelState.IsValid)
            {
                var membershipUser = ((CustomMembershipProvider) Membership.Provider).CreateUser(model.Name,
                    model.Password,
                    model.DateOfBirth == null ? (DateTime?) null : ((DateTime) model.DateOfBirth).ToUniversalTime(),
                    DateTime.Now.ToUniversalTime(), DateTime.Now.ToUniversalTime(), model.Location, true);
                if (membershipUser != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Name, false);
                    return RedirectToAction("Categories", "Musicity");
                }
                ModelState.AddModelError("", "Registration error");
            }
            return View(model);
        }

        [Authorize]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }

        public ActionResult Captcha()
        {
            Session[CaptchaImage.CaptchaValueKey] =
                new Random(DateTime.Now.Millisecond).Next(1111, 9999).ToString(CultureInfo.InvariantCulture);
            using (
                var captcha = new CaptchaImage(Session[CaptchaImage.CaptchaValueKey].ToString(), 211, 50, "Helvetica"))
            {
                Response.Clear();
                Response.ContentType = "image/jpeg";
                captcha.Image.Save(Response.OutputStream, ImageFormat.Jpeg);
            }
            return null;
        }
    }
}