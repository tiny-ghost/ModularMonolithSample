using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ETS.Shared.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSharedInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            services.AddControllers()
                .ConfigureApplicationPartManager(manager =>
                {
                    manager.FeatureProviders.Add(new InternalControllerFeatureProvider());
                });

            return services;
        }

        public static IServiceCollection AddDatabaseContext<T>(this IServiceCollection services, IConfiguration config)
            where T : DbContext
        {
            var connectionString = config.GetConnectionString("DefaultConnection");
            services.AddMSSQL<T>(connectionString);
            return services;
        }

        private static IServiceCollection AddMSSQL<T>(this IServiceCollection services, string connectionString)
            where T : DbContext
        {
            services.AddDbContext<T>(options =>
            options.UseSqlServer(connectionString /*, options => options.MigrationsAssembly(typeof(T).Assembly.FullName))*/));
            //using var scope = services.BuildServiceProvider().CreateScope();
            //var dbContext = scope.ServiceProvider.GetRequiredService<T>();
            //dbContext.Database.Migrate();
            return services;
        }
    }
}
