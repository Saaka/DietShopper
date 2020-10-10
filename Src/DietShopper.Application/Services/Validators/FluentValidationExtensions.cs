using DietShopper.Domain.Enums;

namespace FluentValidation
{
    public static class FluentValidationExtensions
    {
        public static IRuleBuilderOptions<T, TProperty> WithMessageCode<T, TProperty>(
            this IRuleBuilderOptions<T, TProperty> rule, ValidationErrorCode code)
            => rule.WithMessage(code.ToString());
    }
}