﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspnet_tutorial.Models
{
    [Table("users_logins")]
    public class UserLogin
    {
        // Constructor
        public UserLogin()
        {
        }
        
        // Properties
        [Key]
        [Column(Order = 1)]
        [ForeignKey("User")]
        public long UserId { get; set; }
        
        [Key]
        [Column(Order = 2)]
        public string LoginProvider { get; set; }

        [Key]
        [Column(Order = 3)]
        public string ProviderKey { get; set; }
    }
}