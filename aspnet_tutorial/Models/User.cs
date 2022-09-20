using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspnet_tutorial.Models
{
    [Table(("Users"))]
    public class User
    {
        // Constructor
        public User()
        {
            this.UserClaims = new HashSet<UserClaim>();
            this.UserLogins = new HashSet<UserLogin>();
        }

        // Properties
        [Key] 
        [StringLength(128)]
        public string Id { get; set; }
        
        [Required] 
        [StringLength(100)] 
        public string FirstName { get; set; }
        
        [Required] 
        [StringLength(100)] 
        public string LastName { get; set; }
        
        public string Email { get; set; }
        
        public bool? EmailConfirmed { get; set; }
        
        public string PasswordHash { get; set; }
        
        public string SecurityStamp { get; set; }
        
        public string PhoneNumber { get; set; }
        
        public bool? PhoneNumberConfirmed { get; set; }
        
        public bool? TwoFactorEnabled { get; set; }
        
        public DateTime? LockoutEndDateUtc { get; set; }
        
        public bool? LockoutEnabled { get; set; }
        
        public int? AccessFailedCount { get; set; }
        
        public string UserName { get; set; }
        
        // Add relationship to UserClaim and UserLogin models
        public virtual ICollection<UserClaim> UserClaims { get; set; }

        public virtual ICollection<UserLogin> UserLogins { get; set; }
    }
}