

using Data_Access.Repositories;
using Models.Entities;

namespace Data_Access.UnitOfWork
{
    public interface IUnitOfWork
    {
        IProductRepository Products { get; }
        IGenericRepository<Category> Categories { get; }
        void Save();
    }
}
