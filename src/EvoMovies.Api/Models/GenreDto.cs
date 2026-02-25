using System.Text.Json.Serialization;
using EvoMovies.Api.Domain.Movies.Enums;

namespace EvoMovies.Api.Models;

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

internal static class GenreDtoExtensions
{
    public static Genre ToDomainModel(this GenreDto genre) =>
        genre switch
        {
            GenreDto.Action => Genre.Action,
            GenreDto.Comedy => Genre.Comedy,
            GenreDto.Drama => Genre.Drama,
            GenreDto.Horror => Genre.Horror,
            GenreDto.Romance => Genre.Romance,
            GenreDto.SciFi => Genre.SciFi,
            GenreDto.Thriller => Genre.Thriller,
            GenreDto.Other => Genre.Other,
            _ => throw new ArgumentOutOfRangeException(nameof(genre), genre, null)
        };

    public static GenreDto ToDtoModel(this Genre genre) =>
        genre switch
        {
            Genre.Action => GenreDto.Action,
            Genre.Comedy => GenreDto.Comedy,
            Genre.Drama => GenreDto.Drama,
            Genre.Horror => GenreDto.Horror,
            Genre.Romance => GenreDto.Romance,
            Genre.SciFi => GenreDto.SciFi,
            Genre.Thriller => GenreDto.Thriller,
            Genre.Other => GenreDto.Other,
            _ => throw new ArgumentOutOfRangeException(nameof(genre), genre, null)
        };
}