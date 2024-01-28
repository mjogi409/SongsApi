using System.ComponentModel.DataAnnotations;

namespace RelationshipLearning.Models
{
    public class Songs
    {
        [Key]
        public int SongId { get; set; }
        [Required]
        public string SongName { get; set; }
        [Required]
        public Artists Artist { get; set; }

        public Playlists? Playlist { get; set; }

    }
}
