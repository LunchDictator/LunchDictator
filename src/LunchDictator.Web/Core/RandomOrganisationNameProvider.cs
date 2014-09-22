namespace LunchDictator.Web.Core
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Resources;
    using System.Text;

    using LunchDictator.Web.Resources.OrgNameParts;

    public static class RandomOrganisationNameProvider
    {
        private static readonly Random Randomiser = new Random();

        private static readonly List<string> Articles = GetOrgNameParts(OrgNameArticles.ResourceManager);
        private static readonly List<string> Adverbs = GetOrgNameParts(OrgNameAdverbs.ResourceManager);
        private static readonly List<string> Verbs = GetOrgNameParts(OrgNameVerbs.ResourceManager);
        private static readonly List<string> Adjectives = GetOrgNameParts(OrgNameAdjectives.ResourceManager);
        private static readonly List<string> Nouns = GetOrgNameParts(OrgNameNouns.ResourceManager);

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
                name.AppendFormat("{0} ", Articles[Randomiser.Next(Articles.Count)]);
            }

            if (useAdverb)
            {
                name.AppendFormat("{0} ", Adverbs[Randomiser.Next(Articles.Count)]);
            }

            if (useVerb)
            {
                name.AppendFormat("{0} ", Verbs[Randomiser.Next(Articles.Count)]);
            }

            if (useAdjective)
            {
                name.AppendFormat("{0} ", Adjectives[Randomiser.Next(Adjectives.Count)]);
            }

            name.AppendFormat("{0}", Nouns[Randomiser.Next(Nouns.Count)]);

            return name.ToString();
        }

        private static List<string> GetOrgNameParts(ResourceManager resourceManager)
        {
            var resourceSet = resourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
            var result = (from DictionaryEntry entry in resourceSet select entry.Value.ToString()).ToList();
            return result;
        }
    }
}
