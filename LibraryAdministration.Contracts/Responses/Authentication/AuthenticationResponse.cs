namespace LibraryAdministration.Contracts.Responses.Authentication
{
    public class AuthenticationResponse
    {
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Token { get; set; } = null!;
    }
}
