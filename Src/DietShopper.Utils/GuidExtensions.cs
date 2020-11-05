using System;

namespace DietShopper
{
    public static class GuidExtensions
    {
        public static bool IsEmpty(this Guid guid) => guid.Equals(Guid.Empty);
    }
}