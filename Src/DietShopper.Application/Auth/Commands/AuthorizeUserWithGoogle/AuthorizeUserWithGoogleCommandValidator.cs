using DietShopper.Domain.Enums;
using FluentValidation;

namespace DietShopper.Application.Auth.Commands.AuthorizeUserWithGoogle
{
    public class AuthorizeUserWithGoogleCommandValidator: AbstractValidator<AuthorizeUserWithGoogleCommand>
    {
        public AuthorizeUserWithGoogleCommandValidator()
        {
            RuleFor(x => x.GoogleToken)
                .NotEmpty()
                .WithMessageCode(ValidationErrorCode.AuthProviderTokenRequired);
        }   
    }
}