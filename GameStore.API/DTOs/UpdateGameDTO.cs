namespace GameStore.API.DTOs;

public record class UpdateGameDTO(
      int ID,
      string Title,
      string Genre,
      decimal Price,
      DateOnly ReleaseDate
);