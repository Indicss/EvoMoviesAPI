using EvoMovies.Api.Domain.Movies;
using EvoMovies.Api.Domain.Movies.Enums;
using EvoMovies.Api.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EvoMovies.Api.Services;

public sealed class MovieService(AppDbContext dbContext)
{
    public async Task<List<Movie>> RetrieveMoviesAsync(string? search, Genre? genre)
    {
        var query = dbContext.Movies.AsQueryable();
        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(x => x.Title.ToLower().Contains(search));
        }

        if (genre.HasValue)
        {
            query = query.Where(x => x.Genre == genre.Value);
        }
        
        return await query.ToListAsync();
    }

    public async Task<Movie?> RetrieveMovieByIdAsync(Guid id)
    {
        return await dbContext.Movies.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task RegisterMovieAsync(
        string title,
        Genre genre,
        string director,
        DateOnly releaseDate,
        string poster,
        string url)
    {
        var movie = Movie.Register(title, genre, director, releaseDate, poster, url);

        dbContext.Movies.Add(movie);
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteMovieAsync(Guid id)
    {
        var movie = await dbContext.Movies.FindAsync(id);
        if (movie is null) return;

        dbContext.Movies.Remove(movie);
        await dbContext.SaveChangesAsync();
    }
}