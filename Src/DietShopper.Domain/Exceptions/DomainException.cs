using System;
using DietShopper.Domain.Enums;

namespace DietShopper.Domain.Exceptions
{
    public class DomainException : ArgumentException
    {
        public ErrorCode ErrorCode { get; private set; }
        public object ErrorDetails { get; set; }
        
        public DomainException(ErrorCode errorCode, object details = null)
            : base(errorCode.ToString())
        {
            ErrorCode = errorCode;
            ErrorDetails = details;
        }
    }
}