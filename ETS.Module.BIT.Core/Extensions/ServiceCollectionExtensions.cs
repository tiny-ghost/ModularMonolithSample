using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ETS.Module.BIT.Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBitCore(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
