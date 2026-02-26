using EvoMovies.Api.Domain.Movies;
using EvoMovies.Api.Domain.Movies.Enums;
using EvoMovies.Api.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EvoMovies.Api.Services;

public sealed class MovieService(AppDbContext dbContext)
{
    public async Task<List<Movie>> RetrieveMoviesAsync()
    {
        return await dbContext.Movies.ToListAsync();
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