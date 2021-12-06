namespace Har.Archive.Backend.Data.Domain
{
    public class Folder : BaseEntry
    {
        public string Name { get; set; }

        public Folder Parent { get; set; }
    }
}
