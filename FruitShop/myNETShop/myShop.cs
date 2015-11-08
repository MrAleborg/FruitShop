using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Data.OleDb;
using System.Configuration;


namespace myNETShop
{

    public interface ImyShop
    {
        long getArticleCount();
        string getElementByID(long id);
        bool buy(myNETCart.ImyCart target);
    }


    public class myShop : ImyShop
    {
        private OleDbConnection shop;


        public myShop()
        {
            Console.WriteLine("DEBUT CONSTRUCTEUR");

            
            shop = new OleDbConnection(
            "Provider=Microsoft.Jet.OLEDB.4.0; " + 
            "Data Source= C:\\Users\\Alexandre\\Desktop\\FruitShop\\ShopDatabase.mdb");

            Console.WriteLine("FIN CONSTRUCTEUR");
        }

        public long getArticleCount()
        {
            OleDbCommand cmd = new OleDbCommand("SELECT COUNT(*) FROM ShopTable", shop);
            long count;
            try
            {
                shop.Open();
                count = (Int32)cmd.ExecuteScalar();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return -1;
            }
            shop.Close();
            return count;
        }

        public string getElementByID(long id)
        {
            OleDbCommand cmd = new OleDbCommand("select * from ShopTable where ProductID="+id+";", shop);
            OleDbDataReader row;
            try
            {
                shop.Open();
                row = cmd.ExecuteReader();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
            string item="";
            if (row != null)
                Console.WriteLine("OK");
            while (row.Read())
            item = row.GetInt32(0) + ";" +
                row.GetString(1)+ ";" +
                row.GetInt32(2) + ";" +
                row.GetDecimal(3);
            shop.Close();
            return item;
        }

        public bool buy(myNETCart.ImyCart target)
        {
            try
            {
                List<string> m_c = target.getMyCartContent();

                shop.Open();
                foreach (string item in m_c)
                {
                    decimal id = Convert.ToInt32((item.Split(';'))[0]);

                    OleDbCommand cmd = new OleDbCommand("UPDATE ShopTable SET ItemsinStock = ItemsinStock-1  WHERE ProductID = " + id + ";", shop);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            Console.WriteLine("DB MODIFIED");
            shop.Close();
            return true;
        }

    }
}
