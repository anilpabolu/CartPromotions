using System.Collections.Generic;
using NUnit.Framework;
using PromotionEngine.Models;
using PromotionEngine.Database;

namespace CartPromotionsTDD
{
    public class CofigDetailsTest
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void GetPromotionlOffersTest()
        {
            IConfigDetails<PromotionalOfferModel> getConfig = new PromotionlOffers();
            var actualResult = getConfig.Get();


            var expectedResult = new List<PromotionalOfferModel>
            {
                new PromotionalOfferModel{Sku= "A", MinQty= 3, DiscPercentage= 13.5f},
                new PromotionalOfferModel{Sku="B", MinQty=2, DiscPercentage=25},
                new PromotionalOfferModel{Sku="E", MinQty=2, DiscPercentage=5},
            };


            Assert.AreEqual(expectedResult[0].Sku, actualResult[0].Sku);
            Assert.AreEqual(expectedResult[1].Sku, actualResult[1].Sku);
            Assert.AreEqual(expectedResult[2].Sku, actualResult[2].Sku);


            Assert.AreEqual(expectedResult[0].MinQty, actualResult[0].MinQty);
            Assert.AreEqual(expectedResult[1].MinQty, actualResult[1].MinQty);
            Assert.AreEqual(expectedResult[2].MinQty, actualResult[2].MinQty);

            Assert.AreEqual(expectedResult[0].DiscPercentage, actualResult[0].DiscPercentage);
            Assert.AreEqual(expectedResult[2].DiscPercentage, actualResult[2].DiscPercentage);

        }

        [Test]
        public void GetComboOffersTest()
        {

           
            IConfigDetails<ComboOffersModel> getConfig = new ComboOffers();
            var actualResult = getConfig.Get();


            var expectedResult = new List<ComboOffersModel>
            {
                new ComboOffersModel{Skus=new[]{"C","D" }, MinQty= new[]{1,1 }, ComboDiscount=5,ComboDiscountType="Rupees"},
            };

            Assert.AreEqual(expectedResult[0].Skus[0], actualResult[0].Skus[0]);

            Assert.AreEqual(expectedResult[0].MinQty[0], actualResult[0].MinQty[0]);

            Assert.AreEqual(expectedResult[0].ComboDiscount, actualResult[0].ComboDiscount);

            Assert.AreEqual(expectedResult[0].ComboDiscountType, actualResult[0].ComboDiscountType);
        }

        [Test]
        public void GetAvaliableProductDetailsTest()
        {
           
            IConfigDetails<Product> getConfig = new Products();
            var actualResult = getConfig.Get();

            var expectedResult = new List<Product>
            {
                new Product{Sku= "A", ProductName= "ProductA",Price =50 },
            };

            Assert.AreEqual(expectedResult[0].Sku[0], actualResult[0].Sku[0]);
            Assert.AreEqual(expectedResult[0].ProductName[0], actualResult[0].ProductName[0]);
            Assert.AreEqual(expectedResult[0].Price, actualResult[0].Price);


        }
    }
}