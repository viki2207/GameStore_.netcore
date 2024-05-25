using WebApplication1.Entities;
using System.Text.Json;
using System.Collections.Generic;


namespace WebApplication1.Repositories
{
    public class InMeMGamesRespository : IGamesRespository
    {
        private static readonly List<Game> games = new()
        {
            new Game()
            {
                Id = 1,
                Name = "Street Fighter II",
                Genre = "Fighting",
                Price = 19.99M,
                ReleaseDate = new DateTime(2001, 07, 22),
                ImageUri = "https://placehold.co/100"
            },
            new Game()
            {
                Id = 2,
                Name = "Final Fantancy XIV",
                Genre = "Roleplaying",
                Price = 59.99M,
                ReleaseDate = new DateTime(2005, 07, 22),
                ImageUri = "https://placehold.co/100"
            },
            new Game()
            {
                Id = 3,
                Name = "FIFA 23",
                Genre = "Sports",
                Price = 69.99M,
                ReleaseDate = new DateTime(2023, 09, 22),
                ImageUri = "https://placehold.co/100"
            }
        };
        public IEnumerable<Game> GetAll()
        {
            try
            {
                return games;
            }
            catch (System.Exception)
            {

                throw;
            }

        }
        public Game? Get(int id)
        {
            return games.Find(game => game.Id == id);
        }
        public void Create(Game game)
        {
            game.Id = games.Max(game => game.Id) + 1;
            games.Add(game);
        }
        public void Update(Game updatedGame)
        {
            var index = games.FindIndex(game => game.Id == updatedGame.Id);
            games[index] = updatedGame;
        }
        public void Delete(int id)
        {
            var index = games.FindIndex(game => game.Id == id);
            games.RemoveAt(index);
        }
    }
}