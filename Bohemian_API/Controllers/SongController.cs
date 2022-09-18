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
    public class SongController : ControllerBase
    {
        readonly ISongRepository _songRepository;
        public SongController(ISongRepository repo)
        {
            _songRepository = repo;
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult SaveSong(Song songModel)
        {
            try
            {
                var model = _songRepository.NewSong(songModel);

                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("[action]")]
        public IActionResult DeleteSong(int id)
        {
            try
            {
                var model = _songRepository.DeleteSong(id);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("[action]/id")]
        public IActionResult GetSongById(int id)
        {
            try
            {
                var song = _songRepository.GetSongById(id);
                if (song == null) return NotFound();
                return Ok(song);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetSongs()
        {
            try
            {
                var song = _songRepository.GetSongs();
                if (song == null)
                    return NotFound();
                return Ok(song);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("[action]/title")]
        public IActionResult GetSongByTitle(string title)
        {
            try
            {
                var song = _songRepository.GetSongByTitle(title);
                if (song == null) return NotFound();
                return Ok(song);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
