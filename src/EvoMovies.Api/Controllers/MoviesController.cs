using EvoMovies.Api.Models;
using EvoMovies.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace EvoMovies.Api.Controllers;

[Route("api/movies")]
[ApiController]
public class MoviesController(MovieService movieService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetMovies([FromQuery] string? sort)
    {
        var movies = await movieService.RetrieveMoviesAsync(sort);
        return Ok(movies.ConvertAll(MovieResponse.FromMovie));
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
            request.Url
        );

        return Ok();
    }
}