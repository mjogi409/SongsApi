using RelationshipLearning.Models;
using RelationshipLearning.ViewModels;

namespace RelationshipLearning.Services
{
    public interface IPlaylistService
    {
        List<Playlists> GetallPlaylist();
        bool UpdatePlaylist(PlaylistView playlist,int playlistid);
        
        PlaylistView GetPlaylistsById(int playlistid);

        bool CreatePlaylist(PlaylistView playlist);
        
        bool DeletePlaylist(int playlistid);
    }
}
