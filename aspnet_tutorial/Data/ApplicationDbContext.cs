﻿using System.Data.Entity;
using aspnet_tutorial.Models;

namespace aspnet_tutorial.Data
{
    public class ApplicationDbContext : DbContext
    {
        // Constructor
        public ApplicationDbContext()
            : base("name=ApplicationDbContext")
        {

        }
        
        // Register models here..
        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order> Orders { get; set; }
    }
}