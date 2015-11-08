using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using myNETShop;
using myNETCart;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> products = new List<string>();
            List<string> inMycart = new List<string>();
            long count = 0;
            Console.Read();
            ImyShop myshop = new myShop();
            ImyCart mycart = new myCart();
            count = myshop.getArticleCount();
            Console.WriteLine(count);

            Console.WriteLine("SHOP CONTENT : ");
            for (long i = 0; i < count; i++)
            {
                products.Add(myshop.getElementByID(i+1));
                Console.WriteLine(products.Last());
            }

            Console.WriteLine("CART CONTENT : ");
            mycart.addItemToCart(products.ElementAt(2));
            mycart.addItemToCart(products.ElementAt(1));
            mycart.addItemToCart(products.ElementAt(4));
            inMycart = mycart.getMyCartContent();
            foreach (string article in inMycart)
                Console.WriteLine(article);

            Console.WriteLine("CART CONTENT : ");
            mycart.removeItemFromCart(products.ElementAt(1));
            inMycart = mycart.getMyCartContent();
            foreach (string article in inMycart)
                Console.WriteLine(article);


            Console.WriteLine("BUY : ");

            if (myshop.buy(mycart))
            {

                Console.WriteLine("RESET CART : ");
                inMycart = null;
                inMycart = new List<string>();
                mycart = null;
                mycart = new myCart();

                products = null;
                products = new List<string>();

                Console.WriteLine("SHOP CONTENT : ");
                for (long i = 0; i < count; i++)
                {
                    products.Add(myshop.getElementByID(i + 1));
                    Console.WriteLine(products.Last());
                }
            }

            Console.Read();
            Console.Read();
        }
    }
}
