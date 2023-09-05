namespace TreinamentoTestesCore.Test.UnitTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using TreinamentoTestesCore.Domain.Entities;
    using TreinamentoTestesCore.Domain.Interfaces;
    using TreinamentoTestesCore.Domain.Services;

    namespace SimpleApiDDD.Test.UnitTests
    {
        [TestClass]
        [TestCategory("Orders")]
        public class OrderServiceTests
        {
            [TestMethod]
            public void PlaceOrder_ValidOrderRequest_ReturnsOrder()
            {
                // Arrange
                var mockProductService = new Mock<IProductService>();
                mockProductService.Setup(service => service.GetProductById(It.IsAny<int>()))
                    .Returns(new Product { Id = 1, Name = "Test Product", Price = 99.99m });

                var mockOrderRepository = new Mock<IOrderRepository>();

                var orderService = new OrderService(mockProductService.Object, mockOrderRepository.Object);

                var orderRequest = new OrderRequest { ProductId = 1, Quantity = 2 };

                // Act
                var result = orderService.PlaceOrder(orderRequest);

                // Assert
                Assert.IsNotNull(result);
                Assert.AreEqual(199.98m, result.TotalPrice);
            }

            [TestMethod]
            public void GetOrderWithHighestValue_ReturnsOrderWithHighestValue()
            {
                // Arrange
                var orderRepositoryMock = new Mock<IOrderRepository>();
                var mockProductService = new Mock<IProductService>();


                // Configurar o mock para retornar algumas orders fictícias
                var orders = new List<Order>
                {
                    new Order { Id = 1, TotalPrice = 100.00m },
                    new Order { Id = 2, TotalPrice = 75.50m },
                    new Order { Id = 3, TotalPrice = 150.25m }
                };

                orderRepositoryMock.Setup(repo => repo.GetAllOrders()).Returns(orders);

                var orderService = new OrderService(mockProductService.Object, orderRepositoryMock.Object);

                // Act
                var result = orderService.GetOrderWithHighestValue();

                // Assert
                Assert.IsNotNull(result);
                Assert.AreEqual(2, result.Id); // Verifica se a Order retornada é igual a de maior valor (3)
            }
        }
    }
}
