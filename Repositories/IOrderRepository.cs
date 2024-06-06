using SportsStore.Models;

namespace SportsStore.Repositories
{
    public interface IOrderRepository
    {
        IQueryable<Order> Orders { get; }

        void SaveOrder(Order order);    
    }
}
