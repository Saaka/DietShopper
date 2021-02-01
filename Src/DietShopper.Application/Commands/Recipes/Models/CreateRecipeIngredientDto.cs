using System;

namespace DietShopper.Application.Commands.Recipes.Models
{
    public class CreateRecipeIngredientDto
    {
        public Guid ProductGuid { get; set; }
        public Guid MeasureGuid { get; set; }
        public decimal Amount { get; private set; }
        public string Note { get; private set; }
    }
}