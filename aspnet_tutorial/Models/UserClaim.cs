using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspnet_tutorial.Models
{
    [Table("UserClaims")]
    public class UserClaim
    {
        // Constructor
        public UserClaim()
        {
        }
        
        // Properties
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        [StringLength(128)]
        public string UserId { get; set; }

        public string ClaimType { get; set; }

        public string ClaimValue { get; set; }
        
        // Add relationship to User Model
        public virtual User User { get; set; }
    }
}