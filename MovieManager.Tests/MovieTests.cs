using MovieManager.Entities;

public class MovieTests
{
    [Fact]
    public void Create_ShouldReturnMovie_WhenValidInputsAreProvided()
    {
        // Arrange
        var title = "Inception";
        var genre = "Sci-Fi";
        var releaseDate = new DateOnly(2010, 7, 16);
        var rating = 8.8;

        // Act
        var movie = Movie.Create(title, genre, releaseDate, rating);

        // Assert
        Assert.NotNull(movie);
        Assert.Equal(title, movie.Title);
        Assert.Equal(genre, movie.Genre);
        Assert.Equal(releaseDate, movie.ReleaseDate);
        Assert.Equal(rating, movie.Rating);
    }

    [Theory]
    [InlineData("", "Sci-Fi", "2020-01-01", 5.0)]
    [InlineData("Inception", "", "2020-01-01", 5.0)]
    [InlineData("Inception", "Sci-Fi", "2099-01-01", 5.0)] // Future date
    [InlineData("Inception", "Sci-Fi", "2020-01-01", -1)] // Invalid rating
    [InlineData("Inception", "Sci-Fi", "2020-01-01", 11)] // Invalid rating
    public void Create_ShouldThrowArgumentException_WhenInvalidInputsAreProvided(string title, string genre, string releaseDateStr, double rating)
    {
        // Arrange
        var releaseDate = DateOnly.Parse(releaseDateStr);

        // Act & Assert
        Assert.Throws<ArgumentException>(() => Movie.Create(title, genre, releaseDate, rating));
    }

    [Fact]
    public void Update_ShouldModifyProperties_WhenValidInputsAreProvided()
    {
        // Arrange
        var movie = Movie.Create("Inception", "Sci-Fi", new DateOnly(2010, 7, 16), 8.8);

        var newTitle = "Interstellar";
        var newGenre = "Adventure";
        var newReleaseDate = new DateOnly(2014, 11, 7);
        var newRating = 9.0;

        // Act
        movie.Update(newTitle, newGenre, newReleaseDate, newRating);

        // Assert
        Assert.Equal(newTitle, movie.Title);
        Assert.Equal(newGenre, movie.Genre);
        Assert.Equal(newReleaseDate, movie.ReleaseDate);
        Assert.Equal(newRating, movie.Rating);
    }

    [Theory]
    [InlineData("", "Adventure", "2014-11-07", 9.0)]
    [InlineData("Interstellar", "", "2014-11-07", 9.0)]
    [InlineData("Interstellar", "Adventure", "2099-01-01", 9.0)] // Future date
    [InlineData("Interstellar", "Adventure", "2014-11-07", -1)] // Invalid rating
    [InlineData("Interstellar", "Adventure", "2014-11-07", 11)] // Invalid rating
    public void Update_ShouldThrowArgumentException_WhenInvalidInputsAreProvided(string title, string genre, string releaseDateStr, double rating)
    {
        // Arrange
        var movie = Movie.Create("Inception", "Sci-Fi", new DateOnly(2010, 7, 16), 8.8);
        var releaseDate = DateOnly.Parse(releaseDateStr);

        // Act & Assert
        Assert.Throws<ArgumentException>(() => movie.Update(title, genre, releaseDate, rating));
    }
}
