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
    public class ArtistController : ControllerBase
    {
        IArtistRepository _artistRepository;
        public ArtistController(IArtistRepository repo)
        {
            _artistRepository = repo;
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAllArtists()
        {
            try
            {
                var artist = _artistRepository.GetAllArtist();
                if (artist == null)
                    return NotFound();
                return Ok(artist);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("[action]/id")]
        public IActionResult GetArtistById(int id)
        {
            try
            {
                var artist = _artistRepository.GetArtistByID(id);
                if (artist == null) return NotFound();
                return Ok(artist);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        [HttpPost]
        [Route("[action]")]
        public IActionResult SaveArtist(Artist artistModel)
        {
            try
            {
                var model = _artistRepository.NewArtist(artistModel);

                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("[action]")]
        public IActionResult DeleteArtist(int id)
        {
            try
            {
                var model = _artistRepository.DeleteArtist(id);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
