using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using PromotionEngine;
using PromotionEngine.Helper;
using PromotionEngine.Models;

namespace CartPromotionsTDD
{
    class CheckComboOffersTest
    {

        [Test]
        public void ApplyOffersTest()
        {
           
            var comboConfigList = new List<ComboOffersModel>
            {
                new ComboOffersModel{Skus=new[]{"C","D" }, MinQty= new[]{1,1 }, ComboDiscount=5,ComboDiscountType="Rupees"},
            };

            var finalbillingList = new List<BillingProduct>
            {
                new BillingProduct{Sku= "C", DiscountedPrice= 20, Qty = 1 },
                new BillingProduct{Sku= "D", DiscountedPrice= 15, Qty = 1 },
            };

            var expectedResult = new List<BillingProduct>
            {
                new BillingProduct{Sku= "C", DiscountedPrice= 0, Qty = 1 },
                new BillingProduct{Sku= "D", DiscountedPrice= 30, Qty = 1 },
            };


            var actualResult = ComboHelper.CheckComboOffers(comboConfigList, finalbillingList);

            Assert.AreEqual(expectedResult[0].Sku, actualResult[0].Sku);
            Assert.AreEqual(expectedResult[0].DiscountedPrice, actualResult[0].DiscountedPrice);
            Assert.AreEqual(expectedResult[0].Qty, actualResult[0].Qty);
        }


    }
}
