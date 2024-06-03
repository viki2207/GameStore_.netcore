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
        public async Task<IEnumerable<Game>> GetAllAsync()
        {
            try
            {
                return await Task.FromResult(games);
            }
            catch (System.Exception)
            {

                throw;
            }

        }
        public async Task<Game?> GetAsync(int id)
        {
            return await Task.FromResult(games.Find(game => game.Id == id));
        }
        public async Task CreateAsync(Game game)
        {
            game.Id = games.Max(game => game.Id) + 1;
            games.Add(game);
            await Task.CompletedTask;
        }
        public async Task UpdateAsync(Game updatedGame)
        {
            var index = games.FindIndex(game => game.Id == updatedGame.Id);
            games[index] = updatedGame;
            await Task.CompletedTask;
        }
        public async Task DeleteAsync(int id)
        {
            var index = games.FindIndex(game => game.Id == id);
            games.RemoveAt(index);
            await Task.CompletedTask;
        }
    }
}