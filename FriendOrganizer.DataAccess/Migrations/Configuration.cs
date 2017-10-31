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
        }
    }
}
