using DietShopper.Domain.Enums;

namespace FluentValidation
{
    public static class FluentValidationExtensions
    {
        public static IRuleBuilderOptions<T, TProperty> WithMessageCode<T, TProperty>(
            this IRuleBuilderOptions<T, TProperty> rule, ErrorCode code)
            => rule.WithMessage(code.ToString());
    }
}