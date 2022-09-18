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
    public class AlbumController : ControllerBase
    {
        readonly IAlbumRepository _albumRepository;
        public AlbumController(IAlbumRepository repo)
        {
            _albumRepository = repo;
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAlbums()
        {
            try
            {
                var album = _albumRepository.GetAlbums();
                if (album == null)
                    return NotFound();
                return Ok(album);
            }
            catch (Exception e)
            {
                return BadRequest();

            }

        }

        [HttpGet]
        [Route("[action]/id")]
        public IActionResult GetAlbumById(int id)
        {
            try
            {
                var album = _albumRepository.GetAlbumByID(id);
                if (album == null)
                    return NotFound();
                return Ok(album);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }


        [HttpPost]
        [Route("[action]")]
        public IActionResult NewAlbum(Album albumModel)
        {
            try
            {
                var model = _albumRepository.NewAlbum(albumModel);

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
                var model = _albumRepository.DeleteAlbum(id);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


    }
}
