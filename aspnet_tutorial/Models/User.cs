using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspnet_tutorial.Models
{
    [Table(("users"))]
    public class User
    {
        // Constructor
        public User()
        {
        }

        // Properties
        [Key] public long Id { get; set; }
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
    }
}