using Dapper;
using Microsoft.VisualBasic;
using SQL_Testing;
using System;
using System.Data.SqlClient;
using System.Net.WebSockets;
using static System.Runtime.InteropServices.JavaScript.JSType;

class Program
{
    static void Main()
    {
        // Copy from properties of the database server in server explorer (View -> Right click on the server)
        string connectionString = "Data Source=DESKTOP-7SAD67L\\SQLEXPRESS;Initial Catalog=SQLTutorial;Integrated Security=True;Encrypt=False";

        // Using flexible SQL connection and Dapper.
        var databaseHelper = new DatabaseHelper(connectionString);
        var dataRepository = new DataRepository(databaseHelper);
        Account Information = dataRepository.GetData(1231);

        try
        {
            if (Information != null)
            {
                Console.WriteLine(Information.AccID);
                Console.WriteLine($"Name: {Information.name}");
                Console.WriteLine($"Checking Balance: ${Information.Checking}");
                Console.WriteLine($"Saving Balance: ${Information.Saving}");
            }
            else
            {
                Console.WriteLine("Account doesn't exist.");
            }
        }
        catch (Exception ex) 
        {
            Console.WriteLine("Error: " + ex.ToString());
        }
    }
}