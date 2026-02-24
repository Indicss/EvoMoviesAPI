using System.Text.Json.Serialization;

namespace EvoMovies.Api.Models;

public sealed record RegisterMovieRequest(
    string Title,
    RegisterMovieRequest.GenreDto Genre,
    string Director,
    DateOnly ReleaseDate)
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum GenreDto
    {
        Action,
        Comedy,
        Drama,
        Horror,
        Romance,
        SciFi,
        Thriller,
        Other
    }
}