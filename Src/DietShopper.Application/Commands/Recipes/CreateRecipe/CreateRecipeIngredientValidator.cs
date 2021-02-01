using System;
using DietShopper.Application.Commands.Recipes.Models;
using DietShopper.Domain.Constants.Validation;
using DietShopper.Domain.Enums;
using FluentValidation;

namespace DietShopper.Application.Commands.Recipes.CreateRecipe
{
    public class CreateRecipeIngredientValidator : AbstractValidator<CreateRecipeIngredientDto>
    {
        public CreateRecipeIngredientValidator()
        {
            RuleFor(x => x.ProductGuid)
                .NotEmpty()
                .WithMessageCode(ErrorCode.ProductGuidRequired);
            
            RuleFor(x => x.MeasureGuid)
                .NotEmpty()
                .WithMessageCode(ErrorCode.MeasureGuidRequired);
            
            RuleFor(x => x.Amount)
                .GreaterThan(Decimal.Zero)
                .WithMessageCode(ErrorCode.InvalidProductAmount);

            RuleFor(x => x.Note)
                .MaximumLength(IngredientValidationConstants.NoteMaxLength)
                .WithMessageCode(ErrorCode.IngredientNoteTooLong);
        }
    }
}