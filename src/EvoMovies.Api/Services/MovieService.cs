namespace EvoMovies.Api.Services;

public sealed class MovieService
{
    private readonly List<string> _movies = ["Spider-Man 2", "Batman", "Fast & Furious 5"];
    
    public async Task<List<string>> RetrieveMoviesAsync()
    {
        await Task.CompletedTask;

        return _movies;
    }

    public async Task RegisterMovieAsync(string title)
    {
        await Task.CompletedTask;
        
        _movies.Add(title);
    }
}