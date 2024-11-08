using System.ComponentModel.DataAnnotations;

namespace MiniLibrary.Models
{
    public class Company
    {
        [Key]
        public int ID { get; set; }
        public string CompanyName { get; set; }
        public ICollection<Item> Items { get; set; } = new HashSet<Item>();
    }
}
