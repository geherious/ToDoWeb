using Microsoft.EntityFrameworkCore;

namespace ToDoWeb.Data
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddConfiguredDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("WebDb"));
            });
            return services;
        }
    }
}
