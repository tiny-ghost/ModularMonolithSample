using ETS.Module.BIT.Core.Abstractions;
using ETS.Module.BIT.Infrastructure.Persistence;
using ETS.Shared.Infrastructure.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ETS.Module.BIT.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBitInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            services
                .AddDatabaseContext<BitDbContext>(config)
                .AddScoped<IBitDbContext>(provider => provider.GetService<BitDbContext>());
            return services;
        }
    }
}
