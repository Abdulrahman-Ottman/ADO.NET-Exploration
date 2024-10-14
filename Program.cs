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

        static void getFirstNameOfContact(int id)
        {
            string FirstName = "";
            string query = "select FirstName , LastName from Contacts Where ContactID = @ContactID";

            SqlCommand command = new SqlCommand(query , connection);

            command.Parameters.AddWithValue("@ContactID" , id);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null)
                {
                    FirstName = result.ToString();
                }

                connection.Close();

            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            
            Console.WriteLine(FirstName);
        }
        static void Main(string[] args)
        {
            getFirstNameOfContact(1);
        }
    }
}
