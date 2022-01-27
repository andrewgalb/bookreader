using System;
using System.Data.SqlClient;
using SQL;

namespace SQL
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection conn;

            string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            conn = new SqlConnection(connString);


            conn.Open();

            Console.WriteLine("Conn open");

            conn.Close();

        }
    }
}
    