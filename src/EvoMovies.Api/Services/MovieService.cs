using EvoMovies.Api.Domain.Movies;
using EvoMovies.Api.Domain.Movies.Enums;
using EvoMovies.Api.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EvoMovies.Api.Services;

public sealed class MovieService(AppDbContext dbContext)
{
    public async Task<List<Movie>> RetrieveMoviesAsync()
    {
        var movies = await dbContext.Movies.ToListAsync();

        return movies;
    }

    public async Task RegisterMovieAsync(string title, Genre genre, string director, DateOnly releaseDate)
    {
        var movie = Movie.Register(title, genre, director, releaseDate);
        dbContext.Movies.Add(movie);
        
        await dbContext.SaveChangesAsync();
    }
}