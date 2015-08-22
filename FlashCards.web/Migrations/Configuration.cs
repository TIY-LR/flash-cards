using System.Collections.Generic;
using FlashCards.web.Models;

namespace FlashCards.web.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FlashCards.web.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(FlashCards.web.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Courses.AddOrUpdate(x => x.Name,
                new Course() { Name = "Dot Net" },
                new Course()
                {
                    Name = "Front End",

                    CardSets = new List<CardSet>()
                    {
                        new CardSet() {
                        Description = "javascript desc",
                        Name = "javascript",
                        Cards = new List<Card>()
                            {
                                new Card() {FrontText = "What is Javascript??", BackText = "A way to make stuff"}
                            }
                        }

                    },

                }
             );
        }
    }
}
