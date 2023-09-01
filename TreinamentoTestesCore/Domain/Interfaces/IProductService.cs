using TreinamentoTestesCore.Domain.Entities;

namespace TreinamentoTestesCore.Domain.Interfaces
{
    public interface IProductService
    {
        Product GetProductById(int productId);
    }
}
