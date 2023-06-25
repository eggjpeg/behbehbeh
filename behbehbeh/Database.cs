﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace behbehbeh
{
    public class Database
    {
        public string name;
        public List<Table<T>> tables;

        public Database(string name)
        {
            this.name = name;
        }
        public void PrintTable(Table t)
        {
            foreach (var item in t.table.Keys)
                Console.WriteLine(item + ": " + t.table[item]);
        }
        public void CreateTable(string name, string info)
        {
            Table t = new Table(name);
            List<int> lst = new List<int>();
            info.Trim('(');
            info.Trim(')');
            info.Trim(';');
            string[] attributes = info.Split(',');
            foreach (string attribute in attributes)
            {
                string[] typeNamePair = attribute.Split();
                if (typeNamePair[0].Equals("int"))
                {
                    t.table.Add(typeNamePair[1], new List<int>());
                }
                if (typeNamePair[0].Equals("char"))
                {
                    t.table.Add(typeNamePair[1], new List<char>);
                }
                else
                {
                    t.table.Add(typeNamePair[1], new List<string>);
                }
            }
            Console.WriteLine();
        }
    }
}
