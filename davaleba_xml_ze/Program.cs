using System;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

List<Location> locations = new();
List<Container> containers = new();
List<Courier> couriers = new();
List<Order> orders = new();

XmlDocument xDoc = new XmlDocument();
xDoc.Load("XMLForKapanasTask.xml");

XmlElement? xRoot = xDoc.DocumentElement;

if (xRoot != null)
{ 
    // ყველა შვილი ელემენტს გადავუყვებით
    foreach (XmlNode child in xRoot.ChildNodes)
    {
        Console.WriteLine($"Element: {child.Name}");

        // გადავუყვეთ მისი შვილებსაც
        foreach (XmlNode subChild in child.ChildNodes)
        {
            Console.WriteLine($"   SubElement: {subChild.Name}");

            if (subChild.Name == "location")
            {
                Location location = new Location();

                // ვიღებთ ატრიბუტებს
                if (subChild.Attributes?["id"] != null)
                    location.Id = int.Parse(subChild.Attributes["id"]?.Value);

                if (subChild.Attributes?["name"] != null)
                    location.Name = subChild.Attributes["name"].Value;

                if (subChild.Attributes?["adress"] != null)
                    location.Adress = subChild.Attributes["adress"]?.Value;

                locations.Add(location);
            }

            if (subChild.Name == "container")
            {
                Container container = new Container();

                // ვიღებთ ატრიბუტებს
                if (subChild.Attributes?["id"] != null)
                    container.Id = int.Parse(subChild.Attributes["id"].Value);

                if (subChild.Attributes?["name"] != null)
                    container.Name = subChild.Attributes["name"].Value;

                if (subChild.Attributes?["barcode"] != null)
                    container.Barcode = subChild.Attributes["barcode"].Value;

                containers.Add(container);
            }

            if (subChild.Name == "courier")
            {
                Courier courier = new Courier();

                // ვიღებთ ატრიბუტებს
                if (subChild.Attributes?["id"] != null)
                    courier.Id = int.Parse(subChild.Attributes["id"].Value);

                if (subChild.Attributes?["name"] != null)
                    courier.Name = subChild.Attributes["name"].Value;

                if (subChild.Attributes?["surname"] != null)
                    courier.Surname = subChild.Attributes["surname"]?.Value;

                if (subChild.Attributes?["phonenumber"] != null)
                    courier.PhoneNumber = subChild.Attributes["phonenumber"]?.Value ?? "";
                

                couriers.Add(courier);
            }

            if (subChild.Name == "order")
            {
                Order order = new Order();

                // ვიღებთ ატრიბუტებს
                if (subChild.Attributes?["id"] != null)
                    order.Id = int.Parse(subChild.Attributes["id"].Value);

                if (subChild.Attributes?["start_location_id"] != null)
                    order.StartLocationId = int.Parse(subChild.Attributes["start_location_id"].Value);

                if (subChild.Attributes?["end_location_id"] != null)
                    order.EndLocationId = int.Parse(subChild.Attributes["end_location_id"].Value);

                if (subChild.Attributes?["container_id"] != null)
                    order.ContainerId = int.Parse(subChild.Attributes["container_id"].Value);

                if (subChild.Attributes?["courier_id"] != null)
                    order.CourierId = int.Parse(subChild.Attributes["courier_id"].Value);

                if (subChild.Attributes?["start_date_time"] != null)
                    order.StartDateTime = DateTime.ParseExact(subChild.Attributes["start_date_time"]!.Value,
                                                                "dd/MM/yyyy HH:mm", null);

                if (subChild.Attributes?["end_date_time"] != null)
                    order.EndDateTime = DateTime.ParseExact(subChild.Attributes["end_date_time"]!.Value,
                                                                "dd/MM/yyyy HH:mm", null);
                orders.Add(order);
            }


            // attributes
            if (subChild.Attributes != null)
            {
                foreach (XmlAttribute attr in subChild.Attributes)
                {
                    Console.WriteLine($"      {attr.Name} = {attr.Value}");
                }
            }
        }
    }
}

// ობიექტების ბეჭდვა 

Console.WriteLine("/////////");
foreach (var location in locations)
    Console.WriteLine($" id = {location.Id} name = ({location.Name}) - adress = {location.Adress}");

foreach (var container in containers)
    Console.WriteLine($" id = {container.Id} name = ({container.Name}) - barcode = {container.Barcode}");

foreach (var courier in couriers)
    Console.WriteLine($" id = {courier.Id} name = ({courier.Name}) surname = ({courier.Surname})- phoneNumber = {courier.PhoneNumber}");

foreach (var order in orders)
    Console.WriteLine($" id = {order.Id} - start_location_id = {order.StartLocationId} - " +
        $"end_location_id = {order.EndLocationId} - container_id = {order.ContainerId} - " +
        $"courier_id = {order.CourierId} - start_date_time = {order.StartDateTime} - " +
        $"end_date_time = {order.EndDateTime}");

// xml დოკის ბეჭდვა
Console.WriteLine("///////// aq var <<<<<<<<<<<<");
Console.WriteLine(xRoot.InnerXml); // kitxva??? < rato ar bechdavs dokuments consolshi?

// axali xml failis sheqmna da chawera
Console.WriteLine("/////////");
Console.WriteLine("create and save new xml doc");


// ახალი XML-ის აგება
XDocument newDoc = new XDocument( // kitxva?? 
    new XElement("dvshipper",
        new XElement("locations",
            from loc in locations
            select new XElement("location",
                new XAttribute("id", loc.Id),
                new XAttribute("name", loc.Name),
                new XAttribute("adress", loc.Adress)
            )
        ),
        new XElement("containers",
            from cont in containers
            select new XElement("container",
                new XAttribute("id", cont.Id),
                new XAttribute("name", cont.Name),
                new XAttribute("barcode", cont.Barcode)
            )
        ),
        new XElement("couriers",
            from cour in couriers
            select new XElement("courier",
                new XAttribute("id", cour.Id),
                new XAttribute("name", cour.Name),
                new XAttribute("surname", cour.Surname),
                new XAttribute("phonenumber", cour.PhoneNumber)
            )
        ),
        new XElement("orders",
        orders.Select(ord => 
            
                new XElement("order",
                new XAttribute("id", ord.Id),
                new XAttribute("start_location_id", ord.StartLocationId),
                new XAttribute("end_location_id", ord.EndLocationId),
                new XAttribute("container_id", ord.ContainerId),
                new XAttribute("courier_id", ord.CourierId),
                new XAttribute("start_date_time", ord.StartDateTime.ToString("dd/MM/yyyy HH:mm")),
                new XAttribute("end_date_time", ord.EndDateTime.ToString("dd/MM/yyyy HH:mm"))
            )
        ))
    )
);

// newDoc.XPathSelectElements
Console.WriteLine(newDoc);
newDoc.Save("NewXMLForKapanasTask.xml");

// კლასი
class Location
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Adress { get; set; }
}

class Container
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Barcode { get; set; }
}

class Courier
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string? Surname { get; set; } = "";
    public string PhoneNumber { get; set; } = "";
}

class Order
{
    public int Id { get; set; }
    public int StartLocationId { get; set; }
    public int EndLocationId { get; set; }
    public int ContainerId { get; set; }
    public int CourierId { get; set; }
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
}

