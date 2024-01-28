using RelationshipLearning.Models;
using RelationshipLearning.ViewModels;

namespace RelationshipLearning.Services
{
    public interface ISongService
    {
        List<SongsView> GetallSongs();
        Songs GetSongsbyID(int songId);
        bool RemoveSongs(int songId);
        bool AddSong(SongsView data);
        bool UpdateSong(SongsView data, int songId);
    }
}
