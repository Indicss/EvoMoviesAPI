namespace EvoMovies.Api.Models;

public sealed record RegisterMovieRequest(
    string Title,
    GenreDto Genre,
    string Director,
    DateOnly ReleaseDate);