/////////////////////////
// lists  (sheicavs uamrav metodebs - chamateba  gamokleba povna da ase shemdeg)

List<string> people = new List<string>() { "aruza babua", "tamri bibia"};
List<string> wamebulebi = ["zura jafaridze"];


people.Add("gio");
people.Add("txovs gmerts gamoasworebinos codvebi");

foreach (string person in people)
{
    Console.WriteLine(person);
    Console.WriteLine(person[2]);
    Console.WriteLine($"mowameebi : {wamebulebi[0]}");
}

// obieqtebis sia shegvizlia gavaketot list it 

List<Person> peopleGeorgia = new List<Person>()
{
    new Person("vato"),
    new Person("anano"),
    new Person("dato")
};

foreach (Person person in peopleGeorgia)
{
    Console.WriteLine(person.Name);
}


/////////////////////////
// Двухсвязный список LinkedList<T>
Console.WriteLine("LinkedList<T>");
var employees = new List<string> { "Tom", "Sam", "Bob" };

LinkedList<string> xalxi = new LinkedList<string>(employees);
LinkedListNode<string>? current = xalxi.First;


foreach (string person in xalxi)
{
    Console.WriteLine(current.Value);
    Console.WriteLine(person);
}

/////////////////////////
//Queue (Очередь) — ეს არის მონაცემთა სტრუქტურა, რომელიც მუშაობს პრინციპით:
Console.WriteLine("/////// Queue ////////");
Queue<string> people_rigshi = new Queue<string>();

people_rigshi.Enqueue("Tom");
people_rigshi.Enqueue("Bob");
people_rigshi.Enqueue("Sam");

string first = people_rigshi.Dequeue();  // წაიკითხავს Tom-ს და ამოიღებს რიგიდან
// Console.WriteLine(first);         // → Tom


foreach (string adamiani in people_rigshi)
{
    Console.WriteLine(adamiani);
}

/////////////////////////
// klasebi 
class Person
{
    public string Name { get; }
    public Person(string name) => Name = name;
}

