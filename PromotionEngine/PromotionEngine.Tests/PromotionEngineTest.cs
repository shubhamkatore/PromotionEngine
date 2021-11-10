using NUnit.Framework;
using PromotionEngine.Enums;
using PromotionEngine.Models;
using System.Collections.Generic;

namespace PromotionEngine.Tests
{
    public class PromotionEngineTest
    {
        PromotionEngine PromotionEngine;
        Dictionary<string, Product> productList = new Dictionary<string, Product>
        {
            {"A", new Product("A",50)},
            {"B", new Product("B",30)},
            {"C", new Product("C",20)},
            {"D", new Product("D",15)}
        };

        [SetUp]
        public void Setup()
        {
            List<Product> products = new List<Product>
            {
                new Product("A",50),
                new Product("B",30),
                new Product("C",20),
                new Product("D",15)
            };
            List<Promotion> promotions = new List<Promotion>
            {
                new Promotion
                {
                    PromotionType = PromotionType.SingleProduct,
                    Product=productList["A"],
                    DiscountType=DiscountType.Count,
                    Count=3,
                    Price=130
                },
                new Promotion
                {
                    PromotionType = PromotionType.SingleProduct,
                    Product=productList["B"],
                    DiscountType=DiscountType.Count,
                    Count=2,
                    Price=45
                },
                new Promotion
                {
                    PromotionType = PromotionType.MultiProduct,
                    ProductList=new List<Product>
                    {
                        productList["C"],
                        productList["D"]
                    },
                    Price=120
                }
            };
            PromotionEngine = new PromotionEngine(products,promotions);
        }

        [Test]
        public void TestScenarioA()
        {
            List<CartItem> CartItems = new List<CartItem>
            {
                new CartItem("A",1),
                new CartItem("B",1),
                new CartItem("C",1)
            };
            Cart Cart = new Cart(CartItems);
            PromotionEngine.CheckOut(Cart);
            Assert.AreEqual(Cart.Amount, 100);
        }

        [Test]
        public void TestScenarioB()
        {
            List<CartItem> CartItems = new List<CartItem>
            {
                new CartItem("A",5),
                new CartItem("B",5),
                new CartItem("C",1)
            };
            Cart Cart = new Cart(CartItems);
            PromotionEngine.CheckOut(Cart);
            Assert.AreEqual(Cart.Amount, 370);
        }

        [Test]
        public void TestScenarioC()
        {
            List<CartItem> CartItems = new List<CartItem>
            {
                new CartItem("A",3),
                new CartItem("B",5),
                new CartItem("C",1),
                new CartItem("D",1)
            };
            Cart Cart = new Cart(CartItems);
            PromotionEngine.CheckOut(Cart);
            Assert.AreEqual(Cart.Amount, 280);
        }
    }
}
