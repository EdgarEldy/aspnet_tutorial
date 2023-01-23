using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using aspnet_tutorial.Data;
using aspnet_tutorial.Models;

namespace aspnet_tutorial.Seeders
{
    public class OrderSeeder : CreateDatabaseIfNotExists<AspNetDbContext>
    {
        // Orders data seeder goes here..
        public static void Run(AspNetDbContext context)
        {
            if (context.Orders.Any()) return;

            var orders = new List<Order>()
            {
                new Order()
                {
                    CustomerId = 1,
                    ProductId = 1,
                    Qty = 2,
                    Total = 1600
                },
                new Order()
                {
                    CustomerId = 2,
                    ProductId = 2,
                    Qty = 4,
                    Total = 6000
                },
            };

            foreach (var order in orders)
            {
                context.Orders.Add(order);
                context.SaveChanges();
            }
        }
    }
}