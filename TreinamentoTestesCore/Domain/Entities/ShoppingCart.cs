namespace TreinamentoTestesCore.Domain.Entities
{
    public class ShoppingCart
    {
        public List<Product> Items { get; } = new List<Product>();

        public decimal CalculateTotalPrice()
        {
            decimal total = 0;
            foreach (var item in Items)
            {
                total += item.Price;
            }
            return total;
        }
    }
}
