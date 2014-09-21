namespace LunchDictator.Web.Controllers
{
    using System.Web.Mvc;
    using System.Web.Security;

    using LunchDictator.Web.Core;

    public class AccountController : BaseController
    {
        [AllowAnonymous]
        public ActionResult LogIn(string returnUrl)
        {
            return this.View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return this.RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            return this.View();
        }

        [AllowAnonymous]
        public ActionResult Validate()
        {
            return this.View();
        }
    }
}