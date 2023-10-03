using TreinamentoTestesCore.Domain.Entities;

namespace TreinamentoTestesCore.Domain.Interfaces
{
    public interface IOrderRepository
    {
        void SaveOrder(Order order);
        IEnumerable<Order> GetAllOrders();
        Order GetById(int id);
    }
}
