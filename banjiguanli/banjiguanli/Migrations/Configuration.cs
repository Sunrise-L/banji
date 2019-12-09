namespace banjiguanli.Migrations
{
    using banjiguanli.Migrations.Seeds;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<banjiguanli.Models.ClassEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(banjiguanli.Models.ClassEntities context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            new ActionLinksCreator(context).Seed();
            new SideBarsCreator(context).Seed();
            new UsersCreator(context).Seed();
        }
    }
}
