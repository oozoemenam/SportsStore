using Microsoft.EntityFrameworkCore;
using SportsStore.Models;

namespace SportsStore.Repositories
{
    public class EFOrderRepository : IOrderRepository
    {
        private StoreDbContext context;

        public EFOrderRepository(StoreDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Order> Orders => context.Orders
            .Include(o => o.CartLines)
            .ThenInclude(l => l.Product);
        
        public void SaveOrder(Order order)
        {
            context.AttachRange(order.CartLines.Select(l => l.Product));
            if (order.Id == 0)
            {
                context.Orders.Add(order);
            }
            context.SaveChanges();
        }
    }
}
