Person bob = new Person("Bob");
bob.Print(); // вызов метода Print из класса Person

Employee tom = new Employee("Tom", "Microsoft");
tom.Print(); // вызов метода Print из класса Person


Adamiani<string> adamiani1 = new Adamiani<string>("34");
Adamiani<int> adamiani2 = new UniversalPerson<int>(45);
UniversalPerson<int> adamiani3 = new UniversalPerson<int>(33);
Console.WriteLine(adamiani1.Id);
Console.WriteLine(adamiani2.Id);
Console.WriteLine(adamiani3.Id);



// კლასები
class Person
{
    public string Name { get; set; }
    public Person(string name)
    {
        Name = name;
    }
    public virtual void Print()
    {
        Console.WriteLine(Name);
    }
}
class Employee : Person
{
    public string Company { get; set; }
    public Employee(string name, string company) : base(name)
    {
        Company = company;
    }
    public override void Print()
    {
        Console.WriteLine($"{Name} работает в {Company}");
    }
}

// generic კლასები და მათი შთამომავლობა 
class Adamiani<T>
{
    public T Id { get; }
    public Adamiani(T id)
    {
        Id = id;
    }
}

class UniversalPerson<T> : Adamiani<T>
{
    public UniversalPerson(T id) : base(id) { }
}

