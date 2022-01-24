using Ericsson.ETS.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace ETS.Module.BIT.Core.Abstractions
{
    public interface IBitDbContext
    {
        public DbSet<Filter> Filters { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
