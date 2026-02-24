using EvoMovies.Api.Domain.Movies;

namespace EvoMovies.Api.Models;

public sealed record MovieResponse(
    Guid Id,
    string Title,
    string Director,
    DateOnly ReleaseDate,
    DateTime CreatedAt)
{
    public static MovieResponse FromMovie(Movie movie) => new MovieResponse(
        movie.Id,
        movie.Title,
        movie.Director,
        movie.ReleaseDate,
        movie.CreatedAt);
}