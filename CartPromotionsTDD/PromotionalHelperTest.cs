using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using PromotionEngine;
using PromotionEngine.Database;
using PromotionEngine.Helper;
using PromotionEngine.Models;

namespace CartPromotionsTDD
{
    class PromotionalHelperTest
    {

        [Test]
        public void GetPromotionlOffersTest()
        {
            var actualResult = PromotionHelper.GetNormalPrice(2, 50);

            var expectedResult = 100;

            Assert.AreEqual(expectedResult, actualResult);

        }


       

        [Test]
        public void ApplyOffersTest()
        {
            var productList = new List<Product>
            {
                new Product{Sku= "A", ProductName= "ProductA",Price =50 },
                new Product{Sku= "B", ProductName= "ProductB",Price =30 }
            };

            var cartproducts = new List<Product>
            {
                new Product{Sku= "A", ProductName= "ProductA",Price =50 },
                new Product{Sku= "A", ProductName= "ProductA",Price =50 },
                new Product{Sku= "A", ProductName= "ProductA",Price =50 }
            };

            var expectedResult = new List<BillingProduct>
                {
                    new BillingProduct{Sku= "A", DiscountedPrice= 130, Qty = 3 },
                };

            var actualResult = Promotions.ApplyOffers(productList, cartproducts);

            Assert.AreEqual(expectedResult[0].Sku, actualResult[0].Sku);
            Assert.AreEqual(expectedResult[0].DiscountedPrice, actualResult[0].DiscountedPrice);
            Assert.AreEqual(expectedResult[0].Qty, actualResult[0].Qty);
        }



    }
}
