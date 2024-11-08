using Microsoft.EntityFrameworkCore;
using MiniLibrary.Models;

namespace MiniLibrary.Database.Repository
{
    public interface ICompanyRepository : IGenericRepository<Company> { }
    public class CompanyRepository : GenericRepository<Company>, ICompanyRepository
    {
        private readonly SystemDBContext _context;
        public CompanyRepository(SystemDBContext context) : base(context)
        {
            _context = context;
        }
    }
}
