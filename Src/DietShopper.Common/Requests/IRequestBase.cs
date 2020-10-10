using System;

namespace DietShopper.Common.Requests
{
    public interface IRequestBase
    {
        Guid RequestGuid { get; }
    }
}