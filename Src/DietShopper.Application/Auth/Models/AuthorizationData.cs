namespace DietShopper.Application.Auth.Models
{
    public class AuthorizationData
    {
        public AuthUserData User { get; set; }
        public string Token { get; set; }
    }
}