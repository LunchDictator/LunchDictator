namespace LunchDictator.DataAccess.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class User : BaseEntity
    {
        [EmailAddress]
        public string EmailAddress { get; set; }

        public string Password { get; set; }

        public Guid? PasswordChangeSecret { get; set; }
    }
}
