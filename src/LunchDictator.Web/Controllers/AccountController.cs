namespace LunchDictator.Web.Controllers
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;
    using System.Data.Entity.Validation;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using System.Web.Security;

    using LunchDictator.DataAccess.Entities;
    using LunchDictator.Web.Core;
    using LunchDictator.Web.Models;
    using LunchDictator.Web.Resources;

    public class AccountController : BaseController
    {
        [AllowAnonymous]
        public ActionResult LogIn(string returnUrl)
        {
            return this.View("LoginOrRegister", new AccountLoginOrRegisterViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> LogIn(AccountLoginOrRegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            var user = await LunchContext.Users.SingleOrDefaultAsync(u => u.EmailAddress == model.Username);

            if (user != null && user.Password == HashHelper.GetHash(model.Password))
            {
                this.LogInInternal(user.EmailAddress);
                return this.Redirect(model.ReturnUrl ?? FormsAuthentication.DefaultUrl);
            }

            ModelState.AddModelError(string.Empty, WebCommon.LoginFailed);

            return this.View("LoginOrRegister", model);
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            return this.View("LoginOrRegister", new AccountLoginOrRegisterViewModel());
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Register(AccountLoginOrRegisterViewModel model)
        {
            var loginTaken = await LunchContext.Users.AnyAsync(u => u.EmailAddress == model.Username);

            if (loginTaken)
            {
                ModelState.AddModelError(string.Empty, WebCommon.LoginAlreadyTaken);
            }
            else
            {
                try
                {
                    LunchContext.Users.Add(new User { EmailAddress = model.Username, PasswordChangeSecret = Guid.NewGuid() });
                    await LunchContext.SaveChangesAsync();

                    // send activation email
                    model.Message = WebCommon.RegistrationSuccess;
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var validationError in ex.EntityValidationErrors.Where(v => !v.IsValid))
                    {
                        foreach (var error in validationError.ValidationErrors)
                        {
                            ModelState.AddModelError(string.Empty, error.ErrorMessage);
                        }
                    }
                }
            }

            return this.View("LoginOrRegister", model);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return this.RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public async Task<ActionResult> Activate(Guid passwordChangeSecret)
        {
            var user =
                await LunchContext.Users.SingleOrDefaultAsync(u => u.PasswordChangeSecret == passwordChangeSecret);

            return user == null
                       ? this.View("ActivateSecretInvalid")
                       : this.View(new AccountActivateViewModel { PasswordChangeSecret = passwordChangeSecret });
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> Activate(AccountActivateViewModel model)
        {
            var user =
                await LunchContext.Users.SingleOrDefaultAsync(u => u.PasswordChangeSecret == model.PasswordChangeSecret);

            if (user == null)
            {
                return this.View("ActivateSecretInvalid");
            }

            user.Password = HashHelper.GetHash(model.Password);
            user.PasswordChangeSecret = null;

            await LunchContext.SaveChangesAsync();

            this.LogInInternal(user.EmailAddress);

            return this.RedirectToAction("Index", "Home");
        }

        private void LogInInternal(string username)
        {
            FormsAuthentication.SetAuthCookie(username, true);
        }
    }
}