using System.Collections.Generic;
using NUnit.Framework;
using PromotionEngine.Database;
using PromotionEngine.Helper;
using PromotionEngine.Models;


namespace CartPromotionsTDD
{
    class ShoppingHelperTest
    {
        [Test]
        public void GetPromotionlOffersTest()
        {

            IConfigDetails<Product> getConfig = new Products();
            var productList = getConfig.Get();

            var actualResult = ShoppingHelper.DoShopping(productList, "A", 2);

            var expectedResult = new List<Product>
            {
                new Product{Sku= "A", ProductName= "ProductA",Price =50 },
                new Product { Sku = "A", ProductName = "ProductA", Price = 50 }
            };

            Assert.AreEqual(true, actualResult.Item2);

        }
    }
}
