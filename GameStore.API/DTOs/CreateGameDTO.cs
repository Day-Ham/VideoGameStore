using System.ComponentModel.DataAnnotations;

namespace GameStore.API.DTOs;

public record class CreateGameDTO(
      int ID,
     [Required]
      string Title,
     [Required]
      string Genre,
     [Required]
      decimal Price,
     [Required]
      DateOnly ReleaseDate
);
