using System;
using DietShopper.Common.Requests.Models;
using DietShopper.Domain.Enums;
using MediatR;

namespace DietShopper.Common.Requests
{
    public abstract class Request<TResult> : IRequest<RequestResult<TResult>>, IRequestBase
    {
        public Guid RequestGuid { get; } = Guid.NewGuid();
        public RequestContext Context { get; private set; }

        void IRequestBase.SetContext(RequestContext context) => Context = context;

        public RequestResult<TResult> Failure(ErrorCode error, string details = null)
            => new RequestResult<TResult>(error, details);

        public RequestResult<TResult> Success(TResult data)
            => new RequestResult<TResult>(data);
    }

    public abstract class Request : Request<Guid>
    {
        public RequestResult<Guid> Success()
            => new RequestResult<Guid>(RequestGuid);
    }
}