using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspnet_tutorial.Models
{
    [Table("Roles")]
    public class Role
    {
        // Constructor
        public Role()
        {
            this.RolePermissions = new HashSet<RolePermission>();
        }

        // Properties
        [Key] 
        public long Id { get; set; }

        public string Name { get; set; }

        // Add relationship to RolePermission Model
        public virtual ICollection<RolePermission> RolePermissions { get; set; }
    }
}