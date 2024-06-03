using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Repositories;

namespace WebApplication1.Data
{
    public static class DataExtensions
    {
        public static async Task IntializeDbAsync(this IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var DbContext = scope.ServiceProvider.GetRequiredService<GameStoreContext>();
            await DbContext.Database.MigrateAsync();
        }
        public static IServiceCollection AddRepositories(this IServiceCollection services,
        IConfiguration configuration)
        {
            var connString = configuration.GetConnectionString("GameStoreContext");
            services.AddSqlServer<GameStoreContext>(connString).AddScoped<IGamesRespository, EntityFrameworkGamesRepository>();
            return services;
        }
    }
}