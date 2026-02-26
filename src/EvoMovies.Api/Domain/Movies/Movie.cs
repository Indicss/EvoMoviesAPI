using EvoMovies.Api.Domain.Movies.Enums;

namespace EvoMovies.Api.Domain.Movies;

public sealed class Movie
{
    public Guid Id { get; private init; }

    public string Title { get; private set; }

    public Genre Genre { get; private set; }

    public string Director { get; private set; }

    public decimal Rating { get; private set; }

    public DateOnly ReleaseDate { get; private set; }
    
    public string Poster { get; private set; }
    public string Url { get; private set; }

    public DateTime CreatedAt { get; private init; }

    private Movie(
        Guid id,
        string title,
        Genre genre,
        string director,
        decimal rating,
        DateOnly releaseDate,
        string poster,
        string url,
        DateTime createdAt)
    {
        Id = id;
        Title = title;
        Genre = genre;
        Director = director;
        Rating = rating;
        ReleaseDate = releaseDate;
        Poster = poster;
        Url = url;
        CreatedAt = createdAt;
    }

    public static Movie Register(
        string title,
        Genre genre,
        string director,
        DateOnly releaseDate,
        string poster,
        string url)
        => new Movie(
            Guid.NewGuid(),
            title,
            genre,
            director,
            0,
            releaseDate,
            poster,
            url,
            DateTime.UtcNow);

    public void UpdateTitle(string title)
    {
        Title = title;
    }
    
    public void UpdatePoster(string poster) => Poster = poster;
    public void UpdateUrl(string url) => Url = url;
}