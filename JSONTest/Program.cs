using Newtonsoft.Json;
using System;
using System.IO;

namespace JSONTest
{
    class Program
    {
        static void Main(string[] args)
        {

            Product[] products = new Product[2];

            Product product = new Product();
            product.Name = "Apple";
            product.ExpiryDate = new DateTime(2008, 12, 23);
product.Price=3.99;
            product.Sizes = new string[] { "Small", "Medium", "Large" };


            Product product2 = new Product();
            product2.Name = "Orange";
            product2.ExpiryDate = new DateTime(2010, 12, 23);
            product2.Price = 8.99;
            product2.Sizes = new string[] { "Small", "Medium", "Large" };

            products[0] = product;
            products[1] = product2;

            string result = JsonConvert.SerializeObject(products,Formatting.Indented);

          //  Console.WriteLine(result);

           using( StreamWriter sw = new StreamWriter("JsonExample.txt"))
            {
                sw.Write(result);
            }
           /*
            string readResult;

            using (StreamReader sr = new StreamReader("JsonExample.txt"))
            {
                readResult = sr.ReadToEnd();
            }

            Product newProduct = JsonConvert.DeserializeObject<Product>(readResult);
            Console.WriteLine(newProduct.Name);
         */

        }
    }

    class Product
    {
        public string Name;
        public double Price;
        public DateTime ExpiryDate;
        public String[] Sizes;
    }
}
