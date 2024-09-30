using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ADO.NET_Exploration
{
    internal class Program
    {
        static string connectionString = "Server=.;Database=Contacts;User Id=sa;Password=abdulrahman.10.10.2022.abdulrahman";
        
        static void printAllContatcts()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM Contacts";
            SqlCommand command = new SqlCommand(query , connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read()) {
                    int contactID = (int)reader["ContactID"];
                    string firstName = (string)reader["FirstName"];
                    string lastName = (string)reader["LastName"];
                    string email = (string)reader["Email"];
                    string phone = (string)reader["Phone"];
                    string address = (string)reader["Address"];
                    int countryID = (int)reader["CountryID"];

                    Console.WriteLine($"Contact ID: {contactID}");
                    Console.WriteLine($"Name: {firstName} {lastName}");
                    Console.WriteLine($"Email: {email}");
                    Console.WriteLine($"Phone: {phone}");
                    Console.WriteLine($"Address: {address}");
                    Console.WriteLine($"Country ID: {countryID}");
                    Console.WriteLine();
                }

                reader.Close();
                connection.Close();
            }
            catch (Exception ex) {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        static void Main(string[] args)
        {
            printAllContatcts();
        }
    }
}
