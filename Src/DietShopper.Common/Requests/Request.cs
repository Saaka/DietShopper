using System;
using DietShopper.Domain.Enums;
using MediatR;

namespace DietShopper.Common.Requests
{
    public abstract class Request<TResult> : IRequest<RequestResult<TResult>>, IRequestBase
    {
        public Guid RequestGuid { get; } = Guid.NewGuid();

        public RequestResult<TResult> ReturnFailure(ErrorCode error, string details = null)
            => new RequestResult<TResult>(error, details);

        public RequestResult<TResult> ReturnSuccess(TResult data)
            => new RequestResult<TResult>(data);
    }

    public abstract class Request : Request<Guid>
    {
        public RequestResult<Guid> ReturnSuccess()
            => new RequestResult<Guid>(RequestGuid);
    }
}