namespace LunchDictator.DataAccess.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User : BaseEntity
    {
        public User()
        {
            Dictatorships = new HashSet<Dictatorship>();
        }

        [EmailAddress]
        public string EmailAddress { get; set; }

        public string Password { get; set; }

        public Guid? PasswordChangeSecret { get; set; }

        public virtual ICollection<Dictatorship> Dictatorships { get; set; }
    }
}
