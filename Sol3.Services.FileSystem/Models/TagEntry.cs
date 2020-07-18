namespace Sol3.Services.FileSystem.Models
{
    public class TagEntry
    {
        public TagType TagType { get; set; }
        public string Tag { get; set; }
        public string FriendlyTagType => TagType.ToString();
    }
}
