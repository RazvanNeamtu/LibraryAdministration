﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryAdministration.DataAccess.Entities
{
    public class UserInfo
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string CNP { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FirstName { get; set; }
        public IdentityUser? IdentityUser { get; set; }
        public string? IdentityUserId { get; set; }
    }
}
