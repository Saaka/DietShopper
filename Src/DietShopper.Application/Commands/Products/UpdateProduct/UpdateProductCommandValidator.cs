using System.Linq;
using DietShopper.Domain.Constants.Validation;
using DietShopper.Domain.Enums;
using FluentValidation;

namespace DietShopper.Application.Commands.Products.UpdateProduct
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(x => x.ProductGuid)
                .NotEmpty()
                .WithMessageCode(ErrorCode.ProductGuidRequired);
            
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessageCode(ErrorCode.ProductNameRequired)
                .MaximumLength(ProductValidationConstants.ProductNameMaxLength)
                .WithMessageCode(ErrorCode.ProductNameTooLong);

            RuleFor(x => x.ShortName)
                .MaximumLength(ProductValidationConstants.ProductShortNameMaxLength)
                .WithMessageCode(ErrorCode.ProductShortNameTooLong);

            RuleFor(x => x.Description)
                .MaximumLength(ProductValidationConstants.ProductDescriptionMaxLength)
                .WithMessageCode(ErrorCode.ProductDescriptionTooLong);

            RuleFor(x => x.ProductCategoryGuid)
                .NotEmpty()
                .WithMessageCode(ErrorCode.ProductCategoryGuidRequired);

            RuleFor(x => x.ProductMeasures)
                .Must(l => l.Select(x=> x.MeasureGuid).Distinct().Count() == l.Count)
                .WithMessageCode(ErrorCode.ProductMeasuresMustBeUnique);
        }
    }
}