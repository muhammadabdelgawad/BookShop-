using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Access.Data;
using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace Data_Access.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context) { }

        public async Task <IEnumerable<Product>> GetAllWithCategoryAsync()
        {
            return await _dbSet.Include(p => p.Category).ToListAsync();
        }

        
    }
}
