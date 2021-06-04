using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using PromotionEngine.Models;

namespace PromotionEngine.Database
{
    public class ComboOffers : IConfigDetails<ComboOffersModel>
    {
        public List<ComboOffersModel> Get()
        {
            try
            {
                var folderDetails = Path.Combine(Directory.GetCurrentDirectory(), "content\\ComboOffers.json");
                var json = System.IO.File.ReadAllText(folderDetails);

                var rootObject = JsonConvert.DeserializeObject<ComboMaster>(json);
                return rootObject.ComboOffers;
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

            return new List<ComboOffersModel>();
        }
    }
}
