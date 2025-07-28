

using Data_Access.Data;
using Microsoft.EntityFrameworkCore;

namespace Data_Access.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _dbContext;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        public async Task AddAsync(T entity) =>  await _dbSet.AddAsync(entity);

        public void Delete(T entity) => _dbSet.Remove(entity);

        public async Task <IEnumerable<T>> GetAllAsync() => await  _dbSet.ToListAsync();

        public async Task <T> GetByIdAsync(int id) =>await _dbSet.FindAsync(id);

        public void Update(T entity) => _dbSet.Update(entity);

    }
}
