using System;

namespace Har.Archive.Backend.Data.Domain
{
    public interface IDeletable
    {
        bool IsDeleted { get; set; }

        DateTime? DeletedOn { get; set; }
    }
}
