using DietShopper.Common.Requests;

namespace DietShopper.Application.Services
{
    public interface IRequestAuthorizationValidator
    {
        void ValidateRequest(IRequestBase request);
    }
}