using DietShopper.Domain.Constants.Validation;
using DietShopper.Domain.Enums;
using FluentValidation;

namespace DietShopper.Application.Commands.ProductCategories.UpdateProductCategory
{
    public class UpdateProductCategoryCommandValidator : AbstractValidator<UpdateProductCategoryCommand>
    {
        public UpdateProductCategoryCommandValidator()
        {
            RuleFor(x => x.ProductCategoryGuid)
                .NotEmpty()
                .WithMessageCode(ErrorCode.ProductCategoryGuidRequired);

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessageCode(ErrorCode.ProductCategoryNameRequired)
                .MaximumLength(ProductCategoryValidationConstants.ProductCategoryNameMaxLength)
                .WithMessageCode(ErrorCode.ProductCategoryNameTooLong);
        }
    }
}