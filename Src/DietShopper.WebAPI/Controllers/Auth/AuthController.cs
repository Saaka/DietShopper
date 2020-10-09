using System.Threading.Tasks;
using DietShopper.Application.Auth.Models;
using DietShopper.WebAPI.Controllers.Auth.Models;
using Microsoft.AspNetCore.Mvc;

namespace DietShopper.WebAPI.Controllers.Auth
{
    [Route("api/[controller]")]
    public class AuthController : BaseApiController
    {

        [HttpPost("google")]
        public async Task<ActionResult<AuthorizationData>> AuthorizeWithGoogle(AuthorizeUserWithGoogleRequest request)
        {
            return Ok();
        }
    }
}