using DietShopper.Domain.Enums;
using FluentValidation;

namespace DietShopper.Application.Products.Commands.RemoveProductCategory
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