using System;
using System.Collections.Generic;

namespace PromotionEngine.Models
{
    public class Product
    {
        public string Sku { get; set; }
        public string ProductName { get; set; }
        public float Price { get; set; }
    }

    public class ProductMaster
    {
        public List<Product> Products { get; set; }
    }

    public class BillingProduct
    {
        public string Sku { get; set; }
        public double DiscountedPrice { get; set; }
        public float Qty { get; set; }
    }
}
