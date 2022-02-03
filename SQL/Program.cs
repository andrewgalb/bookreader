using System;
using System.Data.SqlClient;
using SQL.Method;

namespace SQL
{
    class Program
    {
        static void Main(string[] args)
        {
            string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


            string insQuery = "INSERT INTO Products (ProductName, UnitPrice) VALUES('TESTTHING', '9999999')";

            string selectQuery = "SELECT ProductID, ProductName, UnitPrice FROM Products ORDER BY UnitPrice DESC";

            string delQuery = "DELETE FROM Products WHERE ProductName = 'TESTTHING'";

            string action;

            Console.WriteLine("Do you want to read the data (Write 1), insert new data (Write 2), Delete data (Write 3), Update data (Write 4)");

            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    Methods.SELECT(connString, selectQuery);
                    break;
                case "2":
                    action = "Inserted";
                    Methods.INSDELUPD(connString, insQuery, action);
                    break;
                case "3":
                    action = "Deleted";
                    Methods.INSDELUPD(connString, delQuery, action);
                    break;
                case "4":
                    Console.WriteLine("What product name do you want?");
                    string whatUpdateName = Console.ReadLine();
                    Console.WriteLine("What price do you want?");
                    string whatUpdateNum = Console.ReadLine();
                    Console.WriteLine("What productID do you want to update?");
                    string whatUpdateID = Console.ReadLine();

                    string whatUpdate = "UPDATE Products SET ProductName = " + whatUpdateName + ", UnitPrice = " + whatUpdateNum + "WHERE ProductID = " + whatUpdateID;
                    action = "Updated";
                    Methods.INSDELUPD(connString, whatUpdate, action);
                    break;
            }





        }
    }
}
    