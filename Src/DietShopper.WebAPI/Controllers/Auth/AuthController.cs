using System.Threading.Tasks;
using DietShopper.Application.Auth.Commands;
using DietShopper.Application.Auth.Models;
using Microsoft.AspNetCore.Mvc;

namespace DietShopper.WebAPI.Controllers.Auth
{
    public class AuthController : BaseApiController
    {
        [HttpPost("google")]
        public async Task<ActionResult<AuthorizationData>> AuthorizeWithGoogle(AuthorizeUserWithGoogleCommand request)
        {
            var result = await Mediator.Send(request);
            return GetResponse(result);
        }
    }
}