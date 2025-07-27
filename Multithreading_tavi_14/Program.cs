/////
using System.Threading;

// получаем текущий поток
Thread currentThread = Thread.CurrentThread;

//получаем имя потока
Console.WriteLine($"Имя потока: {currentThread.Name}");
currentThread.Name = "Метод Main";
Console.WriteLine($"Имя потока: {currentThread.Name}");

Console.WriteLine($"Запущен ли поток: {currentThread.IsAlive}");
Console.WriteLine($"Id потока: {currentThread.ManagedThreadId}");
Console.WriteLine($"Приоритет потока: {currentThread.Priority}");
Console.WriteLine($"Статус потока: {currentThread.ThreadState}");




Thread thread = new Thread(PrintMessage);
thread.Start();  // ← მეორე ნაკადი იწყებს

for (int i = 0; i < 5; i++)
{
    Console.WriteLine("Main thread");
    Thread.Sleep(500);
}


static void PrintMessage()
{
    for (int i = 0; i < 5; i++)
    {
        Console.WriteLine("Secondary thread");
        Thread.Sleep(500);
    }
}


/// 
Console.WriteLine("/////////");
// создаем новый поток
Thread myThread1 = new Thread(Print);
Thread myThread2 = new Thread(new ThreadStart(Print));
Thread myThread3 = new Thread(() => Console.WriteLine("Hello Threads"));

myThread1.Start();  // запускаем поток myThread1
myThread2.Start();  // запускаем поток myThread2
myThread3.Start();  // запускаем поток myThread3

void Print() => Console.WriteLine("Hello Threads");


Console.WriteLine("/////////");

Person tom = new Person("Tom", 37);
// создаем новый поток
Thread myThread = new Thread(Print2);
myThread.Start(tom);

void Print2(object? obj)
{
    // здесь мы ожидаем получить объект Person
    if (obj is Person person)
    {
        Console.WriteLine($"Name = {person.Name}");
        Console.WriteLine($"Age = {person.Age}");
    }
}

/// sinqronizacia

int x = 0;
object locker = new();  // объект-заглушка
// запускаем пять потоков
for (int i = 1; i < 6; i++)
{
    Thread myThread4 = new(Print3);
    myThread4.Name = $"Поток {i}";
    myThread4.Start();
}


void Print3()
{
    lock (locker)
    {
        x = 1;
        for (int i = 1; i < 6; i++)
        {
            Console.WriteLine($"{Thread.CurrentThread.Name}: {x}");
            x++;
            Thread.Sleep(100);
        }
    }
}


record class Person(string Name, int Age);