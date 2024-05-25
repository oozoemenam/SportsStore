using SportsStore.Models;

namespace SportsStore.Repositories
{
    public interface IStoreRepository
    {
        IQueryable<Product> Products { get; }
    }
}
