using Bohemian_API.Models;
using Bohemian_API.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bohemian_API.Repository
{
    public interface IGenreRepository
    {
        List<Genre> GetAllGenre();

        Genre GetGenreByID(int genre_Id);

        ResponseModel NewGenre(Genre genreModel);

        ResponseModel DeleteGenre(int genre_Id);
    }
}
