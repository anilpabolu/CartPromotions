using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using PromotionEngine.Models;

namespace PromotionEngine.Database
{
    public class Products : IConfigDetails<Product>
    {
        public List<Product> Get()
        {
            try
            {
                var folderDetails = Path.Combine(Directory.GetCurrentDirectory(), "content\\Product.json");
                var json = File.ReadAllText(folderDetails);

                var rootObject = JsonConvert.DeserializeObject<ProductMaster>(json);
                return rootObject.Products;
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

            return new List<Product>();
        }
    }
}
