using System.Threading.Tasks;

Task task1 = new Task(() =>
{
    Console.WriteLine($"Task{Task.CurrentId} Starts");
    Thread.Sleep(1000);
    Console.WriteLine($"Task{Task.CurrentId} Ends");
});
task1.Start(); //запускаем задачу

// получаем информацию о задаче
Console.WriteLine($"task1 Id: {task1.Id}");
Console.WriteLine($"task1 is Completed: {task1.IsCompleted}");
Console.WriteLine($"task1 Status: {task1.Status}");

task1.Wait(); // ожидаем завершения задачи

/////////// continuation task
///

Console.WriteLine("continuation task");

Task task2 = new Task(() =>
{
    Console.WriteLine($"Id задачи: {Task.CurrentId}");
});

// задача продолжения - task2 выполняется после task1
Task task3 = task2.ContinueWith(PrintTask);

task2.Start();

// ждем окончания второй задачи
task3.Wait();
Console.WriteLine("Конец метода Main");


void PrintTask(Task t)
{
    Console.WriteLine($"Id задачи: {Task.CurrentId}");
    Console.WriteLine($"Id предыдущей задачи: {t.Id}");
    Thread.Sleep(3000);
}



/////////// parralel
///

Console.WriteLine("parralel");

Parallel.Invoke(
    Print,
    () =>
    {
        Console.WriteLine($"meore Выполняется задача {Task.CurrentId}");
        Thread.Sleep(3000);
    },
    () => Square(5)
);

void Print()
{
    Console.WriteLine($" pirveli Выполняется задача {Task.CurrentId}");
    Thread.Sleep(3000);
}
// вычисляем квадрат числа
void Square(int n)
{
    Console.WriteLine($"mesame Выполняется задача {Task.CurrentId}");
    Thread.Sleep(3000);
    Console.WriteLine($"Результат {n * n}");
}



/////////// cancelTokenSource 
///

Console.WriteLine("cancelTokenSource ");

CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
CancellationToken token = cancelTokenSource.Token;

// задача вычисляет квадраты чисел
Task task = new Task(() =>
{
    for (int i = 1; i < 10; i++)
    {
        if (token.IsCancellationRequested)  // проверяем наличие сигнала отмены задачи
        {
            Console.WriteLine("Операция прервана");
            return;     //  выходим из метода и тем самым завершаем задачу
        }
        Console.WriteLine($"Квадрат числа {i} равен {i * i}");
        Thread.Sleep(200);
    }
}, token);
task.Start();

Thread.Sleep(5000);
// после задержки по времени отменяем выполнение задачи
cancelTokenSource.Cancel();
// ожидаем завершения задачи
Thread.Sleep(1000);
//  проверяем статус задачи
Console.WriteLine($"Task Status: {task.Status}");
cancelTokenSource.Dispose(); // освобождаем ресурсы