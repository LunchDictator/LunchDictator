using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunchDictator.DataAccess.Migrations.Initializers
{
    using System.Data.Entity.Migrations;

    using LunchDictator.DataAccess.Entities;
    using LunchDictator.DataAccess.Enums;

    public static class OrganisationNamePartsInitializer
    {
        public static void Initialize(LunchContext context)
        {
            // Articles
            context.OrganisationNameParts.AddOrUpdate(
                p => p.Id,
                new OrganisationNamePart
                {
                    Id = 1,
                    Value = "The",
                    OrganisationNamePartType = OrganisationNamePartType.Article
                },
                new OrganisationNamePart
                {
                    Id = 2,
                    Value = "These",
                    OrganisationNamePartType = OrganisationNamePartType.Article
                },
                new OrganisationNamePart
                {
                    Id = 3,
                    Value = "Some",
                    OrganisationNamePartType = OrganisationNamePartType.Article
                },
                new OrganisationNamePart
                {
                    Id = 4,
                    Value = "A Few",
                    OrganisationNamePartType = OrganisationNamePartType.Article
                },
                new OrganisationNamePart
                {
                    Id = 5,
                    Value = "Half A Dozen",
                    OrganisationNamePartType = OrganisationNamePartType.Article
                });


            // Adverbs
            context.OrganisationNameParts.AddOrUpdate(
                p => p.Id,
                new OrganisationNamePart
                {
                    Id = 101,
                    Value = "Angrily",
                    OrganisationNamePartType = OrganisationNamePartType.Adverb
                },
                new OrganisationNamePart
                {
                    Id = 102,
                    Value = "Blindly",
                    OrganisationNamePartType = OrganisationNamePartType.Adverb
                },
                new OrganisationNamePart
                {
                    Id = 103,
                    Value = "Eagerly",
                    OrganisationNamePartType = OrganisationNamePartType.Adverb
                },
                new OrganisationNamePart
                {
                    Id = 104,
                    Value = "Foolishly",
                    OrganisationNamePartType = OrganisationNamePartType.Adverb
                },
                new OrganisationNamePart
                {
                    Id = 105,
                    Value = "Mysteriously",
                    OrganisationNamePartType = OrganisationNamePartType.Adverb
                });

            // Verbs
            context.OrganisationNameParts.AddOrUpdate(
                p => p.Id,
                new OrganisationNamePart
                {
                    Id = 201,
                    Value = "Lollygagging",
                    OrganisationNamePartType = OrganisationNamePartType.Verb
                },
                new OrganisationNamePart
                {
                    Id = 202,
                    Value = "Jumping",
                    OrganisationNamePartType = OrganisationNamePartType.Verb
                },
                new OrganisationNamePart
                {
                    Id = 203,
                    Value = "Arguing",
                    OrganisationNamePartType = OrganisationNamePartType.Verb
                },
                new OrganisationNamePart
                {
                    Id = 204,
                    Value = "Bushwhacking",
                    OrganisationNamePartType = OrganisationNamePartType.Verb
                },
                new OrganisationNamePart
                {
                    Id = 205,
                    Value = "Clapping",
                    OrganisationNamePartType = OrganisationNamePartType.Verb
                });

            // Adjectives
            context.OrganisationNameParts.AddOrUpdate(
                p => p.Id,
                new OrganisationNamePart
                {
                    Id = 301,
                    Value = "Arcadian",
                    OrganisationNamePartType = OrganisationNamePartType.Adjective
                },
                new OrganisationNamePart
                {
                    Id = 302,
                    Value = "Corpulent",
                    OrganisationNamePartType = OrganisationNamePartType.Adjective
                },
                new OrganisationNamePart
                {
                    Id = 303,
                    Value = "Calamitous",
                    OrganisationNamePartType = OrganisationNamePartType.Adjective
                },
                new OrganisationNamePart
                {
                    Id = 304,
                    Value = "Feckless",
                    OrganisationNamePartType = OrganisationNamePartType.Adjective
                },
                new OrganisationNamePart
                {
                    Id = 305,
                    Value = "Luminous",
                    OrganisationNamePartType = OrganisationNamePartType.Adjective
                });

            // Nouns
            context.OrganisationNameParts.AddOrUpdate(
                p => p.Id,
                new OrganisationNamePart
                {
                    Id = 401,
                    Value = "Ninjas",
                    OrganisationNamePartType = OrganisationNamePartType.Noun
                },
                new OrganisationNamePart
                {
                    Id = 402,
                    Value = "Rainbows",
                    OrganisationNamePartType = OrganisationNamePartType.Noun
                },
                new OrganisationNamePart
                {
                    Id = 403,
                    Value = "Gnomes",
                    OrganisationNamePartType = OrganisationNamePartType.Noun
                },
                new OrganisationNamePart
                {
                    Id = 404,
                    Value = "Dragons",
                    OrganisationNamePartType = OrganisationNamePartType.Noun
                },
                new OrganisationNamePart
                {
                    Id = 405,
                    Value = "Bunnies",
                    OrganisationNamePartType = OrganisationNamePartType.Noun
                });
        }
    }
}
