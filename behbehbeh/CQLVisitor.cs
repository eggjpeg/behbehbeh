﻿using Antlr4.Runtime;
using System;
using System.Data.SqlClient; // Assuming you're using SQL Server and ADO.NET
using behbehbeh; // Change this to the actual namespace of your generated ANTLR classes
using System.Collections.Generic;

namespace CqlVisitorExample
{
    public class CqlVisitor : SQLiteParser<object>
    {
        public override object VisitSelectStatement(SQLiteParser.StartRule context)
        {
            string columns = context.columns.Text;
            string tableName = context.tableName.Text;
            string condition = context.condition?.Text;

            string connectionString = "xxxxxx"

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sqlQuery = $"SELECT {columns} FROM {tableName}";

                if (!string.IsNullOrEmpty(condition))
                {
                    sqlQuery += $" WHERE {condition}";
                }

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"Column 1: {reader[0]}, Column 2: {reader[1]}");
                        }
                    }
                }
            }

            return base.VisitSelectStatement(context);
        }


        //  entry point to visit the parse tree
        public void VisitParseTree(SQLiteParser.ParseContext context)
        {
            Visit(context);
        }
        private List<Row> ExecuteSQLCommand(string sqlCommand)
        {
            string connectionString = "your_connection_string";
            List<Row> resultSet = new List<Row>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sqlCommand, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Row row = new Row();
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                string columnName = reader.GetName(i);
                                object columnValue = reader.GetValue(i);
                                row.Columns[columnName] = columnValue;
                            }
                            resultSet.Add(row);
                        }
                    }
                }
            }

            return resultSet;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string sqlQuery = "SELECT FirstName, LastName FROM Customers WHERE Age > 21";
            AntlrInputStream input = new AntlrInputStream(sqlQuery);
            CqlGrammarLexer lexer = new CqlGrammarLexer(input);
            CommonTokenStream tokens = new CommonTokenStream(lexer);
            CqlGrammarParser parser = new CqlGrammarParser(tokens);

            CqlGrammarParser.ParseContext parseTree = parser.parse();

            CqlVisitor visitor = new CqlVisitor();
            visitor.VisitParseTree(parseTree);

        }
    }
}
