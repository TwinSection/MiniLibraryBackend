using Microsoft.EntityFrameworkCore;
using MiniLibrary.Models;

namespace MiniLibrary.Database.Repository
{
    public interface IBookshelfRepository : IGenericRepository<Bookshelf> { }
    public class BookshelfRepository : GenericRepository<Bookshelf>, IBookshelfRepository
    {
        private readonly SystemDBContext _context;
        public BookshelfRepository(SystemDBContext context) : base(context)
        {
            _context = context;
        }
    }
}
