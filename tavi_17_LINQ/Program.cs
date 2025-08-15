using System;
using System.Collections.Generic;
using System.Linq;


/*
string[] people = { "Tom", "Bob", "Sam", "Tim", "Tomas", "Bill" };

// создаем новый список для результатов
var selectedPeople = from p in people // передаем каждый элемент из people в переменную p
                     where p.ToUpper().StartsWith("T") //фильтрация по критерию
                     orderby p  // упорядочиваем по возрастанию
                     select p; // выбираем объект в создаваемую коллекцию

foreach (string person in selectedPeople)
    Console.WriteLine(person);
*/


var people2 = new List<Person>
{
    new Person ("Tom", 23),
    new Person ("Bob", 27)
};

var personnel = from p in people2
                let name = $"Mr. {p.Name}"
                let year = DateTime.Now.Year - p.Age
                select new
                {
                    Name = name,
                    Year = year
                };

foreach (var p in personnel)
    Console.WriteLine($"{p.Name} - {p.Year}");

Console.WriteLine("////////////////");
// მეთოდები skip და take 

string[] people = { "Tom", "Sam", "Bob", "Mike", "Kate" };
// пропускаем первые два элемента
var result = people.Skip(2);    // "Bob", "Mike", "Kate"

foreach (var person in result)
    Console.WriteLine(person);

Console.WriteLine("////////////////");
// დაჯგუფება  


Person2[] people3 =
{
    new Person2("Tom", "Microsoft"), new Person2("Sam", "Google"),
    new Person2("Bob", "JetBrains"), new Person2("Mike", "Microsoft"),
    new Person2("Kate", "JetBrains"), new Person2("Alice", "Microsoft"),
};

var companies = from person in people3
                group person by person.Company;

foreach (var company in companies)
{
    Console.WriteLine(company.Key);

    foreach (var person in company)
    {
        Console.WriteLine(person.Name);
    }
    Console.WriteLine(); // для разделения между группами
}






Console.WriteLine("////////////////");
// კლასები
record class Person(string Name, int Age);

record class Person2(string Name, string Company);



