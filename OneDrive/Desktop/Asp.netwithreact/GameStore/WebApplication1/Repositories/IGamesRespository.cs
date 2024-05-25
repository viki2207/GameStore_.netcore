using WebApplication1.Entities;


namespace WebApplication1.Repositories
{
    public interface IGamesRespository
    {
        void Create(Game game);
        void Delete(int id);
        Game? Get(int id);
        IEnumerable<Game> GetAll();
        void Update(Game updatedGame);
    }
}