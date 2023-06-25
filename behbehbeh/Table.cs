using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace behbehbeh
{

    
    public class Table<T> : Database
    {
        public string name;
        public int columns;
        public int rows;
        public Dictionary<string,List<T>> table;
        List<T> t;
        public Table(string name)
        {
            this.name = name;
            table = new Dictionary<string, List<T>>();
            rows = 1;
        }
    }
}
