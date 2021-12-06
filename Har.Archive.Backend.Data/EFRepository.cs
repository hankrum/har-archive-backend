using Har.Archive.Backend.Infrastructure;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq;
using System.Threading.Tasks;

namespace Har.Archive.Backend.Data
{
    public class EFRepository<T> : IEfRepository<T> where T : class
    {
        private readonly MsSqlDbContext context;


        public EFRepository(MsSqlDbContext context)
        {
            this.context = Guard.GetNotNullArgument(context, nameof(context));
        }

        public IQueryable<T> All()
        {
            var queryResult = this.context.Set<T>().AsQueryable();
            return queryResult;
        }

        public T Add(T entity)
        {
            Guard.ArgumentNotNull(entity, nameof(entity));
            EntityEntry entry = this.context.Entry(entity);

            return this.context.Set<T>().Add(entity).Entity;
        }

        public T Delete(T entity)
        {
            Guard.ArgumentNotNull(entity, nameof(entity));
            var entry = this.context.Entry(entity);

            return this.context.Set<T>().Remove(entity).Entity;
        }

        public T Update(T entity)
        {
            Guard.ArgumentNotNull(entity, nameof(entity));
            EntityEntry entry = this.context.Entry(entity);

            return this.context.Set<T>().Update(entity).Entity;
        }

        public async Task<T> GetById(long id)
        {
            return await this.context.Set<T>().FindAsync(id);
        }
    }
}
