using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime.Tree;
namespace behbehbeh
{
    public class Database
    {
        public string name;
        public List<Table> tables;

        public Database(string name)
        {
            this.name = name;
        }
       
    }
}
