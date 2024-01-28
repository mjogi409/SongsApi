using System.ComponentModel.DataAnnotations;

namespace RelationshipLearning.Models
{
    public class Artists
    {
        [Key]
        public int ArtistId { get; set; }
        public string ArtistName { get; set; }
        public List<Songs> Songs { get; set; }
    }
}
