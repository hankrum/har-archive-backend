using System;
using System.ComponentModel.DataAnnotations;

namespace Har.Archive.Backend.Data.Domain
{
    public abstract class BaseEntry : IDeletable, IAuditable
    {
        [Key]
        public long Id { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime? CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
