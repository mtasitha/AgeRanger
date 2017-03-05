namespace AgeRanger.Web.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AgeRanger.Web.Models.AgeRangerDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AgeRangerDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            context.AgeGroups.AddOrUpdate(
                new AgeGroup { Id = 1, Description = "Toddler", MinAge = 0, MaxAge = 2 },
                new AgeGroup { Id = 2, Description = "Child", MinAge = 2, MaxAge = 14 },
                new AgeGroup { Id = 3, Description = "Teenager", MinAge = 14, MaxAge = 20 },
                new AgeGroup { Id = 4, Description = "Early twenties", MinAge = 20, MaxAge = 25 },
                new AgeGroup { Id = 5, Description = "Almost thirty", MinAge = 25, MaxAge = 30 },
                new AgeGroup { Id = 6, Description = "Very adult", MinAge = 30, MaxAge = 50 },
                new AgeGroup { Id = 7, Description = "Kinda old", MinAge = 50, MaxAge = 70 },
                new AgeGroup { Id = 8, Description = "Old", MinAge = 70, MaxAge = 99 },
                new AgeGroup { Id = 9, Description = "Very old", MinAge = 99, MaxAge = 110 },
                new AgeGroup { Id = 10, Description = "Crazy ancient", MinAge = 110, MaxAge = 199 },
                new AgeGroup { Id = 11, Description = "Vampire", MinAge = 199, MaxAge = 4999 },
                new AgeGroup { Id = 12, Description = "Kauri tree", MinAge = 4999, MaxAge = null }
            );
        }
    }
}
