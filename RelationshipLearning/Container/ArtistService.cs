using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RelationshipLearning.Models;
using RelationshipLearning.Services;
using RelationshipLearning.ViewModels;

namespace RelationshipLearning.Container
{
    public class ArtistService : IArtistServices
    {
        private readonly MydbContext _dbContext;
        private readonly IMapper _mapper;
        

        public ArtistService(MydbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public bool AddArtist(ArtistView data)
        {
            Artists artist = _mapper.Map<ArtistView,Artists>(data);
            this._dbContext.Artists.Add(artist);
            this._dbContext.SaveChanges();
            return true;
        }

        public List<Artists> GetallArtist()
        {
            return this._dbContext.Artists.Include(_ => _.Songs).ToList();
        }

        public ArtistView GetArtistsbyID(int artistId)
        {
            var artist = this._dbContext.Artists.Find(artistId);
            var artists = _mapper.Map<ArtistView>(artist);
            return artists;
        }

        
        public bool RemoveArtist(int artistId)
        {
            var artist = this._dbContext.Artists.Find(artistId);
            this._dbContext.Artists.Remove(artist);
            this._dbContext.SaveChanges();
            return true;
        }

        public bool UpdateArtist(ArtistView data, int artistId)
        {
            Artists art = _mapper.Map<Artists>(data);
            var artist = this._dbContext.Artists.Find(artistId);
            artist.ArtistName = art.ArtistName;
            artist.Songs = art.Songs;
            this._dbContext.SaveChanges();
            return true;
        }

        
    }
}
