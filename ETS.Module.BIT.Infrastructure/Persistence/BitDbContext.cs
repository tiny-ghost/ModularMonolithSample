using ETS.Shared.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using ETS.Module.BIT.Core.Abstractions;
using Ericsson.ETS.Core.Models;

namespace ETS.Module.BIT.Infrastructure.Persistence
{
    internal class BitDbContext : ModuleDbContext, IBitDbContext
    {
        protected override string Schema => null;

        public DbSet<Filter> Filters { get; set; }

        public BitDbContext(DbContextOptions<BitDbContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
