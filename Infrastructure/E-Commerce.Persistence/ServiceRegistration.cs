using E_Commerce.Application.Abstractions;
using E_Commerce.Persistence.Concretes;
using E_Commerce.Persistence.Configurations;
using E_Commerce.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace E_Commerce.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<ECommerceDbContext>(options => options.UseNpgsql(Configuration.ConnectionString));
            services.AddSingleton<IProductService, ProductService>();
        }
    }
}
