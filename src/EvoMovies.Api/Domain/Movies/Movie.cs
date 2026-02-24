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
    
    public DateTime CreatedAt { get; private init; }

    private Movie(
        Guid id,
        string title,
        Genre genre,
        string director,
        decimal rating,
        DateOnly releaseDate,
        DateTime createdAt)
    {
        Id = id;
        Title = title;
        Genre = genre;
        Director = director;
        Rating = rating;
        ReleaseDate = releaseDate;
        CreatedAt = createdAt;
    }

    public static Movie Register(string title, Genre genre, string director, DateOnly releaseDate) => new Movie(
        Guid.NewGuid(), 
        title, 
        genre, 
        director, 
        0, 
        releaseDate, 
        DateTime.Now);
    
    public void UpdateTitle(string title)
    {
        Title = title;
    }
}