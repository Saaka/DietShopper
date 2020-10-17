using System.Threading.Tasks;
using DietShopper.Application.Auth.Commands;
using DietShopper.Application.Auth.Models;
using DietShopper.WebAPI.Controllers.Auth.Models;
using Microsoft.AspNetCore.Mvc;

namespace DietShopper.WebAPI.Controllers.Auth
{
    public class AuthController : BaseApiController
    {
        [HttpPost("google")]
        public async Task<ActionResult<AuthorizationData>> AuthorizeWithGoogle(AuthorizeUserWithGoogleRequest request)
        {
            var result = await Mediator.Send(Mapper.Map<AuthorizeUserWithGoogleCommand>(request));
            return GetResponse(result);
        }
    }
}