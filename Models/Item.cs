using System.ComponentModel.DataAnnotations;

namespace MiniLibrary.Models
{
    public class Item
    {
        [Key]
        public int ID { get; set; }
        
        [Required]
        public string Title { get; set; }

        public string? Description { get; set; }
        public string? ISBN { get; set; }
        public ICollection<People>? Author { get; set; } = new HashSet<People>();
        public ICollection<Company>? Publisher { get; set; } = new HashSet<Company>();
        public DateTime? ReleaseDate { get; set; }
        public int? TotalPage { get; set; }
    }
}
