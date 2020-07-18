using System;
using System.Collections.Generic;

namespace Sol3.Infrastructure.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNullOrEmpty(this string src) => string.IsNullOrEmpty(src);
        public static bool IsNullOrWhitespace(this string src) => string.IsNullOrWhiteSpace(src);

        public static void AddErrorInfo(this List<string> messages, Exception ex)
        {
            messages.Add("ERROR");
            var nextEx = ex;
            while (nextEx != null)
            {
                messages.Add(nextEx.Message);
                nextEx = nextEx.InnerException;
            }
            messages.Add(ex.StackTrace);
        }

        public static string ToCsv(this List<string> src, string delimiter = ",")
        {
            var result = string.Empty;
            var token = string.Empty;
            foreach (var itm in src)
            {
                result = $"{result}{token}{itm}";
                token = $"{delimiter} ";
            }
            return result;
        }

        public static DateTime ToDateTime(this DateTime? src, DateTime? @default = null) => src ?? (@default.HasValue ? @default.Value : DateTime.MinValue);
        public static DateTime ToDateTime(this string src, DateTime? @default = null)
        {
            DateTime result;
            if (DateTime.TryParse(src, out result))
                return result;
            return @default.HasValue ? @default.Value : DateTime.MinValue;
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

        public static bool ToBool(this object src, bool @default = false) => bool.TryParse(src.ToString(), out bool result) ? result : @default;
        public static bool IsContainedIn(this string src, Dictionary<int, string> allowed) => (src.IsInt() && allowed.ContainsKey(src.ToInt())) || allowed.ContainsValue(src.ToUpper());
        public static bool IsInt(this string src) => int.TryParse(src, out int ret);

        public static int ToInt(this string src, int? @default = null)
        {
            int ret;
            if (int.TryParse(src, out ret))
                return ret;
            if (@default.HasValue)
                return @default.Value;
            throw new ArgumentException($"The value passed in [{src}] cannot be converted to a valid INT and there was no default defined!");
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

        public static string SimpleFileName(this string fullFileName)
        {
            var index = fullFileName.LastIndexOf("\\") + 1;
            var simpleFileName = fullFileName.Substring(index);
            index = simpleFileName.LastIndexOf(".");
            simpleFileName = simpleFileName.Substring(0, index);
            return simpleFileName;
        }
        public static string Extension(this string fullFileName)
        {
            var index = fullFileName.LastIndexOf(".");
            var simpleFileName = fullFileName.Substring(index);
            return simpleFileName;
        }
    }
}
