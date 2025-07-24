using System.Collections.ObjectModel;


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
/// Коллекция Stack<T>
Console.WriteLine("/////// Queue ////////");
var dzmebi = new List<string> { "vaso", "leaniko", "teo", "azo" };
Stack<string> people_stack = new Stack<string>(dzmebi);


people_stack.Push("kapana anu jadoqari");

foreach (string person in people_stack)
{
    Console.WriteLine(person);
}


//////////////////////////
/// Коллекция Dictionary<K, V>
Console.WriteLine("/////// Коллекция Dictionary<K, V> ////////");
var mike = new KeyValuePair<int, string>(56, "Mike");
var employees_dic = new List<KeyValuePair<int, string>>() { mike };


var people_dict = new Dictionary<int, string>(employees_dic)
{
    { 5, "Tom"},
    { 3, "Sam"},
    { 11, "Bob"}
};

string sam = people[3];  // Sam
Console.WriteLine(sam);  // Sam

foreach (var person in people_dict)
{
    Console.WriteLine($"key: {person.Key}  value: {person.Value}");
}


//////////////////////////
/// Класс ObservableCollection
Console.WriteLine("///// Класс ObservableCollection //////");
var people_observ = new ObservableCollection<string>
{
    "gvanca", "keto", "marika"
};

people_observ[2] = "nini indieli";
Console.WriteLine(people_observ[2]);   // Tom


/////////////////////////
// klasebi 
class Person
{
    public string Name { get; }
    public Person(string name) => Name = name;
}

