using WebApplication1.Entities;


namespace WebApplication1.Repositories
{
    public interface IGamesRespository
    {
        Task CreateAsync(Game game);
        Task DeleteAsync(int id);
        Task<Game?> GetAsync(int id);
        Task<IEnumerable<Game>> GetAllAsync();
        Task UpdateAsync(Game updatedGame);
    }
}