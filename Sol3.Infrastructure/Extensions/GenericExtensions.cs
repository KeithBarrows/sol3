using System.Collections.Generic;

namespace Sol3.Infrastructure.Extensions
{
    public static class GenericExtensions
    {
        public static bool IsNullOrEmpty<T>(this List<T> src) => src == null || src.Count <= 0;
        public static bool HasItems<T>(this List<T> src)=> src != null && src.Count > 0;
    }
}
