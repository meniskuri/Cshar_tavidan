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