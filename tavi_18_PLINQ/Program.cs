int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, };
var squares = from n in numbers.AsParallel()
              select Square(n);

foreach (var n in squares)
    Console.WriteLine(n);

int Square(int n) => n * n;