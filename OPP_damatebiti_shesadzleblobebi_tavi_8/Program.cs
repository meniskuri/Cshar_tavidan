var v1 = new Vector2D(1, 2);
var v2 = new Vector2D(3, 4);
var result = v1 + v2; // ← ეს არ იმუშავებს, სანამ არ განსაზღვრავ ოპერატორს

Console.WriteLine(result.X);

// klasi veqtorebze
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