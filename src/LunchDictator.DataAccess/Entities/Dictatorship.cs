using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunchDictator.DataAccess.Entities
{
    public class Dictatorship : BaseEntity
    {
        public Dictatorship()
        {
            Users = new HashSet<User>();
        }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
