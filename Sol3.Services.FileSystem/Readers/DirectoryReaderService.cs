using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Sol3.Services.FileSystem.Readers
{
    public class DirectoryReaderService
    {
        private readonly string _basePath;

        public DirectoryReaderService(string basePath) => _basePath = basePath;

        public List<string> Get() => RecurseDirectories(_basePath).OrderBy(a => a).ToList();



        private List<string> RecurseDirectories(string path)
        {
            var finalList = new List<string>();
            var dirList = Directory.GetDirectories(path).ToList().Where(a => !a.Contains("Tumblr") && !a.Contains("ToSort"));
            finalList.AddRange(dirList);

            foreach (var dir in dirList)
            {
                finalList.AddRange(RecurseDirectories(dir));
            }
            return finalList;
        }
    }
}
