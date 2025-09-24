using System;
using System.IO; // Path.Combine, Directory.GetParent-სთვის
using davaleba_xml_ze_2.klasebi;
using davaleba_xml_ze_2.servisebi;

// 1️ ვპოულობთ პროექტის root საქაღალდეს (bin/debug/... → მოვდივართ უკან)
string projectRoot = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)!.Parent!.Parent!.Parent!.FullName;

// 2️ XML ფოლდერის სრული გზა
string xmlFolder = Path.Combine(projectRoot, "XML");

// 3️ ფაილების სრული გზები
string xmlPath = Path.Combine(xmlFolder, "XMLForKapanasTask.xml");
string newXmlPath = Path.Combine(xmlFolder, "NewDVShipper.xml");

// 4️ XmlReaderService ობიექტის შექმნა
var reader = new XmlReaderService(xmlPath);

// 5️ XML-ის წაკითხვა
var locations = reader.ReadLocations();
var containers = reader.ReadContainers();
var couriers = reader.ReadCouriers();
var orders = reader.ReadOrders();

// 6️ ახალი xml-ის შექმნა
var writer = new XmlWriterService(locations, containers, couriers, orders);
var newDoc = writer.BuildXml();
writer.SaveToFile(newXmlPath);

// 7️ SearchService
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
            Console.Write("enter courier name and surname (მაგ: leqso abramishvili): ");
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

// 8️ მონაცემების კონსოლზე გამოჩენა
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
