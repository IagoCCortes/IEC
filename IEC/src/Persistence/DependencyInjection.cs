using Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IECDbContext>(options => 
                options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IIECDbContext>(provider => 
                provider.GetService<IECDbContext>());

            return services;
        }
    }
}