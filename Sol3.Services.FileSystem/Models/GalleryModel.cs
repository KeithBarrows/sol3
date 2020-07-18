using System;
using System.Collections.Generic;
using System.Text;

namespace Sol3.Services.FileSystem.Models
{
    public class GalleryModel
    {
        public string CurrentTag { get; set; }
        public List<FileEntry> Files { get; set; } = new List<FileEntry>();
        public List<TagEntry> Tags { get; set; } = new List<TagEntry>();
    }
}
