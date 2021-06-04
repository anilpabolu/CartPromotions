using System.Collections.Generic;
using PromotionEngine.Helper;
using PromotionEngine.Models;

namespace PromotionEngine
{
    public class Promotions
    {
        public static List<BillingProduct> ApplyOffers(List<Product> productList, List<Product> cartproduct)
        {
            var comboOffers = new ComboHelper().Get();
            var promotionalOffers = new PromotionHelper().Get();


            var isPromotionalOfferApplied = PromotionHelper.ApplyPromotionalOffers(productList, cartproduct, promotionalOffers);
            var billingList = isPromotionalOfferApplied.Item1;

            if (!isPromotionalOfferApplied.Item2)
            {
                billingList = ComboHelper.CheckComboOffers(comboOffers, isPromotionalOfferApplied.Item1);

            }

            return billingList;

        }
    }
}
