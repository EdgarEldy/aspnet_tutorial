using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspnet_tutorial.Models
{
    [Table("Orders")]
    public class Order
    {
        //Constructor
        public Order()
        {
            
        }
        
        // Properties goes here..
        [Key]
        public int Id { get; set; }

        [ForeignKey("CustomerId")]
        public int? CustomerId { get; set; }

        [ForeignKey("ProductId")]
        public int? ProductId { get; set; }

        public double Qty { get; set; }

        public double Total { get; set; }
        
        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        // Add relationship to Customer Model
        public virtual Customer Customer { get; set; }
        
        // Add relationship to Product Model
        public virtual Product Product { get; set; }
    }
}