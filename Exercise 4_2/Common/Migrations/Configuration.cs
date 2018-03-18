namespace Common.Migrations
{
    using Common.Model;
    using CommonContext;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(CoreContext context)
        {
            List<User> users = new List<User>()
            {
                new User() {FirstName="Jane", LastName="Doe", DOB=DateTime.Parse("01/06/1980"), Email="jane@email.com"}
            };

            users.ForEach(u => context.Users.Add(u));
            context.SaveChanges();
        }
    }
}
