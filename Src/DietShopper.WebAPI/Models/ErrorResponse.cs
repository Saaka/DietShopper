using DietShopper.Domain.Enums;

namespace DietShopper.WebAPI.Models
{
    public class ErrorResponse
    {
        public string Error => ErrorCode.ToString();
        public ErrorCode ErrorCode { get; }
        public object ErrorDetails { get; }

        public ErrorResponse(ErrorCode code, object details = null)
            => (ErrorCode, ErrorDetails) = (code, details);
    }
}