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

        static void Main(string[] args)
        {

            //ExecuteScalar function return the first column from the first row of the results
        }
    }
}
