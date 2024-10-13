using System;
using System.Data.SqlClient;

namespace ADO.NET_Exploration
{
    internal class Program
    {
        static string connectionString = "Server=.;Database=Contacts;User Id=sa;Password=abdulrahman.10.10.2022.abdulrahman";
        
        static void printAllContatctsWithFirstName(string FirstName)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "SELECT * FROM Contacts where FirstName = @FirstName";

            SqlCommand command = new SqlCommand(query , connection);

            command.Parameters.AddWithValue("@FirstName", FirstName);

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

        static void printAllContatctsWithFirstNameAndCountryId(string FirstName , int CountryId)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "SELECT * FROM Contacts where FirstName = @FirstName and CountryId = @CountryId";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@CountryID", CountryId);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
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
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void Main(string[] args)
        {
            //printAllContatctsWithFirstName("Jane");
            printAllContatctsWithFirstNameAndCountryId("Jane" , 1);
        }
    }
}
