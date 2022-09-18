using Bohemian_API.Models;
using Bohemian_API.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bohemian_API.Repository
{
    public class GenreRepository : IGenreRepository
    {
        private BohemianContext _context;
        public GenreRepository(BohemianContext context)
        {
            _context = context;
        }

        public ResponseModel DeleteGenre(int genre_Id)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                Genre _genre = GetGenreByID(genre_Id);
                if (_genre != null)
                {
                    _context.Remove<Genre>(_genre);
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

        public List<Genre> GetAllGenre()
        {
            List<Genre> genreList;
            try
            {
                genreList = _context.Set<Genre>().ToList();
            }
            catch (Exception)
            {
                throw;
            }

            return genreList;
        }

        public Genre GetGenreByID(int genre_Id)
        {
            Genre genre;
            try
            {
                genre = _context.Find<Genre>(genre_Id);
            }
            catch (Exception)
            {
                throw;
            }
            return genre;
        }

        public ResponseModel NewGenre(Genre genreModel)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                Genre _genre = GetGenreByID(genreModel.Genre_Id);
                if (_genre != null)
                {
                    _genre.Genre_Name = genreModel.Genre_Name;
                    _context.Update<Genre>(_genre);
                    model.Messsage = "Update Successfully";
                }
                else
                {
                    _context.Add<Genre>(genreModel);
                    model.Messsage = "Added Successfully";
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
