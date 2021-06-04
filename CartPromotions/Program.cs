using PromotionEngine;
using static System.Console;

namespace CartPromotions
{
    class Program
    {
        static void Main(string[] args)
        {
            var productList = ConfigDetails.GetAvailableProducts();
           

            WriteLine("\t\t\t *** Welcome to Product Catalogue Page ***");
            WriteLine("\t\t\t -----------------------------------------\n\n");
            //WriteLine("\n\n");
            WriteLine("SKU\t\t Product\t\t Price");
            WriteLine("---------------------------------------------------");
            foreach (var item in productList) WriteLine(item.Sku + "\t\t" + item.ProductName + "\t\t" + item.Price);

            WriteLine("\n");


        }
    }
}
