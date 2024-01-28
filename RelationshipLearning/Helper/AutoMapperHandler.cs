using AutoMapper;
using RelationshipLearning.Models;
using RelationshipLearning.ViewModels;

namespace RelationshipLearning.Helper
{
    public class AutoMapperHandler : Profile
    {
        public AutoMapperHandler()
        {
            CreateMap<Artists, ArtistView>()
                .ForMember(dest => dest.Songs, opt => opt.MapFrom(src => src.Songs));

            CreateMap<Artists, ArtistView>()
                .ForMember(dest => dest.Songs, opt => opt.MapFrom(src => src.Songs)).ReverseMap();

            CreateMap<Songs, SongsView>()
                .ForMember(dest => dest.ArtistName, opt => opt.MapFrom(src => src.Artist.ArtistName))
                .ForMember(dest => dest.PlaylistName, opt => opt.MapFrom(src => src.Playlist.Title));
            
            CreateMap<Songs, SongsView>()
                .ForMember(dest => dest.ArtistName, opt => opt.MapFrom(src => src.Artist.ArtistName))
                .ForMember(dest => dest.PlaylistName, opt => opt.MapFrom(src => src.Playlist.Title)).ReverseMap();

            
            CreateMap<Playlists,PlaylistView>()
                .ForMember(dest=>dest.Songs,opt=>opt.MapFrom(src => src.Songs));

            CreateMap<Playlists, PlaylistView>()
                .ForMember(dest => dest.Songs, opt => opt.MapFrom(src => src.Songs)).ReverseMap();
            //.ForMember(dest => dest.ArtistId, opt => opt.MapFrom(src => src.Artist.ArtistId));

            //CreateMap<Songs, SongsView>().ReverseMap();


        }
    }
}
