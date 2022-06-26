using aspnet_tutorial.Models;
using MySql.Data.EntityFramework;

namespace aspnet_tutorial.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<aspnet_tutorial.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            SetSqlGenerator("MySql.Data.MySqlClient", new MySqlMigrationSqlGenerator());
        }

        protected override void Seed(aspnet_tutorial.Data.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            // Category Seeders
            context.Categories.AddOrUpdate(x => x.Id,
                new Category()
                {
                    Id = 1,
                    CategoryName = "Lemonades"
                },
                new Category()
                {
                    Id = 2,
                    CategoryName = "Alcohols"
                });

            // Product seeders
            context.Products.AddOrUpdate(x => x.Id,
                new Product()
                {
                    Id = 1,
                    CategoryId = 1,
                    ProductName = "Citron",
                    UnitPrice = 800,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Product()
                {
                    Id = 2,
                    CategoryId = 1,
                    ProductName = "Coca Cola",
                    UnitPrice = 800,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Product()
                {
                    Id = 3,
                    CategoryId = 2,
                    ProductName = "Amstel 50 cl",
                    UnitPrice = 1800,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Product()
                {
                    Id = 4,
                    CategoryId = 2,
                    ProductName = "Primus 50 cl",
                    UnitPrice = 1500,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                });
        }
    }
}