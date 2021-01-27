using System;
using DietShopper.Application.Services;
using DietShopper.Common.Requests;

namespace DietShopper.Shared.Services
{
    public class RequestAuthorizationValidator : IRequestAuthorizationValidator
    {
        public void ValidateRequest(IRequestBase request)
        {
            if (request is IRequestWithAdminAuthorization)
            {
                CheckAuthorization(request);
                CheckAdminRights(request);
            }
            else if (request is IRequestWithBasicAuthorization)
                CheckAuthorization(request);
        }

        private void CheckAuthorization(IRequestBase request)
        {
            if (request.Context == null || !request.Context.IsAuthorized)
                throw new UnauthorizedAccessException();
        }

        private void CheckAdminRights(IRequestBase request)
        {
            if (!request.Context.IsAdmin)
                throw new InvalidOperationException();
        }
    }
}