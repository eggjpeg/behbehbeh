using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using System;
using behbehbeh; // Replace with the namespace of your ANTLR-generated parser

namespace ASTPrinter
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "SELECT FirstName, LastName FROM Customers WHERE Age > 18";

            // Create an input stream from the SQL query
            AntlrInputStream inputStream = new AntlrInputStream(input);

            // Create a lexer that feeds off of the input stream
            YourGeneratedLexer lexer = new YourGeneratedLexer(inputStream);

            // Create a buffer of tokens pulled from the lexer
            CommonTokenStream tokens = new CommonTokenStream(lexer);

            // Create a parser that feeds off the tokens buffer
            YourGeneratedParser parser = new YourGeneratedParser(tokens);

            // Start parsing from the root rule (e.g., query)
            IParseTree tree = parser.query();

            // Print the abstract syntax tree (AST)
            PrintAST(tree, parser);
        }
        static void PrintAST(IParseTree tree, SQLiteParser parser)
        {
            PrintASTNode(tree, parser, 0);
        }

        static void PrintASTNode(IParseTree node, SQLiteParser parser, int indentation)
        {
            if (node == null) return;

            for (int i = 0; i < indentation; i++)
            {
                Console.Write("  "); // Adjust the indentation size as needed
            }

            Console.WriteLine(node.ToString(parser));

            for (int i = 0; i < node.ChildCount; i++)
            {
                PrintASTNode(node.GetChild(i), parser, indentation + 1);
            }
        }
    }
}
