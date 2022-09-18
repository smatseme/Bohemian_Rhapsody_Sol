using Bohemian_API.Models;
using Bohemian_API.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bohemian_API.Repository
{
    public class AlbumRepository: IAlbumRepository
    {
        private BohemianContext _context;
        public AlbumRepository(BohemianContext context)
        {
            _context = context;
        }

        public List<Album> GetAlbums()
        {
            List<Album> albumList;
            try
            {
                albumList = _context.Set<Album>().ToList();
            }
            catch (Exception)
            {
                throw;
            }

            return albumList;
        }

        public Album GetAlbumByID(int album_Id)
        {
            Album album;
            try
            {
                album = _context.Find<Album>(album_Id);
            }
            catch (Exception)
            {
                throw;
            }
            return album;
        }

        public ResponseModel NewAlbum(Album albumModel)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                Album _album = GetAlbumByID(albumModel.Album_Id);
                if (_album != null)
                {
                    _album.Album_Title = albumModel.Album_Title;
                    
                    _context.Update<Album>(_album);
                    model.Messsage = "Album Update Successfully";
                }
                else
                {
                    _context.Add<Album>(albumModel);
                    model.Messsage = "Album Added Successfully";
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

        public ResponseModel DeleteAlbum(int album_Id)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                Album _album = GetAlbumByID(album_Id);
                if (_album != null)
                {
                    _context.Remove<Album>(_album);
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
