﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tavi_3_klasebi
{
    internal class Person
    {
        //
        public string name = "Undefined";   // имя
        public int age;                     // возраст

        public void Print()
        {
            Console.WriteLine($"Имя: {name}  Возраст: {age}");
        }
    }
}
