using RelationshipLearning.Models;
using System.ComponentModel.DataAnnotations;

namespace RelationshipLearning.ViewModels
{
    public class PlaylistView
    {

        [Key]
        public int PlaylistsId { get; set; }
        [Required]
        public string Title { get; set; }

        public List<SongsView>? Songs { get; set; }
    }
}
