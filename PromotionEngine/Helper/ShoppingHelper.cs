using System;
using System.Collections.Generic;
using System.Linq;
using PromotionEngine.Models;

namespace PromotionEngine.Helper
{
    public class ShoppingHelper
    {
        public static Tuple<List<Product>, bool, string> DoShopping(List<Product> productList, string sku, int qty)
        {
            if (!string.IsNullOrEmpty(sku) && (productList.Any(p => p.Sku == sku)))
            {
                var lstprd = new List<Product>();

                var prd = productList.First(o => o.Sku == sku);
                for (var i = 0; i < qty; i++)
                {
                    lstprd.Add(prd);
                }

                return new Tuple<List<Product>, bool, string>(lstprd, true, null);//productList.First(o => o.SKU == sku);

            }
            return new Tuple<List<Product>, bool, string>(null, false, "Invalid SKU");
        }
    }
}
