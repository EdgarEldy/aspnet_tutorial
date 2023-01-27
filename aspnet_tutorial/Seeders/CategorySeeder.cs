using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using aspnet_tutorial.Data;
using aspnet_tutorial.Models;

namespace aspnet_tutorial.Seeders
{
    public class CategorySeeder : CreateDatabaseIfNotExists<AspNetDbContext>
    {
        // Category Seeders
        public static void Run(AspNetDbContext context)
        {
            if (context.Categories.Any()) return;

            var categories = new List<Category>()
            {
                new Category()
                {
                    CategoryName = "Lemonades",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Category()
                {
                    CategoryName = "Alcohols",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
            };

            foreach (var category in categories)
            {
                context.Categories.Add(category);
                context.SaveChanges();
            }
        }
    }
}