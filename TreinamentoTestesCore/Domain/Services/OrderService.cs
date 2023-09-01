using TreinamentoTestesCore.Domain.Entities;
using TreinamentoTestesCore.Domain.Interfaces;

namespace TreinamentoTestesCore.Domain.Services
{
    public class OrderService : IOrderService
    {
        private readonly IProductService _productService;
        private readonly IOrderRepository _orderRepository;

        public OrderService(IProductService productService, IOrderRepository orderRepository)
        {
            _productService = productService;
            _orderRepository = orderRepository;
        }

        public Order PlaceOrder(OrderRequest orderRequest)
        {
            // Obter o produto pelo ID utilizando o ProductService
            var product = _productService.GetProductById(orderRequest.ProductId);

            // Calcular o total do pedido
            decimal totalPrice = product.Price * orderRequest.Quantity;

            // Criar o pedido
            var order = new Order
            {
                OrderDate = DateTime.UtcNow,
                TotalPrice = totalPrice
            };

            // Salvar o pedido utilizando o OrderRepository
            _orderRepository.SaveOrder(order);

            return order;
        }

        public IEnumerable<Order> GetOrders()
        {
            return _orderRepository.GetAllOrders();
        }
    }
}
