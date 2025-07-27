using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Access.Data;
using Data_Access.Repositories;
using Models.Entities;

namespace Data_Access.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        public IProductRepository Products { get; private set; }
        public IGenericRepository<Category> Categories { get; private set; }

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            Products = new ProductRepository(dbContext);
            Categories = new GenericRepository<Category>(dbContext);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
