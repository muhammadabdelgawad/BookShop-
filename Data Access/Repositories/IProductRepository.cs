
using Models.Entities;

namespace Data_Access.Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        public IEnumerable<Product> GetAllWithCategory();
      
            


    }
}
