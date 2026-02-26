using EvoMovies.Api.Domain.Movies;
using EvoMovies.Api.Models;

namespace EvoMovies.Api.Models;

public sealed record MovieResponse(
    Guid Id,
    string Title,
    GenreDto Genre,
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
        movie.Genre.ToDtoModel(),
        movie.Director,
        movie.Rating,
        movie.ReleaseDate,
        movie.Poster,
        movie.Url,
        movie.CreatedAt);
}