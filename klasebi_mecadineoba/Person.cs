using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace klasebi_mecadineoba
{
    internal class Person
    {
        public string name;
        public int age;

        public Person()
        {
            name = "default konstruqtori";
            age = 99;
        }

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public void Print()
        {
            Console.WriteLine($"name: {name}  age: {age}");
        }
    }
}
