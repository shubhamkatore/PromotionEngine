namespace PromotionEngine.Models
{
    public class CartItem
    {
        public string Sku { get; set; }
        public int Quantity { get; set; }

        public CartItem(string sku,int quantity)
        {
            Sku = sku;
            Quantity = quantity;
        }
    }
}
