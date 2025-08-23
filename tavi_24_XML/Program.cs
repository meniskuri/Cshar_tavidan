using System.Xml;

var people = new List<Person>();

XmlDocument xDoc = new XmlDocument();
// kitxva ????
xDoc.Load("C:\\Users\\Gio\\Desktop\\Programireba\\Cshar_tavidan\\tavi_24_XML\\obj\\Debug\\net9.0\\people.xml");
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


class Person
{
    public string? Name { get; set; }
    public int Age { get; set; }
    public string? Company { get; set; }
}