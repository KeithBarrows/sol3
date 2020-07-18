using Sol3.Services.FileSystem.Models;
using Sol3.Services.FileSystem.Readers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sol3.Services.FileSystem.Handlers
{
    public class ImageHandler
    {
        private readonly string _basePath;
        private readonly string _baseUri;
        private readonly FileReaderService _fileService;
        private readonly TagReaderService _tagService;
        private List<FileEntry> _fileList;
        private List<TagEntry> _tagList;

        public ImageHandler(string basePath, string httpRequestScheme, string httpRequestHost)
        {
            var baseUri = $"{httpRequestScheme}://{httpRequestHost}/Gallery/";
            _baseUri = new Uri(baseUri).AbsoluteUri;
            _basePath = basePath;
            _fileService = new FileReaderService(_basePath, _baseUri);
            _tagService = new TagReaderService(Files);
        }

        public List<FileEntry> Files
        {
            get
            {
                if (_fileList == null || _fileList.Count <= 0)
                    _fileList = _fileService.Get();
                return _fileList;
            }
            private set { }
        }
        public List<TagEntry> Tags
        {
            get
            {
                if (_tagList == null || _tagList.Count <= 0)
                    _tagList = _tagService.Get().OrderBy(a => a.FriendlyTagType).ThenBy(a => a.Tag).ToList();
                return _tagList;
            }
            private set { }
        }

        public GalleryModel Get()
        {
            var results = new GalleryModel();
            results.Files = Files;
            results.Tags = Tags;
            return results;
        }
        public GalleryModel GetById(string tagName)
        {
            var results = new GalleryModel();
            foreach(var file in Files)
            {
                var tags = file.Tags.Where(a => a.Tag == tagName).ToList();
                if (tags != null && tags.Count > 0)
                    results.Files.Add(file);
            }
            results.Tags = Tags;
            return results;
        }

        public bool ResetVideoCover(string file)
        {
            var results = false;
            _fileService.SetVideoCoverImage(file);
            return results;
        }

        public GalleryModel GetWithSkipTake(int skip = 0, int take = 0)
        {
            var results = new GalleryModel();
            if (take <= 0)
                results.Files = Files;
            else
                results.Files = Files.Skip(skip).Take(take).ToList();
            results.Tags = Tags;
            return results;
        }
        public GalleryModel GetRandom()
        {
            Random rnd = new Random();
            var skip = rnd.Next(0, Files.Count - 100);

            var results = new GalleryModel();
            results.Files = Files.Skip(skip).Take(100).ToList();
            results.Tags = Tags;
            return results;
        }
    }
}
