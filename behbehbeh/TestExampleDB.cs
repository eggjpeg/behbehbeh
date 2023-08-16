using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SimpleSqlDatabaseExample
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;Integrated Security=True"))
            {
                connection.Open();

                // Create a sample database and table
                using (var command = new SqlCommand("CREATE DATABASE SampleDB; USE SampleDB;", connection))
                {
                    command.ExecuteNonQuery();
                }

                using (var command = new SqlCommand(
                    "CREATE TABLE Employees (Id INT PRIMARY KEY, FirstName VARCHAR(50), LastName VARCHAR(50), Salary DECIMAL(18, 2));",
                    connection))
                {
                    command.ExecuteNonQuery();
                }

                // Insert sample data
                using (var command = new SqlCommand(
                    "INSERT INTO Employees (Id, FirstName, LastName, Salary) VALUES " +
                    "(1, 'John', 'Doe', 50000.00), " +
                    "(2, 'Jane', 'Smith', 60000.00), " +
                    "(3, 'Michael', 'Johnson', 75000.00);",
                    connection))
                {
                    command.ExecuteNonQuery();
                }

                // Perform a SELECT query
                using (var command = new SqlCommand("SELECT * FROM Employees;", connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"Id: {reader["Id"]}, FirstName: {reader["FirstName"]}, LastName: {reader["LastName"]}, Salary: {reader["Salary"]}");
                    }
                }

                connection.Close();
            }
        }
    }
}
