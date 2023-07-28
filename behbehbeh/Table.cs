using Microsoft.SqlServer.Server;
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
        //<TableCategoryName, ItemsInCategory>
        public Dictionary<string, List<object>> table;
        public Table(string name)
        {
            this.name = name;
            table = new Dictionary<string,List<object>>();
            rows = 1;
        }
    }
}
