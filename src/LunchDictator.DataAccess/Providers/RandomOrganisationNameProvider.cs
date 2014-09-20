using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunchDictator.DataAccess.Providers
{
    using LunchDictator.DataAccess.Enums;

    public static class RandomOrganisationNameProvider
    {
        private static readonly Random Randomiser = new Random();

        // Gets a new random organisation name
        public static string GetRandomOrganisationName()
        {
            // Determine which name parts to use. Always use nouns.
            var useArticle = Randomiser.Next(0, 2) > 0;
            var useVerb = Randomiser.Next(0, 2) > 0;
            var useAdjective = Randomiser.Next(0, 2) > 0;
            var useAdverb = useVerb && Randomiser.Next(0, 2) > 0;

            var name = new StringBuilder();

            if (useArticle)
            {
                name.AppendFormat("{0} ", GetRandomNamePart(OrganisationNamePartType.Article));
            }

            if (useAdverb)
            {
                name.AppendFormat("{0} ", GetRandomNamePart(OrganisationNamePartType.Adverb));
            }

            if (useVerb)
            {
                name.AppendFormat("{0} ", GetRandomNamePart(OrganisationNamePartType.Verb));
            }

            if (useAdjective)
            {
                name.AppendFormat("{0} ", GetRandomNamePart(OrganisationNamePartType.Adjective));
            }

            name.Append(string.Format("{0}", GetRandomNamePart(OrganisationNamePartType.Noun)));

            return name.ToString();
        }

        private static string GetRandomNamePart(OrganisationNamePartType namePartType)
        {
            using (var ctx = new LunchContext())
            {
                var parts = ctx.OrganisationNameParts.Where(x => x.OrganisationNamePartType == namePartType).Select(x => x.Value).ToList();
                return parts[Randomiser.Next(parts.Count)];
            }
        }
    }
}
