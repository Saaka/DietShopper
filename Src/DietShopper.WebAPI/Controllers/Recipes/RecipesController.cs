using System.Threading.Tasks;
using DietShopper.Application.Commands.Recipes;
using DietShopper.Application.Models;
using DietShopper.Application.Queries.Recipes;
using DietShopper.Application.Queries.Recipes.Models;
using DietShopper.Common.Models;
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

        [HttpPost]
        [Route("list/user")]
        public async Task<ActionResult<PagedList<SimpleRecipeQueryResultDto>>> GetProducts(GetUserRecipesQuery request)
        {
            var result = await Mediator.Send(request);
            return GetResponse(result);
        }
    }
}