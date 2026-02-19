using GameStore.API.Data;
using GameStore.API.DTOs;
using GameStore.API.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddValidation();

//Connection to Sqlite
var connectionString ="Data Source=GameStore.db";
builder.Services.AddSqlite<GameStoreContext>(connectionString);


var app = builder.Build();

app.MapGamesEndpoints();

app.MigrateDb();


app.Run();
