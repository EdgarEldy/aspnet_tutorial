using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using aspnet_tutorial.Data;
using aspnet_tutorial.Models;

namespace aspnet_tutorial.Seeders
{
    public class CustomerSeeder : CreateDatabaseIfNotExists<AspNetDbContext>
    {
        // Customers data seeder goes here..
        public static void Run(AspNetDbContext context)
        {
            if (context.Customers.Any()) return;

            var customers = new List<Customer>()
            {
                new Customer()
                {
                    FirstName = "Edgar",
                    LastName = "Eldy",
                    Tel = "+25765346712",
                    Email = "edgar@mailnator.com",
                    Address = "NYC"
                },
                new Customer()
                {
                    FirstName = "John",
                    LastName = "Travolta",
                    Tel = "+25765774016",
                    Email = "john@mailnator.com",
                    Address = "LA"
                },
            };

            foreach (var customer in customers)
            {
                context.Customers.Add(customer);
                context.SaveChanges();
            }
        }
    }
}