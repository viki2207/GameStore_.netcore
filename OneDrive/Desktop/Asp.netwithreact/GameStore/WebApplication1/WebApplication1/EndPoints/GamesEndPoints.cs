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
            group.MapGet("/", (IGamesRespository gamesRepository) =>
            {
                var games = gamesRepository.GetAll().Select(game => game.AsDto());
                return JsonSerializer.Serialize(games); // Serialize the result to JSON
            });

            group.MapGet("/{id}", (IGamesRespository gamesRepository, int id) =>
            {
                Game? game = gamesRepository.Get(id);
                return game is null ? Results.NotFound() : Results.Ok(game.AsDto());
            }).WithName(GetGameEndpointName);

            group.MapPost("/", (IGamesRespository gamesRepository, CreateGameDto gameDto) =>
            {
                Game game = new()
                {
                    Name = gameDto.Name,
                    Genre = gameDto.Genre,
                    Price = gameDto.Price,
                    ReleaseDate = gameDto.ReleaseDate,
                    ImageUri = gameDto.ImageUri,

                };
                gamesRepository.Create(game);
                return Results.CreatedAtRoute(GetGameEndpointName, new { id = game.Id }, game);
            });


            group.MapPut("/{id}", (IGamesRespository gamesRepository, int id, UpdateGameDto updatedGameDto) =>
            {
                Game? existingGame = gamesRepository.Get(id);
                if (existingGame is null)
                {
                    return Results.NotFound();
                }
                existingGame.Name = updatedGameDto.Name;
                existingGame.Genre = updatedGameDto.Genre;
                existingGame.Price = updatedGameDto.Price;
                existingGame.ReleaseDate = updatedGameDto.ReleaseDate;
                existingGame.ImageUri = updatedGameDto.ImageUri;
                gamesRepository.Update(existingGame);
                return Results.NoContent();
            });

            group.MapDelete("/{id}", (IGamesRespository gamesRepository, int id) =>
            {
                Game? game = gamesRepository.Get(id);
                if (game is not null)
                {
                    gamesRepository.Delete(id);
                }
                return Results.NoContent();
            });

            return group;
        }
    }
}
