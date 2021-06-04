using System.Collections.Generic;

namespace PromotionEngine.Models
{
    public class PromotionalOfferModel
    {
        public string Sku { get; set; }
        public int MinQty { get; set; }
        public float DiscPercentage { get; set; }
    }

    public class PromotionMaster
    {
        public List<PromotionalOfferModel> PromotionalOffers { get; set; }
    }
}

