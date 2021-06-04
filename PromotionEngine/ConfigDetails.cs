using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using PromotionEngine.Models;

namespace PromotionEngine
{
    public class ConfigDetails
    {
        public static List<PromotionalOfferModel> GetPromotionlOffers()
        {
            var folderDetails = Path.Combine(Directory.GetCurrentDirectory(), "content\\PromotionalOffers.json");
            var json = System.IO.File.ReadAllText(folderDetails);

            var rootObject = JsonConvert.DeserializeObject<PromotionMaster>(json);
            return rootObject.PromotionalOffers;
        }

        public static List<ComboOffersModel> GetComboOffers()
        {
            var folderDetails = Path.Combine(Directory.GetCurrentDirectory(), "content\\ComboOffers.json");
            var json = System.IO.File.ReadAllText(folderDetails);

            var rootObject = JsonConvert.DeserializeObject<ComboMaster>(json);
            return rootObject.ComboOffers;
        }

        public static List<Product> GetAvailableProducts()
        {
            var folderDetails = Path.Combine(Directory.GetCurrentDirectory(), "content\\Product.json");
            var json = File.ReadAllText(folderDetails);

            var rootObject = JsonConvert.DeserializeObject<ProductMaster>(json);
            return rootObject.Products;
        }
    }
}
