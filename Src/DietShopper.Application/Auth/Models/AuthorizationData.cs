namespace DietShopper.Application.Auth.Models
{
    public class AuthorizationData
    {
        public AuthorizationUserData User { get; set; }
        public string Token { get; set; }
    }
}