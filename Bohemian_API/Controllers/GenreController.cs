using Bohemian_API.Models;
using Bohemian_API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bohemian_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        readonly IGenreRepository _genreRepository;
        public GenreController(IGenreRepository repo)
        {
            _genreRepository = repo;
        }


        public IActionResult GetAllGenre()
        {
            try
            {
                var genre = _genreRepository.GetAllGenre();
                if (genre == null)
                    return NotFound();
                return Ok(genre);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("[action]/id")]
        public IActionResult GetGenreById(int id)
        {
            try
            {
                var genre = _genreRepository.GetGenreByID(id);
                if (genre == null) return NotFound();
                return Ok(genre);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPost]
        [Route("[action]")]
        public IActionResult SaveGenre(Genre genreModel)
        {
            try
            {
                var model = _genreRepository.NewGenre(genreModel);

                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("[action]")]
        public IActionResult DeleteGenre(int id)
        {
            try
            {
                var model = _genreRepository.DeleteGenre(id);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
