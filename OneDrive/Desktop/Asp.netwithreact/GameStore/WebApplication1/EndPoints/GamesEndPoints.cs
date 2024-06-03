using WebApplication1.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Routing.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Repositories;
using System.Text.Json;
using WebApplication1.Dtos;
namespace WebApplication1.EndPoints
{
    public static class GamesEndPoints
    {
        private const string GetGameEndpointName = "GetGame";


        public static RouteGroupBuilder MapGamesEndPoints(this IEndpointRouteBuilder routes)
        {
            //InMeMGamesRespository gamesRepository = new InMeMGamesRespository();
            var group = routes.MapGroup("/games").WithParameterValidation();
            group.MapGet("/", async (IGamesRespository gamesRepository) =>
          (await gamesRepository.GetAllAsync()).Select(Game => Game.AsDto()));
            group.MapGet("/{id}", async (IGamesRespository gamesRepository, int id) =>
            {
                Game? game = await gamesRepository.GetAsync(id);
                return game is null ? Results.NotFound() : Results.Ok(game.AsDto());
            }).WithName(GetGameEndpointName);

            group.MapPost("/", async (IGamesRespository gamesRepository, CreateGameDto gameDto) =>
            {
                Game game = new()
                {
                    Name = gameDto.Name,
                    Genre = gameDto.Genre,
                    Price = gameDto.Price,
                    ReleaseDate = gameDto.ReleaseDate,
                    ImageUri = gameDto.ImageUri,

                };
                await gamesRepository.CreateAsync(game);
                return Results.CreatedAtRoute(GetGameEndpointName, new { id = game.Id }, game);
            });


            group.MapPut("/{id}", async (IGamesRespository gamesRepository, int id, UpdateGameDto updatedGameDto) =>
            {
                Game? existingGame = await gamesRepository.GetAsync(id);
                if (existingGame is null)
                {
                    return Results.NotFound();
                }
                existingGame.Name = updatedGameDto.Name;
                existingGame.Genre = updatedGameDto.Genre;
                existingGame.Price = updatedGameDto.Price;
                existingGame.ReleaseDate = updatedGameDto.ReleaseDate;
                existingGame.ImageUri = updatedGameDto.ImageUri;
                await gamesRepository.UpdateAsync(existingGame);
                return Results.NoContent();
            });

            group.MapDelete("/{id}", async (IGamesRespository gamesRepository, int id) =>
            {
                Game? game = await gamesRepository.GetAsync(id);
                if (game is not null)
                {
                    await gamesRepository.DeleteAsync(id);
                }
                return Results.NoContent();
            });

            return group;
        }
    }
}
