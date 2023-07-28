using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr.Runtime.Tree;
using Antlr.Runtime;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
namespace behbehbeh
{
    class KeyPrinter : SQLiteParserBaseListener
    {
        // override default listener behavior
        void ExitKey(SQLiteParser.EnterKey context)
        {
            Console.WriteLine("Oh, a key!");
        }
    } 
}
