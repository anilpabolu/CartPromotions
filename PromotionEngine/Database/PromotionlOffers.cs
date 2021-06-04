using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using PromotionEngine.Models;

namespace PromotionEngine.Database
{
    public class PromotionlOffers : IConfigDetails<PromotionalOfferModel>
    {
        public List<PromotionalOfferModel> Get()
        {
            try
            {
                var folderDetails = Path.Combine(Directory.GetCurrentDirectory(), "content\\PromotionalOffers.json");
                var json = System.IO.File.ReadAllText(folderDetails);

                var rootObject = JsonConvert.DeserializeObject<PromotionMaster>(json);
                return rootObject.PromotionalOffers;
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex);
                //throw;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return new List<PromotionalOfferModel>();
        }
    }
}
