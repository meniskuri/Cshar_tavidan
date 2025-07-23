var v1 = new Vector2D(1, 2);
var v2 = new Vector2D(3, 4);
var result = v1 + v2; // ← ეს არ იმუშავებს, სანამ არ განსაზღვრავ ოპერატორს

Console.WriteLine(result.X);

Meter metri = new Meter(3.4);
Console.WriteLine(metri.Value);
double d = metri;



/// ინდექსატორები 
Person[] team = {
    new Person("Gio"),
    new Person("Tamri"),
    new Person("Aruz")
};

Company comp = new Company(team);

// წაკითხვა
Console.WriteLine(comp[1].Name); // → Tamri

// შეცვლა
comp[1] = new Person("Nino");
Console.WriteLine(comp[1].Name); // → Nino


//
Matrix matrix = new Matrix();
Console.WriteLine(matrix[0, 2]);
matrix[0, 0] = 111;
Console.WriteLine(matrix[0, 0]);

// მაგალითი — ჩვეულებრივი return vs ref return
Console.WriteLine("/// return vs ref return ///");
int[] numbers = { 1, 2, 3 };

ref int GetNumber(int index) => ref numbers[index]; // აბრუნებს კოპიას

ref int n = ref GetNumber(0);
Console.WriteLine(n);
n = 100; // ცვლის `n`, მაგრამ არა `numbers[0]`
Console.WriteLine(numbers[0]);
Console.WriteLine(n);

int x = 5;
ref int xRef = ref x;
xRef = 99;
Console.WriteLine(x);
Console.WriteLine(xRef);

// კორტეჟები tuples 
Console.WriteLine("/// tuples ///");
(int, string, bool) data = (25, "hello", true);
Console.WriteLine(data.Item1);




// klasi veqtorebze
class Matrix
{
    int[,] numbers = new int[,] { { 1, 2, 4 }, { 2, 3, 6 }, { 3, 4, 8 } };
    public int this[int i, int j]
    {
        get => numbers[i, j];
        set => numbers[i, j] = value;
    }
}


class Person
{
    public string Name { get; }
    public Person(string name) => Name = name;
}
class Company
{
    Person[] personal;
    public Company(Person[] people) => personal = people;
    // индексатор
    public Person this[int index]
    {
        get => personal[index];
        set => personal[index] = value;
    }
}

class Vector2D
{
    public double X { get; set; }
    public double Y { get; set; }

    public Vector2D(double x, double y)
    {
        X = x;
        Y = y;
    }
    public static Vector2D operator +(Vector2D a, Vector2D b)
    {
        return new Vector2D(a.X + b.X, a.Y + b.Y);
    }
}

public class Meter
{
    public double Value { get; }

    public Meter(double value)
    {
        Value = value;
    }

    // გარდაქმნა Meter → double
    public static implicit operator double(Meter m) => m.Value;
}