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
                    CategoryName = "Lemonades",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Category()
                {
                    Id = 2,
                    CategoryName = "Alcohols",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
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

            // Customer seeders
            context.Customers.AddOrUpdate(x => x.Id,
                new Customer()
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    Tel = "+125684128",
                    Email = "johndoe@gmail.com",
                    Address = "Queens",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                },
                new Customer()
                {
                    Id = 1,
                    FirstName = "James",
                    LastName = "Jones",
                    Tel = "+181235796",
                    Email = "jamesjones@gmail.com",
                    Address = "NYC",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                });

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