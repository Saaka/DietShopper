using System;
using DietShopper.Domain.Enums;

namespace DietShopper.Domain.Exceptions
{
    public class DomainException : ArgumentException
    {
        public ExceptionCode ExceptionCode { get; private set; }

        public DomainException(ExceptionCode exceptionCode, string details = null)
            : base(details ?? exceptionCode.ToString())
        {
            ExceptionCode = exceptionCode;
        }
    }
}