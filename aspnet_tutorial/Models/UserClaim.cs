using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspnet_tutorial.Models
{
    [Table("users_claims")]
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
        public long UserId { get; set; }

        public string ClaimType { get; set; }

        public string ClaimValue { get; set; }
    }
}