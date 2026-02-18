using Microsoft.AspNetCore.Mvc;

namespace Movies.Api.Controllers
{
    [ApiController]
    [Route("api/movies")]
    public class MoviesController : ControllerBase
    {
        private static List<string> Movies = new List<string>
        {
            "Inception",
            "Interstellar",
            "The Matrix"
        };

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(Movies);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            if (id < 0 || id >= Movies.Count)
                return NotFound();

            return Ok(Movies[id]);
        }

        [HttpPost]
        public IActionResult AddMovie([FromBody] string movie)
        {
            Movies.Add(movie);
            return Ok(Movies);
        }
    }
}
