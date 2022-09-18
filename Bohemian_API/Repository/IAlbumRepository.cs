using Bohemian_API.Models;
using Bohemian_API.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bohemian_API.Repository
{
    public interface IAlbumRepository
    {
        List<Album> GetAlbums();

        Album GetAlbumByID(int album_Id);

        ResponseModel NewAlbum(Album albumModel);

        ResponseModel DeleteAlbum(int album_Id);
    }
}
