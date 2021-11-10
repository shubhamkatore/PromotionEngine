namespace PromotionEngine.Models
{
    public class Product
    {
        public string Sku { get; set; }
        public int Price { get; set; }

        public Product(string sku,int price)
        {
            Sku = sku;
            Price = price;
        }
    }
}
