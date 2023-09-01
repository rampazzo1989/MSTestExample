using TreinamentoTestesCore.Domain.Entities;

namespace TreinamentoTestesCore.Domain.Interfaces
{
    public interface IProductRepository
    {
        Product GetProductById(int productId);
    }
}
