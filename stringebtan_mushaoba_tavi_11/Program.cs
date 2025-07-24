///////////////////////////////////////
/// Строки и класс String

string s1 = "hello";
string s2 = new String('a', 6); // результатом будет строка "aaaaaa"
string s3 = new String(new char[] { 'w', 'o', 'r', 'l', 'd' });
string s4 = new String(new char[] { 'w', 'o', 'r', 'l', 'd' }, 1, 3); // orl
string [] s5 = { "vajiko", "antadzeebi", "vaso" };

Console.WriteLine(s1);  // hello
Console.WriteLine(s2);  // aaaaaaa
Console.WriteLine(s3);  // world
Console.WriteLine(s4);  // orl
Console.WriteLine(s5[1]);

Print();
PrintValue("hello");

void Print()
{
    string text = """
              <element attr="content">
                <body>
                </body>
              </element>
              """;
    Console.WriteLine(text);
}

void PrintValue(string val)
{
    string text = $"""
              <element attr="content">
                <body>
                {val}
                </body>
              </element>
              """;
    Console.WriteLine(text);
}