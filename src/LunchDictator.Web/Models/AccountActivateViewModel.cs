namespace LunchDictator.Web.Models
{
    using System;

    public class AccountActivateViewModel
    {
        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public Guid PasswordChangeSecret { get; set; }
    }
}