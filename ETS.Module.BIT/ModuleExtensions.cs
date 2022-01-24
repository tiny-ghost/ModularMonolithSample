using ETS.Module.BIT.Core.Extensions;
using ETS.Module.BIT.Infrastructure.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ETS.Module.BIT
{
    public static class ModuleExtensions
    {
        public static IServiceCollection AddBitModule(this IServiceCollection services, IConfiguration config)
        {
            services
                .AddBitCore()
                .AddBitInfrastructure(config);
            return services;
        }
    }
}
