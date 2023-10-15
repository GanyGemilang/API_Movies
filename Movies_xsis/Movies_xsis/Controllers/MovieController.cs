using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movies_xsis.Entities;
using Movies_xsis.Repositories;
using Org.BouncyCastle.Crypto;

namespace Movies_xsis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly MovieRepository _movieRepository;
        public MovieController(MovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        [HttpGet("GetMovies")]
        public async Task<ActionResult<List<Movie>>> Get()
        {
            List<Movie> data = await _movieRepository.ListMovie();
            if (data == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(data);
            }
        }

        [HttpGet("GetMoviesById/:{id}")]
        public async Task<ActionResult<Movie>> GetById(int id)
        {
            Movie data = await _movieRepository.MovieById(id);
            if (data == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(data);
            }
        }

        [HttpPost("AddMovies")]
        public async Task<ActionResult> AddMovie(Movie movie)
        {
            Movie data = await _movieRepository.AddMovie(movie);
            if (data == null)
            {
                return BadRequest();
            }
            else
            {
                var response = new
                {
                    message = "Add Data Success",
                    data = data
                };

                return Ok(response);
            }
        }

        [HttpPatch("UpdateMovies")]
        public async Task<ActionResult> UpdateMovie(Movie movie)
        {
            Movie data = await _movieRepository.EditMovie(movie);
            if (data == null)
            {
                return BadRequest();
            }
            else
            {
                var response = new
                {
                    message = "Update Data Success",
                    data = data
                };

                return Ok(response);
            }
        }
        [HttpDelete("DeleteMovies:{id}")]
        public async Task<ActionResult<Movie>> DeleteMovies(int id)
        {
            bool data = await _movieRepository.Delete(id);
            if (data == false)
            {
                return NotFound();
            }
            else
            {
                var response = new
                {
                    message = "Delete Data Success"
                };

                return Ok(response);
            }
        }
    }
}
