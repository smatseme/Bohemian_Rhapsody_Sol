using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bohemian_API.Models;
using Bohemian_API.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Bohemian_API.Repository
{
    public class ArtistRepository: IArtistRepository
    {
        private DbContext _context;
        public ArtistRepository(DbContext context)
        {
            _context = context;
        }


        public List<Artist> GetAllArtist()
        {
            List<Artist> artistList;
            try
            {
                artistList = _context.Set<Artist>().ToList();
            }
            catch (Exception)
            {
                throw;
            }

            return artistList;
        }

        public Artist GetArtistByID(int artist_Id)
        {
            Artist artist;
            try
            {
                artist = _context.Find<Artist>(artist_Id);
            }
            catch (Exception)
            {
                throw;
            }
            return artist;
        }

        public ResponseModel NewArtist(Artist artistModel)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                Artist _artist = GetArtistByID(artistModel.Artist_Id);
                if (_artist != null)
                {
                    _artist.Artist_Name = artistModel.Artist_Name;
                    _context.Update<Artist>(_artist);
                    model.Messsage = "Artist Update Successfully";
                }
                else 
                {
                    _context.Add<Artist>(artistModel);
                }
                _context.SaveChanges();
                model.IsSuccess = true;
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Messsage = "Error :" + ex.Message;
            }

            return model;
        }

        public ResponseModel DeleteArtist(int artist_Id)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                Artist _artist = GetArtistByID(artist_Id);
                if (_artist != null)
                {
                    _context.Remove<Artist>(_artist);
                    _context.SaveChanges();
                    model.IsSuccess = true;
                    model.Messsage = "Deleted Successfully";
                }
                else
                {
                    model.IsSuccess = false;
                    model.Messsage = "Record Not Found";
                }
                _context.SaveChanges();
                model.IsSuccess = true;
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Messsage = "Error :" + ex.Message;
            }

            return model;
        }

    }
}
