using System.Collections.Generic;

namespace PromotionEngine.Models
{
    public class Cart
    {
        public List<CartItem> Items { get; set; }
        public int Amount { get; set; }
        public Cart(List<CartItem> items)
        {
            Items = items;
        }
    }
}
