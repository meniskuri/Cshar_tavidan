// shevqmna obieqti
using System;
using System.Xml.Linq;

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


var tom = new Person("Tom", 23);
var bob = (Person)tom.Clone();
bob.Name = "Bob";
Console.WriteLine(tom.Name); // Tom



// interface shevqmeni
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


