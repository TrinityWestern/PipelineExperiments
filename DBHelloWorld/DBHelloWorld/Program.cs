using System;
using System.Data.SqlClient;
using System.Configuration;

class Program
{
    static void Main(string[] args)
    {
        // Retrieve the connection string from app.config
        string connectionString = ConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ConnectionString;

        // SQL query to select "Hello World"
        string query = "SELECT 'Hello World from SQL Server!' [Message]";

        try
        {
            // Create a connection to the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Open the connection
                connection.Open();

                // Create a command to execute the query
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Execute the query and read the result
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Print the result to the console
                            Console.WriteLine(reader["Message"].ToString());
                        }
                        else
                        {
                            Console.WriteLine("No data found.");
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            // Handle any errors
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
