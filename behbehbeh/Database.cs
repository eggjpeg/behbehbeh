using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace behbehbeh
{
    internal class Database
    {
        public string name;

        public Database(string name)
        {
            this.name = name;
        }
        public void CreateTable(string name, string info)
        {
            Table t = new Table(name);
            info.Trim('(');
            info.Trim(')');
            info.Trim(';');
            string[] attributes = info.Split(',');
            foreach (string attribute in attributes)
            {
                string[] typeName = attribute.Split();
                if (typeName[0].Equals("int"))
                {
                    t.table.Add()
                }
                else if (typeName[0].Equals("string"))
                {

                }
                else if (typeName[0].Equals("char"))
                {

                }
            }
        }
    }
}
