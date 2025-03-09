namespace MovieManager.DTOs;

public record CreateMovieDto(string Title, string Genre, DateOnly ReleaseDate, double Rating);