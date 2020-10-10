using System;

namespace DietShopper.Shared.Exceptions
{
    public class ExternalCommunicationException : Exception
    {
        public string Details { get; private set; }
        
        public ExternalCommunicationException(string message, string details = "")
            : base(message)
        {
            Details = details;
        }
    }
}