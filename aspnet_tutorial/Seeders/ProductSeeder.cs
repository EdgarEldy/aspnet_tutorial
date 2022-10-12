using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using aspnet_tutorial.Data;
using aspnet_tutorial.Models;
using Microsoft.AspNet.Identity.Owin;

namespace aspnet_tutorial.Seeders
{
    public class ProductSeeder : CreateDatabaseIfNotExists<AspNetDbContext>
    {
        // Products data seeder goes here..
        public static void Run(AspNetDbContext context)
        {
            if (context.Products.Any()) return;

            var products = new List<Product>
            {
                new Product
                {
                    CategoryId = 1,
                    ProductName = "Fanta Citron 33 L",
                    UnitPrice = 800,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Product
                {
                    CategoryId = 1,
                    ProductName = "Fanta Orange 33 L",
                    UnitPrice = 800,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Product
                {
                    CategoryId = 2,
                    ProductName = "Amstel 50 CL",
                    UnitPrice = 1500,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Product
                {
                    CategoryId = 1,
                    ProductName = "Amstel 65 CL",
                    UnitPrice = 2500,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                }
            };

            foreach (var product in products)
            {
                context.Products.Add(product);
                context.SaveChanges();
            }
        }
    }
}