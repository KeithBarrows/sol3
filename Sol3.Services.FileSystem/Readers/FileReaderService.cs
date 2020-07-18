using MediaToolkit;
using MediaToolkit.Model;
using MediaToolkit.Options;
using Sol3.Infrastructure.Extensions;
using Sol3.Services.FileSystem.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Sol3.Services.FileSystem.Readers
{
    public class FileReaderService
    {
        private readonly string _basePath;
        private readonly string _baseUri;
        private readonly DirectoryReaderService _dirReader;

        public FileReaderService(string basePath, string baseUri)
        {
            _baseUri = baseUri;
            _basePath = basePath;
            _dirReader = new DirectoryReaderService(_basePath);
        }
        public FileReaderService(string basePath, string httpRequestScheme, string httpRequestHost)
        {
            var baseUri = $"{httpRequestScheme}://{httpRequestHost}/Gallery/";
            _baseUri = new Uri(baseUri).AbsoluteUri;
            _basePath = basePath;
            _dirReader = new DirectoryReaderService(_basePath);
        }

        public List<FileEntry> Get()
        {
            var results = new List<FileEntry>();
            var dirList = _dirReader.Get();
            var extensionList = new[] { ".jpg", ".jpeg", ".webp", ".png", ".gif", ".mp4" };
            FileEntry entry;

            foreach (var dir in dirList)
            {
                var loopResults = new List<FileEntry>();
                var fileList = Directory.GetFiles(dir).ToList();
                foreach (var file in fileList)
                {
                    var simpleFileName = file.SimpleFileName();
                    var extension = file.Extension();

                    if (!extensionList.Contains(extension))
                        continue;


                    if(loopResults.Any(a => a.VideoPhysicalPath == file || a.PhysicalPath == file))
                        continue;


                    if (file.EndsWith(".mp4") || file.EndsWith(".flv"))
                    {
                        var coverImage = file.Replace(".mp4", ".jpg");

                        entry = loopResults.FirstOrDefault(a => a.VideoPhysicalPath == file || a.PhysicalPath == coverImage);
                        if (entry != null)
                        {
                            entry.VideoPhysicalPath = file;
                        }
                        else
                        {
                            SetVideoCoverImage(file, coverImage);
                            entry = new FileEntry(_basePath, _baseUri, coverImage, file);
                            loopResults.Add(entry);
                        }

                        var videotag = entry.Tags.FirstOrDefault(a => a.TagType == TagType.Category);
                        if (videotag == null)
                            entry.Tags.Add(new TagEntry { TagType = TagType.Category, Tag = "Video" });
                    }
                    else
                    {
                        entry = new FileEntry(_basePath, _baseUri, file);
                        loopResults.Add(entry);
                    }
                }
                results.AddRange(loopResults);
            }
            return results; 
        }

        public void SetVideoCoverImage(string file, string coverImage = null)
        {
            if (string.IsNullOrWhiteSpace(coverImage))
                coverImage = file.Replace(".mp4", ".jpg");

            var inputFile = new MediaFile { Filename = file };
            var outputFile = new MediaFile { Filename = coverImage };

            using (var engine = new Engine())
            {
                engine.GetMetadata(inputFile);
                var cutPoint = (inputFile.Metadata.Duration.TotalMilliseconds * 0.80);
                var cutTime = TimeSpan.FromMilliseconds(cutPoint);

                // Saves the frame located on the calculated time cut point...
                var options = new ConversionOptions { Seek = cutTime };
                engine.GetThumbnail(inputFile, outputFile, options);
            }
        }
    }
}
