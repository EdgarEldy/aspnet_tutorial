using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using aspnet_tutorial.Models;
using Microsoft.AspNet.Identity;
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

        // Add roles data seeder and attribute every role to a permission
        public static void RoleSeeder(ApplicationDbContext context)
        {
            if (context.Roles.Any()) return;

            var roles = new List<Role>
            {
                new Role
                {
                    Name = "Admin",
                    RolePermissions = new List<RolePermission>()
                },
                new Role
                {
                    Name = "User",
                    RolePermissions = new List<RolePermission>()
                }
            };

            foreach (var role in roles)
            {
                var permissions = new List<Permission>();

                if (role.Name == "Admin")
                {
                    permissions = context.Permissions.ToList();
                }

                else
                {
                    permissions = context.Permissions.Where(p => !DbFunctions.Like(p.Name, "Users.%"))
                        .Where(p => !DbFunctions.Like(p.Name, "Roles.%")).ToList();
                }

                foreach (var permission in permissions)
                {
                    var rolePermission = new RolePermission
                    {
                        Permission = permission
                    };

                    role.RolePermissions.Add(rolePermission);
                }

                context.Roles.Add(role);
                context.SaveChanges();
            }
        }

        // Add user data seeder and attribute admin role to user
        public static void UserSeeder(ApplicationDbContext context)
        {

            var user = new User
            {
                FirstName = "Super",
                LastName = "Admin",
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "72 800 800",
                PhoneNumberConfirmed = true,
                PasswordHash = new PasswordHasher().HashPassword("Pa$$w0rd"),
                SecurityStamp = Guid.NewGuid().ToString(),
                TwoFactorEnabled = false,
                LockoutEnabled = true,
                AccessFailedCount = 0
            };

            context.Users.Add(user);
            context.SaveChanges();

            var userRole = new UserRole
            {
                UserId = context.Users.First(u => u.Email == "admin@gmail.com").Id,
                RoleId = (context.Roles.First(p => p.Name == "Admin")).Id
            };

            context.UserRoles.Add(userRole);
            context.SaveChanges();
        }
    }
}