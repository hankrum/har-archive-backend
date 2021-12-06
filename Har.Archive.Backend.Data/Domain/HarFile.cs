namespace Har.Archive.Backend.Data.Domain
{
    public class HarFile : BaseEntry
    {
        public string Name { get; set; }

        public string Content { get; set; }

        public Folder Folder { get; set; }
    }
}
