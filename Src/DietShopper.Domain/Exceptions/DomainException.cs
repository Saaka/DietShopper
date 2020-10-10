using System;
using DietShopper.Domain.Enums;

namespace DietShopper.Domain.Exceptions
{
    public class DomainException : ArgumentException
    {
        public ErrorCode ErrorCode { get; private set; }

        public DomainException(ErrorCode errorCode, string details = null)
            : base(details ?? errorCode.ToString())
        {
            ErrorCode = errorCode;
        }
    }
}