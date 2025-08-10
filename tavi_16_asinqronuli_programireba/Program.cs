await PrintAsync();   // вызов асинхронного метода
Console.WriteLine("Некоторые действия в методе Main");

void Print()
{
    Thread.Sleep(3000);     // имитация продолжительной работы
    Console.WriteLine("Hello METANIT.COM");
}

// определение асинхронного метода
async Task PrintAsync()
{
    Console.WriteLine("Начало метода PrintAsync"); // выполняется синхронно
    await Task.Run(Print);                // выполняется асинхронно
    Console.WriteLine("Конец метода PrintAsync");
}

Console.WriteLine("///////////////");

// определяем и запускаем задачи
var task1 = PrintAsync2("Hello C#");
var task2 = PrintAsync2("Hello World");
var task3 = PrintAsync2("Hello METANIT.COM");

// ожидаем завершения всех задач
await Task.WhenAll(task1, task2, task3);

async Task PrintAsync2(string message)
{
    await Task.Delay(2000);     // имитация продолжительной операции
    Console.WriteLine(message);
}

Console.WriteLine("///////////////");

// определяем и запускаем задачи
var task11 = PrintAsync3("Hello C#");
var task22 = PrintAsync3("Hello World");
var task33 = PrintAsync3("Hello METANIT.COM");

// ожидаем завершения хотя бы одной задачи
await Task.WhenAny(task11, task22, task33);

async Task PrintAsync3(string message)
{
    await Task.Delay(new Random().Next(1000, 2000));     // имитация продолжительной операции
    Console.WriteLine(message);
}