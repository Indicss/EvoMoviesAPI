using EvoMovies.Api.Domain.Movies;

namespace EvoMovies.Api.Models;

public sealed record MovieResponse(
    Guid Id,
    string Title,
    string Genre,
    string Director,
    decimal Rating,
    DateOnly ReleaseDate,
    string Poster,
    string Url,
    DateTime CreatedAt)
{
    public static MovieResponse FromMovie(Movie movie) => new MovieResponse(
        movie.Id,
        movie.Title,
        movie.Genre.ToString(),
        movie.Director,
        movie.Rating,
        movie.ReleaseDate,
        movie.Poster,
        movie.Url,
        movie.CreatedAt
    );
}