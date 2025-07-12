// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

DayTime now = DayTime.Evening;



PrintMessage(now);                   // Добрый вечер
PrintMessage(DayTime.Afternoon);    // Добрый день
PrintMessage(DayTime.Night);        // Доброй ночи
PrintMessage(DayTime.Morning);

void PrintMessage(DayTime dayTime)
{
    switch (dayTime)
    {
        case DayTime.Morning:
            Console.WriteLine("Доброе утро");
            Console.WriteLine(DayTime.Morning);
            break;
        
        case DayTime.Afternoon:
            Console.WriteLine("Добрый день");
            break;

        case DayTime.Evening:
            Console.WriteLine("Добрый вечер");
            break;

        case DayTime.Night:
            Console.WriteLine("Доброй ночи");
            break;
    }
}
Console.WriteLine(now);  // 0
Console.WriteLine((int)now);  // 0
enum DayTime
{
    Morning,
    Afternoon,
    Evening,
    Night
}

