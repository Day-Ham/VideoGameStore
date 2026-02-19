using System;
using GameStore.API.Models;
using Microsoft.EntityFrameworkCore;

namespace GameStore.API.Data;

public static class DataExtensions
{
    public static void MigrateDb(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var dbContext =scope.ServiceProvider.GetRequiredService<GameStoreContext>();
        dbContext.Database.Migrate();
    }

    public static void AddGameStoreDb(this WebApplicationBuilder builder)
    {
        //Connection to Sqlite
        var connectionString =builder.Configuration.GetConnectionString("GameStore");
        builder.Services.AddSqlite<GameStoreContext>(
    
        connectionString,
        optionsAction: options => options.UseSeeding((context, _) =>
        {
            if (!context.Set<Genre>().Any())
            {
                context.Set<Genre>().AddRange(
                    new Genre { Name = "Action RPG" },
                    new Genre { Name = "Battle Royale" },
                    new Genre { Name = "City Builder" },
                    new Genre { Name = "First-Person Shooter" },
                    new Genre { Name = "Grand Strategy" },
                    new Genre { Name = "Hack and Slash" },
                    new Genre { Name = "Immersive Sim" },
                    new Genre { Name = "Metroidvania" },
                    new Genre { Name = "MMORPG" },
                    new Genre { Name = "Open World Survival" },
                    new Genre { Name = "Platformer" },
                    new Genre { Name = "Puzzle" },
                    new Genre { Name = "Roguelike" },
                    new Genre { Name = "Racing" },
                    new Genre { Name = "Souls-like" },
                    new Genre { Name = "Tactical Shooter" },
                    new Genre { Name = "Turn-Based Strategy" }
                );
                context.SaveChanges();
            }
        })
        );
    }
}
