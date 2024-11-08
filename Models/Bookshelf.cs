namespace MiniLibrary.Models
{
    public class Bookshelf
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Item> Items { get; set; }
    }
}
