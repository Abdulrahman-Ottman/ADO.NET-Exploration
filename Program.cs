﻿using System;
using System.Data;
using System.Net;
using System.Data.SqlClient;

public class Program
{
    static string connectionString = "Server=.;Database=Contacts;User Id=sa;Password=abood";
    static SqlConnection connection = new SqlConnection(connectionString);


    public struct stContact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int CountryID { get; set; }
    }

    static bool DeleteContactsById(string ids)
    {
        bool isDeleted = false;
        string query = $"DELETE FROM Contacts where ContactID in ({ids})";

        SqlCommand command = new SqlCommand(query, connection);


        //command.Parameters.AddWithValue("@FirstName", newContact.FirstName);
        //command.Parameters.AddWithValue("@LastName", newContact.LastName);
        //command.Parameters.AddWithValue("@Email", newContact.Email);
        //command.Parameters.AddWithValue("@Phone", newContact.Phone);
        //command.Parameters.AddWithValue("@Address", newContact.Address);
        //command.Parameters.AddWithValue("@CountryID", newContact.CountryID);
        //command.Parameters.AddWithValue("@id", id);

        try
        {
            connection.Open();

            int result = command.ExecuteNonQuery();

            if (result > 0 )
            {
                isDeleted = true;
            }


            connection.Close();

        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }

        return isDeleted;
    }

    public static void Main()
    {

        // Create a new contact with the required information
        //stContact Contact = new stContact
        //{
        //    FirstName = "Abdulrahman4",
        //    LastName = "Othman4",
        //    Email = "abood@example.com",
        //    Phone = "1234567890",
        //    Address = "123 Main Street",
        //    CountryID = 1
        //};

        bool result = DeleteContactsById("7,8,9");

        Console.WriteLine(result);
    }
}
