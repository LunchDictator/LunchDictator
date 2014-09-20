using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunchDictator.DataAccess.Entities
{
    using LunchDictator.DataAccess.Enums;

    public class OrganisationNamePart : BaseEntity
    {
        public string Value { get; set; }

        public OrganisationNamePartType OrganisationNamePartType { get; set; }
    }
}
