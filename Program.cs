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
        static SqlConnection connection = new SqlConnection(connectionString);


        static bool FindContactById(int id , ref stContact contact)
        {
            bool isFound = false;
            string query = "select * from Contacts Where ContactID = @ContactID";

            SqlCommand command = new SqlCommand(query , connection);

            command.Parameters.AddWithValue("@ContactID" , id);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    contact.FirstName = (string)reader["FirstName"];
                    contact.LastName = (string)reader["LastName"];
                    contact.email = (string)reader["email"];
                    isFound = true;
                }

                connection.Close();

            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return isFound;
        }

        public struct stContact
        {
           public  string FirstName;
           public string LastName;
           public string email;
        }

        static void Main(string[] args)
        {
            stContact contact = new stContact();
            if ( FindContactById(4 ,ref contact) )
            {
                Console.WriteLine(contact.FirstName);
                Console.WriteLine(contact.LastName);
                Console.WriteLine(contact.email);
            }
            else
            {
                Console.WriteLine("Not Found");
            }
        }
    }
}
