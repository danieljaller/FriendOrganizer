using System.Collections.Generic;
using FriendOrganizer.Model;

namespace FriendOrganizer.DataAccess.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FriendOrganizer.DataAccess.FriendOrganizerDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FriendOrganizer.DataAccess.FriendOrganizerDbContext context)
        {
            context.Friends.AddOrUpdate(f => f.FirstName,
                new Friend() { FirstName = "Bosse", LastName = "Bildoktorn" },
                new Friend() { FirstName = "Posse", LastName = "Pildoktorn" },
                new Friend() { FirstName = "Mosse", LastName = "Mildoktorn" },
                new Friend() { FirstName = "Sosse", LastName = "Sildoktorn" }
                );
            context.ProgrammingLanguages.AddOrUpdate(
                pl => pl.Name,
                new ProgrammingLanguage { Name = "C#" },
                new ProgrammingLanguage { Name = "TypeScript" },
                new ProgrammingLanguage { Name = "F#" },
                new ProgrammingLanguage { Name = "Swift" },
                new ProgrammingLanguage { Name = "Java" }
                );

            context.SaveChanges();

            context.FriendPhoneNumbers.AddOrUpdate(pn => pn.Number,
                new FriendPhoneNumber { Number = "+46 76123456", FriendId = context.Friends.First().Id });

            context.Meetings.AddOrUpdate(m => m.Title,
                new Meeting
                {
                    Title = "Laga bilen",
                    DateFrom = new DateTime(2018, 5, 26),
                    DateTo = new DateTime(2018, 5, 26),
                    Friends = new List<Friend>
                    {
                        context.Friends.Single(f => f.FirstName == "Bosse" && f.LastName == "Bildoktorn"),
                        context.Friends.Single(f => f.FirstName == "Sosse" && f.LastName == "Sildoktorn")
                    }
                });
        }
    }
}
