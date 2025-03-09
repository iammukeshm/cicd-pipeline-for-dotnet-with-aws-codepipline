namespace MovieManager.DTOs;

public record MovieDto(Guid Id, string Title, string Genre, DateOnly ReleaseDate, double Rating);