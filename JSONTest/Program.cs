using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Globalization;
using System.IO;

namespace JSONTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Product product = new Product();
            product.Name = "Apple";
            product.ExpiryDate = new DateTime(2008, 12, 28);
            product.Price = 3.99M;
            product.Sizes = new string[] { "Small", "Medium", "Large" };

            string output = JsonConvert.SerializeObject(product, Formatting.Indented);

            Product deserializedProduct = JsonConvert.DeserializeObject<Product>(output);

            using (StreamWriter sw = new StreamWriter("product.json"))
            {
                sw.WriteLine(output);
            }

        }
    }
    class Product
    {
        public string Name;
        public DateTime ExpiryDate;
        public decimal Price;
        public string[] Sizes;

    }
}
