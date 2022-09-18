using Bohemian_API.Models;
using Bohemian_API.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bohemian_API.Repository
{
    public class SongRepository : ISongRepository
    {
        private BohemianContext _context;

        public SongRepository(BohemianContext context)
        {
            _context = context;
        }


        public ResponseModel DeleteSong(int song_Id)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                Song _song = GetSongById(song_Id);
                if (_song != null)
                {
                    _context.Remove<Song>(_song);
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

        public Song GetSongById(int song_Id)
        {
            Song song;
            try
            {
                song = _context.Find<Song>(song_Id);
            }
            catch (Exception)
            {
                throw;
            }
            return song;
        }

        public Song GetSongByTitle(string title)
        {
            Song song;
            try
            {
                song = _context.Find<Song>(title);
            }
            catch (Exception)
            {
                throw;
            }
            return song;
        }

        public List<Song> GetSongs()
        {
            List<Song> songList;
            try
            {
                songList = _context.Set<Song>().ToList();
            }
            catch (Exception)
            {
                throw;
            }

            return songList;
        }

        public ResponseModel NewSong(Song songModel)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                Song _song = GetSongById(songModel.Song_Id);
                if (_song != null)
                {
                    _song.Song_Title = songModel.Song_Title;
                    _song.Song_Length = songModel.Song_Title;
                    _context.Update<Song>(_song);
                    model.Messsage = "Artist Update Successfully";
                }
                else
                {
                    _context.Add<Song>(songModel);
                    model.Messsage = "Song Added Successfully";
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
