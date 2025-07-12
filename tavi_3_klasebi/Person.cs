using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tavi_3_klasebi
{
    public class Person
    {
        //
        public string name;
        public int age;
        public Person(string name, int age)
        {
            Console.WriteLine("Создание объекта Person");
            this.name = name;
            this.age = age;
        }
        public void Print()
        {
            Console.WriteLine($"Имя: {name}  Возраст: {age}");
        }
    }
}
