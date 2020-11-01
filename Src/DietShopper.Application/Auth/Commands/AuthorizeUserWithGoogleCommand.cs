using DietShopper.Application.Auth.Models;
using DietShopper.Common.Requests;

namespace DietShopper.Application.Auth.Commands
{
    public class AuthorizeUserWithGoogleCommand : Request<AuthorizationData>
    {
        public string GoogleToken { get; set; }
    }
}