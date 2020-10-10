using System;
using DietShopper.Domain.Enums;

namespace DietShopper.Common.Requests
{
    public class RequestResult
    {
        public bool IsSuccess { get; }
        public ErrorCode Error { get; set; }
        public string ErrorDetails { get; set; }
        public Guid RequestGuid { get; } = Guid.NewGuid();

        public RequestResult()
            => IsSuccess = true;

        public RequestResult(ErrorCode error, string details = null)
            => (IsSuccess, Error, ErrorDetails) = (false, error, details);
    }

    public class RequestResult<TResult> : RequestResult
    {
        public TResult Data { get; }

        public RequestResult(TResult data)
            => Data = data;

        public RequestResult(ErrorCode error, string details = null) : base(error, details)
        {
        }
    }
}