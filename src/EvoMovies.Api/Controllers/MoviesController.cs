using EvoMovies.Api.Domain.Movies.Enums;
using EvoMovies.Api.Models;
using EvoMovies.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace EvoMovies.Api.Controllers;

[Route("api/movies")]
[ApiController]
public class MoviesController(MovieService movieService) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetMovies()
    {
        var movies = await movieService.RetrieveMoviesAsync();
        
        return Ok(movies.ConvertAll(MovieResponse.FromMovie));
    }

    [HttpPost]
    public async Task<IActionResult> RegisterMovie([FromBody] RegisterMovieRequest request)
    {
        await movieService.RegisterMovieAsync(request.Title, request.Genre switch
        {
            _ => Genre.Other
        }, request.Director, request.ReleaseDate);
        
        return Ok();
    }
}