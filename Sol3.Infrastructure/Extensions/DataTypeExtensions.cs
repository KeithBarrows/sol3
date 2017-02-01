using System;
using System.Collections.Generic;
using System.Linq;

namespace Sol3.Infrastructure.Extensions
{
    public static class DataTypeExtensions
    {
        public static string ToFullString(this Exception src)
        {
            var ex = src;
            var msg = string.Empty;
            var token = string.Empty;
            while (ex != null)
            {
                msg = $"{msg}{token}{ex.Message}";
                token = Environment.NewLine;
                ex = ex.InnerException;
            }
            msg = $"{msg}{token}{token}{src.StackTrace}";
            return msg;
        }
        public static string ToSingleString(this string[] src)
        {
            var message = string.Empty;
            var token = string.Empty;
            foreach (var q in src)
            {
                message = $"{message}{token}{q}";
                token = Environment.NewLine;
            }
            return message;
        }

        public static bool IsNullOrEmpty(this string src)
        {
            return string.IsNullOrEmpty(src);
        }
        public static bool IsNullOrEmpty<T>(this List<T> src)
        {
            return src == null || src.Count <= 0;
        }
        public static bool HasItems<T>(this List<T> src)
        {
            return src != null && src.Count > 0;
        }
        public static bool IsStringNullOrEmpty(this string src)
        {
            return string.IsNullOrEmpty(src);
        }

        public static bool IsNullOrEmpty(this Guid? src)
        {
            return !src.HasValue || src.Equals(Guid.Empty);
        }
        public static bool IsGuidNullOrEmpty(this Guid? src)
        {
            return !src.HasValue || src.Equals(Guid.Empty);
        }

        public static int ToInt(this bool src)
        {
            return src ? 1 : 0;
        }
        public static int ToInt(this bool? src)
        {
            return src?.ToInt() ?? 0;
        }

        public static int ToInt(this string src, int? @default = null)
        {
            int ret;
            if (int.TryParse(src, out ret))
                return ret;
            if (@default.HasValue)
                return @default.Value;
            throw new ArgumentException($"The value passed in [{src}] cannot be converted to a valid INT and there was no default defined!");
        }

        public static bool IsInt(this string src)
        {
            int ret;
            return int.TryParse(src, out ret);
        }

        public static bool Between(this int src, int lower, int upper)
        {
            return src >= lower && src <= upper;
        }

        public static bool ContainedIn(this int src, Dictionary<int, string> allowed)
        {
            return allowed.ContainsKey(src);
        }
        public static bool ContainedIn(this string src, Dictionary<int, string> allowed)
        {
            return (src.IsInt() && allowed.ContainsKey(src.ToInt())) || allowed.ContainsValue(src.ToUpper());
        }

        public static string AllowedText(this int src, Dictionary<int, string> allowed)
        {
            string ret;
            return allowed.TryGetValue(src, out ret) ? ret : string.Empty;
        }
        public static string AllowedText(this string src, Dictionary<int, string> allowed)
        {
            if (src.IsInt() && allowed.ContainsKey(src.ToInt()))
            {
                string ret;
                if (allowed.TryGetValue(src.ToInt(), out ret))
                    return ret;
            }
            return allowed.ContainsValue(src.ToUpper()) ? src : string.Empty;
        }

        public static string ClassName<T>(this T src) where T : class, new()
        {
            var fullName = src.ToString().Split('.');
            return fullName.ToList().Last();
        }

        public static bool ToBool(this int src)
        {
            return src != 0;
        }
    }
}
