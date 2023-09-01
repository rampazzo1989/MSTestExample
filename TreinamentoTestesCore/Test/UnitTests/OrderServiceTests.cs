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

            // Add more test methods here...
        }
    }
}
