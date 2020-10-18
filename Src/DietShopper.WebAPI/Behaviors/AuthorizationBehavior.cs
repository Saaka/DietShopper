using System.Threading;
using System.Threading.Tasks;
using DietShopper.Common.Requests;
using DietShopper.WebAPI.Services;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace DietShopper.WebAPI.Behaviors
{
    public class AuthorizationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequestBase
    {
        private readonly IHttpContextAccessor  _contextAccessor;
        private readonly IContextDataProvider _contextDataProvider;

        public AuthorizationBehavior(IHttpContextAccessor  contextAccessor,
            IContextDataProvider contextDataProvider)
        {
            _contextAccessor = contextAccessor;
            _contextDataProvider = contextDataProvider;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next)
        {
            var requestContext = await _contextDataProvider.GetRequestContext(_contextAccessor.HttpContext);
            request.SetContext(requestContext);

            return await next();
        }
    }
}