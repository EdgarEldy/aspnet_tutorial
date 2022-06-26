using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspnet_tutorial.Models
{
    [Table("Categories")]
    public class Category
    {
        // Constructor
        public Category()
        {
            
        }
        
        // Properties
        [Key]
        public int Id { get; set; }

        public string CategoryName { get; set; }

        public DateTime? CreatedAt { get; set; }
        
        public DateTime? UpdatedAt { get; set; }
    }
}