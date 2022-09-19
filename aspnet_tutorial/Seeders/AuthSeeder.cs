using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using aspnet_tutorial.Models;
using ApplicationDbContext = aspnet_tutorial.Data.ApplicationDbContext;

namespace aspnet_tutorial.Seeders
{
    public class AuthSeeder : CreateDatabaseIfNotExists<ApplicationDbContext>
    {
        // Permissions seeder
        public static void PermissionSeeder(ApplicationDbContext context)
        {
            if (context.Permissions.Any()) return;
            var permissions = new List<string>
            {
                // Roles
                "roles.create",
                "roles.show",
                "roles.edit",
                "roles.delete",

                // Users
                "users.create",
                "users.show",
                "users.edit",
                "users.delete",

                // Categories
                "categories.create",
                "categories.show",
                "categories.edit",
                "categories.delete",

                // Products
                "products.create",
                "products.show",
                "products.edit",
                "products.delete",

                // Customers
                "customers.create",
                "customers.show",
                "customers.edit",
                "customers.delete",

                // Orders
                "orders.create",
                "orders.show",
                "orders.edit",
                "orders.delete",
            };

            foreach (var permission in permissions)
            {
                context.Permissions.Add(new Permission
                {
                    Name = permission
                });
            }

            context.SaveChanges();
        }
    }
}