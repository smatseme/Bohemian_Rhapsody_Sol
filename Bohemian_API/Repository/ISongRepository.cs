using Bohemian_API.Models;
using Bohemian_API.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bohemian_API.Repository
{
    public interface ISongRepository
    {
        List<Song> GetSongs();
        Song GetSongById(int song_Id);
        Song GetSongByTitle(string title);        
        ResponseModel NewSong(Song songModel);
        ResponseModel DeleteSong(int song_Id);
    }

}
