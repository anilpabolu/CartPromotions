using System;
using System.Collections.Generic;
using PromotionEngine;
using PromotionEngine.Database;
using PromotionEngine.Helper;
using PromotionEngine.Models;
using static System.Console;

namespace CartPromotions
{
    class Program
    {
        static void Main(string[] args)
        {

            IConfigDetails<Product> getConfig = new Products();
            var productList = getConfig.Get();


            var cart = new List<Product>();

            WriteLine("\t\t\t *** Welcome to Product Catalogue Page ***");
            WriteLine("\t\t\t -----------------------------------------\n\n");
            //WriteLine("\n\n");
            WriteLine("SKU\t\t Product\t\t Price");
            WriteLine("---------------------------------------------------");
            foreach (var item in productList) WriteLine(item.Sku + "\t\t" + item.ProductName + "\t\t" + item.Price);

            WriteLine("\n");

            do
            {
                WriteLine("\n");
                Write("Please enter the SKU number from the list to place an order: ");

                var sku = ReadLine().ToUpper();

                Write("please enter the required Quantity?  ");

                var qty = 1;

                if (!int.TryParse(ReadLine(), out qty))
                    WriteLine("Please enter valid quantity");


                var shoppingList = ShoppingHelper.DoShopping(productList, sku, qty);

                if (!string.IsNullOrEmpty(shoppingList.Item3))
                    WriteLine("\n **" + shoppingList.Item3 + "**\n");

                if (shoppingList.Item2)
                {
                    cart.AddRange(shoppingList.Item1);
                    WriteLine("\n *******************************");
                    WriteLine("item successfully added to cart !!");
                    WriteLine("\n *******************************");
                    //WriteLine("\n");
                }

                WriteLine("\n");
                Write("Do you wish to continue(Y) or exit for billing information (N) ");

            } while (ReadLine()?.ToUpper() == ("Y"));


            WriteLine("Thank you for shopping");

            var printBillingSUmmary = BillingSUmmary(productList, cart);

            WriteLine("SKU\t\t Quantity\t\t Price");
            WriteLine("---------------------------------------------------");

            double grandTotal = 0;
            foreach (var item in printBillingSUmmary)
            {

                grandTotal += item.DiscountedPrice;
                WriteLine(item.Sku + "\t\t" + item.Qty + "\t\t" + item.DiscountedPrice);

            }
            WriteLine("---------------------------------------------------");
            WriteLine("Grand Total--------------------------------> " + grandTotal);
        }

        public static List<BillingProduct> BillingSUmmary(List<Product> productList, List<Product> cartproducts)
        {
            try
            {
                return Promotions.ApplyOffers(productList, cartproducts);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
