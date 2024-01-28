using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RelationshipLearning.Models;
using RelationshipLearning.Services;
using RelationshipLearning.ViewModels;

namespace RelationshipLearning.Container
{
    public class PlaylistService : IPlaylistService
    {
        public readonly MydbContext _dbcontext;
        public readonly IMapper _mapper;

        public PlaylistService(MydbContext dbcontext, IMapper mapper)
        {
            _dbcontext = dbcontext;
            _mapper = mapper;
        }

        public bool CreatePlaylist(PlaylistView playlist)
        {
            Playlists _plist = _mapper.Map<Playlists>(playlist); 
            _dbcontext.Playlists.Add(_plist);
            _dbcontext.SaveChanges();
            return true;
        }

        public bool DeletePlaylist(int playlistid)
        {
            Playlists playlists = _dbcontext.Playlists.Find(playlistid);
            _dbcontext.Playlists.Remove(playlists);
            _dbcontext.SaveChanges();
            return true;
        }

        public List<Playlists> GetallPlaylist()
        {
            return _dbcontext.Playlists.Include(_ => _.Songs).ToList();
        }

        public PlaylistView GetPlaylistsById(int playlistid)
        {
            Playlists _plist = _dbcontext.Playlists.Find(playlistid);
            var playlist = _mapper.Map<PlaylistView>(_plist);
            return playlist;
        }

        public bool UpdatePlaylist(PlaylistView playlist, int playlistid)
        {
            Playlists _plist = _dbcontext.Playlists.Find(playlistid);
            var playlst = _mapper.Map<Playlists>(_plist);
            _plist.Title = playlst.Title;
            _plist.Songs = playlst.Songs;
            _dbcontext.SaveChanges();
            return true;
        }
    }
}
