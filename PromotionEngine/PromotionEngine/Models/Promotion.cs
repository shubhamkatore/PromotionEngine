using PromotionEngine.Enums;
using System.Collections.Generic;

namespace PromotionEngine.Models
{
    public class Promotion
    {
        public PromotionType PromotionType { get; set; }
        public Product Product { get; set; }
        public List<Product> ProductList { get; set; }
        public DiscountType DiscountType { get; set; }
        public int DiscountPercentage { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
    }
}
