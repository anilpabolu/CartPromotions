using System.Collections.Generic;
using System.Linq;
using PromotionEngine.Database;
using PromotionEngine.Models;

namespace PromotionEngine.Helper
{
    public class ComboHelper : IPromotions<ComboOffersModel>
    {
        private readonly IConfigDetails<ComboOffersModel> _offers = new ComboOffers();

        public List<ComboOffersModel> Get()
        {
            return _offers.Get();
        }


        public static List<BillingProduct> CheckComboOffers(List<ComboOffersModel> comboOffers, List<BillingProduct> finalBillList)
        {
            foreach (var coffer in comboOffers)
            {
                var comboItems = coffer.Skus;

                var comboItemAvailable = true;

                foreach (var item in comboItems)
                {
                    comboItemAvailable = finalBillList.Any(p => p.Sku == item);
                }

                if (comboItemAvailable)
                    GetComboPrice(coffer, finalBillList);
            }

            return finalBillList;
        }

        public static List<BillingProduct> GetComboPrice(ComboOffersModel coffer, List<BillingProduct> finalBillList)
        {
            var counter = 1;

            var minCount = coffer.MinQty;
            var skus = coffer.Skus;
            double amount = 0;

            for (var i = 0; i < skus.Length; i++)
            {
                foreach (var product in finalBillList)
                {
                    if (product.Sku == skus[i] && product.Qty > minCount[i])
                    {

                    }
                    else if (product.Sku == skus[i] && product.Qty == minCount[i])
                    {
                        if (counter != skus.Length)
                        {
                            amount += product.DiscountedPrice;
                            finalBillList.Where(w => w.Sku == skus[i]).ToList().ForEach(s => s.DiscountedPrice = 0);

                        }
                        else
                        {
                            amount += product.DiscountedPrice;
                            finalBillList.Where(w => w.Sku == skus[i]).ToList().ForEach(s =>
                                s.DiscountedPrice = (amount - coffer.ComboDiscount));
                        }

                        counter++;
                    }
                }
            }

            return finalBillList;
        }

    }
}
