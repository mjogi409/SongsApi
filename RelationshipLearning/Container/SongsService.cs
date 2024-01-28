using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RelationshipLearning.Models;
using RelationshipLearning.Services;
using RelationshipLearning.ViewModels;

namespace RelationshipLearning.Container
{
    public class SongsService : ISongService
    {
        private MydbContext _dbContext;
        private readonly IMapper _mapper;

        public SongsService(MydbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public bool AddSong(SongsView data)
        {
            Songs song = _mapper.Map<Songs>(data);
            try
            {
                if (song.Artist.ArtistName == null)
                {
                    return false;
                }
                _dbContext.Songs.Add(song);
                _dbContext.Artists.Add(song.Artist);
                _dbContext.Playlists.Add(song.Playlist);
                _dbContext.SaveChanges();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
            return true;
        }

        public List<SongsView> GetallSongs()
        {
            List<Songs> data = _dbContext.Songs.ToList();

            List<SongsView> songs = new List<SongsView>();

            foreach (Songs song in data)
            {
                songs.Add(_mapper.Map<SongsView>(song));

            }

            return songs;
        }

        public Songs GetSongsbyID(int songId)
        {
            var song = _dbContext.Songs.Find(songId);
            return song;
        }

        public bool RemoveSongs(int songId)
        {
            var song = _dbContext.Songs.Find(songId);
            _dbContext.Songs.Remove(song);
            _dbContext.SaveChanges();
            return true;
        }

        public bool UpdateSong(SongsView data, int songId)
        {
            try
            {
                Songs _song = _mapper.Map<Songs>(data);
                var song = _dbContext.Songs.Find(songId);
                song.SongName = _song.SongName;
                song.Artist = _song.Artist;
                song.Playlist = _song.Playlist;
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
            return true;
        }
    }
}
