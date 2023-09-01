using TreinamentoTestesCore.Domain.Entities;
using TreinamentoTestesCore.Domain.Interfaces;

namespace TreinamentoTestesCore.Infra.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly List<Order> _orders = new();

        public void SaveOrder(Order order)
        {
            _orders.Add(order);
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return _orders;
        }
    }
}
