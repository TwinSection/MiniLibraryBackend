using Microsoft.EntityFrameworkCore;
using MiniLibrary.Models;

namespace MiniLibrary.Database.Repository
{
    public interface IItemRepository : IGenericRepository<Item> { }
    public class ItemRepository : GenericRepository<Item>, IItemRepository
    {
        private readonly SystemDBContext _context;
        public ItemRepository(SystemDBContext context) : base(context)
        {
            _context = context;
        }
    }
}
