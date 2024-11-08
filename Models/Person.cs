using System.ComponentModel.DataAnnotations;

namespace MiniLibrary.Models
{
    public class Person
    {
        [Key] public int ID { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Nickname { get; set; }
        public ICollection<Item> Items { get; set; } = new HashSet<Item>();
    }
}
