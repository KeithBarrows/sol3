using System.Collections.Generic;
using System.Linq;

namespace Sol3.Services.FileSystem.Models
{
    internal static class TagExtensions
    {
        private static List<string> _tags = new List<string> { "a-", "c-", "g-", "h-", "p-", "s-", "v-" };
        private static Dictionary<string,TagType> _tagDictionary = new Dictionary<string, TagType> { { "a-", TagType.Album }, {"c-", TagType.Category }, { "g-", TagType.GallerySet }, { "h-", TagType.Highlight }, { "p-", TagType.People }, { "s-", TagType.Studio }, { "v-", TagType.Video } };

        internal static List<TagEntry> ToTags(this string physicalPath)
        {
            var tags = new List<TagEntry>();
            var pathParts = physicalPath.Split(new[] { '\\', '/' }).ToList();
            foreach(var part in pathParts)
            {
                if(part.IsTag())
                    tags.Add(new TagEntry { Tag = part.ToTag(), TagType = part.ToTagType() });
            }
            return tags;
        }

        internal static bool IsTag(this string part) => _tags.Any(a => a == part.Substring(0, 2).ToLower());
        internal static string ToTag(this string part) => part.Substring(2);
        internal static TagType ToTagType(this string part) => _tagDictionary[part.Substring(0, 2).ToLower()];
    }
}
