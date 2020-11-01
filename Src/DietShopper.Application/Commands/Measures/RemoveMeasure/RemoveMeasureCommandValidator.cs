using DietShopper.Domain.Enums;
using FluentValidation;

namespace DietShopper.Application.Commands.Measures.RemoveMeasure
{
    public class RemoveMeasureCommandValidator : AbstractValidator<RemoveMeasureCommand>
    {
        public RemoveMeasureCommandValidator()
        {
            RuleFor(x => x.MeasureGuid)
                .NotEmpty()
                .WithMessageCode(ErrorCode.MeasureGuidRequired);
        }
    }
}