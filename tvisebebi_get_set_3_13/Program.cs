// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Person person = new Person { Name = "gio" };

Person2 person2 = new Person2("giorgi", 33);
Console.WriteLine(person2.Name);

// Устанавливаем свойство - срабатывает блок Set
// значение "Tom" и есть передаваемое в свойство value
// person.Name = "Tom";

// Получаем значение свойства и присваиваем его переменной - срабатывает блок Get
string personName = person.Name;
Console.WriteLine(personName);  // Tom

class Person
{
    private string name = "Undefined";

    public required string Name
    {
        get
        {
            return name;    // возвращаем значение свойства
        }
        set
        {
            name = value;   // устанавливаем новое значение свойства
        }
    }
}


class Person2
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Person2(string name, int age)
    {
        Name = name;
        Age = age;
    }
}