using EvoMovies.Api.Domain.Movies;

namespace EvoMovies.Api.Models;

public sealed record MovieResponse(
    Guid Id,
    string Title,
    GenreDto Genre,
    string Director,
    DateOnly ReleaseDate,
    DateTime CreatedAt)
{
    public static MovieResponse FromMovie(Movie movie) => new MovieResponse(
        movie.Id,
        movie.Title,
        movie.Genre.ToDtoModel(),
        movie.Director,
        movie.ReleaseDate,
        movie.CreatedAt);
}