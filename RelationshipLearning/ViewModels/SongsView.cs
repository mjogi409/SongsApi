using RelationshipLearning.Models;
using System.ComponentModel.DataAnnotations;

namespace RelationshipLearning.ViewModels
{
    public class SongsView
    {

        [Key]
        public int SongId { get; set; }
        public string SongName { get; set; }
            
        public string ArtistName { get; set; }  
        public string? PlaylistName { get; set; }    

    }
}
