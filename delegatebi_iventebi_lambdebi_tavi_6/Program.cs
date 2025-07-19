Message message1 = Welcome.Print;
message1 += new Hello().Display;
//Message message2 = new Hello().Display;

message1(); // Welcome


delegate void Message();

class Welcome
{
     public static void Print() => Console.WriteLine("Welcome");
}
class Hello
{
    public void Display() => Console.WriteLine("Привет");
}