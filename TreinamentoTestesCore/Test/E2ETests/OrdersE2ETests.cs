using System.Net;

using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TreinamentoTestesCore.Domain.Interfaces;

namespace SimpleApiDDD.Test.E2ETests
{
    [TestClass]
    public class OrdersE2ETests
    {
        private WebApplicationFactory<Program> _factory;
        private HttpClient _client;
        private Mock<IOrderRepository> _orderRepositoryMock;
        private Mock<IProductRepository> _productRepositoryMock;

        [TestInitialize]
        public void Initialize()
        {
            // Configurar mocks para os repositórios
            _orderRepositoryMock = new Mock<IOrderRepository>();
            _productRepositoryMock = new Mock<IProductRepository>();

            _factory = new WebApplicationFactory<Program>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                    // Substituir os serviços reais pelos mocks
                        services.AddSingleton(_orderRepositoryMock.Object);
                        services.AddSingleton(_productRepositoryMock.Object);
                    });
                });

            _client = _factory.CreateClient();
        }

        [TestCleanup]
        public void Cleanup()
        {
            _client.Dispose();
            _factory.Dispose();
        }

        [TestMethod]
        public async Task GetOrders_ReturnsSuccessAndData()
        {
            // Arrange

            // Act
            var response = await _client.GetAsync("/api/order");

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }

}

