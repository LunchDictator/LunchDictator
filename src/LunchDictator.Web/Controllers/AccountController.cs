namespace LunchDictator.Web.Controllers
{
    using System.Data.Entity;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using System.Web.Security;

    using LunchDictator.Web.Core;
    using LunchDictator.Web.Models;
    using LunchDictator.Web.Resources;

    public class AccountController : BaseController
    {
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            return this.View(new AccountLoginViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Login(AccountLoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            var user = await LunchContext.Users.SingleOrDefaultAsync(u => u.EmailAddress == model.Username);

            if (user != null && user.Password == HashHelper.GetHash(model.Password))
            {
                FormsAuthentication.SetAuthCookie(user.EmailAddress, true);
                return this.Redirect(model.ReturnUrl ?? FormsAuthentication.DefaultUrl);
            }

            ModelState.AddModelError(string.Empty, WebCommon.LoginFailed);

            return this.View(model);
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