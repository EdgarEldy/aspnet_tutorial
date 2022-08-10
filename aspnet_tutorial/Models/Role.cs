using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspnet_tutorial.Models
{
    [Table("roles")]
    public class Role
    {
        // Constructor
        public Role()
        {
            
        }
        
        // Properties
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}