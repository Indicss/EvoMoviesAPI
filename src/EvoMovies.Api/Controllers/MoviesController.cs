using EvoMovies.Api.Models;
using EvoMovies.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace EvoMovies.Api.Controllers;

[ApiController]
[Route("api/movies")]
public sealed class MoviesController(MovieService movieService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<MovieResponse>>> GetMovies([FromQuery] string? search)
    {
        var movies = await movieService.RetrieveMoviesAsync(search);
        return Ok(movies.Select(MovieResponse.FromMovie).ToList());
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<MovieResponse>> GetMovieById(Guid id)
    {
        var movie = await movieService.RetrieveMovieByIdAsync(id);
        if (movie is null) return NotFound();

        return Ok(MovieResponse.FromMovie(movie));
    }

    [HttpPost]
    public async Task<IActionResult> RegisterMovie([FromBody] RegisterMovieRequest request)
    {
        await movieService.RegisterMovieAsync(
            request.Title,
            request.Genre.ToDomainModel(),
            request.Director,
            request.ReleaseDate,
            request.Poster,
            request.Url);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteMovie(Guid id)
    {
        await movieService.DeleteMovieAsync(id);
        return NoContent();
    }
}