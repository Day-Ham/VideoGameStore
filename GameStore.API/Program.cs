using GameStore.API.DTOs;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


List<GameDTO> games = [
    new (1,"Risk of Rain 2","Roguelike",4.99M, new DateOnly(1999,09,17)),
    new (2,"Last of Us 2","Action",19.99M, new DateOnly(1999,09,17)),
    new (3,"Yakuza Kiwami 2","Action",14.99M, new DateOnly(1999,09,17)),
    new (4,"Outer Wilds","Story-Rich",9.99M, new DateOnly(1999,09,17)),
    new (5,"Zenless Zone Zero","Gacha",0.00M, new DateOnly(1999,09,17)),

];


app.MapGet("/", () => "Hello World!");
app.MapGet("/games", () => games);
app.MapGet("/games/{id}",(int id)=>games.Find(g=>g.ID==id)).WithName("GetName");
app.MapPost("/games",(CreateGameDTO newGame) =>
{
    GameDTO game = new(
     games.Count+1,
     newGame.Title,
     newGame.Genre,
     newGame.Price,
     newGame.ReleaseDate
     );
     games.Add(game);
     return Results.CreatedAtRoute("GetName",new {id=game.ID},game);
});
app.MapPut("/games/{id}", (int id, UpdateGameDTO updateGame) =>
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

app.MapDelete("/games/{id}",(int id) =>
{
    games.RemoveAll(game=>game.ID==id);
});






app.Run();
