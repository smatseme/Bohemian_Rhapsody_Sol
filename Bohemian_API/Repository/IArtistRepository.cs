using Bohemian_API.Models;
using Bohemian_API.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bohemian_API.Repository
{
    public interface IArtistRepository
    {
        List<Artist> GetAllArtist();

        Artist GetArtistByID(int artist_Id);

        ResponseModel NewArtist(Artist artistModel);

        ResponseModel DeleteArtist(int artist_Id);
    }
}
