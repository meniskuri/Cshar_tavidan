// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Person person = new Person { Name = "gio" };

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
            return name + " yleo ";    // возвращаем значение свойства
        }
        set
        {
            name = value;   // устанавливаем новое значение свойства
        }
    }
}