namespace LunchDictator.Web.Models
{
    public class AccountLoginOrRegisterViewModel
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string ReturnUrl { get; set; }

        public string Message { get; set; }
    }
}