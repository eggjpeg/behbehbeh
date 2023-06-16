using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace behbehbeh
{
    public class Table
    {
        public string name;
        public int columns;
        public int rows;
        public Dictionary<object,object> table;
        public Table(string name)
        {
            this.name = name;
            table = new Dictionary<object, object>();
            rows = 1;
        }
    }
}
