using System.ComponentModel.DataAnnotations;

namespace LibraryAdministration.Contracts.Requests.Authentication
{
    public class AuthenticationRequest
    {
        [Required]
        public string Email { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
    }
}
