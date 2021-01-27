using System.Threading;
using System.Threading.Tasks;
using DietShopper.Application.Services;
using DietShopper.Common.Requests;
using MediatR;

namespace DietShopper.Shared.Behaviors
{
    public class RequestAuthorizationValidatorBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequestBase
    {
        private readonly IRequestAuthorizationValidator _requestAuthorizationValidator;

        public RequestAuthorizationValidatorBehavior(IRequestAuthorizationValidator requestAuthorizationValidator)
        {
            _requestAuthorizationValidator = requestAuthorizationValidator;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            _requestAuthorizationValidator.ValidateRequest(request);

            return await next();
        }
    }
}