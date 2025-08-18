using System.Xml;

XmlDocument xDoc = new XmlDocument();
// kitxva ????
xDoc.Load("C:\\Users\\Gio\\Desktop\\Programireba\\Cshar_tavidan\\tavi_24_XML\\obj\\Debug\\net9.0\\people.xml");
// получим корневой элемент
XmlElement? xRoot = xDoc.DocumentElement;
if (xRoot != null)
{
    // обход всех узлов в корневом элементе
    foreach (XmlElement xnode in xRoot)
    {
        // получаем атрибут name
        XmlNode? attr = xnode.Attributes.GetNamedItem("name");
        Console.WriteLine(attr?.Value);

        // обходим все дочерние узлы элемента user
        foreach (XmlNode childnode in xnode.ChildNodes)
        {
            // если узел - company
            if (childnode.Name == "company")
            {
                Console.WriteLine($"Company: {childnode.InnerText}");
            }
            // если узел age
            if (childnode.Name == "age")
            {
                Console.WriteLine($"Age: {childnode.InnerText}");
            }
        }
        Console.WriteLine();
    }
}