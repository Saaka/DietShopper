using DietShopper.Domain.Constants.Validation;
using DietShopper.Domain.Enums;
using FluentValidation;

namespace DietShopper.Application.Commands.Measures.CreateMeasure
{
    public class CreateMeasureCommandValidator : AbstractValidator<CreateMeasureCommand>
    {
        public CreateMeasureCommandValidator()
        {
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