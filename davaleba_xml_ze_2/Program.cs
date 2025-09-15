using System;
using davaleba_xml_ze_2;
using davaleba_xml_ze_2.klasebi;
using davaleba_xml_ze_2.servisebi;

// 1️ XML ფაილის გზა და 2️ XmlReaderService ობიექტის შექმნა
string xmlPath = "C:\\Users\\Gio\\Desktop\\Programireba\\Cshar_tavidan\\davaleba_xml_ze_2\\XML\\XMLForKapanasTask.xml";
 
var reader = new XmlReaderService(xmlPath);

// 3️ XML-ის წაკითხვა და ობიექტების მიღება
var locations = reader.ReadLocations();
var containers = reader.ReadContainers();
var couriers = reader.ReadCouriers();
var orders = reader.ReadOrders();

// 4 ახალი xml ის შექმნა 
// XmlWriterService–ის შექმნა ახალი XML დოკუმენტის შექმნა შენახვა ფაილში
var writer = new XmlWriterService(locations, containers, couriers, orders);
var newDoc = writer.BuildXml();
// Console.WriteLine(newDoc);
writer.SaveToFile("C:\\Users\\Gio\\Desktop\\Programireba\\Cshar_tavidan\\davaleba_xml_ze_2\\XML\\NewDVShipper.xml");

// search???? rogor gavaketo? 
var search = new SearchService(locations, containers, couriers, orders);

while (true)
{
    Console.WriteLine("\n airchie brzaneba:");
    Console.WriteLine("1 - Orders by locationId");
    Console.WriteLine("2 - Orders by containerId");
    Console.WriteLine("3 - Orders by courierId");
    Console.WriteLine("4 - Locations by courier full name");
    Console.WriteLine("0 - gamosvla");

    Console.Write("sheiyvane ricxvi: ");
    string? choice = Console.ReadLine();

    if (choice == "0")
        break;

    switch (choice)
    {
        case "1":
            Console.Write("enter locationId: ");
            int locId = int.Parse(Console.ReadLine()!);
            var ordersByLocation = search.SearchOrdersByLocation(locId);
            foreach (var o in ordersByLocation)
                Console.WriteLine($"OrderId={o.Id}, Container={o.ContainerId}, Courier={o.CourierId}");
            break;

        case "2":
            Console.Write("enter containerId: ");
            int contId = int.Parse(Console.ReadLine()!);
            var ordersByContainer = search.SearchOrdersByContainer(contId);
            foreach (var o in ordersByContainer)
                Console.WriteLine($"OrderId={o.Id}, StartLoc={o.StartLocationId}, EndLoc={o.EndLocationId}");
            break;

        case "3":
            Console.Write("enter courierId: ");
            int courId = int.Parse(Console.ReadLine()!);
            var ordersByCourier = search.SearchOrdersByCourier(courId);
            foreach (var o in ordersByCourier)
                Console.WriteLine($"OrderId={o.Id}, StartTime={o.StartDateTime}, EndTime={o.EndDateTime}");
            break;

        case "4":
            Console.Write("enter courier name and surname (mag: leqso abramishvili): ");
            string? fullName = Console.ReadLine();
            var locs = search.SearchLocationsByCourier(fullName ?? "");
            foreach (var l in locs)
                Console.WriteLine($"{l.Id} - {l.Name} - {l.Address}");
            break;

        default:
            Console.WriteLine("arasworia!");
            break;
    }
}

// 5 მონაცემების კონსოლზე გამოჩენა
Console.WriteLine("=== Locations ===");
foreach (var loc in locations)
    Console.WriteLine($"{loc.Id} - {loc.Name} - {loc.Address}");

Console.WriteLine("\n=== Containers ===");
foreach (var cont in containers)
    Console.WriteLine($"{cont.Id} - {cont.Name} - {cont.Barcode}");

Console.WriteLine("\n=== Couriers ===");
foreach (var c in couriers)
    Console.WriteLine($"{c.Id} - {c.Name} {c.Surname} - {c.PhoneNumber}");

Console.WriteLine("\n=== Orders ===");
foreach (var o in orders)
    Console.WriteLine($"Order {o.Id}: Location {o.StartLocationId}->{o.EndLocationId}, Container {o.ContainerId}, Courier {o.CourierId}, {o.StartDateTime} - {o.EndDateTime}");
