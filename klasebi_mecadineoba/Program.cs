// klasebis gamocxadeba
using klasebi_mecadineoba;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, jadoqar anu kapan!");

// obieqtebi

Person gio = new ();
gio.name = "aruza";
gio.Print();

Person2 tom_ridli = new ();
tom_ridli.name = "me var tom ridli";
tom_ridli.Print();

Person3 hari = new("giorgi",10);
hari.Print();

// struct - structurebi ravi vnaxot aba
Console.WriteLine("//////////////");
Adamiani tom = new ();
tom.Print();    // Имя:Tom  Возраст: 1

Console.WriteLine("//////////////");
// Adamiani2 tamri = new("tamri",57);
Adamiani2 tamri = new Adamiani2 { name = "tamri", age =57};
tamri.Print();

struct Adamiani
{
    // инициализация полей значениями по умолчанию - доступна с C#10
    public string name;
    public int age;
    public Adamiani() { }
    public void Print() => Console.WriteLine($"Имя: {name}  Возраст: {age}");
}

struct Adamiani2
{
    // struqtura konstruqtorit
    public string name;
    public int age;

    public Adamiani2(string name , int age)
    {
        this.name = name;
        this.age = age;
    }
    public void Print() => Console.WriteLine($"Имя: {name}  Возраст: {age}");
}

