using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Har.Archive.Backend.Data.Domain
{
    public class HarFile : BaseEntry
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        [ForeignKey("PathId")]
        public Path Path { get; set; }

        [Required]
        public long PathId { get; set; }
    }
}
