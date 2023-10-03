namespace TreinamentoTestesCore.Domain.Entities
{
    public class ShoppingCart
    {
        public int ShoppingCartId { get; set; }
        public List<Product> Products { get; set; }

        public ShoppingCart()
        {
            Products = new List<Product>();
        }

        public decimal CalculateTotalPrice()
        {
            decimal total = 0;
            foreach (var item in Products)
            {
                total += item.Price;
            }
            return total;
        }
    }
}
