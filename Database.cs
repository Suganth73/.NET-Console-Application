using System;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client.TelemetryCore.TelemetryClient;

namespace InvestmentPlatform.Database
{
    public static class Dbconnection
    {
        private static string connectionString = @"Data Source=ASPLSP1595\SQLEXPRESS;Initial Catalog=InvestmentPlatform;Integrated Security=True;TrustServerCertificate=True;";

        
        // public static SqlConnection GetConnection()
        // {
        //     Console.WriteLine("Connected");
        //     return new SqlConnection(connectionString);
        // }

        public static void RegisterUser(string username, string password)
        {
         SqlConnection sqlConnection = new SqlConnection(connectionString);

            // using (SqlConnection connection = GetConnection())
            try
            {
                sqlConnection.Open();
                
                string query = @"INSERT INTO Users (Username, Password) VALUES (@Username, @Password)";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);
                SqlDataReader reader = cmd.ExecuteReader();

               
            }
            catch (Exception execption)
            {
                Console.WriteLine("The issue is : "+execption.Message);
            }
        }

        //  public static bool ValidateUser(string username, string password)
        // {
        //     using (SqlConnection connection = GetConnection())
        //     {
        //         string query = "SELECT COUNT(1) FROM Users WHERE Username = @Username AND Password = @Password";
        //         SqlCommand cmd = new SqlCommand(query, connection);
        //         cmd.Parameters.AddWithValue("@Username", username);
        //         cmd.Parameters.AddWithValue("@Password", password);
        //         connection.Open();
        //         int userExists = Convert.ToInt32(cmd.ExecuteScalar());
        //         return userExists > 0; 
        //     }
        // }
        // public static bool AddInvestment(string name, double price, string tickerOrManager, bool isStock)
        // {
        //     using (SqlConnection connection = GetConnection())
        //     {
        //         string query = "INSERT INTO Investments (Name, Price, TickerOrManager, IsStock) VALUES (@Name, @Price, @TickerOrManager, @IsStock)";
        //         SqlCommand cmd = new SqlCommand(query, connection);
        //         cmd.Parameters.AddWithValue("@Name", name);
        //         cmd.Parameters.AddWithValue("@Price", price);
        //         cmd.Parameters.AddWithValue("@TickerOrManager", tickerOrManager);
        //         cmd.Parameters.AddWithValue("@IsStock", isStock);
        //         connection.Open();
        //         int rowsAffected = cmd.ExecuteNonQuery();
        //         return rowsAffected > 0;
        //     }
        // }


    }
}