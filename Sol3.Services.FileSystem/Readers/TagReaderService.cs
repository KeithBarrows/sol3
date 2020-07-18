using Sol3.Infrastructure.Extensions;
using Sol3.Services.FileSystem.Models;
using System.Collections.Generic;
using System.Linq;

namespace Sol3.Services.FileSystem.Readers
{
    public class TagReaderService
    {
        private readonly List<FileEntry> _files;
        private List<TagEntry> _tags;

        public TagReaderService(List<FileEntry> files)
        {
            _files = files;
        }

        public List<TagEntry> Get()
        {
            if (_tags != null && _tags.Count > 0)
                return _tags;

            var tagList = new List<TagEntry>();
            _files.ForEach(file => tagList.AddRange(file.Tags));
            var uniqueTagList = tagList.DistinctBy(a => a.Tag).ToList();
            return uniqueTagList;
        }
    }
}
