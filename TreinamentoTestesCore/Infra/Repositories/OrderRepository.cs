using TreinamentoTestesCore.Domain.Entities;
using TreinamentoTestesCore.Domain.Interfaces;

namespace TreinamentoTestesCore.Infra.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _dbContext;

        public OrderRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void SaveOrder(Order order)
        {
            _dbContext.Orders.Add(order);
        }

        public Order GetById(int id)
        {
            return _dbContext.Orders.FirstOrDefault(o => o.Id == id);
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return _dbContext.Orders.ToList();
        }
    }
}
