using Microsoft.EntityFrameworkCore;
using MiniLibrary.Models;

namespace MiniLibrary.Database.Repository
{
    public interface IItemTypeRepository : IGenericRepository<ItemType> { }
    public class ItemTypeRepository : GenericRepository<ItemType>, IItemTypeRepository
    {
        private readonly SystemDBContext _context;
        public ItemTypeRepository(SystemDBContext context) : base(context)
        {
            _context = context;
        }
    }
}
