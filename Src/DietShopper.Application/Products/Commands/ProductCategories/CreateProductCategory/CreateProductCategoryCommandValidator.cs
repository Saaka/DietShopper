using DietShopper.Domain.Constants.Validation;
using DietShopper.Domain.Enums;
using FluentValidation;

namespace DietShopper.Application.Products.Commands.ProductCategories.CreateProductCategory
{
    public class CreateProductCategoryCommandValidator : AbstractValidator<CreateProductCategoryCommand>
    {
        public CreateProductCategoryCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessageCode(ErrorCode.ProductCategoryNameRequired)
                .MaximumLength(ProductCategoryValidationConstants.ProductCategoryNameMaxLength)
                .WithMessageCode(ErrorCode.ProductCategoryNameTooLong);
        }
    }
}