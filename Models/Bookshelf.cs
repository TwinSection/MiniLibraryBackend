using System.ComponentModel.DataAnnotations;

namespace MiniLibrary.Models
{
    public class Bookshelf
    {
        [Key] public int ID { get; set; }
        [Required] public string Name { get; set; }
        public List<Item> Items { get; set; }
    }
}
