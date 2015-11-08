using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace myNETCart
{

    public interface ImyCart
    {
        bool removeItemFromCart(string item);
        bool addItemToCart(string item);
        List<string> getMyCartContent();
    }

   /* public interface ImyCart_SHOP : ImyCart_ASP
    {
        bool buy();
    }*/

    public class myCart : ImyCart
    {
        private List<string> stuffsInMyCart=null;

        public myCart()
        {
            try
            {
                stuffsInMyCart = new List<string>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public bool addItemToCart(string item)
        {
            try
            {
                stuffsInMyCart.Add(item);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            return true;
        }

        public bool removeItemFromCart(string item)
        {
            try
            {
                stuffsInMyCart.Remove(item);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            return true;
        }

       /* public bool buy()
        {
            try
            {
                Console.WriteLine("try to empty the cart");
                stuffsInMyCart = null;
                stuffsInMyCart = new List<string>();
                Console.WriteLine("cart empty");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            return true;
        }*/

        public List<string> getMyCartContent()
        {
            return stuffsInMyCart;
        }
    }
}
