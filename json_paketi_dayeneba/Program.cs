using Newtonsoft.Json;
 
Person tom = new Person("Tom", 38);
// сериализуем объект tom в код json
string json = JsonConvert.SerializeObject(tom);
Console.WriteLine(json);
 
 
class Person
{
    public string Name {get;set;}
    public int Age {get;set;}
    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
}