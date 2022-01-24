using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace ETS.Shared.Infrastructure.Persistence
{
    public abstract class ModuleDbContext: DbContext
    {
        protected abstract string Schema { get; }

        public ModuleDbContext(DbContextOptions options):base (options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if(!string.IsNullOrEmpty(Schema))
            {
                modelBuilder.HasDefaultSchema(Schema);
            }
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(true, cancellationToken);
        }

    }
}
