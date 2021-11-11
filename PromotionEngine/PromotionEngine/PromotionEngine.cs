using PromotionEngine.Enums;
using PromotionEngine.Interfaces;
using PromotionEngine.Models;
using System.Collections.Generic;
using System.Linq;

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
            HashSet<string> computed = new HashSet<string>();
            foreach (var promotion in _promotions)
            {
                if (promotion.PromotionType == PromotionType.SingleProduct)
                {
                    CalculateSingleProductPromotion(computed, Cart, promotion);
                }
                else
                {
                    CalculateMultiProductPromotion(computed, Cart, promotion);
                }
            }

            CalculateNonPromotional(computed, Cart);
        }

        private void CalculateSingleProductPromotion(HashSet<string> computed, Cart Cart, Promotion promotion)
        {
            foreach (var item in Cart.Items)
            {
                if (item.Sku == promotion.Product.Sku)
                {
                    computed.Add(item.Sku);
                    if (promotion.DiscountType == DiscountType.Count)
                    {
                        Cart.Amount += ((item.Quantity / promotion.Count) * promotion.Price) + ((item.Quantity % promotion.Count) * promotion.Product.Price);
                    }
                    else
                    {
                        var product = _products.Find(prod => prod.Sku == item.Sku);
                        Cart.Amount += (item.Quantity * product.Price)*(promotion.DiscountPercentage/100);
                    }
                    break;
                }
            }
        }

        private void CalculateMultiProductPromotion(HashSet<string> computed, Cart Cart, Promotion promotion)
        {
            int count = 0;
            foreach (var product in promotion.ProductList)
            {
                foreach (var item in Cart.Items)
                {
                    if (product.Sku == item.Sku && !computed.Contains(item.Sku))
                    {
                        count++;
                        break;
                    }
                }
            }
            if (count == promotion.ProductList.Count)
            {
                foreach (var product in promotion.ProductList)
                {
                    computed.Add(product.Sku);
                }
                Cart.Amount += promotion.Price;
            }
        }

        private void CalculateNonPromotional(HashSet<string> computed,Cart Cart)
        {
            foreach (var item in Cart.Items.Where(cItem=>!computed.Contains(cItem.Sku)))
            {
                var product = _products.Find(prod => prod.Sku == item.Sku);
                Cart.Amount += product.Price * item.Quantity;
                computed.Add(item.Sku);
            }
        }

        
    }
}
