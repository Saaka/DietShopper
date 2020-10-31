using DietShopper.Domain.Constants.Validation;
using DietShopper.Domain.Enums;
using FluentValidation;

namespace DietShopper.Application.Products.Commands.Measures.UpdateMeasure
{
    public class UpdateMeasureCommandValidator : AbstractValidator<UpdateMeasureCommand>
    {
        public UpdateMeasureCommandValidator()
        {
            RuleFor(x => x.MeasureGuid)
                .NotEmpty()
                .WithMessageCode(ErrorCode.MeasureGuidRequired);
            
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessageCode(ErrorCode.MeasureNameRequired)
                .MaximumLength(MeasureValidationConstants.MeasureNameMaxLength)
                .WithMessageCode(ErrorCode.MeasureNameTooLong);
            
            RuleFor(x => x.Symbol)
                .NotEmpty()
                .WithMessageCode(ErrorCode.MeasureSymbolRequired)
                .MaximumLength(MeasureValidationConstants.MeasureSymbolMaxLength)
                .WithMessageCode(ErrorCode.MeasureSymbolTooLong);

            When(x => x.IsWeight, () =>
            {
                RuleFor(x => x.ValueInGrams)
                    .NotEmpty()
                    .WithMessageCode(ErrorCode.MeasureValueInGramsRequiredForWeightType);
            });
        }
    }
}