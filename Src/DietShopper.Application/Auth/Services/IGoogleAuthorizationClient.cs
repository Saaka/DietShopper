using System.Threading.Tasks;
using DietShopper.Application.Auth.Models;

namespace DietShopper.Application.Auth.Services
{
    public interface IGoogleAuthorizationClient
    {
        Task<AuthorizationData> AuthorizeWithGoogleToken(string googleToken);
    }
}