using EvoMovies.Api.Domain.Movies;
using EvoMovies.Api.Domain.Movies.Enums;
using EvoMovies.Api.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EvoMovies.Api.Services;

public sealed class MovieService(AppDbContext dbContext)
{
    public async Task<List<Movie>> RetrieveMoviesAsync(string? sort)
    {
        IQueryable<Movie> query = dbContext.Movies;

        query = sort?.ToLower() switch
        {
            "newest" => query.OrderByDescending(x => x.ReleaseDate),
            _ => query.OrderByDescending(x => x.CreatedAt)
        };

        return await query.ToListAsync();
    }

    public async Task RegisterMovieAsync(
        string title,
        Genre genre,
        string director,
        DateOnly releaseDate,
        string poster,
        string url)
    {
        var movie = Movie.Register(
            title,
            genre,
            director,
            releaseDate,
            poster,
            url
        );

        dbContext.Movies.Add(movie);

        await dbContext.SaveChangesAsync();
    }
}