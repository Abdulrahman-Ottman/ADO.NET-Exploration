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
        static string connectionString = "Server=.;Database=Contacts;User Id=sa;Password=abood";
        static SqlConnection connection = new SqlConnection(connectionString);

        static void printContactInfo(SqlDataReader reader)
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
        static void executeAndPrint(SqlCommand command)
        {
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read()) {
                    printContactInfo(reader);
                }

                reader.Close();
                connection.Close();
            }
            catch (Exception ex) {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void searchContactStartWith(string startWith)
        {
            string query = "select * from Contacts where FirstName Like @start + '%'";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@start", startWith);
            executeAndPrint(command);
        }

        static void searchContactEndWith(string endWith)
        {
            string query = "select * from Contacts where FirstName Like  '%' + @end ";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@end", endWith);
            executeAndPrint(command);
        }

        static void searchContactContains(string contain)
        {
            string query = "select * from Contacts where FirstName Like  '%' + @contain + '%' ";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@contain", contain);
            executeAndPrint(command);
        }

        static void Main(string[] args)
        {
            //searchContactStartWith("jo");
            //searchContactEndWith("l");
            searchContactContains("e");
        }
    }
}
