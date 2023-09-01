using Microsoft.AspNetCore.Mvc;
using TreinamentoTestesCore.Domain.Entities;
using TreinamentoTestesCore.Domain.Interfaces;

namespace TreinamentoTestesCore.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public ActionResult PlaceOrder(OrderRequest orderRequest)
        {
            var order = _orderService.PlaceOrder(orderRequest);
            return Ok(order);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Order>> GetOrders()
        {
            var orders = _orderService.GetOrders();
            return Ok(orders);
        }
    }
}
