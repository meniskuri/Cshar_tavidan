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

// klasebi 
class Person
{
    public string Name { get; }
    public Person(string name) => Name = name;
}

