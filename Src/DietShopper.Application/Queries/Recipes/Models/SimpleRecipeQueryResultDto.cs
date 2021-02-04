using System;

namespace DietShopper.Application.Queries.Recipes.Models
{
    public class SimpleRecipeQueryResultDto
    {
        public Guid RecipeGuid { get; set; }
        public string Name { get; set; }
    }
}