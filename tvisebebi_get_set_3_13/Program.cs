// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

// obieqtebi 
Person person = new Person { Name = "gio" };

Person2 person2 = new Person2("giorgi", 33);
Console.WriteLine(person2.Name);

string personName = person.Name;
Console.WriteLine(personName);  // Tom

// test nullable 
Console.WriteLine("////////// nullable //////////");
string? name = null;

PrintUpper(name!);

void PrintUpper(string text)
{
    // if (text == null) Console.WriteLine("null");
    //else Console.WriteLine(text.ToUpper());
    // Console.WriteLine(text.ToUpper());
}







///  klasebi
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