using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspnet_tutorial.Models
{
    [Table("permissions")]
    public class Permission
    {
        // Constructor
        public Permission()
        {
            
        }
        
        // Properties
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}