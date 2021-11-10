using PromotionEngine.Interfaces;
using PromotionEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine
{
    public class PromotionEngine : IPromotionEngine
    {
        private List<Product> _products;
        private List<Promotion> _promotions;

        public PromotionEngine(List<Product> Products, List<Promotion> Promotions)
        {
            _products = Products;
            _promotions = Promotions;
        }
        public void CheckOut(Cart Cart)
        {
        }
    }
}
