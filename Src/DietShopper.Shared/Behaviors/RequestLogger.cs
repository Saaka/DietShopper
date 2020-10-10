using System.Threading;
using System.Threading.Tasks;
using DietShopper.Common.Requests;
using DietShopper.Shared.Exceptions;
using Microsoft.Extensions.Logging;

namespace DietShopper.Shared.Behaviors
{
    public class RequestLogger<TRequest, TResponse> : MediatR.IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequestBase
    {
        private readonly ILogger _logger;

        public RequestLogger(ILogger<RequestLogger<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken,
            MediatR.RequestHandlerDelegate<TResponse> next)
        {
            var name = typeof(TRequest).Name;
            TResponse response;

            _logger.LogInformation("{Name} handler started. [RequestGuid:{RequestGuid}]", 
                name, request.RequestGuid);
            try
            {
                response = await next();
            }
            catch (CommandValidationException)
            {
                _logger.LogWarning("{Name} handler validation failed. [RequestGuid:{RequestGuid}]",
                    name, request.RequestGuid);
                throw;
            }
            catch
            {
                _logger.LogError("{Name} handler failed with exception. [RequestGuid:{RequestGuid}]", 
                    name, request.RequestGuid);
                throw;
            }

            _logger.LogInformation("{Name} handler finished. [RequestGuid:{RequestGuid}]",
                name, request.RequestGuid);

            return response;
        }
    }
}