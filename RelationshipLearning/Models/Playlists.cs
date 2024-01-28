using System.ComponentModel.DataAnnotations;

namespace RelationshipLearning.Models
{
    public class Playlists
    {
        [Key]
        public int PlaylistsId { get; set; }
        [Required]
        public string Title { get; set; }

        public List<Songs>? Songs { get; set; }

        //public List<Users> Users { get; set; }
    }
}
