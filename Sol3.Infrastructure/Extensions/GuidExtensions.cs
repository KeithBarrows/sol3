using System;

namespace Sol3.Infrastructure.Extensions
{
    public static class GuidExtensions
    {
        public static bool IsNullOrEmpty(this Guid? src) => !src.HasValue || src.Equals(Guid.Empty);
        public static bool IsGuidNullOrEmpty(this Guid? src) => !src.HasValue || src.Equals(Guid.Empty);
    }
}
