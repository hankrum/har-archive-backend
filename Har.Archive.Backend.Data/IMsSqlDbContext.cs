using Har.Archive.Backend.Data.Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace Har.Archive.Backend.Data
{
    public interface IMsSqlDbContext : IDisposable
    {
        DbSet<HarFile> HarFiles { get; set; }

        DbSet<Path> Paths { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        int SaveChanges();
    }
}
