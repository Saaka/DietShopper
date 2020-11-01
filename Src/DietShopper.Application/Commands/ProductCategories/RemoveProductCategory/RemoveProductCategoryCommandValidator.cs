using DietShopper.Domain.Enums;
using FluentValidation;

namespace DietShopper.Application.Commands.ProductCategories.RemoveProductCategory
{
    public class RemoveProductCategoryCommandValidator : AbstractValidator<RemoveProductCategoryCommand>
    {
        public RemoveProductCategoryCommandValidator()
        {
            RuleFor(x => x.ProductCategoryGuid)
                .NotEmpty()
                .WithMessageCode(ErrorCode.ProductCategoryGuidRequired);
        }
    }
}