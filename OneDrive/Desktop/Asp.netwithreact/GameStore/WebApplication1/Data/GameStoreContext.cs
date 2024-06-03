using System.Reflection;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Entities;

namespace WebApplication1.Data;

public class GameStoreContext : DbContext
{
    public GameStoreContext(DbContextOptions<GameStoreContext> options) : base(options)
    {

    }
    public DbSet<Game> Games => Set<Game>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}