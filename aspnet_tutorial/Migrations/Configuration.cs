using aspnet_tutorial.Models;
using aspnet_tutorial.Seeders;

namespace aspnet_tutorial.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Data.AspNetDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Data.AspNetDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            // Category Seeders
            CategorySeeder.Run(context);
            // Product seeders
            ProductSeeder.Run(context);

            // Customer seeders
            CustomerSeeder.Run(context);

            // Order seeders
            OrderSeeder.Run(context);

            // Permission Seeders
            AuthSeeder.PermissionSeeder(context);

            // Role Seeders
            AuthSeeder.RoleSeeder(context);
        }
    }
}