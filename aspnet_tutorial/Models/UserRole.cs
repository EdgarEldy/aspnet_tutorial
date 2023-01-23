using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspnet_tutorial.Models
{
    [Table("UserRoles")]
    public class UserRole
    {
        // Constructor
        public UserRole()
        {
            
        }

        // Properties
        [Key]
        [Column(Order = 1)]
        [ForeignKey("User")]
        public long UserId { get; set; }

        [Key]
        [Column(Order = 2)]
        [ForeignKey("Role")]
        public long RoleId { get; set; }

        // Add relationship to User model
        public virtual User User { get; set; }

        // Add relationship to Role model
        public virtual Role Role { get; set; }
    }
}