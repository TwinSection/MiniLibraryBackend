using System.ComponentModel.DataAnnotations;

namespace MiniLibrary.Models
{
    public class ItemType
    {
        [Key] public int ID { get; set; }
        [Required] public string TypeName { get; set; }

        public static List<ItemType> DefaultTypes()
        {
            return new List<ItemType>
            {
                new ItemType(){ TypeName="Book"},
                new ItemType(){ TypeName="Manga"},
                new ItemType(){ TypeName="Comic"},
            };
        }
    }
}
