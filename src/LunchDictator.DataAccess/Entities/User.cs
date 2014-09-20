using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunchDictator.DataAccess.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class User : BaseEntity
    {
        [EmailAddress]
        public string EmailAddress { get; set; }

        public string Password { get; set; }
    }
}
