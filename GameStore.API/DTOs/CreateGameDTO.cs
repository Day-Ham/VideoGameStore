namespace GameStore.API.DTOs;

public record class CreateGameDTO(
      int ID,
      string Title,
      string Genre,
      decimal Price,
      DateOnly ReleaseDate
);
