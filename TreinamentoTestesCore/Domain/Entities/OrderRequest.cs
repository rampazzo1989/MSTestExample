namespace TreinamentoTestesCore.Domain.Entities
{
    public class OrderRequest
    {
        public int OrderRequestId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }

    }
}
