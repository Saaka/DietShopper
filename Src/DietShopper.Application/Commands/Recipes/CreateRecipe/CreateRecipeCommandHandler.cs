using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DietShopper.Application.Commands.Recipes.Models;
using DietShopper.Application.Models;
using DietShopper.Application.Repositories;
using DietShopper.Application.Services;
using DietShopper.Common.Requests;
using DietShopper.Domain.Entities;

namespace DietShopper.Application.Commands.Recipes.CreateRecipe
{
    public class CreateRecipeCommandHandler : RequestHandler<CreateRecipeCommand, RecipeDto>
    {
        private readonly IGuid _guid;
        private readonly IRecipesRepository _recipesRepository;
        private readonly IProductsRepository _productsRepository;
        private readonly IProductMeasuresRepository _productMeasuresRepository;

        public CreateRecipeCommandHandler(IGuid guid, IRecipesRepository recipesRepository, IProductsRepository productsRepository, IProductMeasuresRepository productMeasuresRepository)
        {
            _guid = guid;
            _recipesRepository = recipesRepository;
            _productsRepository = productsRepository;
            _productMeasuresRepository = productMeasuresRepository;
        }

        public override async Task<RequestResult<RecipeDto>> Handle(CreateRecipeCommand request, CancellationToken cancellationToken)
        {
            var recipe = new Recipe(_guid.GetGuid(), request.Context.User.UserId, request.Name, request.Description);
            await CreateIngredients(recipe, request.Ingredients);

            return new RequestResult<RecipeDto>(new RecipeDto());
        }

        private async Task CreateIngredients(Recipe recipe, List<CreateRecipeIngredientDto> ingredientModels)
        {
            var productIds = await _productsRepository.GetProductIdsByGuids(ingredientModels.Select(x => x.ProductGuid));
            var productMeasures = await _productMeasuresRepository.GetProductMeasureBaseByGuids(ingredientModels.Select(x => x.ProductMeasureGuid));
        }
    }
}