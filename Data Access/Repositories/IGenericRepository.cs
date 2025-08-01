﻿
using System.Threading.Tasks;

namespace Data_Access.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task <IEnumerable<T>> GetAllAsync();
        Task <T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
    
}
