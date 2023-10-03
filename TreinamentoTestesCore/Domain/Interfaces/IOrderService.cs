using TreinamentoTestesCore.Domain.Entities;

namespace TreinamentoTestesCore.Domain.Interfaces
{
    public interface IOrderService
    {
        Order PlaceOrder(OrderRequest orderRequest);
        IEnumerable<Order> GetOrders();
        Order GetOrder(int orderId);
    }
}
