using RestFullApi.Interfaces;
using RestFullApi.Repositories;
using RestFullApi.Services;

namespace RestFullApi.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IProductRepository, ProductRepository>(provider =>
                new ProductRepository(configuration.GetConnectionString("PostgreConnection")));
            services.AddScoped<ProductService>();

            services.AddScoped<IBotTokenRepository, BotTokenRepository>(provider =>
                new BotTokenRepository(configuration.GetConnectionString("PostgreConnection")));
            services.AddScoped<BotTokenService>();
        }
    }
}
