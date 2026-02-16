namespace GameStore.API.DTOs;

public record class GameDTO
(  int ID,
  string Title,
  string Genre,
  decimal Price,
  DateOnly ReleaseDate);