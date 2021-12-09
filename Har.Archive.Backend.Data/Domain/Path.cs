using System.ComponentModel.DataAnnotations;

namespace Har.Archive.Backend.Data.Domain
{
    public class Path : BaseEntry
    {
        [Required]
        public string Text { get; set; }
    }
}
