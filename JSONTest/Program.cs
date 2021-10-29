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


            Person person1 = new Person();
            Person person2 = new Person();

            person1.Name = "Alex";
            person1.Age = 30;
            City city1 = new City();
            city1.Name = "Washington DC";
            city1.population = 1000000;
            person1.City = city1;
            person2.Name = "Johan";
            person2.Age = 45;
            City city2 = new City();
            city2.Name = "New York";
            city2.population = 2000000;
            person2.City = city2;

            string output1 = JsonConvert.SerializeObject(person1, Formatting.Indented);

            string output2 = JsonConvert.SerializeObject(person2, Formatting.Indented);


            using (StreamWriter sw = new StreamWriter("person.json"))
            {
                sw.WriteLine(output1);
                sw.WriteLine(output2);
            }

            Person person1back = JsonConvert.DeserializeObject<Person>(output1);

            Console.ReadKey();
        }
    }
    class Product
    {
        public string Name;
        public DateTime ExpiryDate;
        public decimal Price;
        public string[] Sizes;

    }
    class Person
    {
        public string Name;
        public int Age;
        public City City;
    }
    class City
    {
        public string Name;
        public double population;
    }
}
