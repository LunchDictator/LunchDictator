namespace LunchDictator.Web.Core
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Resources;
    using System.Text;

    using LunchDictator.Web.Resources.DictatorshipNameParts;

    /// <summary>
    /// Generates a randomly generated dictatorship name based on entries in various resource files
    /// </summary>
    public static class RandomDictatorshipNameProvider
    {
        private static readonly Random Randomiser = new Random();

        private static readonly List<string> Adjectives = GetDictatorshipNameParts(DictatorshipNameAdjectives.ResourceManager);
        private static readonly List<string> StateOwnerships = GetDictatorshipNameParts(DictatorshipNameStateOwnership.ResourceManager);
        private static readonly List<string> StateTypes = GetDictatorshipNameParts(DictatorshipNameStateType.ResourceManager);
        private static readonly List<string> Nouns = GetDictatorshipNameParts(DictatorshipNameNouns.ResourceManager);
        private static readonly List<string> PluralNouns = GetDictatorshipNameParts(DictatorshipNamePluralNouns.ResourceManager);
        private static readonly List<string> Verbs = GetDictatorshipNameParts(DictatorshipNameVerbs.ResourceManager);

        // Gets a new random dictatorship name
        public static string GetRandomDictatorshipName()
        {
            // Determine which name parts to use. Always use "the", state type, "of" and noun/plural noun.
            var useAdjective = Randomiser.Next(0, 2) > 0;
            var useStateOwnership = Randomiser.Next(0, 2) > 0;
            var useVerb = Randomiser.Next(0, 2) > 0;

            var name = new StringBuilder();

            name.AppendFormat("{0} ", DictatorshipNameCommon.The);

            if (useAdjective)
            {
                name.AppendFormat("{0} ", Adjectives[Randomiser.Next(Adjectives.Count)]);
            }

            if (useStateOwnership)
            {
                name.AppendFormat("{0} ", StateOwnerships[Randomiser.Next(StateOwnerships.Count)]);
            }

            name.AppendFormat("{0} ", StateTypes[Randomiser.Next(StateTypes.Count)]);
            name.AppendFormat("{0} ", DictatorshipNameCommon.Of);

            if (useVerb)
            {
                name.AppendFormat("{0} ", Nouns[Randomiser.Next(Nouns.Count)]);
                name.Append(Verbs[Randomiser.Next(Verbs.Count)]);
            }
            else
            {
                name.Append(PluralNouns[Randomiser.Next(PluralNouns.Count)]);
            }

            return name.ToString();
        }

        private static List<string> GetDictatorshipNameParts(ResourceManager resourceManager)
        {
            var resourceSet = resourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
            var result = (from DictionaryEntry entry in resourceSet select entry.Value.ToString()).ToList();
            return result;
        }
    }
}
