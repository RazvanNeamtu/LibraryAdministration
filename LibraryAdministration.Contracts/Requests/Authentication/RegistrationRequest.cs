using System.ComponentModel.DataAnnotations;

namespace LibraryAdministration.Contracts.Requests.Authentication
{
    public class RegistrationRequest
    {
        [Required(ErrorMessage = "Email is mandatory!")]
        public string Email { get; set; } = null!;
        [Required(ErrorMessage = "Username is mandatory!")]
        public string Username { get; set; } = null!;
        /// <summary>
        /// Password must be at least 6 characters.
        /// </summary>
        [Required(ErrorMessage = "Password is mandatory!")]
        [MinLength(6)]
        public string Password { get; set; } = null!;
        [Required]
        [StringLength(13)]
        public string CNP { get; set; }
        [Required]
        [MinLength(1)]
        public string LastName { get; set; }
        [Required]
        [MinLength(1)]
        public string FirstName { get; set; }
    }
}
