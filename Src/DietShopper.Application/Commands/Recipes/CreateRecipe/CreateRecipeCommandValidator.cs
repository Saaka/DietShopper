using System.Linq;
using DietShopper.Domain.Constants.Validation;
using DietShopper.Domain.Enums;
using FluentValidation;

namespace DietShopper.Application.Commands.Recipes.CreateRecipe
{
    public class CreateRecipeCommandValidator : AbstractValidator<CreateRecipeCommand>
    {
        public CreateRecipeCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessageCode(ErrorCode.RecipeNameRequired)
                .MaximumLength(RecipeValidationConstant.RecipeNameMaxLength)
                .WithMessageCode(ErrorCode.RecipeNameTooLong);

            RuleFor(x => x.Description)
                .MaximumLength(RecipeValidationConstant.RecipeDescMaxLength)
                .WithMessageCode(ErrorCode.RecipeDescriptionTooLong);

            RuleForEach(x => x.Ingredients)
                .SetValidator(new CreateRecipeIngredientValidator());

            RuleFor(x => x.Ingredients)
                .Must(list => list.Select(x => x.ProductGuid).Distinct().Count() == list.Count)
                .WithMessageCode(ErrorCode.IngredientsMustBeUnique);
        }
    }
}