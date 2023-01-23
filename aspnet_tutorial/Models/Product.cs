using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspnet_tutorial.Models
{
    [Table("Products")]
    public class Product
    {
        //Constructor
        public Product()
        {
            this.Orders = new HashSet<Order>();
        }
        
        // Properties goes here..
        public int Id { get; set; }

        [ForeignKey("Category")]
        public int? CategoryId { get; set; }

        public string ProductName { get; set; }

        public double UnitPrice { get; set; }
        
        public DateTime? CreatedAt { get; set; }
        
        public DateTime? UpdatedAt { get; set; }

        // Add relationship to Category Model
        public virtual Category Category { get; set; }
        
        // Add relationship to Order model
        public virtual  ICollection<Order> Orders { get; set; }
    }
}