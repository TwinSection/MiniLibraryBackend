using Microsoft.EntityFrameworkCore;
using MiniLibrary.Models;

namespace MiniLibrary.Database.Repository
{
    public interface IPersonRepository : IGenericRepository<Person> { }

    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        private readonly SystemDBContext _context;
        public PersonRepository(SystemDBContext context) : base(context)
        {
            _context = context;
        }
    }
}
