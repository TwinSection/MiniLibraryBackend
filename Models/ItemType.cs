namespace MiniLibrary.Models
{
    public class ItemType
    {
        public int ID { get; set; }
        public string TypeName { get; set; }

        public static List<ItemType> DefaultTypes()
        {
            return new List<ItemType>
            {
                new ItemType(){ ID=0, TypeName="Book"},
                new ItemType(){ ID=1, TypeName="Manga"},
                new ItemType(){ ID=2, TypeName="Comic"},
            };
        }
    }
}
