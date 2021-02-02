using System.Threading.Tasks;
using DietShopper.Application.Commands.Recipes;
using DietShopper.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DietShopper.WebAPI.Controllers.Recipes
{
    [Authorize]
    public class RecipesController : BaseApiController
    {
        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<RecipeDto>> CreateProduct(CreateRecipeCommand request)
        {
            var result = await Mediator.Send(request);

            return GetResponse(result);
        }
    }
}