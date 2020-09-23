using Microsoft.AspNetCore.Mvc;

namespace DietShopper.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HealthCheckController: ControllerBase
    {
        [HttpGet]
        public IActionResult HealthCheck() => Ok("OK");
    }
}