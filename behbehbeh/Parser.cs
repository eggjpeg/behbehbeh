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
        String input = "input text to parse";
        ICharStream stream = CharStreams.fromString(input);
        ITokenSource lexer = new SQLiteLexer(stream);
        ITokenStream tokens = new CommonTokenStream(lexer);
        SQLiteParser parser = new SQLiteParser(tokens);
        parser.BuildParseTree = true;
        IParseTree tree = parser.StartRule;
        KeyPrinter printer = new KeyPrinter();
        ParseTreeWalker.Default.Walk(printer, tree);
    }


    }
}
