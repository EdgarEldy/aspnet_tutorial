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

            // Order seeders
            context.Orders.AddOrUpdate(x => x.Id,
                new Order()
                {
                    Id = 1,
                    CustomerId = 1,
                    ProductId = 1,
                    Qty = 2,
                    Total = 1600,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Order()
                {
                    Id = 2,
                    CustomerId = 2,
                    ProductId = 3,
                    Qty = 3,
                    Total = 5400,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now 
                });
        }
    }
}