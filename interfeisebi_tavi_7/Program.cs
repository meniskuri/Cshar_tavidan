using System;
using System.Xml.Linq;

// shevqmna obieqti
IMovable modzraoba = new Modzraoba();
modzraoba.Name = "giorgi";
modzraoba.Move();

// გენერიკებით
// მეთოდი ორი მნიშვნელობის შედარებისთვის
T GetMax<T>(T x, T y) where T : IComparable<T> // kitxva 
{
    if (x.CompareTo(y) > 0)
        return x;
    else
        return y;
}

int a = 5;
int b = 8;
int max = GetMax(a, b);
Console.WriteLine(max); // 8

///////////////////

var tom = new Person("Tom", 23);
var bob = (Person)tom.Clone();
bob.Name = "Bob";
Console.WriteLine(tom.Name); // Tom

// სორტიროვკა 
var tamri = new Person_sort("tamri", 56);
var gio = new Person_sort("gio", 33);
var aruz = new Person_sort("aruz", 62);

Person_sort[] people = { tamri, gio, aruz };
Array.Sort(people);

foreach (Person_sort person in people)
{
    Console.WriteLine($"{person.Name} - {person.Age}");
}





// interface shevqmeni
class Person_sort : IComparable
{
    public string Name { get; }
    public int Age { get; set; }
    public Person_sort(string name, int age)
    {
        Name = name; Age = age;
    }
    public int CompareTo(object? o)
    {
        if (o is Person_sort person_s) return Age.CompareTo(person_s.Age);
        else throw new ArgumentException("Некорректное значение параметра");
    }
}

class Person : ICloneable // kitxva maqvs 
{
    public string Name { get; set; }
    public int Age { get; set; }
    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
    public object Clone()
    {
        return new Person(Name, Age);
    }
}

interface IMovable
{
    // константа
    const int minSpeed = 0;     // минимальная скорость
    // статическая переменная
    // static int maxSpeed = 60;   // максимальная скорость
    // метод
    void Move(); // движение
  
    // свойство
    string Name { get; set; }   // название

    delegate void MoveHandler(string message);  // определение делегата для события
    // событие
    // event MoveHandler MoveEvent;    // событие движения
}

// shevqmeni klasi
class Modzraoba : IMovable
{
    public void Move()
    {
        Console.WriteLine($"imozrave {Name}");
    }
    public string Name { get; set; }
}



