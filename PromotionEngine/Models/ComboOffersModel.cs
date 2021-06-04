using System.Collections.Generic;

namespace PromotionEngine.Models
{
    public class ComboOffersModel
    {
        public string[] Skus { get; set; }
        public int[] MinQty { get; set; }
        public int ComboDiscount { get; set; }
        public string ComboDiscountType { get; set; }
    }

    public class ComboMaster
    {
        public List<ComboOffersModel> ComboOffers { get; set; }
    }

}
