﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspnet_tutorial.Models
{
    [Table("Permissions")]
    public class Permission
    {
        // Constructor
        public Permission()
        {
            this.RolePermissions = new HashSet<RolePermission>();
        }
        
        // Properties
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        
        // Add relationship to RolePermission Model
        public virtual ICollection<RolePermission> RolePermissions { get; set; }
    }
}