using System;
using System.Collections.Generic;
using System.Linq;
using PromotionEngine.Database;
using PromotionEngine.Models;

namespace PromotionEngine.Helper
{
    public class PromotionHelper : IPromotions<PromotionalOfferModel>
    {
        private readonly IConfigDetails<PromotionalOfferModel> _offers = new PromotionlOffers();
        public List<PromotionalOfferModel> Get()
        {
            return _offers.Get();
        }


        public static Tuple<List<BillingProduct>, bool> ApplyPromotionalOffers(List<Product> products, List<Product> cartProduct, List<PromotionalOfferModel> promitionalOffers)
        {
            var finalBillingList = new List<BillingProduct>();
            int count;
            var isPromotionalOfferApplied = false;

            foreach (var item in products)
            {
                count = cartProduct.Count(n => n.Sku == item.Sku);

                var checkSku = cartProduct.Any(s => s.Sku == item.Sku);

                if (count > 0 && checkSku)
                {
                    var itemFinalBilling1 = new BillingProduct { Sku = item.Sku, Qty = count }; // = new BillingProduct();

                    finalBillingList.Add(itemFinalBilling1);
                }
            }

            foreach (var item in finalBillingList)
            {
                var itemOffer = promitionalOffers.Any(p => p.Sku == item.Sku) ? promitionalOffers.Find(n => n.Sku == item.Sku) : null;


                count = cartProduct.Count(n => n.Sku == item.Sku);

                if (itemOffer != null)
                {

                    item.DiscountedPrice = GetPrice(count, itemOffer, products.Find(n => n.Sku == item.Sku).Price, products.Find(n => n.Sku == item.Sku).Recursive);
                    isPromotionalOfferApplied = true;
                }
                else
                {
                    item.DiscountedPrice = GetNormalPrice(count, products.Find(n => n.Sku == item.Sku).Price);
                }


            }

            return new Tuple<List<BillingProduct>, bool>(finalBillingList, isPromotionalOfferApplied);

        }



        public static double GetNormalPrice(int count, float price)
        {
            return Math.Abs(count * price);
        }

        private static double GetPrice(int count, PromotionalOfferModel itemOffer, float itemPrice, bool isRecursive)
        {

            float totalItemPrice;

            if (count >= itemOffer.MinQty)
            {
                float discountPrice = 0;
                var counter = count;
                do
                {
                    discountPrice += ((itemOffer.MinQty * itemPrice) * itemOffer.DiscPercentage / 100);

                    counter -= itemOffer.MinQty;

                } while (counter >= itemOffer.MinQty && isRecursive);

                totalItemPrice = (count * itemPrice) - discountPrice;
            }
            else
            {

                totalItemPrice = (count * itemPrice);
            }

            return Math.Round(totalItemPrice);

        }


    }
}
