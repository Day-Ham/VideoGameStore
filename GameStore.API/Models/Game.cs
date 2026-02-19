namespace GameStore.API.Models;

public class Game
{
    public int ID {get;set;}
    public required String Title {get;set;} = string.Empty;
    public  Genre? Genre {get;set;}

    public int GenreID{get;set;}

    public decimal Price {get;set;}

    public DateOnly ReleaseDate {get;set;}

}
