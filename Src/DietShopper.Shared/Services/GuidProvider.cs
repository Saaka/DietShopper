using System;
using DietShopper.Application.Services;

namespace DietShopper.Shared.Services
{
    public class GuidProvider : IGuid
    {
        public Guid GetGuid() => Guid.NewGuid();
    }
}