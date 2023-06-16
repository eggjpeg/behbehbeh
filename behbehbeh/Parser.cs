using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace behbehbeh
{
   public enum Commands
    {
        Create, Drop, Alter, Rename, Insert, Update, Delete, Call, Lock, Select
    }
    public class Parser
    {
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
                            t = new Table(ar[2]);
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
