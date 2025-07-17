Person bob = new Person("Bob");
bob.Print(); // вызов метода Print из класса Person

Employee tom = new Employee("Tom", "Microsoft");
tom.Print(); // вызов метода Print из класса Person

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