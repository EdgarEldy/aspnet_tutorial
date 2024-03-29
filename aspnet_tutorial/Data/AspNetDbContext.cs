﻿using System.Data.Entity;
using aspnet_tutorial.Models;

namespace aspnet_tutorial.Data
{
    public class AspNetDbContext : DbContext
    {
        // Constructor
        public AspNetDbContext()
            : base("name=AspNetDbContext")
        {

        }
        
        // Register models here..
        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order> Orders { get; set; }
        
        // Permissions
        public DbSet<Permission> Permissions { get; set; }
        
        // Roles
        public DbSet<Role> Roles { get; set; }
        
        // RolePermissions
        public DbSet<RolePermission> RolePermissions { get; set; }
        
        // Users
        public DbSet<User> Users { get; set; }
        
        // UserClaims
        public DbSet<UserClaim> UserClaims { get; set; }
        
        // UserLogins
        public DbSet<UserLogin> UserLogins { get; set; }
        
        // UserRoles
        public DbSet<UserRole> UserRoles { get; set; }
    }
}