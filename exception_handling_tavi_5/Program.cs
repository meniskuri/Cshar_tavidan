// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

try
{
    string text = File.ReadAllText("data.txt");
    Console.WriteLine(text);
}
catch (FileNotFoundException ex)
{
    Console.WriteLine($"faili ver moizebna {ex.StackTrace}");
}

// throw 
try
{
    Console.Write("Введите имя: ");
    string? name = Console.ReadLine();
    if (name == null || name.Length < 2)
    {
        throw new Exception("Длина имени меньше 2 символов");
    }
    else
    {
        Console.WriteLine($"Ваше имя: {name}");
    }
}
catch (Exception e)
{
    Console.WriteLine($"Ошибка: {e.Message}");
}

// კლასში შექმნილი throw 

try
{
    Person person = new Person { Name = "Tom", Age = 17 };
}
catch (Exception ex)
{
    Console.WriteLine($"Ошибка: {ex.Message}");
}

class Person
{
    private int age;
    public string Name { get; set; } = "";
    public int Age
    {
        get => age;
        set
        {
            if (value < 18)
                throw new Exception("Лицам до 18 регистрация запрещена");
            else
                age = value;
        }
    }
}