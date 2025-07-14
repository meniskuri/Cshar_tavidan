using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace klasebi_mecadineoba
{
    internal class Person3
    {
        public string name;
        public int age;
        /*
        public Person3() : this("Неизвестно")    // первый конструктор
        { }
        public Person3(string name) : this(name, 18) // второй конструктор
        { }
        */
        public Person3(string name , int age)     // третий конструктор
        {
            this.name = name;
            this.age = age;
        }
        public void Print() => Console.WriteLine($"Имя: {name}  Возраст: {age}");
    }
}
