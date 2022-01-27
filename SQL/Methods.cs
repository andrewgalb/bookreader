using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SQL.Method
{
    class Methods
    {
        public static void SELECT(string connectionString, string query)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand commandTwo = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = commandTwo.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine("{0} {1} {2}", reader.GetInt32(0), reader.GetString(1), reader.GetDecimal(2));
                            }
                        }
                        Console.WriteLine("\n");
                    }
                    catch (SqlException e)
                    {
                        Console.WriteLine("Error: " + e.ToString());
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }
        public static void INSDELUPD(string connectionString, string query, string action)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand commandOne = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    commandOne.ExecuteNonQuery();
                    Console.WriteLine("Records " + action + " Successfully \n");
                }
                catch (SqlException e)
                {
                    Console.WriteLine("Error Generated. Details: " + e.ToString());
                }
                finally
                {
                    connection.Close();
                }

            }
        }

    }
}
