using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TreinamentoTestesCore.Domain.Entities;
using TreinamentoTestesCore.Domain.Interfaces;
using TreinamentoTestesCore.Domain.Services;

namespace TreinamentoTestesCore.Test.UnitTests
{
    [TestClass]
    [TestCategory("Products")]
    public class ProductServiceTests
    {
        [TestMethod]
        public void GetProductById_ProductExists_ReturnsProduct()
        {
            // Arrange
            var mockProductRepository = new Mock<IProductRepository>();
            mockProductRepository.Setup(repository => repository.GetProductById(It.IsAny<int>()))
                .Returns(new Product { Id = 1, Name = "Test Product", Price = 99.99m });

            var productService = new ProductService(mockProductRepository.Object);

            // Act
            var result = productService.GetProductById(1);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Test Product", result.Name);
            Assert.AreEqual(99.99m, result.Price);
        }
    }
}
