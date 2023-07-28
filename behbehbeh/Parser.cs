using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
namespace behbehbeh
{
  
    public class Parser
    {

     
    public void MyParseMethod()
    {
        String input = "your text to parse here";
        ICharStream stream = CharStreams.fromString(input);
        ITokenSource lexer = new SQLiteLexer(stream);
        ITokenStream tokens = new CommonTokenStream(lexer);
        MyGrammarParser parser = new SQLiteParser(tokens);
        parser.BuildParseTree = true;
        IParseTree tree = parser.StartRule();
        KeyPrinter printer = new KeyPrinter();
        ParseTreeWalker.Default.Walk(printer, tree);
    }
    public void Parse(string line)
    {
            Database d;
            Table t;
            if (line != null)
            {
                string[] ar  = line.Split(null, 3);
                switch (ar[0])
                {
                    case "create":

                        if (ar[1].Equals("db"))
                            d = new Database(ar[2]); 
                        else if (ar[1].Equals("table"))
                        {

                        }
                        break;
                    case "drop":
                        // code block
                        break;
                    case "alter":
                        // code block
                        break;
                    case "rename":
                        // code block
                        break;
                    case "insert":
                        // code block
                        break;
                    case "update":
                        // code block
                        break;
                    case "delete":
                        // code block
                        break;
                    case "call":
                        // code block
                        break;
                    case "lock":
                        // code block
                        break;
                    case "select":
                        // code block
                        break;
                }
            }
        }
        //create table tablename(datatype attribute1, ... , datatype attributen );

    }
}
