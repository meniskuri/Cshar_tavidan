// shevqmna obieqti
IMovable modzraoba = new Modzraoba();
modzraoba.Move();

// interface shevqmeni
interface IMovable
{
    // константа
    const int minSpeed = 0;     // минимальная скорость
    // статическая переменная
    // static int maxSpeed = 60;   // максимальная скорость
    // метод
    void Move();                // движение
    // свойство
    // string Name { get; set; }   // название

    delegate void MoveHandler(string message);  // определение делегата для события
    // событие
    // event MoveHandler MoveEvent;    // событие движения
}

// shevqmeni klasi
class Modzraoba : IMovable
{
    public void Move()
    {
        Console.WriteLine("imozrave");
    }
}

