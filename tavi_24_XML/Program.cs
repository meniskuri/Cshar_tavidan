using System.Xml;
using System.Xml.Linq;

var people = new List<Person>();

XmlDocument xDoc = new XmlDocument();
// kitxva ????
xDoc.Load("people2.xml");
// получим корневой элемент
XmlElement? xRoot = xDoc.DocumentElement;
if (xRoot != null)
{
    foreach (XmlElement xnode in xRoot)
    {
        Person person = new Person();
        XmlNode? attr = xnode.Attributes.GetNamedItem("name");
        person.Name = attr?.Value;
 
        foreach (XmlNode childnode in xnode.ChildNodes)
        {
            if (childnode.Name == "company")
                person.Company = childnode.InnerText;
 
            if (childnode.Name == "age")
                person.Age = int.Parse(childnode.InnerText);
        }
        people.Add(person);
    }
    foreach (var person in people)
        Console.WriteLine($"{person.Name} ({person.Company}) - {person.Age}");
}


// создаем новый элемент person
XmlElement personElem = xDoc.CreateElement("person");

// создаем атрибут name
XmlAttribute nameAttr = xDoc.CreateAttribute("name");

// создаем элементы company и age
XmlElement companyElem = xDoc.CreateElement("company");
XmlElement ageElem = xDoc.CreateElement("age");

// создаем текстовые значения для элементов и атрибута
XmlText nameText = xDoc.CreateTextNode("Mark");
XmlText companyText = xDoc.CreateTextNode("Facebook");
XmlText ageText = xDoc.CreateTextNode("30");

//добавляем узлы
nameAttr.AppendChild(nameText);
companyElem.AppendChild(companyText);
ageElem.AppendChild(ageText);

// добавляем атрибут name
personElem.Attributes.Append(nameAttr);
// добавляем элементы company и age
personElem.AppendChild(companyElem);
personElem.AppendChild(ageElem);
// добавляем в корневой элемент новый элемент person
xRoot?.AppendChild(personElem);
// сохраняем изменения xml-документа в файл
xDoc.Save("people2.xml");


// axali qsm dokumentis sheqmna 

XDocument xdoc2 = new XDocument();
// создаем первый элемент person
XElement tom = new XElement("person");
// создаем атрибут name
XAttribute tomNameAttr = new XAttribute("name", "Tom");
// создаем два элемента company и age 
XElement tomCompanyElem = new XElement("company", "Microsoft");
XElement tomAgeElem = new XElement("age", 37);
// добавляем атрибут и элементы в первый элемент person
tom.Add(tomNameAttr);
tom.Add(tomCompanyElem);
tom.Add(tomAgeElem);

// создаем второй элемент person
XElement bob = new XElement("person");
// создаем для него атрибут name
XAttribute bobNameAttr = new XAttribute("name", "Bob");
// и два элемента - company и age
XElement bobCompanyElem = new XElement("company", "Google");
XElement bobAgeElem = new XElement("age", 41);
bob.Add(bobNameAttr);
bob.Add(bobCompanyElem);
bob.Add(bobAgeElem);
// создаем корневой элемент
XElement people2 = new XElement("people");
// добавляем два элемента person в корневой элемент
people2.Add(tom);
people2.Add(bob);
// добавляем корневой элемент в документ
xdoc2.Add(people2);
//сохраняем документ
xdoc2.Save("people3.xml");

Console.WriteLine("Data saved");

// linq u ti 
XDocument xdoc3 = new XDocument(new XElement("people",
    new XElement("person",
        new XAttribute("name", "Tom"),
        new XElement("company", "Microsoft"),
        new XElement("age", 37)),
    new XElement("person",
        new XAttribute("name", "Bob"),
        new XElement("company", "Google"),
        new XElement("age", 41))));
xdoc3.Save("people4.xml");

Console.WriteLine("Data saved");

XDocument xdoc = XDocument.Load("people4.xml");
// получаем корневой узел
XElement? peopleaxali = xdoc.Element("people");
if (people is not null)
{
    // проходим по всем элементам person
    foreach (XElement person in peopleaxali.Elements("person"))
    {

        XAttribute? name = person.Attribute("name");
        XElement? company = person.Element("company");
        XElement? age = person.Element("age");

        Console.WriteLine($"Person: {name?.Value}");
        Console.WriteLine($"Company: {company?.Value}");
        Console.WriteLine($"Age: {age?.Value}");

        Console.WriteLine(); //  для разделения при выводе на консоль
    }
}


class Person
{
    public string? Name { get; set; }
    public int Age { get; set; }
    public string? Company { get; set; }
}