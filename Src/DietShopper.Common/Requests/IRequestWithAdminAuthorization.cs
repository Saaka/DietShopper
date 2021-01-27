using System;
using DietShopper.Common.Requests.Models;

namespace DietShopper.Common.Requests
{
    public interface IRequestWithAdminAuthorization
    {
        Guid RequestGuid { get; }
        RequestContext Context { get; }
    }
}