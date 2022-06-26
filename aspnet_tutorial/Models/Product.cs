using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspnet_tutorial.Models
{
    [Table("Products")]
    public class Product
    {
        //Constructor
        public Product()
        {
            
        }
        
        // Properties goes here..
        public int Id { get; set; }

        public int? CategoryId { get; set; }

        public string ProductName { get; set; }

        public double UnitPrice { get; set; }
        
        public DateTime? CreatedAt { get; set; }
        
        public DateTime? UpdatedAt { get; set; }
    }
}