using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace tavi_3_klasebi
{
    internal class Program
    {
        class Person3
        {
            string name;
            int age;
            public Person3(string name, int age)
            {
                this.name = name;
                this.age = age;
            }

            public void Deconstruct(out string personName, out int personAge)
            {
                personName = name;
                personAge = age;
            }
        }

        static void Main(string[] args)
        {
            // shevqmant konstruqtorit obieqti
            Person giorgi = new Person ("giorgi",33);
            // ეს რატო არ მუშაობს?
            // Person giorgi = new Person {name = "giorgi",age = 33};
            Console.WriteLine(giorgi);
            giorgi.Print();

            // პერვიჩნიე კონსტრუქტორი person2 
            // ჩემს ვერსიაში არ მუშაობს (ახალი ვერსია როგორ დავაყენო?)

            // დეკონსტრუქტორები person3 ზე
            Console.WriteLine("/////// dekonstruqtori ///////");
            Person3 person3 = new Person3("Tom", 33);
            (string name, int age) = person3;

            Console.WriteLine(name);    // Tom
            Console.WriteLine(age);     // 33
        }
    }
}
