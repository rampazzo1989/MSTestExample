using TreinamentoTestesCore.Domain.Entities;
using TreinamentoTestesCore.Domain.Interfaces;

namespace TreinamentoTestesCore.Domain.Services
{
    public class ProductService: IProductService
    {

        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Product GetProductById(int productId)
        {
            return _productRepository.GetProductById(productId);
        }
    }
}
