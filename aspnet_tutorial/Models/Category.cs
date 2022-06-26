using System;
using System.Collections.Generic;
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
            this.Products = new HashSet<Product>();
        }

        // Properties
        [Key] public int Id { get; set; }

        public string CategoryName { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        //Add relationship to Product Model(One to Many)
        public virtual ICollection<Product> Products { get; set; }
    }
}