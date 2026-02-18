using System;
using GameStore.API.DTOs;

namespace GameStore.API.Endpoints;

public static class GamesEndpoints
{
    const string GetGameEndpointName= "GetGame";
    private static readonly List<GameDTO> games = [
        new (1,"Risk of Rain 2","Roguelike",4.99M, new DateOnly(1999,09,17)),
        new (2,"Last of Us 2","Action",19.99M, new DateOnly(1999,09,17)),
        new (3,"Yakuza Kiwami 2","Action",14.99M, new DateOnly(1999,09,17)),
        new (4,"Outer Wilds","Story-Rich",9.99M, new DateOnly(1999,09,17)),
        new (5,"Zenless Zone Zero","Gacha",0.00M, new DateOnly(1999,09,17)),
    ];

    public static void MapGamesEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/games");
        group.MapGet("/", () => games);
        group.MapGet("/{id}",(int id) =>
        {
        var game = games.Find(g=>g.ID==id);
            if (game != null)
            {
                return Results.Ok(game);
            }
            else
            {
                return Results.NotFound(new {Message=$"Game {id} not found "});
            }
        }).WithName(GetGameEndpointName);
        group.MapPost("/",(CreateGameDTO newGame) =>
        {
            GameDTO game = new(
            games.Count+1,
            newGame.Title,
            newGame.Genre,
            newGame.Price,
            newGame.ReleaseDate
            );
            games.Add(game);
            return Results.Created($"/games/{game.ID}", game);
        });
        group.MapPut("/{id}", (int id, UpdateGameDTO updateGame) =>
        {
            var index =games.FindIndex(games=>games.ID==id);
            games[index] = new GameDTO(
                id,
                updateGame.Title,
                updateGame.Genre,
                updateGame.Price,
                updateGame.ReleaseDate
                );

                return Results.NoContent();
        });
        group.MapDelete("/{id}",(int id) =>
        {
            games.RemoveAll(game=>game.ID==id);
        });
    
    }
}
