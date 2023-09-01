using TreinamentoTestesCore.Domain.Entities;
using TreinamentoTestesCore.Domain.Interfaces;

namespace TreinamentoTestesCore.Infra.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private List<Product> _products = new List<Product>
        {
            new Product { Id = 1, Name = "Product 1", Price = 100 },
            new Product { Id = 2, Name = "Product 2", Price = 150 }
            // Adicione mais produtos aqui
        };

        public Product GetProductById(int productId)
        {
            return _products.Find(p => p.Id == productId);
        }
    }
}
