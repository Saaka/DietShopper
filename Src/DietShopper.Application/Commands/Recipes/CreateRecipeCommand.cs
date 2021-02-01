using System.Collections.Generic;
using DietShopper.Application.Commands.Recipes.Models;
using DietShopper.Application.Models;
using DietShopper.Common.Requests;

namespace DietShopper.Application.Commands.Recipes
{
    public class CreateRecipeCommand : Request<RecipeDto>, IRequestWithBasicAuthorization
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<CreateRecipeIngredientDto> Ingredients { get; set; } = new List<CreateRecipeIngredientDto>();
    }
}