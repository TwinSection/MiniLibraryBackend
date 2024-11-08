using Microsoft.EntityFrameworkCore;

namespace MiniLibrary.Database.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIDAsync(int ID);
        T GetByID(int ID);
        Task AddAsync(T Entity);
        void Add(T Entity);
        Task<bool> UpdateAsync(T entity);
        bool Update(T entity);
        Task<bool> DeleteAsync(int id);
        bool Delete(int id);
        Task SaveAsync();
        void Save();
    }

    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly SystemDBContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(SystemDBContext context)
        {
            _context = context;
            _context.StartUp();
            _dbSet = context.Set<T>();
        }

        public async Task<T> GetByIDAsync(int ID) => await _dbSet.FindAsync(ID);
        public T GetByID(int ID) => _dbSet.Find(ID);
        public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();
        public IEnumerable<T> GetAll() => _dbSet.ToList();
        public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);
        public void Add(T entity) => _dbSet.Add(entity);
        public async Task SaveAsync() => await _context.SaveChangesAsync();
        public void Save() => _context.SaveChanges();

        public async Task<bool> UpdateAsync(T entity)
        {
            try
            {
                _dbSet.Update(entity);
                await SaveAsync();
            }catch(Exception e)
            {
                return false;
            }
            return true;
        }

        public bool Update(T entity)
        {
            try
            {
                _dbSet.Update(entity);
                Save();
            }catch(Exception e)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await GetByIDAsync(id);
            if (entity != null)
            {
                try
                {
                    _dbSet.Remove(entity);
                    await SaveAsync();
                }catch(Exception e)
                {
                    return false;
                }
            }
            return true;
        }
        public bool Delete(int id)
        {
            var entity = GetByID(id);
            if (entity != null)
            {
                try
                {
                    _dbSet.Remove(entity);
                    Save();
                }catch(Exception e)
                {
                    return false;
                }
            }
            return true;
        }

    }
}
