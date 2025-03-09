namespace MovieManager.DTOs;

public record UpdateMovieDto(string Title, string Genre, DateOnly ReleaseDate, double Rating);
