using Sol3.Infrastructure.Extensions;
using System;
using System.Collections.Generic;

namespace Sol3.Services.FileSystem.Models
{
    public class FileEntry
    {
        private readonly string _basePath;
        private readonly string _baseUri;
        private string _physicalPath;

        public FileEntry(string basePath, string baseUri, string physicalPath)
        {
            _baseUri = baseUri;
            _basePath = basePath;
            PhysicalPath = physicalPath;
            VideoPhysicalPath = string.Empty;
        }
        public FileEntry(string basePath, string baseUri, string physicalPath, string videoPhysicalPath)
        {
            _baseUri = baseUri;
            _basePath = basePath;
            PhysicalPath = physicalPath;
            VideoPhysicalPath = videoPhysicalPath;
        }

        public string PhysicalPath 
        {
            get 
            {
                return _physicalPath;
            }
            private set 
            {
                Tags = value.ToTags();
                _physicalPath = value;
            } 
        }
        public string GalleryString => new Uri(PhysicalPath.Replace(_basePath, _baseUri).Replace(@"\", "/")).AbsoluteUri;
        public List<TagEntry> Tags { get; set; }

        public string VideoPhysicalPath { get; set; }
        public string VideoString => HasVideo ? new Uri(VideoPhysicalPath.Replace(_basePath, _baseUri).Replace(@"\", "/")).AbsoluteUri : null;
        public bool HasVideo => !VideoPhysicalPath.IsNullOrWhitespace();
    }
}
