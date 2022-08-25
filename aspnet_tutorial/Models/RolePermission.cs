using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspnet_tutorial.Models
{
    [Table("roles_permissions")]
    public class RolePermission
    {
        // Constructor
        public RolePermission()
        {
            
        }
        
        // Properties 
        [Key]
        [Column(Order = 1)]
        [ForeignKey("Permission")]
        public long PermissionId { get; set; }

        [Key]
        [Column(Order = 2)]
        [ForeignKey("Role")]
        public long RoleId { get; set; }
        
        // Add relationship to Permission Model
        public virtual Permission Permission { get; set; }
        
        // Add relationship to User Model
        public virtual User User { get; set; }
    }
}