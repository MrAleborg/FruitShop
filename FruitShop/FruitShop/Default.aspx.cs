using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using myNETShop;
using myNETCart;

namespace FruitShop
{
    public partial class _Default : System.Web.UI.Page
    {
        private List<string> shop_content;
        private List<string> cart_content;
        private long Article_Count;
        private ImyShop myASPshop;
        ImyCart mycart = null;

        private void updatelist()
        {
            ArticlesInShop.ClearSelection();
            shop_content = new List<string>();
            myASPshop = new myShop();
            //List<string> shp = new List<string>();
            Article_Count = myASPshop.getArticleCount();
            Label1.Text = Convert.ToString(Article_Count);
            for (long i = 0; i < Article_Count; i++)
            {
                string row;
                shop_content.Add(row = myASPshop.getElementByID(i + 1));
                //string r = row[1] + "(" + row[2] + ") " + row[3] + "kr";
                ArticlesInShop.Items.Add(row);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            updatelist();
           
        }

        protected void createcart_Click(object sender, EventArgs e)
        {
            mycart = new myCart();
        }

        protected void ArticlesInShop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mycart == null)
            {
                mycart = new myCart();
                Session["cart"] = mycart;
            }
            mycart.addItemToCart(ArticlesInShop.SelectedItem.Value);
            Cart.Items.Add(ArticlesInShop.SelectedItem.Value);
        }

        protected void Cart_SelectedIndexChanged(object sender, EventArgs e)
        {
            mycart.removeItemFromCart(ArticlesInShop.SelectedItem.Value);
            Cart.Items.Remove(ArticlesInShop.SelectedItem.Value);
        }

        protected void Buy_Click(object sender, EventArgs e)
        {
            myASPshop.buy(mycart);
            Cart.ClearSelection();
        }
    }
}
