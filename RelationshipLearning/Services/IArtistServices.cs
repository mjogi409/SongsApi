using RelationshipLearning.Models;
using RelationshipLearning.ViewModels;

namespace RelationshipLearning.Services
{
    public interface IArtistServices
    {

        List<Artists> GetallArtist();
        ArtistView GetArtistsbyID(int artistId);
        bool RemoveArtist(int aritstId);
        bool AddArtist(ArtistView data);
        bool UpdateArtist(ArtistView data, int artistId);
    }
}
