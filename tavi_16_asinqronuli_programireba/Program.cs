﻿await PrintAsync();   // вызов асинхронного метода
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

