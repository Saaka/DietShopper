using System;
using DietShopper.Domain.Enums;

namespace DietShopper.Domain.Exceptions
{
    public class InternalException : Exception
    {
        public ErrorCode ErrorCode { get; }

        public InternalException(ErrorCode errorCode, string details = null)
            : base(details ?? errorCode.ToString())
        {
            ErrorCode = errorCode;
        }
    }
}