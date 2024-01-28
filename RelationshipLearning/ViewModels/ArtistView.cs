using RelationshipLearning.Models;
using System.ComponentModel.DataAnnotations;

namespace RelationshipLearning.ViewModels
{
    public class ArtistView
    {

        [Key]
        public int ArtistId { get; set; }
        public string ArtistName { get; set; }
        public List<SongsView> Songs { get; set; }
    }
}
