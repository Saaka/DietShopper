using System;
using DietShopper.Common.Requests.Models;

namespace DietShopper.Common.Requests
{
    public interface IRequestBase
    {
        Guid RequestGuid { get; }
        RequestContext Context { get; }
        void SetContext(RequestContext context);
    }
}