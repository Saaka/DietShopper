using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DietShopper.Application.Commands.Recipes.Models;
using DietShopper.Application.Models;
using DietShopper.Application.Repositories;
using DietShopper.Application.Services;
using DietShopper.Common.Requests;
using DietShopper.Domain.Entities;
using DietShopper.Domain.Enums;
using DietShopper.Domain.Exceptions;

namespace DietShopper.Application.Commands.Recipes.CreateRecipe
{
    public class CreateRecipeCommandHandler : RequestHandler<CreateRecipeCommand, RecipeDto>
    {
        private readonly IGuid _guid;
        private readonly IMapper _mapper;
        private readonly IRecipesRepository _recipesRepository;
        private readonly IProductsRepository _productsRepository;
        private readonly IProductMeasuresRepository _productMeasuresRepository;

        public CreateRecipeCommandHandler(IGuid guid, IMapper mapper, IRecipesRepository recipesRepository, IProductsRepository productsRepository,
            IProductMeasuresRepository productMeasuresRepository)
        {
            _guid = guid;
            _mapper = mapper;
            _recipesRepository = recipesRepository;
            _productsRepository = productsRepository;
            _productMeasuresRepository = productMeasuresRepository;
        }

        public override async Task<RequestResult<RecipeDto>> Handle(CreateRecipeCommand request, CancellationToken cancellationToken)
        {
            var recipe = new Recipe(_guid.GetGuid(), request.Context.User.UserId, request.Name, request.Description);
            await CreateIngredients(recipe, request.Ingredients);

            await _recipesRepository.Save(recipe);
            return new RequestResult<RecipeDto>(_mapper.Map<RecipeDto>(recipe));
        }

        private async Task CreateIngredients(Recipe recipe, List<CreateRecipeIngredientDto> ingredientModels)
        {
            var productIds = await _productsRepository.GetProductIdsByGuids(ingredientModels.Select(x => x.ProductGuid));
            var productMeasures = await _productMeasuresRepository.GetProductMeasureBaseByGuids(ingredientModels.Select(x => x.ProductMeasureGuid));

            foreach (var ingredientModel in ingredientModels)
            {
                var productId = productIds.FirstOrDefault(x => x.ProductGuid == ingredientModel.ProductGuid);
                var measure = productMeasures.FirstOrDefault(x => x.ProductMeasureGuid == ingredientModel.ProductMeasureGuid);
                if (productId == null)
                    throw new DomainException(ErrorCode.ProductNotExists, new { ingredientModel.ProductGuid });
                if (measure == null)
                    throw new DomainException(ErrorCode.ProductMeasureNotFound, new { ingredientModel.ProductMeasureGuid });

                var ingredient = new Ingredient(_guid.GetGuid(), productId.ProductId, measure.ProductMeasureId, ingredientModel.Amount,
                    ingredientModel.Amount * measure.ValueInGrams, ingredientModel.Note);

                recipe.AddIngredient(ingredient);
            }
        }
    }
}