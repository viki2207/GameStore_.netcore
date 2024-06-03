using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Data
{
    public static class DataExtensions
    {
        public static void IntializeDb(this IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var DbContext = scope.ServiceProvider.GetRequiredService<GameStoreContext>();
            DbContext.Database.Migrate();
        }
    }
}