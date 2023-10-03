using System.Net;

using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using TreinamentoTestesCore.Domain.Entities;
using TreinamentoTestesCore.Domain.Interfaces;
using TreinamentoTestesCore.Infra;

namespace SimpleApiDDD.Test.E2ETests
{
    [TestClass]
    public class OrdersE2ETests
    {
        private WebApplicationFactory<Program> _factory;
        private HttpClient _client;
        //private Mock<IOrderRepository> _orderRepositoryMock;
        //private Mock<IProductRepository> _productRepositoryMock;
        private DbContextOptions<AppDbContext> _dbContextOptions;
        private AppDbContext _dbContext;


        [TestInitialize]
        public void Initialize()
        {
            // Configurar mocks para os repositórios
            //_orderRepositoryMock = new Mock<IOrderRepository>();
            //_productRepositoryMock = new Mock<IProductRepository>();

            // Configurar as opções do DbContext para usar um banco de dados SQLite em memória
            //_dbContextOptions = new DbContextOptionsBuilder<AppDbContext>()
            //    .UseInMemoryDatabase(databaseName: "TestDatabase")
            //    .Options;

            _factory = new WebApplicationFactory<Program>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        // Replace the real DbContext with an in-memory database for testing
                        var serviceProvider = new ServiceCollection()
                            .AddEntityFrameworkInMemoryDatabase()
                            .BuildServiceProvider();

                        services.AddDbContext<AppDbContext>(options =>
                        {
                            options.UseInMemoryDatabase("database.db");
                            options.UseInternalServiceProvider(serviceProvider);
                        });
                    });
                });

            _client = _factory.CreateClient();

            // Obter o DbContext para inserir e remover registros temporários
            //_dbContext = _factory.Services.GetRequiredService<AppDbContext>();
        }

        [TestCleanup]
        public void Cleanup()
        {
            _client.Dispose();
            _factory.Dispose();

            // Limpar o banco de dados em memória após o teste
            //_dbContext.Database.EnsureDeleted();
        }

        [TestMethod]
        public async Task GetOrders_ReturnsSuccessAndData()
        {
            // Arrange
            // Inserir dados de teste no banco de dados em memória
            var order = new Order
            {
                OrderDate = DateTime.Now,
                // Suponha que OrderRequests seja uma lista de pedidos associados a este pedido
                OrderRequests = new List<OrderRequest>
                {
                    new OrderRequest
                    {
                        Product = new Product
                        {
                            Name = "Produto de Teste 1",
                            Price = 10.0M
                        },
                        Quantity = 2
                    },
                    new OrderRequest
                    {
                        Product = new Product
                        {
                            Name = "Produto de Teste 2",
                            Price = 15.0M
                        },
                        Quantity = 3
                    }
                }
            };

            using (var scope = _factory.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                // Apply database migrations
                dbContext.Database.Migrate();

                dbContext.Orders.Add(order);

                dbContext.SaveChanges();
            }


            // Act
            var response = await _client.GetAsync($"/api/order/{order.Id}");

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var content = await response.Content.ReadAsStringAsync();
            var responseOrder = JsonConvert.DeserializeObject<Order>(content);

            Assert.IsNotNull(responseOrder);
            Assert.AreEqual(responseOrder.Id, order.Id);
        }
    }

}

